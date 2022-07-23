namespace HotelManagement
{
    partial class frmMain
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelTop = new HotelManagement.GradientPanel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblBranchName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTopName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnPower = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnSize = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnLogout = new Bunifu.Framework.UI.BunifuImageButton();
            this.picProfileTop = new HotelManagement.CirclePictureBox();
            this.panelLeftSlide = new HotelManagement.GradientPanel();
            this.gradientPanel1 = new HotelManagement.GradientPanel();
            this.btnSlideMenu = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnSetting = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBranch = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMessage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnUser = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnService = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAccounting = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRoom = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBooking = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelSide = new HotelManagement.GradientPanel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfileTop)).BeginInit();
            this.panelLeftSlide.SuspendLayout();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlideMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(70, 70);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1836, 967);
            this.panelContainer.TabIndex = 6;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.panelTop.ColorLeft = System.Drawing.Color.Empty;
            this.panelTop.ColorRight = System.Drawing.Color.Empty;
            this.panelTop.Controls.Add(this.bunifuSeparator1);
            this.panelTop.Controls.Add(this.lblBranchName);
            this.panelTop.Controls.Add(this.lblTopName);
            this.panelTop.Controls.Add(this.btnPower);
            this.panelTop.Controls.Add(this.btnSize);
            this.panelTop.Controls.Add(this.btnLogout);
            this.panelTop.Controls.Add(this.picProfileTop);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(70, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1836, 70);
            this.panelTop.TabIndex = 5;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(1609, 13);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(10, 44);
            this.bunifuSeparator1.TabIndex = 0;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            // 
            // lblBranchName
            // 
            this.lblBranchName.AutoSize = true;
            this.lblBranchName.Font = new System.Drawing.Font("ONE DAY", 12F);
            this.lblBranchName.ForeColor = System.Drawing.Color.White;
            this.lblBranchName.Location = new System.Drawing.Point(36, 26);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(117, 16);
            this.lblBranchName.TabIndex = 12;
            this.lblBranchName.Text = "Branch  Name";
            // 
            // lblTopName
            // 
            this.lblTopName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopName.AutoSize = true;
            this.lblTopName.Font = new System.Drawing.Font("Fira Sans Book", 11F);
            this.lblTopName.ForeColor = System.Drawing.Color.White;
            this.lblTopName.Location = new System.Drawing.Point(1452, 23);
            this.lblTopName.Name = "lblTopName";
            this.lblTopName.Size = new System.Drawing.Size(104, 18);
            this.lblTopName.TabIndex = 11;
            this.lblTopName.Text = "Hello , Behzad";
            // 
            // btnPower
            // 
            this.btnPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPower.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPower.Image = global::HotelManagement.Properties.Resources.powerW;
            this.btnPower.ImageActive = null;
            this.btnPower.Location = new System.Drawing.Point(1767, 20);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(30, 30);
            this.btnPower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPower.TabIndex = 10;
            this.btnPower.TabStop = false;
            this.btnPower.Zoom = 10;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnSize
            // 
            this.btnSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSize.Image = global::HotelManagement.Properties.Resources._1954538_64;
            this.btnSize.ImageActive = null;
            this.btnSize.Location = new System.Drawing.Point(1643, 20);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(30, 30);
            this.btnSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSize.TabIndex = 10;
            this.btnSize.TabStop = false;
            this.btnSize.Zoom = 10;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Image = global::HotelManagement.Properties.Resources.LogW;
            this.btnLogout.ImageActive = null;
            this.btnLogout.Location = new System.Drawing.Point(1705, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(30, 30);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogout.TabIndex = 10;
            this.btnLogout.TabStop = false;
            this.btnLogout.Zoom = 10;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // picProfileTop
            // 
            this.picProfileTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picProfileTop.BackColor = System.Drawing.Color.Transparent;
            this.picProfileTop.Image = global::HotelManagement.Properties.Resources.employee_Profilemale;
            this.picProfileTop.Location = new System.Drawing.Point(1383, 10);
            this.picProfileTop.Name = "picProfileTop";
            this.picProfileTop.Size = new System.Drawing.Size(51, 51);
            this.picProfileTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfileTop.TabIndex = 8;
            this.picProfileTop.TabStop = false;
            // 
            // panelLeftSlide
            // 
            this.panelLeftSlide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(70)))), ((int)(((byte)(89)))));
            this.panelLeftSlide.ColorLeft = System.Drawing.Color.Empty;
            this.panelLeftSlide.ColorRight = System.Drawing.Color.Empty;
            this.panelLeftSlide.Controls.Add(this.btnDashboard);
            this.panelLeftSlide.Controls.Add(this.gradientPanel1);
            this.panelLeftSlide.Controls.Add(this.btnSetting);
            this.panelLeftSlide.Controls.Add(this.btnBranch);
            this.panelLeftSlide.Controls.Add(this.btnMessage);
            this.panelLeftSlide.Controls.Add(this.btnUser);
            this.panelLeftSlide.Controls.Add(this.btnService);
            this.panelLeftSlide.Controls.Add(this.btnAccounting);
            this.panelLeftSlide.Controls.Add(this.btnRoom);
            this.panelLeftSlide.Controls.Add(this.btnBooking);
            this.panelLeftSlide.Controls.Add(this.panelSide);
            this.panelLeftSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeftSlide.Location = new System.Drawing.Point(0, 0);
            this.panelLeftSlide.Name = "panelLeftSlide";
            this.panelLeftSlide.Size = new System.Drawing.Size(70, 1037);
            this.panelLeftSlide.TabIndex = 3;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(4)))), ((int)(((byte)(205)))), ((int)(((byte)(35)))));
            this.gradientPanel1.ColorLeft = System.Drawing.Color.Empty;
            this.gradientPanel1.ColorRight = System.Drawing.Color.Empty;
            this.gradientPanel1.Controls.Add(this.btnSlideMenu);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(70, 75);
            this.gradientPanel1.TabIndex = 8;
            // 
            // btnSlideMenu
            // 
            this.btnSlideMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnSlideMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlideMenu.Image = global::HotelManagement.Properties.Resources.menu__3_;
            this.btnSlideMenu.ImageActive = null;
            this.btnSlideMenu.Location = new System.Drawing.Point(16, 21);
            this.btnSlideMenu.Name = "btnSlideMenu";
            this.btnSlideMenu.Size = new System.Drawing.Size(38, 37);
            this.btnSlideMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSlideMenu.TabIndex = 5;
            this.btnSlideMenu.TabStop = false;
            this.btnSlideMenu.Zoom = 10;
            this.btnSlideMenu.Click += new System.EventHandler(this.btnSlideMenu_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Active = false;
            this.btnSetting.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.BorderRadius = 0;
            this.btnSetting.ButtonText = "    Setting";
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.DisabledColor = System.Drawing.Color.Gray;
            this.btnSetting.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnSetting.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSetting.Iconimage = global::HotelManagement.Properties.Resources.setting;
            this.btnSetting.Iconimage_right = null;
            this.btnSetting.Iconimage_right_Selected = null;
            this.btnSetting.Iconimage_Selected = null;
            this.btnSetting.IconMarginLeft = 0;
            this.btnSetting.IconMarginRight = 0;
            this.btnSetting.IconRightVisible = true;
            this.btnSetting.IconRightZoom = 0D;
            this.btnSetting.IconVisible = true;
            this.btnSetting.IconZoom = 50D;
            this.btnSetting.IsTab = true;
            this.btnSetting.Location = new System.Drawing.Point(7, 817);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(6);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSetting.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnSetting.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSetting.selected = false;
            this.btnSetting.Size = new System.Drawing.Size(215, 57);
            this.btnSetting.TabIndex = 4;
            this.btnSetting.Text = "    Setting";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Textcolor = System.Drawing.Color.White;
            this.btnSetting.TextFont = new System.Drawing.Font("Microsoft YaHei UI", 10.2F);
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnBranch
            // 
            this.btnBranch.Active = false;
            this.btnBranch.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnBranch.BackColor = System.Drawing.Color.Transparent;
            this.btnBranch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBranch.BorderRadius = 0;
            this.btnBranch.ButtonText = "   Branch";
            this.btnBranch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBranch.DisabledColor = System.Drawing.Color.Gray;
            this.btnBranch.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnBranch.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBranch.Iconimage = global::HotelManagement.Properties.Resources.branch;
            this.btnBranch.Iconimage_right = null;
            this.btnBranch.Iconimage_right_Selected = null;
            this.btnBranch.Iconimage_Selected = null;
            this.btnBranch.IconMarginLeft = 0;
            this.btnBranch.IconMarginRight = 0;
            this.btnBranch.IconRightVisible = true;
            this.btnBranch.IconRightZoom = 0D;
            this.btnBranch.IconVisible = true;
            this.btnBranch.IconZoom = 60D;
            this.btnBranch.IsTab = true;
            this.btnBranch.Location = new System.Drawing.Point(7, 737);
            this.btnBranch.Margin = new System.Windows.Forms.Padding(6);
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Normalcolor = System.Drawing.Color.Transparent;
            this.btnBranch.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnBranch.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBranch.selected = false;
            this.btnBranch.Size = new System.Drawing.Size(215, 57);
            this.btnBranch.TabIndex = 4;
            this.btnBranch.Text = "   Branch";
            this.btnBranch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBranch.Textcolor = System.Drawing.Color.White;
            this.btnBranch.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBranch.Click += new System.EventHandler(this.btnBranch_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.Active = false;
            this.btnMessage.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnMessage.BackColor = System.Drawing.Color.Transparent;
            this.btnMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMessage.BorderRadius = 0;
            this.btnMessage.ButtonText = "  Message";
            this.btnMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMessage.DisabledColor = System.Drawing.Color.Gray;
            this.btnMessage.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnMessage.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMessage.Iconimage = global::HotelManagement.Properties.Resources._1011336_48;
            this.btnMessage.Iconimage_right = null;
            this.btnMessage.Iconimage_right_Selected = null;
            this.btnMessage.Iconimage_Selected = null;
            this.btnMessage.IconMarginLeft = 0;
            this.btnMessage.IconMarginRight = 0;
            this.btnMessage.IconRightVisible = true;
            this.btnMessage.IconRightZoom = 0D;
            this.btnMessage.IconVisible = true;
            this.btnMessage.IconZoom = 85D;
            this.btnMessage.IsTab = true;
            this.btnMessage.Location = new System.Drawing.Point(7, 657);
            this.btnMessage.Margin = new System.Windows.Forms.Padding(6);
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Normalcolor = System.Drawing.Color.Transparent;
            this.btnMessage.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnMessage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMessage.selected = false;
            this.btnMessage.Size = new System.Drawing.Size(215, 57);
            this.btnMessage.TabIndex = 4;
            this.btnMessage.Text = "  Message";
            this.btnMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMessage.Textcolor = System.Drawing.Color.White;
            this.btnMessage.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnMessage.Click += new System.EventHandler(this.btnMessage_Click);
            // 
            // btnUser
            // 
            this.btnUser.Active = false;
            this.btnUser.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnUser.BackColor = System.Drawing.Color.Transparent;
            this.btnUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUser.BorderRadius = 0;
            this.btnUser.ButtonText = "   User";
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.DisabledColor = System.Drawing.Color.Gray;
            this.btnUser.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnUser.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUser.Iconimage = global::HotelManagement.Properties.Resources.account_box;
            this.btnUser.Iconimage_right = null;
            this.btnUser.Iconimage_right_Selected = null;
            this.btnUser.Iconimage_Selected = null;
            this.btnUser.IconMarginLeft = 0;
            this.btnUser.IconMarginRight = 0;
            this.btnUser.IconRightVisible = true;
            this.btnUser.IconRightZoom = 0D;
            this.btnUser.IconVisible = true;
            this.btnUser.IconZoom = 60D;
            this.btnUser.IsTab = true;
            this.btnUser.Location = new System.Drawing.Point(7, 577);
            this.btnUser.Margin = new System.Windows.Forms.Padding(6);
            this.btnUser.Name = "btnUser";
            this.btnUser.Normalcolor = System.Drawing.Color.Transparent;
            this.btnUser.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnUser.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUser.selected = false;
            this.btnUser.Size = new System.Drawing.Size(215, 57);
            this.btnUser.TabIndex = 4;
            this.btnUser.Text = "   User";
            this.btnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUser.Textcolor = System.Drawing.Color.White;
            this.btnUser.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click_1);
            // 
            // btnService
            // 
            this.btnService.Active = false;
            this.btnService.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnService.BackColor = System.Drawing.Color.Transparent;
            this.btnService.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnService.BorderRadius = 0;
            this.btnService.ButtonText = "   Services";
            this.btnService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnService.DisabledColor = System.Drawing.Color.Gray;
            this.btnService.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnService.Iconcolor = System.Drawing.Color.Transparent;
            this.btnService.Iconimage = global::HotelManagement.Properties.Resources.covered_food_tray_on_a_hand_of_hotel_room_service;
            this.btnService.Iconimage_right = null;
            this.btnService.Iconimage_right_Selected = null;
            this.btnService.Iconimage_Selected = null;
            this.btnService.IconMarginLeft = 0;
            this.btnService.IconMarginRight = 0;
            this.btnService.IconRightVisible = true;
            this.btnService.IconRightZoom = 0D;
            this.btnService.IconVisible = true;
            this.btnService.IconZoom = 60D;
            this.btnService.IsTab = true;
            this.btnService.Location = new System.Drawing.Point(7, 497);
            this.btnService.Margin = new System.Windows.Forms.Padding(6);
            this.btnService.Name = "btnService";
            this.btnService.Normalcolor = System.Drawing.Color.Transparent;
            this.btnService.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnService.OnHoverTextColor = System.Drawing.Color.White;
            this.btnService.selected = false;
            this.btnService.Size = new System.Drawing.Size(215, 57);
            this.btnService.TabIndex = 4;
            this.btnService.Text = "   Services";
            this.btnService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.Textcolor = System.Drawing.Color.White;
            this.btnService.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnService.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnAccounting
            // 
            this.btnAccounting.Active = false;
            this.btnAccounting.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnAccounting.BackColor = System.Drawing.Color.Transparent;
            this.btnAccounting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccounting.BorderRadius = 0;
            this.btnAccounting.ButtonText = "   Billing";
            this.btnAccounting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccounting.DisabledColor = System.Drawing.Color.Gray;
            this.btnAccounting.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnAccounting.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAccounting.Iconimage = global::HotelManagement.Properties.Resources.card3;
            this.btnAccounting.Iconimage_right = null;
            this.btnAccounting.Iconimage_right_Selected = null;
            this.btnAccounting.Iconimage_Selected = null;
            this.btnAccounting.IconMarginLeft = 0;
            this.btnAccounting.IconMarginRight = 0;
            this.btnAccounting.IconRightVisible = true;
            this.btnAccounting.IconRightZoom = 0D;
            this.btnAccounting.IconVisible = true;
            this.btnAccounting.IconZoom = 60D;
            this.btnAccounting.IsTab = true;
            this.btnAccounting.Location = new System.Drawing.Point(8, 417);
            this.btnAccounting.Margin = new System.Windows.Forms.Padding(6);
            this.btnAccounting.Name = "btnAccounting";
            this.btnAccounting.Normalcolor = System.Drawing.Color.Transparent;
            this.btnAccounting.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnAccounting.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAccounting.selected = false;
            this.btnAccounting.Size = new System.Drawing.Size(215, 57);
            this.btnAccounting.TabIndex = 4;
            this.btnAccounting.Text = "   Billing";
            this.btnAccounting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccounting.Textcolor = System.Drawing.Color.White;
            this.btnAccounting.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAccounting.Click += new System.EventHandler(this.btnAccounting_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.Active = false;
            this.btnRoom.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnRoom.BackColor = System.Drawing.Color.Transparent;
            this.btnRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRoom.BorderRadius = 0;
            this.btnRoom.ButtonText = "   Room";
            this.btnRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoom.DisabledColor = System.Drawing.Color.Gray;
            this.btnRoom.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnRoom.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRoom.Iconimage = global::HotelManagement.Properties.Resources.opened_door_aperture;
            this.btnRoom.Iconimage_right = null;
            this.btnRoom.Iconimage_right_Selected = null;
            this.btnRoom.Iconimage_Selected = null;
            this.btnRoom.IconMarginLeft = 0;
            this.btnRoom.IconMarginRight = 0;
            this.btnRoom.IconRightVisible = true;
            this.btnRoom.IconRightZoom = 0D;
            this.btnRoom.IconVisible = true;
            this.btnRoom.IconZoom = 60D;
            this.btnRoom.IsTab = true;
            this.btnRoom.Location = new System.Drawing.Point(7, 337);
            this.btnRoom.Margin = new System.Windows.Forms.Padding(6);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Normalcolor = System.Drawing.Color.Transparent;
            this.btnRoom.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnRoom.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRoom.selected = false;
            this.btnRoom.Size = new System.Drawing.Size(215, 57);
            this.btnRoom.TabIndex = 4;
            this.btnRoom.Text = "   Room";
            this.btnRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoom.Textcolor = System.Drawing.Color.White;
            this.btnRoom.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.Active = false;
            this.btnBooking.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnBooking.BackColor = System.Drawing.Color.Transparent;
            this.btnBooking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBooking.BorderRadius = 0;
            this.btnBooking.ButtonText = "   Booking";
            this.btnBooking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBooking.DisabledColor = System.Drawing.Color.Gray;
            this.btnBooking.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnBooking.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBooking.Iconimage = global::HotelManagement.Properties.Resources.calendar_text;
            this.btnBooking.Iconimage_right = null;
            this.btnBooking.Iconimage_right_Selected = null;
            this.btnBooking.Iconimage_Selected = null;
            this.btnBooking.IconMarginLeft = 0;
            this.btnBooking.IconMarginRight = 0;
            this.btnBooking.IconRightVisible = true;
            this.btnBooking.IconRightZoom = 0D;
            this.btnBooking.IconVisible = true;
            this.btnBooking.IconZoom = 60D;
            this.btnBooking.IsTab = true;
            this.btnBooking.Location = new System.Drawing.Point(7, 257);
            this.btnBooking.Margin = new System.Windows.Forms.Padding(6);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Normalcolor = System.Drawing.Color.Transparent;
            this.btnBooking.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnBooking.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBooking.selected = false;
            this.btnBooking.Size = new System.Drawing.Size(215, 57);
            this.btnBooking.TabIndex = 4;
            this.btnBooking.Text = "   Booking";
            this.btnBooking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooking.Textcolor = System.Drawing.Color.White;
            this.btnBooking.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBooking.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.Active = false;
            this.btnDashboard.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashboard.BorderRadius = 0;
            this.btnDashboard.ButtonText = "   Dashboard";
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.DisabledColor = System.Drawing.Color.Gray;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.btnDashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.Iconimage = global::HotelManagement.Properties.Resources.home__1_;
            this.btnDashboard.Iconimage_right = null;
            this.btnDashboard.Iconimage_right_Selected = null;
            this.btnDashboard.Iconimage_Selected = null;
            this.btnDashboard.IconMarginLeft = 0;
            this.btnDashboard.IconMarginRight = 0;
            this.btnDashboard.IconRightVisible = true;
            this.btnDashboard.IconRightZoom = 0D;
            this.btnDashboard.IconVisible = true;
            this.btnDashboard.IconZoom = 60D;
            this.btnDashboard.IsTab = true;
            this.btnDashboard.Location = new System.Drawing.Point(8, 176);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(6);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Normalcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(66)))));
            this.btnDashboard.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDashboard.selected = false;
            this.btnDashboard.Size = new System.Drawing.Size(215, 57);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "   Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Textcolor = System.Drawing.Color.White;
            this.btnDashboard.TextFont = new System.Drawing.Font("Yu Gothic UI Light", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDashboard.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelSide
            // 
            this.panelSide.ColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(172)))), ((int)(((byte)(254)))));
            this.panelSide.ColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.panelSide.Location = new System.Drawing.Point(1, 177);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(5, 56);
            this.panelSide.TabIndex = 7;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelTop;
            this.bunifuDragControl1.Vertical = true;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1906, 1037);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeftSlide);
            this.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProfileTop)).EndInit();
            this.panelLeftSlide.ResumeLayout(false);
            this.gradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSlideMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private GradientPanel panelLeftSlide;
        private GradientPanel panelTop;
        private Bunifu.Framework.UI.BunifuImageButton btnSlideMenu;
        private GradientPanel panelSide;
        private Bunifu.Framework.UI.BunifuFlatButton btnDashboard;
        private Bunifu.Framework.UI.BunifuFlatButton btnRoom;
        private Bunifu.Framework.UI.BunifuFlatButton btnBooking;
        private Bunifu.Framework.UI.BunifuFlatButton btnUser;
        private Bunifu.Framework.UI.BunifuFlatButton btnService;
        private Bunifu.Framework.UI.BunifuFlatButton btnAccounting;
        private CirclePictureBox picProfileTop;
        private GradientPanel gradientPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnSetting;
        private Bunifu.Framework.UI.BunifuFlatButton btnBranch;
        private Bunifu.Framework.UI.BunifuFlatButton btnMessage;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panelContainer;
        private Bunifu.Framework.UI.BunifuImageButton btnLogout;
        private Bunifu.Framework.UI.BunifuImageButton btnSize;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTopName;
        private Bunifu.Framework.UI.BunifuCustomLabel lblBranchName;
        private Bunifu.Framework.UI.BunifuImageButton btnPower;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
    }
}