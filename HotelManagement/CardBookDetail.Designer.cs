namespace HotelManagement
{
    partial class CardBookDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardBookDetail));
            this.btnBookll = new System.Windows.Forms.Button();
            this.lblRoom = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dateEnd = new Bunifu.Framework.UI.BunifuDatepicker();
            this.lblPay = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblPayDate = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel9 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel15 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.dateStart = new Bunifu.Framework.UI.BunifuDatepicker();
            this.bunifuCustomLabel8 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCards2 = new Bunifu.Framework.UI.BunifuCards();
            this.btnBook = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panelBasic = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNothing = new System.Windows.Forms.Label();
            this.dgvRoom = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelStatusBook = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel10 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCircleProgressbar5 = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel6 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel21 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCards2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panelBasic.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelStatusBook.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBookll
            // 
            this.btnBookll.BackColor = System.Drawing.Color.SkyBlue;
            this.btnBookll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookll.Font = new System.Drawing.Font("Helvetica World", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBookll.ForeColor = System.Drawing.Color.White;
            this.btnBookll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBookll.Location = new System.Drawing.Point(653, 702);
            this.btnBookll.Name = "btnBookll";
            this.btnBookll.Size = new System.Drawing.Size(182, 39);
            this.btnBookll.TabIndex = 11;
            this.btnBookll.Text = "Book";
            this.btnBookll.UseVisualStyleBackColor = false;
            this.btnBookll.Visible = false;
            this.btnBookll.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Leelawadee UI Semilight", 10F);
            this.lblRoom.Location = new System.Drawing.Point(147, 284);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(128, 23);
            this.lblRoom.TabIndex = 8;
            this.lblRoom.Text = "Number - Type ";
            // 
            // dateEnd
            // 
            this.dateEnd.BackColor = System.Drawing.Color.Transparent;
            this.dateEnd.BorderRadius = 5;
            this.dateEnd.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.dateEnd.ForeColor = System.Drawing.Color.Gray;
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateEnd.FormatCustom = null;
            this.dateEnd.Location = new System.Drawing.Point(151, 181);
            this.dateEnd.Margin = new System.Windows.Forms.Padding(0);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(338, 40);
            this.dateEnd.TabIndex = 7;
            this.dateEnd.Value = new System.DateTime(2018, 8, 5, 16, 3, 51, 882);
            this.dateEnd.onValueChanged += new System.EventHandler(this.dateEnd_onValueChanged);
            // 
            // lblPay
            // 
            this.lblPay.AutoSize = true;
            this.lblPay.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.lblPay.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPay.Location = new System.Drawing.Point(147, 367);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(58, 22);
            this.lblPay.TabIndex = 5;
            this.lblPay.Text = "200000";
            // 
            // lblPayDate
            // 
            this.lblPayDate.AutoSize = true;
            this.lblPayDate.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.lblPayDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPayDate.Location = new System.Drawing.Point(23, 367);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(89, 23);
            this.lblPayDate.TabIndex = 5;
            this.lblPayDate.Text = "Total Pay  :";
            // 
            // bunifuCustomLabel9
            // 
            this.bunifuCustomLabel9.AutoSize = true;
            this.bunifuCustomLabel9.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.bunifuCustomLabel9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuCustomLabel9.Location = new System.Drawing.Point(25, 283);
            this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
            this.bunifuCustomLabel9.Size = new System.Drawing.Size(63, 23);
            this.bunifuCustomLabel9.TabIndex = 5;
            this.bunifuCustomLabel9.Text = "Room :";
            // 
            // bunifuCustomLabel15
            // 
            this.bunifuCustomLabel15.AutoSize = true;
            this.bunifuCustomLabel15.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.bunifuCustomLabel15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuCustomLabel15.Location = new System.Drawing.Point(23, 189);
            this.bunifuCustomLabel15.Name = "bunifuCustomLabel15";
            this.bunifuCustomLabel15.Size = new System.Drawing.Size(108, 23);
            this.bunifuCustomLabel15.TabIndex = 5;
            this.bunifuCustomLabel15.Text = "Check - Out :";
            // 
            // dateStart
            // 
            this.dateStart.BackColor = System.Drawing.Color.Transparent;
            this.dateStart.BorderRadius = 5;
            this.dateStart.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.dateStart.ForeColor = System.Drawing.Color.Gray;
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dateStart.FormatCustom = null;
            this.dateStart.Location = new System.Drawing.Point(151, 86);
            this.dateStart.Margin = new System.Windows.Forms.Padding(0);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(338, 40);
            this.dateStart.TabIndex = 7;
            this.dateStart.Value = new System.DateTime(2018, 8, 5, 16, 3, 51, 882);
            this.dateStart.onValueChanged += new System.EventHandler(this.dateStart_onValueChanged);
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.AutoSize = true;
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Segoe UI Semilight", 10F);
            this.bunifuCustomLabel8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(25, 96);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(94, 23);
            this.bunifuCustomLabel8.TabIndex = 5;
            this.bunifuCustomLabel8.Text = "Check - In :";
            // 
            // bunifuCards2
            // 
            this.bunifuCards2.BackColor = System.Drawing.Color.White;
            this.bunifuCards2.BorderRadius = 5;
            this.bunifuCards2.BottomSahddow = true;
            this.bunifuCards2.color = System.Drawing.Color.White;
            this.bunifuCards2.Controls.Add(this.btnBook);
            this.bunifuCards2.Controls.Add(this.panel5);
            this.bunifuCards2.Controls.Add(this.panelStatusBook);
            this.bunifuCards2.Controls.Add(this.panel6);
            this.bunifuCards2.LeftSahddow = false;
            this.bunifuCards2.Location = new System.Drawing.Point(3, 3);
            this.bunifuCards2.Name = "bunifuCards2";
            this.bunifuCards2.RightSahddow = true;
            this.bunifuCards2.ShadowDepth = 20;
            this.bunifuCards2.Size = new System.Drawing.Size(1144, 693);
            this.bunifuCards2.TabIndex = 23;
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Helvetica World", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBook.Location = new System.Drawing.Point(946, 635);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(155, 48);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "Book";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click_1);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel9);
            this.panel5.Location = new System.Drawing.Point(56, 112);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1032, 526);
            this.panel5.TabIndex = 5;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panelBasic);
            this.panel9.Controls.Add(this.panel1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1032, 526);
            this.panel9.TabIndex = 5;
            // 
            // panelBasic
            // 
            this.panelBasic.Controls.Add(this.panel10);
            this.panelBasic.Controls.Add(this.lblRoom);
            this.panelBasic.Controls.Add(this.dateStart);
            this.panelBasic.Controls.Add(this.dateEnd);
            this.panelBasic.Controls.Add(this.bunifuCustomLabel8);
            this.panelBasic.Controls.Add(this.lblPay);
            this.panelBasic.Controls.Add(this.bunifuCustomLabel15);
            this.panelBasic.Controls.Add(this.lblPayDate);
            this.panelBasic.Controls.Add(this.bunifuCustomLabel9);
            this.panelBasic.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBasic.Location = new System.Drawing.Point(0, 0);
            this.panelBasic.Name = "panelBasic";
            this.panelBasic.Size = new System.Drawing.Size(513, 526);
            this.panelBasic.TabIndex = 4;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(237)))), ((int)(((byte)(200)))));
            this.panel10.Controls.Add(this.bunifuCustomLabel4);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.ForeColor = System.Drawing.Color.Black;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(513, 36);
            this.panel10.TabIndex = 6;
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Josefin Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(41, 5);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(58, 27);
            this.bunifuCustomLabel4.TabIndex = 5;
            this.bunifuCustomLabel4.Text = "Detail";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNothing);
            this.panel1.Controls.Add(this.dgvRoom);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(569, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 526);
            this.panel1.TabIndex = 5;
            // 
            // lblNothing
            // 
            this.lblNothing.AutoSize = true;
            this.lblNothing.Font = new System.Drawing.Font("Yu Gothic Light", 13F);
            this.lblNothing.ForeColor = System.Drawing.Color.Gray;
            this.lblNothing.Location = new System.Drawing.Point(173, 249);
            this.lblNothing.Name = "lblNothing";
            this.lblNothing.Size = new System.Drawing.Size(113, 29);
            this.lblNothing.TabIndex = 14;
            this.lblNothing.Text = "Empty List";
            this.lblNothing.Visible = false;
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            this.dgvRoom.AllowUserToResizeColumns = false;
            this.dgvRoom.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.BackgroundColor = System.Drawing.Color.White;
            this.dgvRoom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRoom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvRoom.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRoom.ColumnHeadersHeight = 40;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRoom.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRoom.DoubleBuffered = true;
            this.dgvRoom.EnableHeadersVisualStyles = false;
            this.dgvRoom.GridColor = System.Drawing.Color.Aquamarine;
            this.dgvRoom.HeaderBgColor = System.Drawing.Color.AliceBlue;
            this.dgvRoom.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(114)))), ((int)(((byte)(136)))));
            this.dgvRoom.Location = new System.Drawing.Point(0, 36);
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            this.dgvRoom.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRoom.RowHeadersVisible = false;
            this.dgvRoom.RowHeadersWidth = 40;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(91)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRoom.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRoom.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRoom.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRoom.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleGreen;
            this.dgvRoom.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvRoom.RowTemplate.Height = 50;
            this.dgvRoom.RowTemplate.ReadOnly = true;
            this.dgvRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoom.Size = new System.Drawing.Size(463, 490);
            this.dgvRoom.TabIndex = 7;
            this.dgvRoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoom_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(188)))));
            this.panel2.Controls.Add(this.bunifuCustomLabel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 36);
            this.panel2.TabIndex = 6;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Josefin Sans", 10.2F);
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(43, 5);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(88, 27);
            this.bunifuCustomLabel3.TabIndex = 5;
            this.bunifuCustomLabel3.Text = "Room List";
            // 
            // panelStatusBook
            // 
            this.panelStatusBook.Controls.Add(this.bunifuCustomLabel10);
            this.panelStatusBook.Controls.Add(this.bunifuCircleProgressbar5);
            this.panelStatusBook.Location = new System.Drawing.Point(55, 626);
            this.panelStatusBook.Name = "panelStatusBook";
            this.panelStatusBook.Size = new System.Drawing.Size(547, 60);
            this.panelStatusBook.TabIndex = 17;
            this.panelStatusBook.Visible = false;
            // 
            // bunifuCustomLabel10
            // 
            this.bunifuCustomLabel10.AutoSize = true;
            this.bunifuCustomLabel10.Font = new System.Drawing.Font("Leelawadee UI", 9F);
            this.bunifuCustomLabel10.ForeColor = System.Drawing.Color.Red;
            this.bunifuCustomLabel10.Location = new System.Drawing.Point(55, 19);
            this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
            this.bunifuCustomLabel10.Size = new System.Drawing.Size(193, 20);
            this.bunifuCustomLabel10.TabIndex = 16;
            this.bunifuCustomLabel10.Text = "Unable To Complete Action";
            // 
            // bunifuCircleProgressbar5
            // 
            this.bunifuCircleProgressbar5.animated = false;
            this.bunifuCircleProgressbar5.animationIterval = 5;
            this.bunifuCircleProgressbar5.animationSpeed = 300;
            this.bunifuCircleProgressbar5.BackColor = System.Drawing.Color.White;
            this.bunifuCircleProgressbar5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuCircleProgressbar5.BackgroundImage")));
            this.bunifuCircleProgressbar5.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bunifuCircleProgressbar5.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuCircleProgressbar5.LabelVisible = false;
            this.bunifuCircleProgressbar5.LineProgressThickness = 3;
            this.bunifuCircleProgressbar5.LineThickness = 3;
            this.bunifuCircleProgressbar5.Location = new System.Drawing.Point(10, 9);
            this.bunifuCircleProgressbar5.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bunifuCircleProgressbar5.MaxValue = 100;
            this.bunifuCircleProgressbar5.Name = "bunifuCircleProgressbar5";
            this.bunifuCircleProgressbar5.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bunifuCircleProgressbar5.ProgressColor = System.Drawing.Color.Red;
            this.bunifuCircleProgressbar5.Size = new System.Drawing.Size(38, 38);
            this.bunifuCircleProgressbar5.TabIndex = 15;
            this.bunifuCircleProgressbar5.Value = 100;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.panel6.Controls.Add(this.bunifuCustomLabel21);
            this.panel6.Location = new System.Drawing.Point(0, 25);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1601, 70);
            this.panel6.TabIndex = 1;
            // 
            // bunifuCustomLabel21
            // 
            this.bunifuCustomLabel21.AutoSize = true;
            this.bunifuCustomLabel21.Font = new System.Drawing.Font("Penumbra Sans Std", 15F);
            this.bunifuCustomLabel21.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel21.Location = new System.Drawing.Point(62, 20);
            this.bunifuCustomLabel21.Name = "bunifuCustomLabel21";
            this.bunifuCustomLabel21.Size = new System.Drawing.Size(86, 31);
            this.bunifuCustomLabel21.TabIndex = 2;
            this.bunifuCustomLabel21.Text = "Book";
            // 
            // CardBookDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.bunifuCards2);
            this.Controls.Add(this.btnBookll);
            this.Name = "CardBookDetail";
            this.Size = new System.Drawing.Size(1151, 754);
            this.Load += new System.EventHandler(this.CardBookDetail_Load);
            this.bunifuCards2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panelBasic.ResumeLayout(false);
            this.panelBasic.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelStatusBook.ResumeLayout(false);
            this.panelStatusBook.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBookll;
        private Bunifu.Framework.UI.BunifuDatepicker dateEnd;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel15;
        private Bunifu.Framework.UI.BunifuDatepicker dateStart;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel8;
        private Bunifu.Framework.UI.BunifuCustomLabel lblRoom;
        private Bunifu.Framework.UI.BunifuCustomLabel lblPay;
        private Bunifu.Framework.UI.BunifuCustomLabel lblPayDate;
        private Bunifu.Framework.UI.BunifuCards bunifuCards2;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Panel panel10;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private System.Windows.Forms.Panel panelBasic;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvRoom;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private System.Windows.Forms.Label lblNothing;
        private System.Windows.Forms.Panel panelStatusBook;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bunifuCircleProgressbar5;
        private System.Windows.Forms.Panel panel6;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel21;
    }
}
