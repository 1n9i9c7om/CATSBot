namespace CATSBot
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabMain = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.picDebug2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.picDebug = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnLightTheme = new MetroFramework.Controls.MetroButton();
            this.btnDarkTheme = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnChangeStyle = new MetroFramework.Controls.MetroTile();
            this.styleBox = new MetroFramework.Controls.MetroComboBox();
            this.lbl_style = new MetroFramework.Controls.MetroLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCurrentMemuPath = new MetroFramework.Controls.MetroTextBox();
            this.btnChangeMemuPath = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btnResetStats = new MetroFramework.Controls.MetroTile();
            this.nudReconnectTime = new System.Windows.Forms.NumericUpDown();
            this.chkAutoReconnect = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chkUseSidebar = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnStart = new MetroFramework.Controls.MetroTile();
            this.lblStats = new MetroFramework.Controls.MetroLabel();
            this.metroStyle = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabMain.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDebug2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDebug)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconnectTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.metroTabPage1);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Location = new System.Drawing.Point(8, 53);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 3;
            this.tabMain.Size = new System.Drawing.Size(274, 459);
            this.tabMain.TabIndex = 0;
            this.tabMain.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.picDebug2);
            this.metroTabPage1.Controls.Add(this.button3);
            this.metroTabPage1.Controls.Add(this.button2);
            this.metroTabPage1.Controls.Add(this.button1);
            this.metroTabPage1.Controls.Add(this.picDebug);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(266, 417);
            this.metroTabPage1.TabIndex = 3;
            this.metroTabPage1.Text = "metroTabPage1";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // picDebug2
            // 
            this.picDebug2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDebug2.Location = new System.Drawing.Point(3, 338);
            this.picDebug2.Name = "picDebug2";
            this.picDebug2.Size = new System.Drawing.Size(260, 38);
            this.picDebug2.TabIndex = 6;
            this.picDebug2.TabStop = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(92, 382);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Capture Cats";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(179, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Stop CATS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(3, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start CATS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // picDebug
            // 
            this.picDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDebug.Location = new System.Drawing.Point(4, 3);
            this.picDebug.Name = "picDebug";
            this.picDebug.Size = new System.Drawing.Size(266, 318);
            this.picDebug.TabIndex = 2;
            this.picDebug.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.btnLightTheme);
            this.tabPage3.Controls.Add(this.btnDarkTheme);
            this.tabPage3.Controls.Add(this.metroLabel3);
            this.tabPage3.Controls.Add(this.btnChangeStyle);
            this.tabPage3.Controls.Add(this.styleBox);
            this.tabPage3.Controls.Add(this.lbl_style);
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(266, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Appearance";
            // 
            // btnLightTheme
            // 
            this.btnLightTheme.Location = new System.Drawing.Point(137, 156);
            this.btnLightTheme.Name = "btnLightTheme";
            this.btnLightTheme.Size = new System.Drawing.Size(117, 40);
            this.btnLightTheme.TabIndex = 6;
            this.btnLightTheme.Text = "Light Theme";
            this.btnLightTheme.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnLightTheme.UseSelectable = true;
            this.btnLightTheme.Click += new System.EventHandler(this.btnLightTheme_Click);
            // 
            // btnDarkTheme
            // 
            this.btnDarkTheme.Location = new System.Drawing.Point(11, 156);
            this.btnDarkTheme.Name = "btnDarkTheme";
            this.btnDarkTheme.Size = new System.Drawing.Size(120, 40);
            this.btnDarkTheme.TabIndex = 5;
            this.btnDarkTheme.Text = "Dark Theme";
            this.btnDarkTheme.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDarkTheme.UseSelectable = true;
            this.btnDarkTheme.Click += new System.EventHandler(this.btnDarkTheme_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(10, 134);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(100, 19);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "Choose Theme:";
            // 
            // btnChangeStyle
            // 
            this.btnChangeStyle.ActiveControl = null;
            this.btnChangeStyle.Location = new System.Drawing.Point(10, 65);
            this.btnChangeStyle.Name = "btnChangeStyle";
            this.btnChangeStyle.Size = new System.Drawing.Size(120, 40);
            this.btnChangeStyle.TabIndex = 3;
            this.btnChangeStyle.Text = "Change Style";
            this.btnChangeStyle.UseSelectable = true;
            this.btnChangeStyle.Click += new System.EventHandler(this.btnChangeStyle_Click);
            // 
            // styleBox
            // 
            this.styleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.styleBox.FormattingEnabled = true;
            this.styleBox.ItemHeight = 23;
            this.styleBox.Items.AddRange(new object[] {
            "Black",
            "White",
            "Silver",
            "Blue",
            "Green",
            "Lime",
            "Teal",
            "Orange",
            "Brown",
            "Pink",
            "Magenta",
            "Purple",
            "Red",
            "Yellow"});
            this.styleBox.Location = new System.Drawing.Point(10, 30);
            this.styleBox.Name = "styleBox";
            this.styleBox.Size = new System.Drawing.Size(244, 29);
            this.styleBox.TabIndex = 2;
            this.styleBox.UseSelectable = true;
            // 
            // lbl_style
            // 
            this.lbl_style.AutoSize = true;
            this.lbl_style.Location = new System.Drawing.Point(10, 8);
            this.lbl_style.Name = "lbl_style";
            this.lbl_style.Size = new System.Drawing.Size(138, 19);
            this.lbl_style.TabIndex = 1;
            this.lbl_style.Text = "Choose color scheme:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLog);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(266, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Location = new System.Drawing.Point(0, 1);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(266, 416);
            this.txtLog.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.txtCurrentMemuPath);
            this.tabPage2.Controls.Add(this.btnChangeMemuPath);
            this.tabPage2.Controls.Add(this.metroLabel4);
            this.tabPage2.Controls.Add(this.btnResetStats);
            this.tabPage2.Controls.Add(this.nudReconnectTime);
            this.tabPage2.Controls.Add(this.chkAutoReconnect);
            this.tabPage2.Controls.Add(this.metroLabel2);
            this.tabPage2.Controls.Add(this.chkUseSidebar);
            this.tabPage2.Controls.Add(this.metroLabel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(266, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // txtCurrentMemuPath
            // 
            // 
            // 
            // 
            this.txtCurrentMemuPath.CustomButton.Image = null;
            this.txtCurrentMemuPath.CustomButton.Location = new System.Drawing.Point(150, 1);
            this.txtCurrentMemuPath.CustomButton.Name = "";
            this.txtCurrentMemuPath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtCurrentMemuPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentMemuPath.CustomButton.TabIndex = 1;
            this.txtCurrentMemuPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentMemuPath.CustomButton.UseSelectable = true;
            this.txtCurrentMemuPath.CustomButton.Visible = false;
            this.txtCurrentMemuPath.Lines = new string[0];
            this.txtCurrentMemuPath.Location = new System.Drawing.Point(8, 173);
            this.txtCurrentMemuPath.MaxLength = 32767;
            this.txtCurrentMemuPath.Name = "txtCurrentMemuPath";
            this.txtCurrentMemuPath.PasswordChar = '\0';
            this.txtCurrentMemuPath.ReadOnly = true;
            this.txtCurrentMemuPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentMemuPath.SelectedText = "";
            this.txtCurrentMemuPath.SelectionLength = 0;
            this.txtCurrentMemuPath.SelectionStart = 0;
            this.txtCurrentMemuPath.ShortcutsEnabled = true;
            this.txtCurrentMemuPath.Size = new System.Drawing.Size(172, 23);
            this.txtCurrentMemuPath.TabIndex = 10;
            this.txtCurrentMemuPath.UseSelectable = true;
            this.txtCurrentMemuPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentMemuPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnChangeMemuPath
            // 
            this.btnChangeMemuPath.Location = new System.Drawing.Point(186, 173);
            this.btnChangeMemuPath.Name = "btnChangeMemuPath";
            this.btnChangeMemuPath.Size = new System.Drawing.Size(75, 23);
            this.btnChangeMemuPath.TabIndex = 9;
            this.btnChangeMemuPath.Text = "Change";
            this.btnChangeMemuPath.UseSelectable = true;
            this.btnChangeMemuPath.Click += new System.EventHandler(this.btnChangeMemuPath_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(3, 151);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(115, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "MEmu Install Path:";
            // 
            // btnResetStats
            // 
            this.btnResetStats.ActiveControl = null;
            this.btnResetStats.Location = new System.Drawing.Point(11, 370);
            this.btnResetStats.Name = "btnResetStats";
            this.btnResetStats.Size = new System.Drawing.Size(243, 40);
            this.btnResetStats.TabIndex = 5;
            this.btnResetStats.Text = "Reset Stats";
            this.btnResetStats.UseSelectable = true;
            this.btnResetStats.Click += new System.EventHandler(this.btnResetStats_Click);
            // 
            // nudReconnectTime
            // 
            this.nudReconnectTime.BackColor = System.Drawing.Color.White;
            this.nudReconnectTime.ForeColor = System.Drawing.Color.Black;
            this.nudReconnectTime.Location = new System.Drawing.Point(78, 128);
            this.nudReconnectTime.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudReconnectTime.Name = "nudReconnectTime";
            this.nudReconnectTime.Size = new System.Drawing.Size(41, 20);
            this.nudReconnectTime.TabIndex = 4;
            this.nudReconnectTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudReconnectTime.ValueChanged += new System.EventHandler(this.nudReconnectTime_ValueChanged);
            // 
            // chkAutoReconnect
            // 
            this.chkAutoReconnect.AutoSize = true;
            this.chkAutoReconnect.Checked = true;
            this.chkAutoReconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoReconnect.Location = new System.Drawing.Point(6, 130);
            this.chkAutoReconnect.Name = "chkAutoReconnect";
            this.chkAutoReconnect.Size = new System.Drawing.Size(170, 15);
            this.chkAutoReconnect.TabIndex = 3;
            this.chkAutoReconnect.Text = "Yes, after                  minutes.";
            this.chkAutoReconnect.UseSelectable = true;
            this.chkAutoReconnect.CheckedChanged += new System.EventHandler(this.chkAutoReconnect_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(1, 69);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(230, 57);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Reconnect automatically after being \r\ndisconnected because another device \r\nused " +
    "the account.";
            // 
            // chkUseSidebar
            // 
            this.chkUseSidebar.AutoSize = true;
            this.chkUseSidebar.Checked = true;
            this.chkUseSidebar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseSidebar.Location = new System.Drawing.Point(5, 45);
            this.chkUseSidebar.Name = "chkUseSidebar";
            this.chkUseSidebar.Size = new System.Drawing.Size(150, 15);
            this.chkUseSidebar.TabIndex = 1;
            this.chkUseSidebar.Text = "MEmu Sidebar enabled?";
            this.chkUseSidebar.UseSelectable = true;
            this.chkUseSidebar.CheckedChanged += new System.EventHandler(this.chkUseSidebar_CheckedChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(1, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(216, 76);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Uncheck this, if you have the bar \r\non the right side in MEmu disabled.\r\n\r\n";
            // 
            // btnStart
            // 
            this.btnStart.ActiveControl = null;
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(12, 519);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(266, 51);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStats
            // 
            this.lblStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(12, 578);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(178, 19);
            this.lblStats.TabIndex = 2;
            this.lblStats.Text = "Wins: 0 (0 Crowns) | Losses: 0";
            // 
            // metroStyle
            // 
            this.metroStyle.Owner = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 605);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabMain);
            this.MinimumSize = new System.Drawing.Size(289, 605);
            this.Name = "frmMain";
            this.Text = "CATSBot | catsbot.net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.tabMain.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDebug2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDebug)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconnectTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroTile btnStart;
        public MetroFramework.Controls.MetroLabel lblStats;
        public System.Windows.Forms.TextBox txtLog;
        private MetroFramework.Controls.MetroLabel lbl_style;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroComboBox styleBox;
        private MetroFramework.Controls.MetroTile btnChangeStyle;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnLightTheme;
        private MetroFramework.Controls.MetroButton btnDarkTheme;
        public MetroFramework.Components.MetroStyleManager metroStyle;
        public MetroFramework.Controls.MetroCheckBox chkUseSidebar;
        public MetroFramework.Controls.MetroCheckBox chkAutoReconnect;
        public System.Windows.Forms.NumericUpDown nudReconnectTime;
        private MetroFramework.Controls.MetroTile btnResetStats;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        public System.Windows.Forms.PictureBox picDebug;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.PictureBox picDebug2;
        private MetroFramework.Controls.MetroButton btnChangeMemuPath;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroTextBox txtCurrentMemuPath;
    }
}