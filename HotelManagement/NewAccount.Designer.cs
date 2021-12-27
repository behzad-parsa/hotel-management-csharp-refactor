namespace HotelManagement
{
    partial class NewAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAccount));
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.panelCustStatus = new System.Windows.Forms.Panel();
            this.lblCustError = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.prgbCustError = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panelCustLeft = new System.Windows.Forms.Panel();
            this.txtDescription = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBalance = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtAccountNumber = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtBank = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtAccountName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelCustStatus.SuspendLayout();
            this.panelCustLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(194)))), ((int)(((byte)(169)))));
            this.panelTop.Controls.Add(this.pictureBox2);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.bunifuCustomLabel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(488, 62);
            this.panelTop.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::HotelManagement.Properties.Resources._296812_48;
            this.pictureBox2.Location = new System.Drawing.Point(431, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagement.Properties.Resources._392530_48;
            this.pictureBox1.Location = new System.Drawing.Point(23, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Abel", 13F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(78, 17);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(121, 28);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "New Account";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.panelCustStatus);
            this.panel2.Controls.Add(this.panelCustLeft);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 579);
            this.panel2.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(194)))), ((int)(((byte)(169)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Helvetica World", 9F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(344, 501);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(127, 46);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Submit";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelCustStatus
            // 
            this.panelCustStatus.Controls.Add(this.lblCustError);
            this.panelCustStatus.Controls.Add(this.prgbCustError);
            this.panelCustStatus.Location = new System.Drawing.Point(31, 501);
            this.panelCustStatus.Name = "panelCustStatus";
            this.panelCustStatus.Size = new System.Drawing.Size(311, 49);
            this.panelCustStatus.TabIndex = 19;
            this.panelCustStatus.Visible = false;
            // 
            // lblCustError
            // 
            this.lblCustError.AutoEllipsis = true;
            this.lblCustError.AutoSize = true;
            this.lblCustError.Font = new System.Drawing.Font("Leelawadee UI", 9F);
            this.lblCustError.ForeColor = System.Drawing.Color.Red;
            this.lblCustError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustError.Location = new System.Drawing.Point(42, 15);
            this.lblCustError.Name = "lblCustError";
            this.lblCustError.Size = new System.Drawing.Size(41, 20);
            this.lblCustError.TabIndex = 16;
            this.lblCustError.Text = "Error";
            // 
            // prgbCustError
            // 
            this.prgbCustError.animated = false;
            this.prgbCustError.animationIterval = 5;
            this.prgbCustError.animationSpeed = 300;
            this.prgbCustError.BackColor = System.Drawing.Color.White;
            this.prgbCustError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prgbCustError.BackgroundImage")));
            this.prgbCustError.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.prgbCustError.ForeColor = System.Drawing.Color.SeaGreen;
            this.prgbCustError.LabelVisible = false;
            this.prgbCustError.LineProgressThickness = 3;
            this.prgbCustError.LineThickness = 3;
            this.prgbCustError.Location = new System.Drawing.Point(-3, 5);
            this.prgbCustError.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.prgbCustError.MaxValue = 100;
            this.prgbCustError.Name = "prgbCustError";
            this.prgbCustError.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.prgbCustError.ProgressColor = System.Drawing.Color.Red;
            this.prgbCustError.Size = new System.Drawing.Size(38, 38);
            this.prgbCustError.TabIndex = 15;
            this.prgbCustError.Value = 100;
            // 
            // panelCustLeft
            // 
            this.panelCustLeft.Controls.Add(this.txtDescription);
            this.panelCustLeft.Controls.Add(this.txtBalance);
            this.panelCustLeft.Controls.Add(this.txtAccountNumber);
            this.panelCustLeft.Controls.Add(this.txtBank);
            this.panelCustLeft.Controls.Add(this.txtAccountName);
            this.panelCustLeft.Location = new System.Drawing.Point(27, 10);
            this.panelCustLeft.Name = "panelCustLeft";
            this.panelCustLeft.Size = new System.Drawing.Size(439, 487);
            this.panelCustLeft.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtDescription.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtDescription.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtDescription.BorderThickness = 1;
            this.txtDescription.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtDescription.isPassword = false;
            this.txtDescription.Location = new System.Drawing.Point(6, 349);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(429, 128);
            this.txtDescription.TabIndex = 4;
            this.txtDescription.Text = "Description";
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Enter += new System.EventHandler(this.TextBoxEnter);
            this.txtDescription.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // txtBalance
            // 
            this.txtBalance.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBalance.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtBalance.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBalance.BorderThickness = 1;
            this.txtBalance.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBalance.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBalance.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtBalance.ForeColor = System.Drawing.Color.Gray;
            this.txtBalance.isPassword = false;
            this.txtBalance.Location = new System.Drawing.Point(6, 261);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(4);
            this.txtBalance.MaxLength = 32767;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(429, 43);
            this.txtBalance.TabIndex = 3;
            this.txtBalance.Text = "Balance";
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBalance.OnValueChanged += new System.EventHandler(this.txtBalance_OnValueChanged);
            this.txtBalance.Enter += new System.EventHandler(this.TextBoxEnter);
            this.txtBalance.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtAccountNumber.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtAccountNumber.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtAccountNumber.BorderThickness = 1;
            this.txtAccountNumber.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAccountNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccountNumber.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtAccountNumber.ForeColor = System.Drawing.Color.Gray;
            this.txtAccountNumber.isPassword = false;
            this.txtAccountNumber.Location = new System.Drawing.Point(6, 180);
            this.txtAccountNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountNumber.MaxLength = 32767;
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(429, 43);
            this.txtAccountNumber.TabIndex = 2;
            this.txtAccountNumber.Text = "Account Number";
            this.txtAccountNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAccountNumber.Enter += new System.EventHandler(this.TextBoxEnter);
            this.txtAccountNumber.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // txtBank
            // 
            this.txtBank.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtBank.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtBank.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtBank.BorderThickness = 1;
            this.txtBank.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBank.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBank.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtBank.ForeColor = System.Drawing.Color.Gray;
            this.txtBank.isPassword = false;
            this.txtBank.Location = new System.Drawing.Point(6, 99);
            this.txtBank.Margin = new System.Windows.Forms.Padding(4);
            this.txtBank.MaxLength = 32767;
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(429, 43);
            this.txtBank.TabIndex = 1;
            this.txtBank.Text = "Bank";
            this.txtBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBank.Enter += new System.EventHandler(this.TextBoxEnter);
            this.txtBank.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // txtAccountName
            // 
            this.txtAccountName.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtAccountName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtAccountName.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtAccountName.BorderThickness = 1;
            this.txtAccountName.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAccountName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAccountName.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtAccountName.ForeColor = System.Drawing.Color.Gray;
            this.txtAccountName.isPassword = false;
            this.txtAccountName.Location = new System.Drawing.Point(8, 18);
            this.txtAccountName.Margin = new System.Windows.Forms.Padding(4);
            this.txtAccountName.MaxLength = 32767;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(427, 43);
            this.txtAccountName.TabIndex = 0;
            this.txtAccountName.Text = "Account Name";
            this.txtAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAccountName.Enter += new System.EventHandler(this.TextBoxEnter);
            this.txtAccountName.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelTop;
            this.bunifuDragControl1.Vertical = true;
            // 
            // NewAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 641);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewAccount";
            this.Load += new System.EventHandler(this.NewAccount_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelCustStatus.ResumeLayout(false);
            this.panelCustStatus.PerformLayout();
            this.panelCustLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panelCustLeft;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBank;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAccountName;
        private System.Windows.Forms.Panel panelCustStatus;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCustError;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgbCustError;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtDescription;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtBalance;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAccountNumber;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnOk;
    }
}