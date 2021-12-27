namespace HotelManagement
{
    partial class NewRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRole));
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txtRole = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btnSub = new System.Windows.Forms.Button();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panelAccess = new System.Windows.Forms.Panel();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.lblCustError = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.prgbCustError = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // txtRole
            // 
            this.txtRole.BorderColorFocused = System.Drawing.Color.Blue;
            this.txtRole.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.txtRole.BorderColorMouseHover = System.Drawing.Color.Blue;
            this.txtRole.BorderThickness = 1;
            this.txtRole.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRole.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.txtRole.ForeColor = System.Drawing.Color.Gray;
            this.txtRole.isPassword = false;
            this.txtRole.Location = new System.Drawing.Point(60, 63);
            this.txtRole.Margin = new System.Windows.Forms.Padding(4);
            this.txtRole.MaxLength = 32767;
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(255, 35);
            this.txtRole.TabIndex = 10;
            this.txtRole.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnSub
            // 
            this.btnSub.BackColor = System.Drawing.Color.MediumVioletRed;
            this.btnSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSub.Font = new System.Drawing.Font("Helvetica World", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSub.ForeColor = System.Drawing.Color.White;
            this.btnSub.Location = new System.Drawing.Point(221, 571);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(96, 42);
            this.btnSub.TabIndex = 16;
            this.btnSub.Text = "Submit";
            this.btnSub.UseVisualStyleBackColor = false;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.Black;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(33, 136);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(69, 23);
            this.bunifuCustomLabel2.TabIndex = 14;
            this.bunifuCustomLabel2.Text = "Access :";
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
            this.bunifuCustomLabel1.TabIndex = 15;
            this.bunifuCustomLabel1.Text = "Role :";
            // 
            // panelAccess
            // 
            this.panelAccess.Location = new System.Drawing.Point(60, 178);
            this.panelAccess.Name = "panelAccess";
            this.panelAccess.Size = new System.Drawing.Size(257, 375);
            this.panelAccess.TabIndex = 13;
            // 
            // panelStatus
            // 
            this.panelStatus.Controls.Add(this.lblCustError);
            this.panelStatus.Controls.Add(this.prgbCustError);
            this.panelStatus.Location = new System.Drawing.Point(17, 571);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(198, 42);
            this.panelStatus.TabIndex = 22;
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
            // NewRole
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.btnSub);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.panelAccess);
            this.Controls.Add(this.txtRole);
            this.Name = "NewRole";
            this.Size = new System.Drawing.Size(359, 631);
            this.Load += new System.EventHandler(this.NewRole_Load);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtRole;
        private System.Windows.Forms.Button btnSub;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panelAccess;
        private System.Windows.Forms.Panel panelStatus;
        private Bunifu.Framework.UI.BunifuCustomLabel lblCustError;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgbCustError;
    }
}
