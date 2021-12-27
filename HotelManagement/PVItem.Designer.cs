namespace HotelManagement
{
    partial class PVItem
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
            this.lblName = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTime = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblLastMessage = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.picProfile = new HotelManagement.OvalPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Fira Sans Book", 11F);
            this.lblName.Location = new System.Drawing.Point(142, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(170, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Behzad Pesarakluo";
            this.lblName.MouseEnter += new System.EventHandler(this.lblName_MouseEnter);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Fira Sans Book", 11F);
            this.lblTime.Location = new System.Drawing.Point(348, 28);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(76, 23);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "4:40 AM";
            // 
            // lblLastMessage
            // 
            this.lblLastMessage.AutoSize = true;
            this.lblLastMessage.Font = new System.Drawing.Font("Fira Sans Light", 10F);
            this.lblLastMessage.Location = new System.Drawing.Point(152, 67);
            this.lblLastMessage.Name = "lblLastMessage";
            this.lblLastMessage.Size = new System.Drawing.Size(99, 20);
            this.lblLastMessage.TabIndex = 1;
            this.lblLastMessage.Text = "Hello World";
            // 
            // picProfile
            // 
            this.picProfile.Image = global::HotelManagement.Properties.Resources.rainy_weather_wallpaper_800x600;
            this.picProfile.Location = new System.Drawing.Point(25, 12);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(90, 92);
            this.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProfile.TabIndex = 0;
            this.picProfile.TabStop = false;
            // 
            // PVItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblLastMessage);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picProfile);
            this.Name = "PVItem";
            this.Size = new System.Drawing.Size(444, 123);
            this.Load += new System.EventHandler(this.PanelPV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OvalPictureBox picProfile;
        private Bunifu.Framework.UI.BunifuCustomLabel lblName;
        public Bunifu.Framework.UI.BunifuCustomLabel lblLastMessage;
        public Bunifu.Framework.UI.BunifuCustomLabel lblTime;
    }
}
