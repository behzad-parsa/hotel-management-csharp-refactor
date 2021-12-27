namespace HotelManagement
{
    partial class ActionSerivce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionSerivce));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDecription = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtPrice = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtTitle = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelCustStatus = new System.Windows.Forms.Panel();
            this.lblCustError = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.prgbCustError = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelCustStatus.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.panelCustStatus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 324);
            this.panel2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDecription);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.bunifuCustomLabel3);
            this.panel1.Controls.Add(this.bunifuCustomLabel8);
            this.panel1.Location = new System.Drawing.Point(23, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 238);
            this.panel1.TabIndex = 22;
            // 
            // txtDecription
            // 
            this.txtDecription.AutoSize = true;
            this.txtDecription.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtDecription.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtDecription.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtDecription.BorderThickness = 1;
            this.txtDecription.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDecription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDecription.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtDecription.ForeColor = System.Drawing.Color.Gray;
            this.txtDecription.isPassword = false;
            this.txtDecription.Location = new System.Drawing.Point(138, 151);
            this.txtDecription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDecription.MaxLength = 32767;
            this.txtDecription.Name = "txtDecription";
            this.txtDecription.Size = new System.Drawing.Size(250, 65);
            this.txtDecription.TabIndex = 2;
            this.txtDecription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDecription.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // txtPrice
            // 
            this.txtPrice.AutoSize = true;
            this.txtPrice.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtPrice.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtPrice.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtPrice.BorderThickness = 1;
            this.txtPrice.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtPrice.ForeColor = System.Drawing.Color.Gray;
            this.txtPrice.isPassword = false;
            this.txtPrice.Location = new System.Drawing.Point(138, 85);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrice.MaxLength = 32767;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(250, 37);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrice.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(9, 155);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(92, 20);
            this.bunifuCustomLabel2.TabIndex = 5;
            this.bunifuCustomLabel2.Text = "Description :";
            this.bunifuCustomLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTitle
            // 
            this.txtTitle.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtTitle.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtTitle.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtTitle.BorderThickness = 1;
            this.txtTitle.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtTitle.isPassword = false;
            this.txtTitle.Location = new System.Drawing.Point(138, 20);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.MaxLength = 32767;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(250, 36);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTitle.Enter += new System.EventHandler(this.TextBoxEnter);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(9, 90);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(49, 20);
            this.bunifuCustomLabel3.TabIndex = 5;
            this.bunifuCustomLabel3.Text = "Price :";
            this.bunifuCustomLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(9, 25);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(44, 20);
            this.bunifuCustomLabel8.TabIndex = 6;
            this.bunifuCustomLabel8.Text = "Title :";
            this.bunifuCustomLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Helvetica World", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(305, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 45);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelCustStatus
            // 
            this.panelCustStatus.Controls.Add(this.lblCustError);
            this.panelCustStatus.Controls.Add(this.prgbCustError);
            this.panelCustStatus.Location = new System.Drawing.Point(24, 245);
            this.panelCustStatus.Name = "panelCustStatus";
            this.panelCustStatus.Size = new System.Drawing.Size(275, 51);
            this.panelCustStatus.TabIndex = 19;
            this.panelCustStatus.Visible = false;
            // 
            // lblCustError
            // 
            this.lblCustError.AutoEllipsis = true;
            this.lblCustError.AutoSize = true;
            this.lblCustError.Font = new System.Drawing.Font("Leelawadee UI", 8F);
            this.lblCustError.ForeColor = System.Drawing.Color.Red;
            this.lblCustError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustError.Location = new System.Drawing.Point(44, 15);
            this.lblCustError.Name = "lblCustError";
            this.lblCustError.Size = new System.Drawing.Size(177, 19);
            this.lblCustError.TabIndex = 16;
            this.lblCustError.Text = "Unable To Complete Action";
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
            this.prgbCustError.Location = new System.Drawing.Point(2, 6);
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
            this.panelTop.Controls.Add(this.picIcon);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(433, 60);
            this.panelTop.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::HotelManagement.Properties.Resources._296812_48;
            this.pictureBox2.Location = new System.Drawing.Point(386, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // picIcon
            // 
            this.picIcon.Image = global::HotelManagement.Properties.Resources._326602_32;
            this.picIcon.Location = new System.Drawing.Point(25, 15);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(30, 30);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Abel", 13F);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(69, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(46, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelTop;
            this.bunifuDragControl1.Vertical = true;
            // 
            // ActionSerivce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(433, 384);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActionSerivce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ActionSerivce";
            this.Load += new System.EventHandler(this.ActionSerivce_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelCustStatus.ResumeLayout(false);
            this.panelCustStatus.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtDecription;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtPrice;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtTitle;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelCustStatus;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCustError;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgbCustError;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picIcon;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTitle;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}