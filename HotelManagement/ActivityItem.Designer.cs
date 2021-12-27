namespace HotelManagement
{
    partial class ActivityItem
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblDate = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTitle = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblDescription = new Bunifu.Framework.UI.BunifuCustomLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelManagement.Properties.Resources.circleAct;
            this.pictureBox1.Location = new System.Drawing.Point(45, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.ActivityItem_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.ActivityItem_MouseLeave);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(64, 90);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(10, 91);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = true;
            this.bunifuSeparator1.MouseEnter += new System.EventHandler(this.ActivityItem_MouseEnter);
            this.bunifuSeparator1.MouseLeave += new System.EventHandler(this.ActivityItem_MouseLeave);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(64, -4);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(10, 40);
            this.bunifuSeparator2.TabIndex = 1;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = true;
            this.bunifuSeparator2.MouseEnter += new System.EventHandler(this.ActivityItem_MouseEnter);
            this.bunifuSeparator2.MouseLeave += new System.EventHandler(this.ActivityItem_MouseLeave);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(130)))), ((int)(((byte)(154)))));
            this.lblDate.Location = new System.Drawing.Point(121, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(121, 20);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "3 HOURS AGO";
            this.lblDate.MouseEnter += new System.EventHandler(this.ActivityItem_MouseEnter);
            this.lblDate.MouseLeave += new System.EventHandler(this.ActivityItem_MouseLeave);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Acumin Pro SemiCondensed", 10F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(130)))), ((int)(((byte)(154)))));
            this.lblTitle.Location = new System.Drawing.Point(127, 91);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(121, 18);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "UPLOAD CONTENT";
            this.lblTitle.MouseEnter += new System.EventHandler(this.ActivityItem_MouseEnter);
            this.lblTitle.MouseLeave += new System.EventHandler(this.ActivityItem_MouseLeave);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoEllipsis = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(155)))), ((int)(((byte)(175)))));
            this.lblDescription.Location = new System.Drawing.Point(127, 120);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(287, 58);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Invoice has been Edited By Behzad";
            this.lblDescription.MouseEnter += new System.EventHandler(this.ActivityItem_MouseEnter);
            this.lblDescription.MouseLeave += new System.EventHandler(this.ActivityItem_MouseLeave);
            // 
            // ActivityItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ActivityItem";
            this.Size = new System.Drawing.Size(448, 178);
            this.Load += new System.EventHandler(this.ActivityItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDate;
        private Bunifu.Framework.UI.BunifuCustomLabel lblTitle;
        private Bunifu.Framework.UI.BunifuCustomLabel lblDescription;
    }
}
