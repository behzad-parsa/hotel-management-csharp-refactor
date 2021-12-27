namespace HotelManagement
{
    partial class CustomeNumeric
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
            this.txtTitle = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.picSubtract = new System.Windows.Forms.PictureBox();
            this.picAdd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSubtract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.BorderColorFocused = System.Drawing.Color.Transparent;
            this.txtTitle.BorderColorIdle = System.Drawing.Color.Transparent;
            this.txtTitle.BorderColorMouseHover = System.Drawing.Color.Transparent;
            this.txtTitle.BorderThickness = 1;
            this.txtTitle.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtTitle.isPassword = false;
            this.txtTitle.Location = new System.Drawing.Point(42, 6);
            this.txtTitle.MaxLength = 32767;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(33, 29);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Text = "0";
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTitle.OnValueChanged += new System.EventHandler(this.txtTitle_OnValueChanged);
            // 
            // picSubtract
            // 
            this.picSubtract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSubtract.Image = global::HotelManagement.Properties.Resources.substract;
            this.picSubtract.Location = new System.Drawing.Point(3, 6);
            this.picSubtract.Name = "picSubtract";
            this.picSubtract.Size = new System.Drawing.Size(25, 25);
            this.picSubtract.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSubtract.TabIndex = 2;
            this.picSubtract.TabStop = false;
            this.picSubtract.Click += new System.EventHandler(this.picSubtract_Click);
            // 
            // picAdd
            // 
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = global::HotelManagement.Properties.Resources.add;
            this.picAdd.Location = new System.Drawing.Point(87, 6);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(25, 25);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdd.TabIndex = 2;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CustomeNumeric
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picSubtract);
            this.Controls.Add(this.picAdd);
            this.Controls.Add(this.txtTitle);
            this.Name = "CustomeNumeric";
            this.Size = new System.Drawing.Size(122, 35);
            this.Load += new System.EventHandler(this.CustomeNumeric_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSubtract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuMetroTextbox txtTitle;
        private System.Windows.Forms.PictureBox picAdd;
        private System.Windows.Forms.PictureBox picSubtract;
    }
}
