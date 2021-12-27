namespace HotelManagement
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPower = new System.Windows.Forms.PictureBox();
            this.pictureEye = new System.Windows.Forms.PictureBox();
            this.txtPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtUsername = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblErrorLogin = new System.Windows.Forms.Label();
            this.lblForgotPass = new System.Windows.Forms.Label();
            this.btnLogin = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.prgWaiting = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.btnCheck = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtForgotEmail = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.labelHeader = new System.Windows.Forms.Label();
            this.LblErrorFrogot = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pictureLock = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEye)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPower);
            this.panel1.Controls.Add(this.pictureEye);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.lblErrorLogin);
            this.panel1.Controls.Add(this.lblForgotPass);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 399);
            this.panel1.TabIndex = 0;
            // 
            // btnPower
            // 
            this.btnPower.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPower.Image = global::HotelManagement.Properties.Resources.powerB;
            this.btnPower.Location = new System.Drawing.Point(12, 346);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(32, 41);
            this.btnPower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPower.TabIndex = 3;
            this.btnPower.TabStop = false;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // pictureEye
            // 
            this.pictureEye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureEye.Image = global::HotelManagement.Properties.Resources.Eye;
            this.pictureEye.Location = new System.Drawing.Point(339, 115);
            this.pictureEye.Name = "pictureEye";
            this.pictureEye.Size = new System.Drawing.Size(32, 32);
            this.pictureEye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureEye.TabIndex = 5;
            this.pictureEye.TabStop = false;
            this.pictureEye.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft JhengHei Light", 10.2F);
            this.txtPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.HintForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.HintText = "Password";
            this.txtPassword.isPassword = true;
            this.txtPassword.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.txtPassword.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txtPassword.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.txtPassword.LineThickness = 1;
            this.txtPassword.Location = new System.Drawing.Point(66, 108);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(306, 43);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.OnValueChanged += new System.EventHandler(this.txtPassword_OnValueChanged);
            this.txtPassword.Enter += new System.EventHandler(this.TextBoxes_Enter);
            // 
            // txtUsername
            // 
            this.txtUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUsername.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft JhengHei Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.Black;
            this.txtUsername.HintForeColor = System.Drawing.Color.DarkGray;
            this.txtUsername.HintText = "Username";
            this.txtUsername.isPassword = false;
            this.txtUsername.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.txtUsername.LineIdleColor = System.Drawing.Color.DarkGray;
            this.txtUsername.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.txtUsername.LineThickness = 1;
            this.txtUsername.Location = new System.Drawing.Point(66, 16);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(306, 46);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.OnValueChanged += new System.EventHandler(this.txtUsername_OnValueChanged);
            this.txtUsername.Enter += new System.EventHandler(this.TextBoxes_Enter);
            // 
            // lblErrorLogin
            // 
            this.lblErrorLogin.AutoSize = true;
            this.lblErrorLogin.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblErrorLogin.Font = new System.Drawing.Font("Helvetica World", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblErrorLogin.ForeColor = System.Drawing.Color.Red;
            this.lblErrorLogin.Location = new System.Drawing.Point(61, 172);
            this.lblErrorLogin.Name = "lblErrorLogin";
            this.lblErrorLogin.Size = new System.Drawing.Size(45, 27);
            this.lblErrorLogin.TabIndex = 3;
            this.lblErrorLogin.Text = "Error";
            this.lblErrorLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorLogin.Visible = false;
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblForgotPass.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this.lblForgotPass.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblForgotPass.Location = new System.Drawing.Point(116, 338);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(182, 26);
            this.lblForgotPass.TabIndex = 3;
            this.lblForgotPass.Text = "Forgot The Password ?";
            this.lblForgotPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblForgotPass.Click += new System.EventHandler(this.LblCLickMethod);
            // 
            // btnLogin
            // 
            this.btnLogin.ActiveBorderThickness = 1;
            this.btnLogin.ActiveCornerRadius = 30;
            this.btnLogin.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnLogin.ActiveForecolor = System.Drawing.Color.White;
            this.btnLogin.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.ButtonText = "Login";
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnLogin.IdleBorderThickness = 1;
            this.btnLogin.IdleCornerRadius = 30;
            this.btnLogin.IdleFillColor = System.Drawing.Color.White;
            this.btnLogin.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnLogin.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnLogin.Location = new System.Drawing.Point(66, 225);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(282, 62);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Controls.Add(this.prgWaiting);
            this.panel2.Controls.Add(this.btnCheck);
            this.panel2.Controls.Add(this.txtForgotEmail);
            this.panel2.Controls.Add(this.lblLogin);
            this.panel2.Controls.Add(this.labelHeader);
            this.panel2.Controls.Add(this.LblErrorFrogot);
            this.panel2.Location = new System.Drawing.Point(427, 304);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(440, 399);
            this.panel2.TabIndex = 0;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Yu Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.Azure;
            this.lblTime.Location = new System.Drawing.Point(278, 52);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(80, 22);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "00:09:00";
            this.lblTime.Visible = false;
            // 
            // prgWaiting
            // 
            this.prgWaiting.animated = true;
            this.prgWaiting.animationIterval = 15;
            this.prgWaiting.animationSpeed = 10;
            this.prgWaiting.BackColor = System.Drawing.Color.Transparent;
            this.prgWaiting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prgWaiting.BackgroundImage")));
            this.prgWaiting.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.prgWaiting.ForeColor = System.Drawing.Color.SeaGreen;
            this.prgWaiting.LabelVisible = false;
            this.prgWaiting.LineProgressThickness = 2;
            this.prgWaiting.LineThickness = 3;
            this.prgWaiting.Location = new System.Drawing.Point(23, 115);
            this.prgWaiting.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.prgWaiting.MaxValue = 100;
            this.prgWaiting.Name = "prgWaiting";
            this.prgWaiting.ProgressBackColor = System.Drawing.Color.AliceBlue;
            this.prgWaiting.ProgressColor = System.Drawing.Color.DeepSkyBlue;
            this.prgWaiting.Size = new System.Drawing.Size(48, 48);
            this.prgWaiting.TabIndex = 3;
            this.prgWaiting.Value = 55;
            this.prgWaiting.Visible = false;
            // 
            // btnCheck
            // 
            this.btnCheck.ActiveBorderThickness = 1;
            this.btnCheck.ActiveCornerRadius = 30;
            this.btnCheck.ActiveFillColor = System.Drawing.Color.White;
            this.btnCheck.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnCheck.ActiveLineColor = System.Drawing.Color.White;
            this.btnCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnCheck.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCheck.BackgroundImage")));
            this.btnCheck.ButtonText = "Check";
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCheck.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnCheck.IdleBorderThickness = 1;
            this.btnCheck.IdleCornerRadius = 30;
            this.btnCheck.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.btnCheck.IdleForecolor = System.Drawing.Color.White;
            this.btnCheck.IdleLineColor = System.Drawing.Color.White;
            this.btnCheck.Location = new System.Drawing.Point(75, 233);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(283, 58);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtForgotEmail
            // 
            this.txtForgotEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtForgotEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtForgotEmail.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtForgotEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtForgotEmail.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtForgotEmail.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtForgotEmail.HintForeColor = System.Drawing.Color.White;
            this.txtForgotEmail.HintText = "Email";
            this.txtForgotEmail.isPassword = false;
            this.txtForgotEmail.LineFocusedColor = System.Drawing.Color.White;
            this.txtForgotEmail.LineIdleColor = System.Drawing.Color.White;
            this.txtForgotEmail.LineMouseHoverColor = System.Drawing.Color.White;
            this.txtForgotEmail.LineThickness = 1;
            this.txtForgotEmail.Location = new System.Drawing.Point(74, 115);
            this.txtForgotEmail.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txtForgotEmail.MaxLength = 32767;
            this.txtForgotEmail.Name = "txtForgotEmail";
            this.txtForgotEmail.Size = new System.Drawing.Size(284, 45);
            this.txtForgotEmail.TabIndex = 0;
            this.txtForgotEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtForgotEmail.OnValueChanged += new System.EventHandler(this.txtForgotEmail_OnValueChanged);
            // 
            // lblLogin
            // 
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.Location = new System.Drawing.Point(173, 338);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(90, 26);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogin.Click += new System.EventHandler(this.LblCLickMethod);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelHeader.Font = new System.Drawing.Font("Yu Gothic", 10.2F, System.Drawing.FontStyle.Bold);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(54, 52);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(160, 22);
            this.labelHeader.TabIndex = 3;
            this.labelHeader.Text = "Enter Your Email :";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelHeader.Click += new System.EventHandler(this.LblCLickMethod);
            // 
            // LblErrorFrogot
            // 
            this.LblErrorFrogot.AutoSize = true;
            this.LblErrorFrogot.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LblErrorFrogot.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9F);
            this.LblErrorFrogot.ForeColor = System.Drawing.Color.Brown;
            this.LblErrorFrogot.Location = new System.Drawing.Point(72, 187);
            this.LblErrorFrogot.Name = "LblErrorFrogot";
            this.LblErrorFrogot.Size = new System.Drawing.Size(162, 20);
            this.LblErrorFrogot.TabIndex = 3;
            this.LblErrorFrogot.Text = "Forgot The Password ?";
            this.LblErrorFrogot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblErrorFrogot.Visible = false;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(239)))));
            this.bunifuSeparator1.LineThickness = 2;
            this.bunifuSeparator1.Location = new System.Drawing.Point(66, 16);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(140, 6);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator2.LineThickness = 2;
            this.bunifuSeparator2.Location = new System.Drawing.Point(208, 16);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(140, 6);
            this.bunifuSeparator2.TabIndex = 1;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // pictureLock
            // 
            this.pictureLock.Image = global::HotelManagement.Properties.Resources.login;
            this.pictureLock.Location = new System.Drawing.Point(120, 62);
            this.pictureLock.Name = "pictureLock";
            this.pictureLock.Size = new System.Drawing.Size(178, 173);
            this.pictureLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLock.TabIndex = 2;
            this.pictureLock.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(853, 703);
            this.Controls.Add(this.pictureLock);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEye)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.PictureBox pictureLock;
        private Bunifu.Framework.UI.BunifuThinButton2 btnLogin;
        private System.Windows.Forms.Label lblForgotPass;
        private System.Windows.Forms.Label lblLogin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUsername;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPassword;
        private System.Windows.Forms.PictureBox pictureEye;
        private System.Windows.Forms.Label lblErrorLogin;
        private Bunifu.Framework.UI.BunifuThinButton2 btnCheck;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtForgotEmail;
        private System.Windows.Forms.Label LblErrorFrogot;
        private System.Windows.Forms.Label labelHeader;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgWaiting;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTime;
        private System.Windows.Forms.PictureBox btnPower;
    }
}

