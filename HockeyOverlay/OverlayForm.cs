using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HockeyEditor;
using HockeyOverlay.Models;

namespace HockeyOverlay
{
    public partial class OverlayForm : Form
    {
        public const string gamename = "Hockey?";

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr window, int index);
        IntPtr handle = FindWindowByCaption(IntPtr.Zero, gamename);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        public struct RECT
        {
            public int left, top, right, bottom;
        }


        StringFormat sf = new StringFormat();
        StringFormat sfAlign = new StringFormat();
        public ConfigModel config = new ConfigModel();
        public GameStatsModel gameStats = new GameStatsModel();

        public KeyboardHook hook = new KeyboardHook();

        static HQMTeam TeamTouch;
        static Player PlayerTouch;
        static Queue<string> BQueue = new Queue<string>();
        static Queue<string> RQueue = new Queue<string>();
        static List<string> SecondA = new List<string>();
        static List<string> RGoalieList = new List<string>();
        static List<string> BGoalieList = new List<string>();
        static int QueueSize = 3;
        static Boolean GShot = false;
        static int RSave = 0, BSave = 0;
        static int ShotCounterR = 0, ShotCounterB = 0;
        static Boolean shot = false;
        static Boolean wrote = false;
        static Boolean assist = false;
        static float Posx = 0, Posy = 0, Posz = 0;
        static List<string> Bshot = new List<string>();
        static List<string> Rshot = new List<string>();
        static string GameTime;

        SolidBrush leagueBrush;
        SolidBrush textBrush;
        SolidBrush borderBrush;

        WMPLib.WindowsMediaPlayer arena = new WMPLib.WindowsMediaPlayer();

        public OverlayForm(ConfigModel _config)
        {
            InitializeComponent();

            typeof(OverlayForm).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, this, new object[] { true });

            config = _config;

            InitBrushes();

            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            sfAlign.Alignment = StringAlignment.Center;

            RECT outrect;
            GetWindowRect(handle, out outrect);

            this.Size = new Size(outrect.right - outrect.left, outrect.bottom - outrect.top);

            this.Top = outrect.top;
            this.Left = outrect.left;

            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.Black;
            this.TransparencyKey = System.Drawing.Color.Black;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            this.TopMost = true;
            this.Opacity = (double)config.Opacity / (double)100;

            OverlayForm.CheckForIllegalCrossThreadCalls = false;
            this.Paint += new PaintEventHandler(RenderGraphics);
            Thread PrePaintThread = new Thread(new ThreadStart(PrePaint));
            PrePaintThread.Start();

            var worker = new BackgroundWorker();
            worker.DoWork += BackgroundCollectStats_DoWork;
            worker.RunWorkerAsync();

            hook.KeyPressed +=
            new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(ModifierKeyItems.Control,
                Keys.T);

            InitializeQueue();

