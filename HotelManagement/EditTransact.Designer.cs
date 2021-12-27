namespace HotelManagement
{
    partial class EditTransact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTransact));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAmount = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtDescription = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtTransNum = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panelType = new System.Windows.Forms.Panel();
            this.panelPaymentMethod = new System.Windows.Forms.Panel();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnOk = new System.Windows.Forms.Button();
            this.panelCustStatus = new System.Windows.Forms.Panel();
            this.lblCustError = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.prgbCustError = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelCustStatus.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.panelCustStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 573);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtTransNum);
            this.panel1.Controls.Add(this.panelType);
            this.panel1.Controls.Add(this.panelPaymentMethod);
            this.panel1.Controls.Add(this.cmbAccount);
            this.panel1.Controls.Add(this.bunifuCustomLabel3);
            this.panel1.Controls.Add(this.bunifuCustomLabel9);
            this.panel1.Controls.Add(this.bunifuCustomLabel8);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Controls.Add(this.bunifuCustomLabel7);
            this.panel1.Controls.Add(this.bunifuCustomLabel5);
            this.panel1.Location = new System.Drawing.Point(32, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 497);
            this.panel1.TabIndex = 22;
            // 
            // txtAmount
            // 
            this.txtAmount.AutoSize = true;
            this.txtAmount.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtAmount.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtAmount.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtAmount.BorderThickness = 1;
            this.txtAmount.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmount.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtAmount.ForeColor = System.Drawing.Color.Gray;
            this.txtAmount.isPassword = false;
            this.txtAmount.Location = new System.Drawing.Point(187, 314);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAmount.MaxLength = 32767;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(304, 37);
            this.txtAmount.TabIndex = 11;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtDescription.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtDescription.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtDescription.BorderThickness = 1;
            this.txtDescription.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtDescription.isPassword = false;
            this.txtDescription.Location = new System.Drawing.Point(187, 387);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(304, 94);
            this.txtDescription.TabIndex = 11;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtTransNum
            // 
            this.txtTransNum.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtTransNum.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtTransNum.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtTransNum.BorderThickness = 1;
            this.txtTransNum.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTransNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTransNum.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtTransNum.ForeColor = System.Drawing.Color.Gray;
            this.txtTransNum.isPassword = false;
            this.txtTransNum.Location = new System.Drawing.Point(187, 244);
            this.txtTransNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransNum.MaxLength = 32767;
            this.txtTransNum.Name = "txtTransNum";
            this.txtTransNum.Size = new System.Drawing.Size(304, 36);
            this.txtTransNum.TabIndex = 12;
            this.txtTransNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panelType
            // 
            this.panelType.Font = new System.Drawing.Font("Leelawadee UI", 8F);
            this.panelType.Location = new System.Drawing.Point(187, 26);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(304, 65);
            this.panelType.TabIndex = 10;
            // 
            // panelPaymentMethod
            // 
            this.panelPaymentMethod.Font = new System.Drawing.Font("Leelawadee UI", 8F);
            this.panelPaymentMethod.Location = new System.Drawing.Point(187, 156);
            this.panelPaymentMethod.Name = "panelPaymentMethod";
            this.panelPaymentMethod.Size = new System.Drawing.Size(304, 65);
            this.panelPaymentMethod.TabIndex = 10;
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(187, 109);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(304, 24);
            this.cmbAccount.TabIndex = 9;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(84, 314);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(81, 23);
            this.bunifuCustomLabel3.TabIndex = 5;
            this.bunifuCustomLabel3.Text = "Amount :";
            this.bunifuCustomLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(61, 387);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(104, 23);
            this.bunifuCustomLabel9.TabIndex = 5;
            this.bunifuCustomLabel9.Text = "Description :";
            this.bunifuCustomLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(1, 244);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(164, 23);
            this.bunifuCustomLabel8.TabIndex = 6;
            this.bunifuCustomLabel8.Text = "Transactio Number :";
            this.bunifuCustomLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(105, 26);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(60, 23);
            this.bunifuCustomLabel2.TabIndex = 7;
            this.bunifuCustomLabel2.Text = "Type : ";
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.AutoSize = true;
            this.bunifuCustomLabel7.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(16, 156);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(149, 23);
            this.bunifuCustomLabel7.TabIndex = 7;
            this.bunifuCustomLabel7.Text = "Payment Method :";
            this.bunifuCustomLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(83, 107);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(82, 23);
            this.bunifuCustomLabel5.TabIndex = 8;
            this.bunifuCustomLabel5.Text = "Account :";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Helvetica World", 9F, System.Drawing.FontStyle.Bold);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(385, 508);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(142, 43);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelCustStatus
            // 
            this.panelCustStatus.Controls.Add(this.lblCustError);
            this.panelCustStatus.Controls.Add(this.prgbCustError);
            this.panelCustStatus.Location = new System.Drawing.Point(33, 509);
            this.panelCustStatus.Name = "panelCustStatus";
            this.panelCustStatus.Size = new System.Drawing.Size(346, 42);
            this.panelCustStatus.TabIndex = 19;
            this.panelCustStatus.Visible = false;
            // 
            // lblCustError
            // 
            this.lblCustError.AutoSize = true;
            this.lblCustError.Font = new System.Drawing.Font("Leelawadee UI", 9F);
            this.lblCustError.ForeColor = System.Drawing.Color.Red;
            this.lblCustError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustError.Location = new System.Drawing.Point(58, 10);
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
            this.prgbCustError.Location = new System.Drawing.Point(10, 1);
            this.prgbCustError.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.prgbCustError.MaxValue = 100;
            this.prgbCustError.Name = "prgbCustError";
            this.prgbCustError.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.prgbCustError.ProgressColor = System.Drawing.Color.Red;
            this.prgbCustError.Size = new System.Drawing.Size(38, 38);
            this.prgbCustError.TabIndex = 15;
            this.prgbCustError.Value = 100;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelTop.Controls.Add(this.pictureBox2);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.bunifuCustomLabel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(550, 63);
            this.panelTop.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::HotelManagement.Properties.Resources._296812_48;
            this.pictureBox2.Location = new System.Drawing.Point(494, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagement.Properties.Resources._326602_32;
            this.pictureBox1.Location = new System.Drawing.Point(32, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Abel", 13F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(78, 18);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(46, 28);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Edit";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelTop;
            this.bunifuDragControl1.Vertical = true;
            // 
            // EditTransact
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 636);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditTransact";
            this.Text = "EditTransact";
            this.Load += new System.EventHandler(this.EditTransact_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCustStatus.ResumeLayout(false);
            this.panelCustStatus.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panelCustStatus;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCustError;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgbCustError;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtAmount;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtTransNum;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtDescription;
        private System.Windows.Forms.Panel panelType;
        private System.Windows.Forms.Panel panelPaymentMethod;
        private System.Windows.Forms.ComboBox cmbAccount;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
    }
}