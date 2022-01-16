namespace HotelManagement
{
    partial class CardInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardInvoice));
            this.CardPersonalInfo = new Bunifu.Framework.UI.BunifuCards();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelEmpLeft = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvInvoice = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.txtEmpNationalCode = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.panelEmpStatus = new System.Windows.Forms.Panel();
            this.lbl = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.prgbEmpError = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.CardPersonalInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelEmpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.panelEmpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // CardPersonalInfo
            // 
            this.CardPersonalInfo.BackColor = System.Drawing.Color.White;
            this.CardPersonalInfo.BorderRadius = 5;
            this.CardPersonalInfo.BottomSahddow = true;
            this.CardPersonalInfo.color = System.Drawing.Color.White;
            this.CardPersonalInfo.Controls.Add(this.panel1);
            this.CardPersonalInfo.Controls.Add(this.panelEmpLeft);
            this.CardPersonalInfo.Controls.Add(this.panelEmpStatus);
            this.CardPersonalInfo.LeftSahddow = false;
            this.CardPersonalInfo.Location = new System.Drawing.Point(3, 3);
            this.CardPersonalInfo.Name = "CardPersonalInfo";
            this.CardPersonalInfo.RightSahddow = true;
            this.CardPersonalInfo.ShadowDepth = 20;
            this.CardPersonalInfo.Size = new System.Drawing.Size(1554, 833);
            this.CardPersonalInfo.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(93)))), ((int)(((byte)(212)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1554, 78);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::HotelManagement.Properties.Resources.clipboard;
            this.pictureBox1.Location = new System.Drawing.Point(23, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.bunifuCustomLabel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(88, 24);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(382, 31);
            this.bunifuCustomLabel2.TabIndex = 1;
            this.bunifuCustomLabel2.Text = "INVOICE LIST";
            this.bunifuCustomLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // panelEmpLeft
            // 
            this.panelEmpLeft.Controls.Add(this.pictureBox2);
            this.panelEmpLeft.Controls.Add(this.dgvInvoice);
            this.panelEmpLeft.Controls.Add(this.txtEmpNationalCode);
            this.panelEmpLeft.Location = new System.Drawing.Point(3, 84);
            this.panelEmpLeft.Name = "panelEmpLeft";
            this.panelEmpLeft.Size = new System.Drawing.Size(1528, 655);
            this.panelEmpLeft.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::HotelManagement.Properties.Resources.search1;
            this.pictureBox2.Location = new System.Drawing.Point(946, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;

            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(91)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvInvoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInvoice.ColumnHeadersHeight = 50;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoice.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvInvoice.DoubleBuffered = true;
            this.dgvInvoice.EnableHeadersVisualStyles = false;
            this.dgvInvoice.HeaderBgColor = System.Drawing.Color.SeaGreen;
            this.dgvInvoice.HeaderForeColor = System.Drawing.Color.White;
            this.dgvInvoice.Location = new System.Drawing.Point(3, 81);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.ReadOnly = true;
            this.dgvInvoice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvInvoice.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(91)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            this.dgvInvoice.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvInvoice.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvInvoice.RowTemplate.Height = 50;
            this.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoice.Size = new System.Drawing.Size(1504, 557);
            this.dgvInvoice.TabIndex = 19;

            this.dgvInvoice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellDoubleClick);
            // 
            // txtEmpNationalCode
            // 
            this.txtEmpNationalCode.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtEmpNationalCode.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtEmpNationalCode.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtEmpNationalCode.BorderThickness = 1;
            this.txtEmpNationalCode.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmpNationalCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmpNationalCode.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.txtEmpNationalCode.ForeColor = System.Drawing.Color.DarkGray;
            this.txtEmpNationalCode.isPassword = false;
            this.txtEmpNationalCode.Location = new System.Drawing.Point(481, 13);
            this.txtEmpNationalCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmpNationalCode.MaxLength = 32767;
            this.txtEmpNationalCode.Name = "txtEmpNationalCode";
            this.txtEmpNationalCode.Size = new System.Drawing.Size(512, 43);
            this.txtEmpNationalCode.TabIndex = 0;
            this.txtEmpNationalCode.Text = "Search By National Code ...";
            this.txtEmpNationalCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmpNationalCode.OnValueChanged += new System.EventHandler(this.txtEmpNationalCode_OnValueChanged);
            this.txtEmpNationalCode.Enter += new System.EventHandler(this.txtEmpNationalCode_Enter);
            // 
            // panelEmpStatus
            // 
            this.panelEmpStatus.Controls.Add(this.lbl);
            this.panelEmpStatus.Controls.Add(this.prgbEmpError);
            this.panelEmpStatus.Location = new System.Drawing.Point(32, 758);
            this.panelEmpStatus.Name = "panelEmpStatus";
            this.panelEmpStatus.Size = new System.Drawing.Size(559, 60);
            this.panelEmpStatus.TabIndex = 18;
            this.panelEmpStatus.Visible = false;
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.lbl.ForeColor = System.Drawing.Color.Red;
            this.lbl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl.Location = new System.Drawing.Point(55, 21);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(494, 23);
            this.lbl.TabIndex = 16;
            this.lbl.Text = "Error";
            // 
            // prgbEmpError
            // 
            this.prgbEmpError.animated = false;
            this.prgbEmpError.animationIterval = 5;
            this.prgbEmpError.animationSpeed = 300;
            this.prgbEmpError.BackColor = System.Drawing.Color.White;
            this.prgbEmpError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prgbEmpError.BackgroundImage")));
            this.prgbEmpError.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.prgbEmpError.ForeColor = System.Drawing.Color.SeaGreen;
            this.prgbEmpError.LabelVisible = false;
            this.prgbEmpError.LineProgressThickness = 3;
            this.prgbEmpError.LineThickness = 3;
            this.prgbEmpError.Location = new System.Drawing.Point(10, 9);
            this.prgbEmpError.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.prgbEmpError.MaxValue = 100;
            this.prgbEmpError.Name = "prgbEmpError";
            this.prgbEmpError.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.prgbEmpError.ProgressColor = System.Drawing.Color.Red;
            this.prgbEmpError.Size = new System.Drawing.Size(42, 42);
            this.prgbEmpError.TabIndex = 15;
            this.prgbEmpError.Value = 100;
            // 
            // CardInvoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.CardPersonalInfo);
            this.Name = "CardInvoice";
            this.Size = new System.Drawing.Size(1557, 843);
            this.Load += new System.EventHandler(this.CardInvoice_Load);
            this.CardPersonalInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelEmpLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.panelEmpStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards CardPersonalInfo;
        private System.Windows.Forms.Panel panelEmpLeft;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtEmpNationalCode;
        private System.Windows.Forms.Panel panelEmpStatus;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgbEmpError;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvInvoice;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