            if (config.EnableArenaSound)
            {
                InitSound();
            }
        }

        public void InitBrushes()
        {
            leagueBrush = new SolidBrush(config.LeagueColor);
            textBrush = new SolidBrush(config.TextColor);
            borderBrush = new SolidBrush(config.BorderColor);
        }

        static void InitializeQueue()
        {
            QueueAdd(RQueue, "");
            QueueAdd(RQueue, "");
            QueueAdd(RQueue, "");
            QueueAdd(BQueue, "");
            QueueAdd(BQueue, "");
            QueueAdd(BQueue, "");

        }

        public void InitSound()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data", "Arena");
            var files = Directory.GetFiles(path);
            if (files.Any())
            {
                var random = new Random();
                var itemIndex = random.Next(0, files.Length);
                arena.URL = files[itemIndex];
                arena.settings.volume = 5;
                arena.PlayStateChange += Pl_PlayStateChange;
                arena.controls.play();
            }
            
        }

        private void Pl_PlayStateChange(int NewState)
        {
            if (arena.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                arena.controls.play();
            }
        }

        static Queue<string> QueueAdd(Queue<string> score, string item)
        {
            if (score.Count == QueueSize)
            {
                score.Dequeue();
                score.Enqueue(item);
            }
            else if (score.Count < QueueSize)
            {
                score.Enqueue(item);
            }
            return score;
        }

        public void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            config.ShowStats = !config.ShowStats;
        }

        private void BackgroundCollectStats_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MemoryEditor.Init(true);

                while (true)
                {
                    SwitchTeams();


                    if (GameInfo.AfterGoalFaceoffTime > 50)
                    {
                        gameStats.GoalReplay = Chat.ChatMessages.TakeLast(2).Any(x => x.Message == "Goal replay");
                    }
                    else
                    {
                        gameStats.GoalReplay = false;
                    }

                    if (GameInfo.AfterGoalFaceoffTime != 0)
                    {
                        var scoreChanged = false;
                        if (gameStats.RedScore != GameInfo.RedScore)
                        {
                            gameStats.Event = EventType.GoalRed;
                            scoreChanged = true;
                        }
                        if (gameStats.BlueScore != GameInfo.BlueScore)
                        {
                            gameStats.Event = EventType.GoalBlue;
                            scoreChanged = true;
                        }

                        if (scoreChanged)
                        {
                            var scorer = String.Empty;
                            var assist = String.Empty;
                            foreach (var player in gameStats.Players)
                            {
                                var playerItem = PlayerManager.Players.SingleOrDefault(x => x.Name == player.Name);
                                if (playerItem != null)
                                {
                                    if (playerItem.Goals != player.Goals)
                                    {
                                        scorer = playerItem.Name;
                                        gameStats.LastScorerGoals = playerItem.Goals;
                                    }

                                    if (playerItem.Assists != player.Assists)
                                    {
                                        assist = playerItem.Name;
                                        gameStats.LastAssistAssists = playerItem.Assists;
                                    }
                                }
                            }

                            gameStats.LastScorer = scorer;
                            gameStats.LastAssist = assist;

                            if (config.EnableHorn)
                            {
                                PlayHorn();
                            }
                        }

                    }

                    gameStats.EventTimer = GameInfo.AfterGoalFaceoffTime;

                    if (GameInfo.Period != 0)
                    {
                        FillPlayers();
                        TeamTouchedPuck();
                        GoalieTouchPuck();
                        Puckonnet();
                    }


                    gameStats.RedScore = GameInfo.RedScore;
                    gameStats.BlueScore = GameInfo.BlueScore;
                    switch (GameInfo.Period)
                    {
                        case 0:
                            gameStats.Period = "INT";
                            break;
                        case 1:
                            gameStats.Period = "1st";
                            break;
                        case 2:
                            gameStats.Period = "2nd";
                            break;
                        case 3:
                            gameStats.Period = "3rd";
                            break;
                        default:
                            gameStats.Period = "OT";
                            break;
                    }

                    if (GameInfo.IntermissionTime == 0)
                    {
                        var time = TimeSpan.FromSeconds((int)GameInfo.GameTime / 100);
                        gameStats.Time = time.ToString(@"m\:ss");
                    }
                    else
                    {
                        gameStats.Period = "INT";
                        var time = TimeSpan.FromSeconds((int)GameInfo.IntermissionTime / 100);
                        gameStats.Time = time.ToString(@"m\:ss");
                    }

                    Thread.Sleep(config.Delay);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void PlayHorn()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data", "Horns");
            var files = Directory.GetFiles(path);
            if (files.Any())
            {
                var random = new Random();
                var itemIndex = random.Next(0, files.Length);
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                wplayer.URL = files[itemIndex];
                wplayer.controls.play();
            }
        }

        static string Puckonnet()
        {
            float Velx = Puck.Position.X - Posx;
            float Vely = Puck.Position.Y - Posy;
            float Velz = Puck.Position.Z - Posz;
            Posx = Puck.Position.X;
            Posy = Puck.Position.Y;
            Posz = Puck.Position.Z;

            float Time = 0, x = 0, y = 0;
            String ShotOnNet = "false";
            int red = 0;
            if (Velz < 0)
            {
                Time = (4.15f - Puck.Position.Z) / Velz;
                red = 1; // blue
            }

            if (Velz > 0)
            {
                Time = (56.85f - Puck.Position.Z) / Velz;
                red = 2; // red
            }


            x = Puck.Position.X + Velx * Time;
            y = Puck.Position.Y + Vely * Time;
            if (x > 13.75 && x < 16.25 && red == 1) // blue
            {
                if (y < .83)
                {
                    ShotOnNet = "true";
                    if (Puck.Position.Z < 10 && Puck.Position.Z > 3.8 && Puck.Position.X < 19 && Puck.Position.X > 11)
                    {
                        if (shot == false && GameInfo.GameTime > 0 && GameInfo.IntermissionTime == 0 && GameInfo.AfterGoalFaceoffTime == 0)
                        {
                            if (TeamTouch == HQMTeam.Red)
                            {
                                ShotCounterB++;
                                Bshot.Add("Red Shot " + ShotCounterB + " / by " + PlayerTouch.Name + " / at " + GameTime + " of period " + GameInfo.Period);
                                shot = true;
                            }
                        }
                    }
                }
            }
            else if (x > 13.75 && x < 16.25 && red == 2) // red
            {
                if (y < .83)
                {
                    ShotOnNet = "true";
                    if (Puck.Position.Z > 51 && Puck.Position.Z < 57.2 && Puck.Position.X < 19 && Puck.Position.X > 11)
                    {
                        if (shot == false && GameInfo.GameTime > 0 && GameInfo.IntermissionTime == 0 && GameInfo.AfterGoalFaceoffTime == 0)
                        {
                            if (TeamTouch == HQMTeam.Blue)
                            {
                                ShotCounterR++;
                                Rshot.Add("Blue Shot " + ShotCounterR + " / by " + PlayerTouch.Name + " / at " + GameTime + " of period " + GameInfo.Period);
                                shot = true;
                            }
                        }
                    }
                }
            }
            else
            {
                ShotOnNet = "False";
                shot = false;
            }

            return ShotOnNet;
        }

        public void FillPlayers()
        {
            foreach(var player in PlayerManager.Players.Where(x=>x.Team!= HQMTeam.NoTeam))
            {
                var playerItem = gameStats.Players.SingleOrDefault(x => x.Name == player.Name);
                if (playerItem!=null)
                {
                    playerItem.Goals = player.Goals;
                    playerItem.Assists = player.Assists;
                    playerItem.Team = player.Team;
                }
                else
                {
                    gameStats.Players.Add(new PlayerItem
                    {
                        Name = player.Name,
                        Team = player.Team,
                        Goals = player.Goals,
                        Assists = player.Assists
                    });
                }
            }
        }

        public void GoalieTouchPuck()
        {
            if (shot == true && GameInfo.IntermissionTime == 0)
            {
                GShot = true;
            }

            foreach (Player p in PlayerManager.Players)
            {
                if (p.Team == HQMTeam.Blue && Puck.Position.Z < 21.5)
                {

                    if (shot == false && GShot == true && GameInfo.IntermissionTime == 0 && GameInfo.AfterGoalFaceoffTime == 0)
                    {
                        if (PlayerTouch.Name == p.Name)
                        {
                            BSave++;
                            BGoalieList.Add("Blue Player: " + p.Name + " / Save number: " + BSave + " / at: " + GameTime + " of period " + GameInfo.Period);
                            GShot = false;

                        }
                    }
                }
                if (p.Team == HQMTeam.Red && Puck.Position.Z > 39)
                {
                    if (shot == false && GShot == true && GameInfo.IntermissionTime == 0 && GameInfo.AfterGoalFaceoffTime == 0)
                    {
                        if (PlayerTouch.Name == p.Name)
                        {
                            RSave++;
                            RGoalieList.Add("Red Player: " + p.Name + " / Save number: " + RSave + " / at: " + GameTime + " of period " + GameInfo.Period);
                            GShot = false;

                        }
                    }
                }
            }
        }
        public void TeamTouchedPuck()
        {
            foreach (Player p in PlayerManager.Players)
            {
                if ((p.StickPosition - Puck.Position).Magnitude < 0.25f)
                {
                    TeamTouch = p.Team;
                    PlayerTouch = p;
                    if (TeamTouch == HQMTeam.Blue && p.Name != BQueue.ElementAt(2))
                    {
                        if (GameInfo.GameTime > 0 && GameInfo.IntermissionTime == 0)
                        {
                            BQueue = QueueAdd(BQueue, p.Name);
                        }

                    }
                    if (TeamTouch == HQMTeam.Red && p.Name != RQueue.ElementAt(2))
                    {
                        if (GameInfo.GameTime > 0 && GameInfo.IntermissionTime == 0)
                        {
                            RQueue = QueueAdd(RQueue, p.Name);
                            
                        }

                    }

                    if (GameInfo.GameTime > 0 && GameInfo.IntermissionTime == 0 && GameInfo.AfterGoalFaceoffTime == 0)
                    {
                        if (TeamTouch == HQMTeam.Red)
                        {
                            gameStats.RedTouches += 1;
                        }
                        else
                        {
                            gameStats.BlueTouches += 1;
                        }
                    }
                }
            }
        }

        public void SwitchTeams()
        {
            if (config.Team1Players.Count!=0 || config.Team2Players.Count != 0)
            {
                var found = false;
                foreach(var redPlayer in PlayerManager.Players.Where(x => x.Team == HQMTeam.Red))
                {
                    if (config.Team2Players.Contains(redPlayer.Name))
                    {
                        var team1Name = config.Team2Name;
                        var team1Color = config.Team2Color;
                        var team1Players = config.Team2Players;
                        var team1Logo = config.Team2Logo;

                        config.Team2Name = config.Team1Name;
                        config.Team2Color = config.Team1Color;
                        config.Team2Players = config.Team1Players;
                        config.Team2Logo = config.Team1Logo;

                        config.Team1Name = team1Name;
                        config.Team1Color = team1Color;
                        config.Team1Players = team1Players;
                        config.Team1Logo = team1Logo;

                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    foreach (var bluePlayer in PlayerManager.Players.Where(x => x.Team == HQMTeam.Blue))
                    {
                        if (config.Team1Players.Contains(bluePlayer.Name))
                        {
                            var team1Name = config.Team2Name;
                            var team1Color = config.Team2Color;
                            var team1Players = config.Team2Players;
                            var team1Logo = config.Team2Logo;

                            config.Team2Name = config.Team1Name;
                            config.Team2Color = config.Team1Color;
                            config.Team2Players = config.Team1Players;
                            config.Team2Logo = config.Team1Logo;

                            config.Team1Name = team1Name;
                            config.Team1Color = team1Color;
                            config.Team1Players = team1Players;
                            config.Team1Logo = team1Logo;
                            break;
                        }
                    }
                }
                
            }
        }

        private void PrePaint()
        {
            while (true)
            {
                RECT outrect;
                GetWindowRect(handle, out outrect);

                this.Size = new Size(outrect.right - outrect.left, outrect.bottom - outrect.top);

                this.Top = outrect.top;
                this.Left = outrect.left;

                SetScorePosition();

                this.Refresh();
                
                Thread.Sleep(config.Delay);
            }
        }

        private void RenderStats(Graphics g)
        {
            var width = 600;
            var height = 500;

            var x = Size.Width / 2 - width / 2;
            var y = Size.Height / 2 - height / 2;

            var brRect = new Rectangle(x -2 , y - 2, width+4, height + 4);
            var borderRect = RoundedRect(brRect, 16, 16, 16, 16);
            var brGradientBrush = new LinearGradientBrush(brRect, config.BorderColor, config.BorderColor, LinearGradientMode.Vertical);
            g.FillPath(brGradientBrush, borderRect);

            var rlRect = new Rectangle(x, y, width, height);
            var rlGradientBrush = new LinearGradientBrush(rlRect, config.LeagueColor, config.LeagueColor, LinearGradientMode.Horizontal);
            var redLRect = RoundedRect(rlRect, 16,16,16,16);
            g.FillPath(rlGradientBrush, redLRect);

            var colWidth = width / 3;

            g.DrawImage(config.Team1Logo, x + colWidth / 2 - 40, y + 30, 80, 80);
            g.DrawImage(config.Team2Logo, x + width - colWidth / 2 - 40, y + 30, 80, 80);

            var titleFont = new Font("Arial", 18, FontStyle.Bold);
            var subtitleFont = new Font("Arial", 14, FontStyle.Bold);

            g.DrawString(gameStats.RedScore.ToString(), titleFont, textBrush, x + colWidth / 2, y + 30 + 130, sf);
            g.DrawString("SCORE", subtitleFont, textBrush, x + width / 2, y + 30 + 130, sf);
            g.DrawString(gameStats.BlueScore.ToString(), titleFont, textBrush, x + width - colWidth / 2, y + 30 + 130, sf);

            g.DrawString((gameStats.RedScore + BSave).ToString(), titleFont, textBrush, x + colWidth / 2, y + 30 + 160, sf);
            g.DrawString("SHOTS", subtitleFont, textBrush, x + width / 2, y + 30 + 160, sf);
            g.DrawString(((gameStats.BlueScore + RSave).ToString()).ToString(), titleFont, textBrush, x + width - colWidth / 2, y + 30 + 160, sf);

            g.DrawString(RSave.ToString(), titleFont, textBrush, x + colWidth / 2, y + 30 + 190, sf);
            g.DrawString("SAVES", subtitleFont, textBrush, x + width / 2, y + 30 + 190, sf);
            g.DrawString((BSave.ToString()).ToString(), titleFont, textBrush, x + width - colWidth / 2, y + 30 + 190, sf);

            var redPossession = 50;

            if (gameStats.RedTouches + gameStats.BlueTouches != 0)
            {
                redPossession = (int)Math.Round((decimal)100 / (decimal)(gameStats.RedTouches + gameStats.BlueTouches) * gameStats.RedTouches);
            }

            g.DrawString(redPossession.ToString(), titleFont, textBrush, x + colWidth / 2, y + 30 + 220, sf);
            g.DrawString("POSSESSION", subtitleFont, textBrush, x + width / 2, y + 30 + 220, sf);
            g.DrawString((100 - redPossession).ToString(), titleFont, textBrush, x + width - colWidth / 2, y + 30 + 220, sf);
        }

        private void SetScorePosition()
        {
            var width = 260;
            var height = 60;

            switch (config.ScorePosition)
            {
                case PositionType.TopLeft:
                    config.ScoreX = 30;
                    config.ScoreY = 50;
                    break;
                case PositionType.TopCenter:
                    config.ScoreX = this.Size.Width/2- width/2;
                    config.ScoreY = 50;
                    break;
                case PositionType.TopRight:
                    config.ScoreX = this.Size.Width - width - 30;
                    config.ScoreY = 50;
                    break;
                case PositionType.BottomLeft:
                    config.ScoreX = 30;
                    config.ScoreY = this.Size.Height - height - 30;
                    break;
                case PositionType.BottomCenter:
                    config.ScoreX = this.Size.Width / 2 - width / 2;
                    config.ScoreY = this.Size.Height - height - 30;
                    break;
                case PositionType.BottomRight:
                    config.ScoreX = this.Size.Width - width - 30;
                    config.ScoreY = this.Size.Height - height - 30;
                    break;
            }

        }

        private void RenderGraphics(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            if (config.ShowScore)
            {
                RenderScore(g);
                RenderEvents(g);
            }

            if (config.ShowStats)
            {
                RenderStats(g);
            }
        }

        private void RenderScore(Graphics g)
        {
            //border rect
            var brRect = new Rectangle(config.ScoreX-2, config.ScoreY-2, 264, 64);
            var borderRect = RoundedRect(brRect, 0, 0, 0, 0);
            var brGradientBrush = new LinearGradientBrush(brRect, config.BorderColor, config.BorderColor, LinearGradientMode.Vertical);
            g.FillPath(brGradientBrush, borderRect);

            //league logo
            var lRect = new Rectangle(config.ScoreX, config.ScoreY, 60, 60);
            var logoRect = RoundedRect(lRect, 0, 0, 0, 0);
            var tGradientBrush = new LinearGradientBrush(lRect, config.LeagueColor, config.LeagueColor, LinearGradientMode.Vertical);
            g.FillPath(tGradientBrush, logoRect);
            g.DrawImage(config.LeagueLogo, config.ScoreX, config.ScoreY, 60, 60);

            //time
            var tRect = new Rectangle(config.ScoreX + 60, config.ScoreY, 70, 60);
            var timeRect = RoundedRect(tRect, 0, 0, 0, 0);
            g.FillPath(tGradientBrush, timeRect);
            var lPen = new Pen(Color.Gray, 2);
            g.DrawLine(lPen, tRect.X + 15, tRect.Y + tRect.Height / 2, tRect.X + tRect.Width - 15, tRect.Y + tRect.Height / 2);
            var pCenter = Center(new Rectangle(tRect.X, tRect.Y, tRect.Width, tRect.Height / 2));
            var tCenter = Center(new Rectangle(tRect.X, tRect.Y+ tRect.Height / 2, tRect.Width, tRect.Height / 2));
            var tFont = new Font("Arial", 10, FontStyle.Bold);
            g.DrawString(gameStats.Period, tFont, textBrush, pCenter.X, pCenter.Y, sf);
            g.DrawString(gameStats.Time, tFont, textBrush, tCenter.X, tCenter.Y, sf);

            //team logo
            var rlRect = new Rectangle(tRect.X + tRect.Width, config.ScoreY, 30, 30);
            var rlGradientBrush = new LinearGradientBrush(rlRect, config.LeagueColor, config.Team1Color, LinearGradientMode.Horizontal);
            var redLRect = RoundedRect(rlRect, 0, 0, 0, 0);
            g.FillPath(rlGradientBrush, redLRect);
            g.DrawImage(config.Team1Logo, tRect.X + tRect.Width, config.ScoreY, 30, 30);
            var blRect = new Rectangle(tRect.X + tRect.Width, config.ScoreY + 30, 30, 30);
            var blGradientBrush = new LinearGradientBrush(blRect, config.LeagueColor, config.Team2Color, LinearGradientMode.Horizontal);
            var blueLRect = RoundedRect(blRect, 0, 0, 0, 0);
            g.FillPath(blGradientBrush, blueLRect);
            g.DrawImage(config.Team2Logo, tRect.X + tRect.Width, config.ScoreY+30, 30, 30);

            //team
            var rRect = new Rectangle(rlRect.X+ rlRect.Width, config.ScoreY, 70, 30);
            var rGradientBrush = new LinearGradientBrush(rRect, config.Team1Color, config.LeagueColor, LinearGradientMode.Horizontal);
            var redRect = RoundedRect(rRect, 0, 0, 0, 0);
            g.FillPath(rGradientBrush, redRect);
            var bRect = new Rectangle(rlRect.X + rlRect.Width, config.ScoreY + 30, 70, 30);
            var bGradientBrush = new LinearGradientBrush(bRect, config.Team2Color, config.LeagueColor, LinearGradientMode.Horizontal);
            var blueRect = RoundedRect(bRect, 0, 0, 0, 0);
            g.FillPath(bGradientBrush, blueRect);
            var font = new Font("Arial", 14, FontStyle.Bold);
            var redCenter = Center(rRect);
            var blueCenter = Center(bRect);
            g.DrawString(config.Team1Name, font, textBrush, redCenter.X, redCenter.Y, sf);
            g.DrawString(config.Team2Name, font, textBrush, blueCenter.X, blueCenter.Y, sf);

            //score
            var sRect = new Rectangle(rRect.X+ rRect.Width, config.ScoreY, 30, 60);
            var sGradientBrush = new LinearGradientBrush(sRect, config.LeagueColor, config.LeagueColor, LinearGradientMode.Horizontal);
            var scoreRect = RoundedRect(sRect, 0, 0, 0, 0);
            g.FillPath(sGradientBrush, scoreRect);
            var scoreFont = new Font("Arial", 18, FontStyle.Bold);
            var sRCenter = Center(new Rectangle(sRect.X, sRect.Y, sRect.Width, sRect.Height / 2));
            var sBCenter = Center(new Rectangle(sRect.X, sRect.Y+ sRect.Height / 2, sRect.Width, sRect.Height / 2));
            g.DrawString(gameStats.RedScore.ToString(), scoreFont, textBrush, sRCenter.X, sRCenter.Y, sf);
            g.DrawString(gameStats.BlueScore.ToString(), scoreFont, textBrush, sBCenter.X, sBCenter.Y, sf);
        }

        private void RenderEvents(Graphics g)
        {
            if (gameStats.Event!=EventType.Nothing && gameStats.EventTimer != 0)
            {
                SetEventsPosition();

                switch (gameStats.Event)
                {
                    case EventType.GoalRed:
                    case EventType.GoalBlue:
                        //border rect
                        var brRect = new Rectangle(config.EventsX - 2, config.EventsY - 2, 384, 64);
                        var borderRect = RoundedRect(brRect, 0, 8, 0, 8);
                        var brGradientBrush = new LinearGradientBrush(brRect, config.BorderColor, config.BorderColor, LinearGradientMode.Vertical);
                        g.FillPath(brGradientBrush, borderRect);

                        var eRect = new Rectangle(config.EventsX, config.EventsY, 100, 60);
                        var eventRect = RoundedRect(eRect, 0, 0, 0, 8);
                        var eGradientBrush = new LinearGradientBrush(eRect, config.LeagueColor, config.LeagueColor, LinearGradientMode.Horizontal);
                        g.FillPath(eGradientBrush, eventRect);

                        var font = new Font("Arial", 14, FontStyle.Bold);
                        var eCenter = Center(new Rectangle(eRect.X, eRect.Y, eRect.Width, eRect.Height));
                        g.DrawString("GOAL", font, textBrush, eCenter.X, eCenter.Y, sf);

                        var lRect = new Rectangle(eRect.X+ eRect.Width, config.EventsY, 60, 60);
                        var logoRect = RoundedRect(lRect, 0, 0, 0, 0);
                        var lGradientBrush = new LinearGradientBrush(lRect, config.LeagueColor, config.LeagueColor, LinearGradientMode.Horizontal);
                        g.FillPath(lGradientBrush, logoRect);
                        g.DrawImage(gameStats.Event== EventType.GoalRed?config.Team1Logo: config.Team2Logo, lRect.X, lRect.Y, 60, 60);

                        var sRect = new Rectangle(lRect.X+ lRect.Width, config.EventsY, 220, 60);
                        var scoreRect = RoundedRect(sRect, 0, 8, 0, 0);
                        var sGradientBrush = new LinearGradientBrush(sRect, gameStats.Event == EventType.GoalRed ? config.Team1Color: config.Team2Color, config.LeagueColor, LinearGradientMode.Horizontal);
                        g.FillPath(sGradientBrush, scoreRect);

                        if (!String.IsNullOrEmpty(gameStats.LastScorer))
                        {
                            var sFont = new Font("Arial", 17, FontStyle.Bold);
                            g.DrawString(String.Join("", gameStats.LastScorer.Take(10)), sFont, textBrush, sRect.X + 4, sRect.Y + 4);
                            g.DrawString(gameStats.LastScorerGoals.ToString(), sFont, textBrush, sRect.X + 200, sRect.Y + 4, sfAlign);
                        }

                        if (!String.IsNullOrEmpty(gameStats.LastAssist))
                        {
                            var aFont = new Font("Arial", 12, FontStyle.Bold);
                            g.DrawString(String.Join("", gameStats.LastAssist.Take(14)), aFont, textBrush, sRect.X + 4, sRect.Y + 34);
                            g.DrawString(gameStats.LastAssistAssists.ToString(), aFont, textBrush, sRect.X + 200, sRect.Y + 34, sfAlign);
                        }

                        if (gameStats.GoalReplay)
                        {
                            var rFont = new Font("Arial", 12, FontStyle.Bold);
                            var rBrush = new SolidBrush(Color.Red);
                            g.FillEllipse(rBrush, config.ScoreX, config.ScoreY + 67, 12, 12);
                            g.DrawString("GOAL REPLAY", rFont, textBrush, config.ScoreX + 16, config.ScoreY+64);
                        }
                        break;
                }
            }
        }

        private void SetEventsPosition()
        {
            var width = 380;
            var height = 60;

            switch (config.EventPosition)
            {
                case PositionType.TopLeft:
                    config.EventsX = 30;
                    config.EventsY = 50;
                    break;
                case PositionType.TopCenter:
                    config.EventsX = this.Size.Width / 2 - width / 2;
                    config.EventsY = 50;
                    break;
                case PositionType.TopRight:
                    config.EventsX = this.Size.Width - width - 30;
                    config.EventsY = 50;
                    break;
                case PositionType.BottomLeft:
                    config.EventsX = 30;
                    config.EventsY = this.Size.Height - height - 30;
                    break;
                case PositionType.BottomCenter:
                    config.EventsX = this.Size.Width / 2 - width / 2;
                    config.EventsY = this.Size.Height - height - 30;
                    break;
                case PositionType.BottomRight:
                    config.EventsX = this.Size.Width - width - 30;
                    config.EventsY = this.Size.Height - height - 30;
                    break;
            }

        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius1, int radius2, int radius3, int radius4)
        {
            int diameter1 = radius1 * 2;
            int diameter2 = radius2 * 2;
            int diameter3 = radius3 * 2;
            int diameter4 = radius4 * 2;

            Rectangle arc1 = new Rectangle(bounds.Location, new Size(diameter1, diameter1));
            Rectangle arc2 = new Rectangle(bounds.Location, new Size(diameter2, diameter2));
            Rectangle arc3 = new Rectangle(bounds.Location, new Size(diameter3, diameter3));
            Rectangle arc4 = new Rectangle(bounds.Location, new Size(diameter4, diameter4));
            GraphicsPath path = new GraphicsPath();
 
            if (radius1 == 0)
            {
                path.AddLine(arc1.Location, arc1.Location);
            }
            else
            {
                path.AddArc(arc1, 180, 90);
            }

            arc2.X = bounds.Right - diameter2;
            if (radius2 == 0)
            {
                path.AddLine(arc2.Location, arc2.Location);
            }
            else
            {
                path.AddArc(arc2, 270, 90);
            }

            arc3.X = bounds.Right - diameter3;
            arc3.Y = bounds.Bottom - diameter3;
            if (radius3 == 0)
            {
                path.AddLine(arc3.Location, arc3.Location);
            }
            else
            {
                path.AddArc(arc3, 0, 90);
            }

            arc4.X = bounds.Right - diameter4;
            arc4.Y = bounds.Bottom - diameter4;
            arc4.X = bounds.Left;
            if (radius4 == 0)
            {
                path.AddLine(arc4.Location, arc4.Location);
            }
            else
            {
                path.AddArc(arc4, 90, 90);
            }

            path.CloseFigure();
            return path;
        }

        public Point Center(Rectangle rect)
        {
            return new Point(rect.Left + rect.Width / 2,
                             rect.Top + rect.Height / 2);
        }

    }
}
