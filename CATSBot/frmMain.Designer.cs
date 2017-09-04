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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabMain = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.healthThresholdLabel = new System.Windows.Forms.Label();
            this.chkAutoUpdate = new MetroFramework.Controls.MetroCheckBox();
            this.btnCheckUpdates = new MetroFramework.Controls.MetroButton();
            this.chkUseChestLogic = new MetroFramework.Controls.MetroCheckBox();
            this.btnResetStats = new MetroFramework.Controls.MetroButton();
            this.nudDelayMultiplier = new System.Windows.Forms.NumericUpDown();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtCurrentMemuPath = new MetroFramework.Controls.MetroTextBox();
            this.btnChangeMemuPath = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.nudReconnectTime = new System.Windows.Forms.NumericUpDown();
            this.chkAutoReconnect = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkAlwaysTop = new MetroFramework.Controls.MetroCheckBox();
            this.btnLightTheme = new MetroFramework.Controls.MetroButton();
            this.btnDarkTheme = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.btnChangeStyle = new MetroFramework.Controls.MetroTile();
            this.styleBox = new MetroFramework.Controls.MetroComboBox();
            this.lbl_style = new MetroFramework.Controls.MetroLabel();
            this.btnStart = new MetroFramework.Controls.MetroTile();
            this.lblStats = new MetroFramework.Controls.MetroLabel();
            this.metroStyle = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayMultiplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconnectTime)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 1;
            this.tabMain.UseSelectable = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLog);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // txtLog
            // 
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.healthThresholdLabel);
            this.tabPage2.Controls.Add(this.chkAutoUpdate);
            this.tabPage2.Controls.Add(this.btnCheckUpdates);
            this.tabPage2.Controls.Add(this.chkUseChestLogic);
            this.tabPage2.Controls.Add(this.btnResetStats);
            this.tabPage2.Controls.Add(this.nudDelayMultiplier);
            this.tabPage2.Controls.Add(this.metroLabel5);
            this.tabPage2.Controls.Add(this.txtCurrentMemuPath);
            this.tabPage2.Controls.Add(this.btnChangeMemuPath);
            this.tabPage2.Controls.Add(this.metroLabel4);
            this.tabPage2.Controls.Add(this.nudReconnectTime);
            this.tabPage2.Controls.Add(this.chkAutoReconnect);
            this.tabPage2.Controls.Add(this.metroLabel2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // healthThresholdLabel
            // 
            resources.ApplyResources(this.healthThresholdLabel, "healthThresholdLabel");
            this.healthThresholdLabel.Name = "healthThresholdLabel";
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.Checked = true;
            this.chkAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chkAutoUpdate, "chkAutoUpdate");
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.UseSelectable = true;
            this.chkAutoUpdate.CheckedChanged += new System.EventHandler(this.chkAutoUpdate_CheckedChanged);
            // 
            // btnCheckUpdates
            // 
            resources.ApplyResources(this.btnCheckUpdates, "btnCheckUpdates");
            this.btnCheckUpdates.Name = "btnCheckUpdates";
            this.btnCheckUpdates.UseSelectable = true;
            this.btnCheckUpdates.Click += new System.EventHandler(this.btnCheckUpdates_Click);
            // 
            // chkUseChestLogic
            // 
            this.chkUseChestLogic.Checked = true;
            this.chkUseChestLogic.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.chkUseChestLogic, "chkUseChestLogic");
            this.chkUseChestLogic.Name = "chkUseChestLogic";
            this.chkUseChestLogic.UseSelectable = true;
            // 
            // btnResetStats
            // 
            resources.ApplyResources(this.btnResetStats, "btnResetStats");
            this.btnResetStats.Name = "btnResetStats";
            this.btnResetStats.UseSelectable = true;
            this.btnResetStats.Click += new System.EventHandler(this.btnResetStats_Click);
            // 
            // nudDelayMultiplier
            // 
            this.nudDelayMultiplier.DecimalPlaces = 1;
            this.nudDelayMultiplier.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudDelayMultiplier, "nudDelayMultiplier");
            this.nudDelayMultiplier.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDelayMultiplier.Name = "nudDelayMultiplier";
            this.nudDelayMultiplier.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // metroLabel5
            // 
            resources.ApplyResources(this.metroLabel5, "metroLabel5");
            this.metroLabel5.Name = "metroLabel5";
            // 
            // txtCurrentMemuPath
            // 
            // 
            // 
            // 
            this.txtCurrentMemuPath.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.txtCurrentMemuPath.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.txtCurrentMemuPath.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.txtCurrentMemuPath.CustomButton.Name = "";
            this.txtCurrentMemuPath.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.txtCurrentMemuPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtCurrentMemuPath.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.txtCurrentMemuPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtCurrentMemuPath.CustomButton.UseSelectable = true;
            this.txtCurrentMemuPath.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.txtCurrentMemuPath.Lines = new string[0];
            resources.ApplyResources(this.txtCurrentMemuPath, "txtCurrentMemuPath");
            this.txtCurrentMemuPath.MaxLength = 32767;
            this.txtCurrentMemuPath.Name = "txtCurrentMemuPath";
            this.txtCurrentMemuPath.PasswordChar = '\0';
            this.txtCurrentMemuPath.ReadOnly = true;
            this.txtCurrentMemuPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurrentMemuPath.SelectedText = "";
            this.txtCurrentMemuPath.SelectionLength = 0;
            this.txtCurrentMemuPath.SelectionStart = 0;
            this.txtCurrentMemuPath.ShortcutsEnabled = true;
            this.txtCurrentMemuPath.UseSelectable = true;
            this.txtCurrentMemuPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtCurrentMemuPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnChangeMemuPath
            // 
            resources.ApplyResources(this.btnChangeMemuPath, "btnChangeMemuPath");
            this.btnChangeMemuPath.Name = "btnChangeMemuPath";
            this.btnChangeMemuPath.UseSelectable = true;
            this.btnChangeMemuPath.Click += new System.EventHandler(this.btnChangeMemuPath_Click);
            // 
            // metroLabel4
            // 
            resources.ApplyResources(this.metroLabel4, "metroLabel4");
            this.metroLabel4.Name = "metroLabel4";
            // 
            // nudReconnectTime
            // 
            this.nudReconnectTime.BackColor = System.Drawing.Color.White;
            this.nudReconnectTime.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.nudReconnectTime, "nudReconnectTime");
            this.nudReconnectTime.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudReconnectTime.Name = "nudReconnectTime";
            this.nudReconnectTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudReconnectTime.ValueChanged += new System.EventHandler(this.nudReconnectTime_ValueChanged);
            // 
            // chkAutoReconnect
            // 
            resources.ApplyResources(this.chkAutoReconnect, "chkAutoReconnect");
            this.chkAutoReconnect.Checked = true;
            this.chkAutoReconnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoReconnect.Name = "chkAutoReconnect";
            this.chkAutoReconnect.UseSelectable = true;
            this.chkAutoReconnect.CheckedChanged += new System.EventHandler(this.chkAutoReconnect_CheckedChanged);
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.chkAlwaysTop);
            this.tabPage3.Controls.Add(this.btnLightTheme);
            this.tabPage3.Controls.Add(this.btnDarkTheme);
            this.tabPage3.Controls.Add(this.metroLabel3);
            this.tabPage3.Controls.Add(this.btnChangeStyle);
            this.tabPage3.Controls.Add(this.styleBox);
            this.tabPage3.Controls.Add(this.lbl_style);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            // 
            // chkAlwaysTop
            // 
            resources.ApplyResources(this.chkAlwaysTop, "chkAlwaysTop");
            this.chkAlwaysTop.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkAlwaysTop.Name = "chkAlwaysTop";
            this.chkAlwaysTop.UseSelectable = true;
            this.chkAlwaysTop.CheckedChanged += new System.EventHandler(this.chkAlwaysTop_CheckedChanged);
            // 
            // btnLightTheme
            // 
            resources.ApplyResources(this.btnLightTheme, "btnLightTheme");
            this.btnLightTheme.Name = "btnLightTheme";
            this.btnLightTheme.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnLightTheme.UseSelectable = true;
            this.btnLightTheme.Click += new System.EventHandler(this.btnLightTheme_Click);
            // 
            // btnDarkTheme
            // 
            resources.ApplyResources(this.btnDarkTheme, "btnDarkTheme");
            this.btnDarkTheme.Name = "btnDarkTheme";
            this.btnDarkTheme.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnDarkTheme.UseSelectable = true;
            this.btnDarkTheme.Click += new System.EventHandler(this.btnDarkTheme_Click);
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.Name = "metroLabel3";
            // 
            // btnChangeStyle
            // 
            this.btnChangeStyle.ActiveControl = null;
            resources.ApplyResources(this.btnChangeStyle, "btnChangeStyle");
            this.btnChangeStyle.Name = "btnChangeStyle";
            this.btnChangeStyle.UseSelectable = true;
            this.btnChangeStyle.Click += new System.EventHandler(this.btnChangeStyle_Click);
            // 
            // styleBox
            // 
            resources.ApplyResources(this.styleBox, "styleBox");
            this.styleBox.FormattingEnabled = true;
            this.styleBox.Items.AddRange(new object[] {
            resources.GetString("styleBox.Items"),
            resources.GetString("styleBox.Items1"),
            resources.GetString("styleBox.Items2"),
            resources.GetString("styleBox.Items3"),
            resources.GetString("styleBox.Items4"),
            resources.GetString("styleBox.Items5"),
            resources.GetString("styleBox.Items6"),
            resources.GetString("styleBox.Items7"),
            resources.GetString("styleBox.Items8"),
            resources.GetString("styleBox.Items9"),
            resources.GetString("styleBox.Items10"),
            resources.GetString("styleBox.Items11"),
            resources.GetString("styleBox.Items12"),
            resources.GetString("styleBox.Items13")});
            this.styleBox.Name = "styleBox";
            this.styleBox.UseSelectable = true;
            // 
            // lbl_style
            // 
            resources.ApplyResources(this.lbl_style, "lbl_style");
            this.lbl_style.Name = "lbl_style";
            // 
            // btnStart
            // 
            this.btnStart.ActiveControl = null;
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblStats
            // 
            resources.ApplyResources(this.lblStats, "lblStats");
            this.lblStats.Name = "lblStats";
            // 
            // metroStyle
            // 
            this.metroStyle.Owner = this;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.frmMain_LocationChanged);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelayMultiplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReconnectTime)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.TextBox txtLog;
        public MetroFramework.Controls.MetroComboBox styleBox;
        public System.Windows.Forms.NumericUpDown nudReconnectTime;
        public System.Windows.Forms.NumericUpDown nudDelayMultiplier;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
        public System.Windows.Forms.Label healthThresholdLabel;
        private MetroFramework.Controls.MetroTabControl tabMain;
        private MetroFramework.Controls.MetroLabel lbl_style;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTile btnChangeStyle;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnLightTheme;
        private MetroFramework.Controls.MetroButton btnDarkTheme;
        private MetroFramework.Controls.MetroButton btnChangeMemuPath;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btnResetStats;
        private MetroFramework.Controls.MetroButton btnCheckUpdates;
        private MetroFramework.Controls.MetroTile btnStart;
        private MetroFramework.Controls.MetroLabel lblStats;
        private MetroFramework.Components.MetroStyleManager metroStyle;
        private MetroFramework.Controls.MetroCheckBox chkAutoReconnect;
        private MetroFramework.Controls.MetroTextBox txtCurrentMemuPath;
        private MetroFramework.Controls.MetroCheckBox chkAlwaysTop;
        private MetroFramework.Controls.MetroCheckBox chkUseChestLogic;
        private MetroFramework.Controls.MetroCheckBox chkAutoUpdate;
    }
}