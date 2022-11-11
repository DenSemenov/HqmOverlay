using HockeyEditor;
using HockeyOverlay.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HockeyOverlay
{
    public partial class MainForm : Form
    {
        public bool started = false;
        public OverlayForm of = null;
        public ConfigModel config = new ConfigModel();
        System.Drawing.Graphics g;
        public MainForm()
        {
            InitializeComponent();

            Init();
        }

        public void Init()
        {
            var items = new List<PositionModel>();
            items.Add(new PositionModel("Top Left", PositionType.TopLeft));
            items.Add(new PositionModel("Top Center", PositionType.TopCenter));
            items.Add(new PositionModel("Top Right", PositionType.TopRight));
            items.Add(new PositionModel("Bottom Left", PositionType.BottomLeft));
            items.Add(new PositionModel("Bottom Center", PositionType.BottomCenter));
            items.Add(new PositionModel("Bottom Right", PositionType.BottomRight));

            cbbPosition.DisplayMember = "Name";
            cbbPosition.ValueMember = "Position";
            cbbPosition.DataSource = items.ToList();

            cbbEventsPosition.DisplayMember = "Name";
            cbbEventsPosition.ValueMember = "Position";
            cbbEventsPosition.DataSource = items.ToList();

            cbbEventsPosition.SelectedValue = PositionType.BottomRight;

            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(directory, "config.json");
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                config = JsonConvert.DeserializeObject<ConfigModel>(json);

                cbShowScore.Checked = config.ShowScore;
                txbTeam1Name.Text = config.Team1Name;
                txbTeam2Name.Text = config.Team2Name;
                cbbPosition.SelectedValue = config.ScorePosition;
                cbbEventsPosition.SelectedValue = config.EventPosition;
                numDelay.Value = config.Delay;
                numOpacity.Value = config.Opacity;
                txbTeam1Players.Text = String.Join(Environment.NewLine, config.Team1Players);
                txbTeam2Players.Text = String.Join(Environment.NewLine, config.Team2Players);
                pnlTeam1Color.BackColor = config.Team1Color;
                pnlTeam2Color.BackColor = config.Team2Color;
                txbTeam1Color.Text = HexConverter(config.Team1Color);
                txbTeam2Color.Text = HexConverter(config.Team2Color);
                cbEnableSound.Checked = config.EnableArenaSound;
                cbHornSound.Checked = config.EnableHorn;
                pnlLeagueColor.BackColor = config.LeagueColor;
                pnlTextColor.BackColor = config.TextColor;
                pnlBorderColor.BackColor = config.BorderColor;
                txbLeagueColor.Text = HexConverter(config.LeagueColor);
                txbTextColor.Text = HexConverter(config.TextColor);
                txbBorderColor.Text = HexConverter(config.BorderColor);
            }
        }

        private static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                try
                {
                    MemoryEditor.Init(true);
                    BindProps();
                    of = new OverlayForm(config);
                    of.Show();

                    btnStart.Text = "Stop";
                    started = true;
                }
                catch
                {
                    MessageBox.Show("Process not found");
                }
            }
            else
            {
                of.Close();

                btnStart.Text = "Start";
                started = false;
            }
        }

        public void BindProps()
        {
            config.ShowScore = cbShowScore.Checked;
            config.Team1Name = (txbTeam1Name.Text.Trim() != String.Empty ? txbTeam1Name.Text.Trim() : "Red").ToUpper();
            config.Team2Name = (txbTeam2Name.Text.Trim() != String.Empty ? txbTeam2Name.Text.Trim() : "Blue").ToUpper();
            config.ScorePosition = (PositionType)cbbPosition.SelectedValue;
            config.EventPosition = (PositionType)cbbEventsPosition.SelectedValue;
            config.Delay = (int)numDelay.Value;
            config.Opacity = (int)numOpacity.Value;
            config.Team1Players = txbTeam1Players.Text.Split(Environment.NewLine).ToList();
            config.Team2Players = txbTeam2Players.Text.Split(Environment.NewLine).ToList();
            config.EnableArenaSound = cbEnableSound.Checked;
            config.EnableHorn = cbHornSound.Checked;
            var json = JsonConvert.SerializeObject(config);
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            File.WriteAllText(Path.Combine(directory, "config.json"), json);
        }

        private void pnlTeam1Color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = config.Team1Color;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlTeam1Color.BackColor = colorDialog.Color;
                config.Team1Color = colorDialog.Color;
                txbTeam1Color.Text = HexConverter(config.Team1Color);
            }
        }

        private void pnlTeam2Color_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = config.Team2Color;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlTeam2Color.BackColor = colorDialog.Color;
                config.Team2Color = colorDialog.Color;
                txbTeam2Color.Text = HexConverter(config.Team2Color);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "";

            var codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

            dlg.DefaultExt = ".png"; 

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                var image =  Image.FromFile(fileName);
                pcbLeagueLogo.Image = image;
                config.LeagueLogo = image;
            }
        }

        private void pcbTeam1Logo_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "";

            var codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

            dlg.DefaultExt = ".png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                var image = Image.FromFile(fileName);
                pcbTeam1Logo.Image = image;
                config.Team1Logo = image;
            }
        }

        private void pcbTeam2Logo_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "";

            var codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

            dlg.DefaultExt = ".png";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                var image = Image.FromFile(fileName);
                pcbTeam2Logo.Image = image;
                config.Team2Logo = image;
            }
        }

        private void txbTeam1Color_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var color = ColorTranslator.FromHtml(txbTeam1Color.Text);
                pnlTeam1Color.BackColor = color;
                config.Team1Color = color;
            }
            catch { }
        }

        private void txbTeam2Color_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var color = ColorTranslator.FromHtml(txbTeam2Color.Text);
                pnlTeam2Color.BackColor = color;
                config.Team2Color = color;
            }
            catch { }
        }

        private void txbLeagueColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var color = ColorTranslator.FromHtml(txbLeagueColor.Text);
                pnlLeagueColor.BackColor = color;
                config.LeagueColor = color;
            }
            catch { }
        }

        private void txbTextColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var color = ColorTranslator.FromHtml(txbTextColor.Text);
                pnlTextColor.BackColor = color;
                config.TextColor = color;
            }
            catch { }
        }

        private void txbBorderColor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var color = ColorTranslator.FromHtml(txbBorderColor.Text);
                pnlBorderColor.BackColor = color;
                config.BorderColor = color;
            }
            catch { }
        }

        private void pnlLeagueColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = config.LeagueColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlLeagueColor.BackColor = colorDialog.Color;
                config.LeagueColor = colorDialog.Color;
                txbLeagueColor.Text = HexConverter(config.LeagueColor);
            }
        }

        private void pnlTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = config.TextColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlTextColor.BackColor = colorDialog.Color;
                config.TextColor = colorDialog.Color;
                txbTextColor.Text = HexConverter(config.TextColor);
            }
        }

        private void pnlBorderColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            colorDialog.Color = config.BorderColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pnlTextColor.BackColor = colorDialog.Color;
                config.BorderColor = colorDialog.Color;
                txbBorderColor.Text = HexConverter(config.BorderColor);
            }
        }
    }
}
