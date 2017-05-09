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
            this.tabMain = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkUseSidebar = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnStart = new MetroFramework.Controls.MetroTile();
            this.lblStats = new MetroFramework.Controls.MetroLabel();
            this.btn_styleBlu = new MetroFramework.Controls.MetroTile();
            this.lbl_style = new MetroFramework.Controls.MetroLabel();
            this.btn_styleRed = new MetroFramework.Controls.MetroTile();
            this.btn_styleBlack = new MetroFramework.Controls.MetroTile();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Location = new System.Drawing.Point(8, 53);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(274, 459);
            this.tabMain.TabIndex = 0;
            this.tabMain.UseSelectable = true;
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
            this.txtLog.Location = new System.Drawing.Point(0, 1);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(266, 416);
            this.txtLog.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.chkUseSidebar);
            this.tabPage2.Controls.Add(this.metroLabel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(266, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
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
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.btn_styleBlack);
            this.tabPage3.Controls.Add(this.btn_styleRed);
            this.tabPage3.Controls.Add(this.lbl_style);
            this.tabPage3.Controls.Add(this.btn_styleBlu);
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(266, 417);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Appereance";
            // 
            // btnStart
            // 
            this.btnStart.ActiveControl = null;
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
            this.lblStats.AutoSize = true;
            this.lblStats.Location = new System.Drawing.Point(12, 578);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(178, 19);
            this.lblStats.TabIndex = 2;
            this.lblStats.Text = "Wins: 0 (0 Crowns) | Losses: 0";
            // 
            // btn_styleBlu
            // 
            this.btn_styleBlu.ActiveControl = null;
            this.btn_styleBlu.Location = new System.Drawing.Point(10, 30);
            this.btn_styleBlu.Name = "btn_styleBlu";
            this.btn_styleBlu.Size = new System.Drawing.Size(150, 43);
            this.btn_styleBlu.Style = MetroFramework.MetroColorStyle.Blue;
            this.btn_styleBlu.TabIndex = 1;
            this.btn_styleBlu.Text = "Blue";
            this.btn_styleBlu.UseSelectable = true;
            this.btn_styleBlu.Click += new System.EventHandler(this.btn_styleBlu_Click);
            // 
            // lbl_style
            // 
            this.lbl_style.AutoSize = true;
            this.lbl_style.Location = new System.Drawing.Point(10, 5);
            this.lbl_style.Name = "lbl_style";
            this.lbl_style.Size = new System.Drawing.Size(91, 19);
            this.lbl_style.TabIndex = 1;
            this.lbl_style.Text = "Choose color:";
            // 
            // btn_styleRed
            // 
            this.btn_styleRed.ActiveControl = null;
            this.btn_styleRed.Location = new System.Drawing.Point(10, 80);
            this.btn_styleRed.Name = "btn_styleRed";
            this.btn_styleRed.Size = new System.Drawing.Size(150, 43);
            this.btn_styleRed.Style = MetroFramework.MetroColorStyle.Red;
            this.btn_styleRed.TabIndex = 2;
            this.btn_styleRed.Text = "Red";
            this.btn_styleRed.UseSelectable = true;
            this.btn_styleRed.Click += new System.EventHandler(this.btn_styleRed_Click);
            // 
            // btn_styleBlack
            // 
            this.btn_styleBlack.ActiveControl = null;
            this.btn_styleBlack.Location = new System.Drawing.Point(10, 130);
            this.btn_styleBlack.Name = "btn_styleBlack";
            this.btn_styleBlack.Size = new System.Drawing.Size(150, 43);
            this.btn_styleBlack.Style = MetroFramework.MetroColorStyle.Black;
            this.btn_styleBlack.TabIndex = 3;
            this.btn_styleBlack.Text = "Black";
            this.btn_styleBlack.UseSelectable = true;
            this.btn_styleBlack.Click += new System.EventHandler(this.btn_styleBlack_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 605);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabMain);
            this.Name = "frmMain";
            this.Text = "CATSBot | catsbot.net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private MetroFramework.Controls.MetroCheckBox chkUseSidebar;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroTile btnStart;
        public MetroFramework.Controls.MetroLabel lblStats;
        public System.Windows.Forms.TextBox txtLog;
        private MetroFramework.Controls.MetroLabel lbl_style;
        private MetroFramework.Controls.MetroTile btn_styleBlu;
        private MetroFramework.Controls.MetroTile btn_styleBlack;
        private MetroFramework.Controls.MetroTile btn_styleRed;
    }
}
