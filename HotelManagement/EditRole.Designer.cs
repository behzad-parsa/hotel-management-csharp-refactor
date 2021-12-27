namespace HotelManagement
{
    partial class EditRole
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRole));
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panelAccess = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblCustError = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.prgbCustError = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbRole
            // 
            this.cmbRole.BackColor = System.Drawing.Color.White;
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(60, 60);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(257, 24);
            this.cmbRole.TabIndex = 0;
            this.cmbRole.SelectedValueChanged += new System.EventHandler(this.cmbRole_SelectedValueChanged);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(60, 83);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(257, 10);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // panelAccess
            // 
            this.panelAccess.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelAccess.Location = new System.Drawing.Point(60, 172);
            this.panelAccess.Name = "panelAccess";
            this.panelAccess.Size = new System.Drawing.Size(257, 393);
            this.panelAccess.TabIndex = 2;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Yu Gothic UI", 10F);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(33, 29);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(52, 23);
            this.bunifuCustomLabel1.TabIndex = 3;
            this.bunifuCustomLabel1.Text = "Role :";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(33, 128);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(69, 23);
            this.bunifuCustomLabel2.TabIndex = 3;
            this.bunifuCustomLabel2.Text = "Access :";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Helvetica World", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(221, 571);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.lblCustError);
            this.panelStatus.Controls.Add(this.prgbCustError);
            this.panelStatus.Location = new System.Drawing.Point(17, 571);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(198, 42);
            this.panelStatus.TabIndex = 21;
            this.panelStatus.Visible = false;
            // 
            // lblCustError
            // 
            this.lblCustError.AutoSize = true;
            this.lblCustError.Font = new System.Drawing.Font("Vazir", 8F);
            this.lblCustError.ForeColor = System.Drawing.Color.Red;
            this.lblCustError.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustError.Location = new System.Drawing.Point(45, 10);
            this.lblCustError.Name = "lblCustError";
            this.lblCustError.Size = new System.Drawing.Size(47, 23);
            this.lblCustError.TabIndex = 16;
            this.lblCustError.Text = "Failed";
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
            this.prgbCustError.Location = new System.Drawing.Point(10, 2);
            this.prgbCustError.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.prgbCustError.MaxValue = 100;
            this.prgbCustError.Name = "prgbCustError";
            this.prgbCustError.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.prgbCustError.ProgressColor = System.Drawing.Color.Red;
            this.prgbCustError.Size = new System.Drawing.Size(36, 36);
            this.prgbCustError.TabIndex = 15;
            this.prgbCustError.Value = 100;
            // 
            // EditRole
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.panelAccess);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.cmbRole);
            this.Name = "EditRole";
            this.Size = new System.Drawing.Size(359, 631);
            this.Load += new System.EventHandler(this.EditRole_Load);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRole;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Panel panelAccess;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.Button btnSave;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel panelStatus;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCustError;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgbCustError;
    }
}
