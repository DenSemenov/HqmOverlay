namespace HockeyOverlay
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.cbShowScore = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTeam1Color = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTeam1Name = new System.Windows.Forms.TextBox();
            this.pnlTeam2Color = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbTeam2Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pcbLeagueLogo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbTeam1Color = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbTeam1Players = new System.Windows.Forms.TextBox();
            this.pcbTeam1Logo = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbTeam2Color = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbTeam2Players = new System.Windows.Forms.TextBox();
            this.pcbTeam2Logo = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbPosition = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbShowEvents = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbEventsPosition = new System.Windows.Forms.ComboBox();
            this.cbHornSound = new System.Windows.Forms.CheckBox();
            this.cbEnableSound = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txbBorderColor = new System.Windows.Forms.TextBox();
            this.pnlBorderColor = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txbTextColor = new System.Windows.Forms.TextBox();
            this.pnlTextColor = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txbLeagueColor = new System.Windows.Forms.TextBox();
            this.pnlLeagueColor = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLeagueLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTeam1Logo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTeam2Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(461, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbShowScore
            // 
            this.cbShowScore.AutoSize = true;
            this.cbShowScore.Checked = true;
            this.cbShowScore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowScore.Location = new System.Drawing.Point(6, 6);
            this.cbShowScore.Name = "cbShowScore";
            this.cbShowScore.Size = new System.Drawing.Size(129, 19);
            this.cbShowScore.TabIndex = 2;
            this.cbShowScore.Text = "Show custom score";
            this.cbShowScore.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 47);
            this.panel1.TabIndex = 3;
            // 
            // pnlTeam1Color
            // 
            this.pnlTeam1Color.BackColor = System.Drawing.Color.Red;
            this.pnlTeam1Color.Location = new System.Drawing.Point(229, 55);
            this.pnlTeam1Color.Name = "pnlTeam1Color";
            this.pnlTeam1Color.Size = new System.Drawing.Size(23, 23);
            this.pnlTeam1Color.TabIndex = 9;
            this.pnlTeam1Color.Click += new System.EventHandler(this.pnlTeam1Color_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Color";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Short name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbTeam1Name
            // 
            this.txbTeam1Name.Location = new System.Drawing.Point(131, 22);
            this.txbTeam1Name.Name = "txbTeam1Name";
            this.txbTeam1Name.Size = new System.Drawing.Size(121, 23);
            this.txbTeam1Name.TabIndex = 6;
            // 
            // pnlTeam2Color
            // 
            this.pnlTeam2Color.BackColor = System.Drawing.Color.Blue;
            this.pnlTeam2Color.Location = new System.Drawing.Point(234, 55);
            this.pnlTeam2Color.Name = "pnlTeam2Color";
            this.pnlTeam2Color.Size = new System.Drawing.Size(23, 23);
            this.pnlTeam2Color.TabIndex = 11;
            this.pnlTeam2Color.Click += new System.EventHandler(this.pnlTeam2Color_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Short name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Color";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbTeam2Name
            // 
            this.txbTeam2Name.Location = new System.Drawing.Point(137, 22);
            this.txbTeam2Name.Name = "txbTeam2Name";
            this.txbTeam2Name.Size = new System.Drawing.Size(119, 23);
            this.txbTeam2Name.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "League logo";
            // 
            // pcbLeagueLogo
            // 
            this.pcbLeagueLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbLeagueLogo.Image = global::HockeyOverlay.Properties.Resources.puck0;
            this.pcbLeagueLogo.Location = new System.Drawing.Point(206, 3);
            this.pcbLeagueLogo.Name = "pcbLeagueLogo";
            this.pcbLeagueLogo.Size = new System.Drawing.Size(48, 48);
            this.pcbLeagueLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLeagueLogo.TabIndex = 8;
            this.pcbLeagueLogo.TabStop = false;
            this.pcbLeagueLogo.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbTeam1Color);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txbTeam1Players);
            this.groupBox1.Controls.Add(this.pcbTeam1Logo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pnlTeam1Color);
            this.groupBox1.Controls.Add(this.txbTeam1Name);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 267);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Team 1";
            // 
            // txbTeam1Color
            // 
            this.txbTeam1Color.Location = new System.Drawing.Point(131, 55);
            this.txbTeam1Color.Name = "txbTeam1Color";
            this.txbTeam1Color.Size = new System.Drawing.Size(92, 23);
            this.txbTeam1Color.TabIndex = 19;
            this.txbTeam1Color.TextChanged += new System.EventHandler(this.txbTeam1Color_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Players";
            // 
            // txbTeam1Players
            // 
            this.txbTeam1Players.Location = new System.Drawing.Point(6, 170);
            this.txbTeam1Players.Multiline = true;
            this.txbTeam1Players.Name = "txbTeam1Players";
            this.txbTeam1Players.Size = new System.Drawing.Size(246, 72);
            this.txbTeam1Players.TabIndex = 17;
            // 
            // pcbTeam1Logo
            // 
            this.pcbTeam1Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbTeam1Logo.Image = global::HockeyOverlay.Properties.Resources.puck0;
            this.pcbTeam1Logo.Location = new System.Drawing.Point(204, 91);
            this.pcbTeam1Logo.Name = "pcbTeam1Logo";
            this.pcbTeam1Logo.Size = new System.Drawing.Size(48, 48);
            this.pcbTeam1Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbTeam1Logo.TabIndex = 16;
            this.pcbTeam1Logo.TabStop = false;
            this.pcbTeam1Logo.Click += new System.EventHandler(this.pcbTeam1Logo_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Team logo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbTeam2Color);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txbTeam2Players);
            this.groupBox2.Controls.Add(this.pcbTeam2Logo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.pnlTeam2Color);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txbTeam2Name);
            this.groupBox2.Location = new System.Drawing.Point(270, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 267);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Team 2";
            // 
            // txbTeam2Color
            // 
            this.txbTeam2Color.Location = new System.Drawing.Point(137, 55);
            this.txbTeam2Color.Name = "txbTeam2Color";
            this.txbTeam2Color.Size = new System.Drawing.Size(92, 23);
            this.txbTeam2Color.TabIndex = 20;
            this.txbTeam2Color.TextChanged += new System.EventHandler(this.txbTeam2Color_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "Players";
            // 
            // txbTeam2Players
            // 
            this.txbTeam2Players.Location = new System.Drawing.Point(6, 170);
            this.txbTeam2Players.Multiline = true;
            this.txbTeam2Players.Name = "txbTeam2Players";
            this.txbTeam2Players.Size = new System.Drawing.Size(246, 72);
            this.txbTeam2Players.TabIndex = 18;
            // 
            // pcbTeam2Logo
            // 
            this.pcbTeam2Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbTeam2Logo.Image = global::HockeyOverlay.Properties.Resources.puck0;
            this.pcbTeam2Logo.Location = new System.Drawing.Point(208, 91);
            this.pcbTeam2Logo.Name = "pcbTeam2Logo";
            this.pcbTeam2Logo.Size = new System.Drawing.Size(48, 48);
            this.pcbTeam2Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbTeam2Logo.TabIndex = 17;
            this.pcbTeam2Logo.TabStop = false;
            this.pcbTeam2Logo.Click += new System.EventHandler(this.pcbTeam2Logo_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Team logo";
            // 
            // numDelay
            // 
            this.numDelay.Location = new System.Drawing.Point(148, 109);
            this.numDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(120, 23);
            this.numDelay.TabIndex = 11;
            this.numDelay.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Delay";
            // 
            // cbbPosition
            // 
            this.cbbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPosition.FormattingEnabled = true;
            this.cbbPosition.Location = new System.Drawing.Point(147, 28);
            this.cbbPosition.Name = "cbbPosition";
            this.cbbPosition.Size = new System.Drawing.Size(121, 23);
            this.cbbPosition.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Position";
            // 
            // cbShowEvents
            // 
            this.cbShowEvents.AutoSize = true;
            this.cbShowEvents.Checked = true;
            this.cbShowEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowEvents.Location = new System.Drawing.Point(6, 55);
            this.cbShowEvents.Name = "cbShowEvents";
            this.cbShowEvents.Size = new System.Drawing.Size(135, 19);
            this.cbShowEvents.TabIndex = 15;
            this.cbShowEvents.Text = "Show custom events";
            this.cbShowEvents.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Position";
            // 
            // cbbEventsPosition
            // 
            this.cbbEventsPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbEventsPosition.FormattingEnabled = true;
            this.cbbEventsPosition.Location = new System.Drawing.Point(147, 77);
            this.cbbEventsPosition.Name = "cbbEventsPosition";
            this.cbbEventsPosition.Size = new System.Drawing.Size(120, 23);
            this.cbbEventsPosition.TabIndex = 16;
            // 
            // cbHornSound
            // 
            this.cbHornSound.AutoSize = true;
            this.cbHornSound.Checked = true;
            this.cbHornSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHornSound.Location = new System.Drawing.Point(6, 169);
            this.cbHornSound.Name = "cbHornSound";
            this.cbHornSound.Size = new System.Drawing.Size(125, 19);
            this.cbHornSound.TabIndex = 19;
            this.cbHornSound.Text = "Enable horn sound";
            this.cbHornSound.UseVisualStyleBackColor = true;
            // 
            // cbEnableSound
            // 
            this.cbEnableSound.AutoSize = true;
            this.cbEnableSound.Checked = true;
            this.cbEnableSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEnableSound.Location = new System.Drawing.Point(6, 144);
            this.cbEnableSound.Name = "cbEnableSound";
            this.cbEnableSound.Size = new System.Drawing.Size(129, 19);
            this.cbEnableSound.TabIndex = 18;
            this.cbEnableSound.Text = "Enable arena sound";
            this.cbEnableSound.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 309);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numOpacity);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.cbHornSound);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cbEnableSound);
            this.tabPage1.Controls.Add(this.cbbPosition);
            this.tabPage1.Controls.Add(this.numDelay);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbShowScore);
            this.tabPage1.Controls.Add(this.cbbEventsPosition);
            this.tabPage1.Controls.Add(this.cbShowEvents);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(540, 281);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numOpacity
            // 
            this.numOpacity.Location = new System.Drawing.Point(147, 200);
            this.numOpacity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numOpacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(120, 23);
            this.numOpacity.TabIndex = 21;
            this.numOpacity.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "Opacity";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txbBorderColor);
            this.tabPage2.Controls.Add(this.pnlBorderColor);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.txbTextColor);
            this.tabPage2.Controls.Add(this.pnlTextColor);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txbLeagueColor);
            this.tabPage2.Controls.Add(this.pnlLeagueColor);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.pcbLeagueLogo);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(540, 281);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "League";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txbBorderColor
            // 
            this.txbBorderColor.Location = new System.Drawing.Point(133, 133);
            this.txbBorderColor.Name = "txbBorderColor";
            this.txbBorderColor.Size = new System.Drawing.Size(92, 23);
            this.txbBorderColor.TabIndex = 28;
            this.txbBorderColor.TextChanged += new System.EventHandler(this.txbBorderColor_TextChanged);
            // 
            // pnlBorderColor
            // 
            this.pnlBorderColor.BackColor = System.Drawing.Color.Red;
            this.pnlBorderColor.Location = new System.Drawing.Point(231, 133);
            this.pnlBorderColor.Name = "pnlBorderColor";
            this.pnlBorderColor.Size = new System.Drawing.Size(23, 23);
            this.pnlBorderColor.TabIndex = 27;
            this.pnlBorderColor.Click += new System.EventHandler(this.pnlBorderColor_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 15);
            this.label15.TabIndex = 26;
            this.label15.Text = "Border color";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbTextColor
            // 
            this.txbTextColor.Location = new System.Drawing.Point(133, 96);
            this.txbTextColor.Name = "txbTextColor";
            this.txbTextColor.Size = new System.Drawing.Size(92, 23);
            this.txbTextColor.TabIndex = 25;
            this.txbTextColor.TextChanged += new System.EventHandler(this.txbTextColor_TextChanged);
            // 
            // pnlTextColor
            // 
            this.pnlTextColor.BackColor = System.Drawing.Color.Red;
            this.pnlTextColor.Location = new System.Drawing.Point(231, 96);
            this.pnlTextColor.Name = "pnlTextColor";
            this.pnlTextColor.Size = new System.Drawing.Size(23, 23);
            this.pnlTextColor.TabIndex = 24;
            this.pnlTextColor.Click += new System.EventHandler(this.pnlTextColor_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "Text color";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbLeagueColor
            // 
            this.txbLeagueColor.Location = new System.Drawing.Point(133, 61);
            this.txbLeagueColor.Name = "txbLeagueColor";
            this.txbLeagueColor.Size = new System.Drawing.Size(92, 23);
            this.txbLeagueColor.TabIndex = 22;
            this.txbLeagueColor.TextChanged += new System.EventHandler(this.txbLeagueColor_TextChanged);
            // 
            // pnlLeagueColor
            // 
            this.pnlLeagueColor.BackColor = System.Drawing.Color.Red;
            this.pnlLeagueColor.Location = new System.Drawing.Point(231, 61);
            this.pnlLeagueColor.Name = "pnlLeagueColor";
            this.pnlLeagueColor.Size = new System.Drawing.Size(23, 23);
            this.pnlLeagueColor.TabIndex = 21;
            this.pnlLeagueColor.Click += new System.EventHandler(this.pnlLeagueColor_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "Color";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(540, 281);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Teams";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 359);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Hockey overlay";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbLeagueLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTeam1Logo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTeam2Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbShowScore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTeam1Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbTeam2Name;
        private System.Windows.Forms.Panel pnlTeam1Color;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlTeam2Color;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pcbLeagueLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbShowEvents;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbEventsPosition;
        private System.Windows.Forms.PictureBox pcbTeam1Logo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pcbTeam2Logo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbTeam1Players;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbTeam2Players;
        private System.Windows.Forms.TextBox txbTeam1Color;
        private System.Windows.Forms.TextBox txbTeam2Color;
        private System.Windows.Forms.CheckBox cbEnableSound;
        private System.Windows.Forms.CheckBox cbHornSound;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txbLeagueColor;
        private System.Windows.Forms.Panel pnlLeagueColor;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbBorderColor;
        private System.Windows.Forms.Panel pnlBorderColor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txbTextColor;
        private System.Windows.Forms.Panel pnlTextColor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numOpacity;
        private System.Windows.Forms.Label label16;
    }
}
