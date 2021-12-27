namespace HotelManagement
{
    partial class PayDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayDialog));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.gradientPanel1 = new HotelManagement.GradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblAmountPay = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblStatus = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblCustomerName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnPay = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtDescription = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtTransNum = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panelPaymentMethod = new System.Windows.Forms.Panel();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel7 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.gradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.gradientPanel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.ColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(66)))), ((int)(((byte)(68)))));
            this.gradientPanel1.ColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(40)))), ((int)(((byte)(60)))));
            this.gradientPanel1.Controls.Add(this.panel1);
            this.gradientPanel1.Controls.Add(this.lblAmountPay);
            this.gradientPanel1.Controls.Add(this.lblStatus);
            this.gradientPanel1.Controls.Add(this.lblCustomerName);
            this.gradientPanel1.Controls.Add(this.bunifuCustomLabel1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(305, 670);
            this.gradientPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.bunifuCustomLabel3);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(52, 611);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 47);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagement.Properties.Resources.leftArrow;
            this.pictureBox1.Location = new System.Drawing.Point(14, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Poppins Thin", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(50, 11);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(132, 26);
            this.bunifuCustomLabel3.TabIndex = 0;
            this.bunifuCustomLabel3.Text = "Cancel Payment";
            this.bunifuCustomLabel3.Click += new System.EventHandler(this.panel1_Click);
            // 
            // lblAmountPay
            // 
            this.lblAmountPay.BackColor = System.Drawing.Color.Transparent;
            this.lblAmountPay.Font = new System.Drawing.Font("Microsoft YaHei Light", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountPay.ForeColor = System.Drawing.Color.White;
            this.lblAmountPay.Location = new System.Drawing.Point(60, 297);
            this.lblAmountPay.Name = "lblAmountPay";
            this.lblAmountPay.Size = new System.Drawing.Size(174, 40);
            this.lblAmountPay.TabIndex = 0;
            this.lblAmountPay.Text = "3500000";
            this.lblAmountPay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Yu Gothic UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblStatus.ForeColor = System.Drawing.Color.SpringGreen;
            this.lblStatus.Location = new System.Drawing.Point(50, 493);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(202, 42);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Successful";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomerName.Font = new System.Drawing.Font("Yu Gothic UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.White;
            this.lblCustomerName.Location = new System.Drawing.Point(50, 153);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(202, 52);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Advent Pro", 12F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(58, 262);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(176, 23);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Pay";
            this.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.txtTransNum);
            this.panel2.Controls.Add(this.panelPaymentMethod);
            this.panel2.Controls.Add(this.cmbAccount);
            this.panel2.Controls.Add(this.bunifuCustomLabel4);
            this.panel2.Controls.Add(this.bunifuCustomLabel9);
            this.panel2.Controls.Add(this.bunifuCustomLabel8);
            this.panel2.Controls.Add(this.bunifuCustomLabel7);
            this.panel2.Controls.Add(this.bunifuCustomLabel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(305, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 670);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotelManagement.Properties.Resources.credit_card;
            this.pictureBox2.Location = new System.Drawing.Point(23, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnPay
            // 
            this.btnPay.ActiveBorderThickness = 1;
            this.btnPay.ActiveCornerRadius = 20;
            this.btnPay.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnPay.ActiveForecolor = System.Drawing.Color.White;
            this.btnPay.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnPay.BackColor = System.Drawing.Color.White;
            this.btnPay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPay.BackgroundImage")));
            this.btnPay.ButtonText = "Pay";
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnPay.IdleBorderThickness = 1;
            this.btnPay.IdleCornerRadius = 20;
            this.btnPay.IdleFillColor = System.Drawing.Color.White;
            this.btnPay.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnPay.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnPay.Location = new System.Drawing.Point(161, 596);
            this.btnPay.Margin = new System.Windows.Forms.Padding(5);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(181, 51);
            this.btnPay.TabIndex = 4;
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
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
            this.txtDescription.Location = new System.Drawing.Point(190, 400);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(277, 135);
            this.txtDescription.TabIndex = 3;
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
            this.txtTransNum.Location = new System.Drawing.Point(190, 327);
            this.txtTransNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtTransNum.MaxLength = 32767;
            this.txtTransNum.Name = "txtTransNum";
            this.txtTransNum.Size = new System.Drawing.Size(277, 36);
            this.txtTransNum.TabIndex = 3;
            this.txtTransNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panelPaymentMethod
            // 
            this.panelPaymentMethod.Location = new System.Drawing.Point(174, 201);
            this.panelPaymentMethod.Name = "panelPaymentMethod";
            this.panelPaymentMethod.Size = new System.Drawing.Size(293, 84);
            this.panelPaymentMethod.TabIndex = 2;
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(174, 123);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(293, 24);
            this.cmbAccount.TabIndex = 1;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(79, 15);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(266, 45);
            this.bunifuCustomLabel4.TabIndex = 0;
            this.bunifuCustomLabel4.Text = "Payments";
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel9.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(38, 393);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(135, 36);
            this.bunifuCustomLabel9.TabIndex = 0;
            this.bunifuCustomLabel9.Text = "Description :";
            this.bunifuCustomLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(33, 327);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(158, 36);
            this.bunifuCustomLabel8.TabIndex = 0;
            this.bunifuCustomLabel8.Text = "Transactio Number :";
            this.bunifuCustomLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCustomLabel7
            // 
            this.bunifuCustomLabel7.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel7.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel7.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel7.Location = new System.Drawing.Point(33, 201);
            this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
            this.bunifuCustomLabel7.Size = new System.Drawing.Size(135, 23);
            this.bunifuCustomLabel7.TabIndex = 0;
            this.bunifuCustomLabel7.Text = "Payment Method :";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel5.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(33, 123);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(135, 23);
            this.bunifuCustomLabel5.TabIndex = 0;
            this.bunifuCustomLabel5.Text = "Account :";
            // 
            // PayDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 670);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PayDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PayDialog";
            this.Load += new System.EventHandler(this.PayDialog_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panel2;
        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel lblAmountPay;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCustomerName;
        private System.Windows.Forms.Panel panelPaymentMethod;
        private System.Windows.Forms.ComboBox cmbAccount;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtDescription;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtTransNum;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuThinButton2 btnPay;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel lblStatus;
    }
}