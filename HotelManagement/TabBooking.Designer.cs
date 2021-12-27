namespace HotelManagement
{
    partial class TabBooking
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
            this.lblNewBook = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lineTab = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblBookList = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelTab = new System.Windows.Forms.Panel();
            this.bunifuSeparator4 = new Bunifu.Framework.UI.BunifuSeparator();
            this.panelTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNewBook
            // 
            this.lblNewBook.BackColor = System.Drawing.Color.Transparent;
            this.lblNewBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNewBook.Font = new System.Drawing.Font("Raleway Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewBook.ForeColor = System.Drawing.Color.Black;
            this.lblNewBook.Location = new System.Drawing.Point(35, 18);
            this.lblNewBook.Name = "lblNewBook";
            this.lblNewBook.Size = new System.Drawing.Size(124, 26);
            this.lblNewBook.TabIndex = 0;
            this.lblNewBook.Text = "New Book";
            this.lblNewBook.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblNewBook.Click += new System.EventHandler(this.lblNewBook_Click);
            // 
            // lineTab
            // 
            this.lineTab.BackColor = System.Drawing.Color.Transparent;
            this.lineTab.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.lineTab.LineThickness = 2;
            this.lineTab.Location = new System.Drawing.Point(35, 49);
            this.lineTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lineTab.Name = "lineTab";
            this.lineTab.Size = new System.Drawing.Size(124, 10);
            this.lineTab.TabIndex = 1;
            this.lineTab.Transparency = 255;
            this.lineTab.Vertical = false;
            // 
            // lblBookList
            // 
            this.lblBookList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBookList.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this.lblBookList.ForeColor = System.Drawing.Color.DarkGray;
            this.lblBookList.Location = new System.Drawing.Point(183, 18);
            this.lblBookList.Name = "lblBookList";
            this.lblBookList.Size = new System.Drawing.Size(124, 26);
            this.lblBookList.TabIndex = 0;
            this.lblBookList.Text = "Book List";
            this.lblBookList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblBookList.Click += new System.EventHandler(this.lblBookList_Click);
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(155, 20);
            this.bunifuSeparator2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(21, 20);
            this.bunifuSeparator2.TabIndex = 3;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = true;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 57);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1836, 908);
            this.panelContainer.TabIndex = 4;
            // 
            // panelTab
            // 
            this.panelTab.BackColor = System.Drawing.SystemColors.Window;
            this.panelTab.Controls.Add(this.lineTab);
            this.panelTab.Controls.Add(this.bunifuSeparator4);
            this.panelTab.Controls.Add(this.lblNewBook);
            this.panelTab.Controls.Add(this.lblBookList);
            this.panelTab.Controls.Add(this.bunifuSeparator2);
            this.panelTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTab.Location = new System.Drawing.Point(0, 0);
            this.panelTab.Name = "panelTab";
            this.panelTab.Size = new System.Drawing.Size(1836, 57);
            this.panelTab.TabIndex = 0;
            // 
            // bunifuSeparator4
            // 
            this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.bunifuSeparator4.LineThickness = 1;
            this.bunifuSeparator4.Location = new System.Drawing.Point(0, 53);
            this.bunifuSeparator4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuSeparator4.Name = "bunifuSeparator4";
            this.bunifuSeparator4.Size = new System.Drawing.Size(1847, 5);
            this.bunifuSeparator4.TabIndex = 2;
            this.bunifuSeparator4.Transparency = 255;
            this.bunifuSeparator4.Vertical = false;
            // 
            // TabBooking
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelTab);
            this.Name = "TabBooking";
            this.Size = new System.Drawing.Size(1836, 965);
            this.Load += new System.EventHandler(this.TabBooking_Load);
            this.panelTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel lblNewBook;
        private Bunifu.Framework.UI.BunifuSeparator lineTab;
        private Bunifu.Framework.UI.BunifuCustomLabel lblBookList;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel panelTab;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator4;
    }
}
