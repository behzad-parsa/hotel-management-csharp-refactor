using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace HotelManagement
{ 
    public partial class InvoiceDetail : UserControl
    {
        public static int CustomerID;
        public static int ResID;
        public static int BillID;
        public static bool payFlag = false;
        private double newDiscount;
        private string newDescription;
        public static int TranID;

        ScreenCapture capScreen = new ScreenCapture();
        public InvoiceDetail()
        {
            InitializeComponent();
        }
        //private void cap()
        //{
        //    Bitmap bmp = new Bitmap(this.radPanel1.Width, this.radPanel1.Height);
        //    radPanel1.DrawToBitmap(bmp, new Rectangle(Point.Empty, this.radPanel1.Size));

        //    RadFixedDocument document = new RadFixedDocument();
        //    RadFixedPage page = document.Pages.AddPage();
        //    page.Size = new System.Windows.Size(radPanel1.Width, radPanel1.Height);


        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //        Image image = new Image();
        //        image.ImageSource = new Telerik.Windows.Documents.Fixed.Model.Resources.ImageSource(ms);
        //        image.Width = radPanel1.Width;
        //        image.Height = radPanel1.Height;

        //        document.Pages.First().Content.Add(image);
        //    }

        //    PdfFormatProvider provider = new PdfFormatProvider();
        //    using (Stream output = File.OpenWrite("Test.pdf"))
        //    {
        //        provider.Export(document, output);
        //    }
        //}
        //private void captureScreen()
        //{
        //    try
        //    {
        //        // Call the CaptureAndSave method from the ScreenCapture class 
        //        // And create a temporary file in C:\Temp
        //        capScreen.CaptureAndSave
        //        (@"E:\Temp\test.png", CaptureMode.Window, ImageFormat.Png);
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message.ToString());
        //    }
        //}

        private void InvoiceDetail_Load(object sender, EventArgs e)
        {        
            if (payFlag)
            {
                btnPay.Text = "Pay Info";
                btnEdit.Enabled = false;
                picPaid.Visible = true;

            }
            else
            {
                btnPay.Text = "Pay Invoice";
                btnEdit.Enabled = true;
                picPaid.Visible = false;
            }       
            
            string query = "Select res.* , cust.* , a.* , r.* , rn.Title As RoomNum , b.* , b.DateModified as BillDate  , b.id As Bid, u.* , e.* , bi.BranchName AS Bname , bi.State As Bstate, bi.Tel As Btel , bi.City as Bcity , bi.Address as Baddress  " +
                "From Reservation res , Customer cust , Actor a , Room r , RoomNumber rn , Bill b , [dbo].[User] u , Employee e , BranchInfo bi Where res.id = " + ResID + "AND res.CustomerID = cust.id And " +
                "cust.actID = a.id And res.RoomID = r.id And r.RoomNumberID = rn.id AND b.ResID = " + ResID +"AND res.UserID = u.ID AND " +
                "u.EmployeeID = e.ID ANd e.BranchID = bi.ID";
            var data = HotelDatabase.Database.Query(query);

            if(data.Rows[0]["CancelDate"] != DBNull.Value)
            {
                DateTime cancelDate = Convert.ToDateTime(data.Rows[0]["CancelDate"]);
                panelCancel.Visible = true;
                lblCancel.Text = cancelDate.ToString("MM - dd - yyyy");

            }
               
            
            DateTime checkin = Convert.ToDateTime(data.Rows[0]["StartDate"]);
            DateTime checkout = Convert.ToDateTime(data.Rows[0]["EndDate"]);
            lblCheckinout.Text = checkin.ToString("MM-dd-yyyy") + " / " + checkout.ToString("MM-dd-yyyy");
            lblRoomCount.Text = (checkout - checkin).Days.ToString() +" Days";
            lblRoomNumber.Text = data.Rows[0]["RoomNum"].ToString();
            lblCustName.Text = data.Rows[0]["Firstname"].ToString() + " " + data.Rows[0]["Lastname"].ToString();
            lblCustStateCity.Text = data.Rows[0]["State"].ToString() + ", " + data.Rows[0]["City"].ToString();
            lblCustTel.Text = data.Rows[0]["Mobile"].ToString();
            lblCustEmail.Text = data.Rows[0]["Email"].ToString();
            lblSubtotal.Text = data.Rows[0]["TotalCharge"].ToString();
            lblBillNo.Text = data.Rows[0]["BillNo"].ToString();
            lblRoomAmount.Text = data.Rows[0]["RoomCharge"].ToString();
            lblFoodAmount.Text = data.Rows[0]["FoodCharge"].ToString();
            lblServiceAmount.Text = data.Rows[0]["ServiceCharge"].ToString();
            lblTotal.Text = data.Rows[0]["TotalCharge"].ToString();           
            lblDate.Text =Convert.ToDateTime( data.Rows[0]["BillDate"]).ToString("dd'th' MMM , yyy");
            lblRoomRate.Text = data.Rows[0]["Price"].ToString() + "/D";
            lblHotelName.Text = data.Rows[0]["Bname"].ToString() +" Hotel";       
            lblHotelStateCity.Text = data.Rows[0]["Bstate"].ToString()+", "+ data.Rows[0]["Bcity"].ToString();
            lblHotelTell.Text = data.Rows[0]["Btel"].ToString();
            lblHotelAddress.Text = data.Rows[0]["Baddress"].ToString();         
            lblBottom.Text = lblHotelName.Text + " | " + lblHotelStateCity.Text + " | " + lblHotelTell.Text + " | " + data.Rows[0]["Baddress"].ToString();

            BillID = Convert.ToInt32(data.Rows[0]["Bid"]);
            picLogo.Image = Image.FromStream(new MemoryStream(Current.CurrentUser.Branch.Logo));
            lblDiscount.Text = data.Rows[0]["Discount"].ToString();
            lblTotal.Text =  ConvertDiscount(lblDiscount.Text, lblSubtotal.Text).ToString();
            lblAmount.Text = lblTotal.Text;

            string foodQuery = "Select Count(f.ID) From OrderFood f Where f.ResID = " + ResID;
            var foodData = HotelDatabase.Database.Query(foodQuery);
            if (foodData.Rows[0][0] != DBNull.Value) lblFoodCount.Text = foodData.Rows[0][0].ToString();
            else lblFoodCount.Text = "0";

            //string serviceQuery
            string serviceQuery = "Select Count(s.ID) From OrderService s Where s.ResID = " + ResID;
            var serviceData = HotelDatabase.Database.Query(serviceQuery);
            if (serviceData.Rows[0][0] != DBNull.Value) lblServiceCount.Text = serviceData.Rows[0][0].ToString();
            else lblServiceCount.Text = "0";
        }

        private double ConvertDiscount(string txtDis , string txtSubTotal)
        {
            double dis = Convert.ToDouble(txtDis);
            dis = dis / 100;
            double subTotal = Convert.ToDouble(txtSubTotal);
            if (dis == 0)
            {
                return subTotal;
            }
            else
            {
                subTotal = subTotal - (dis * subTotal);
                return subTotal;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var bmp = Theme.DarkBack(this.ParentForm);
            // put the darkened screenshot into a Panel and bring it to the front:
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                this.ParentForm.Controls.Add(p);
                p.BringToFront();
                // display your dialog somehow:
                //PayDialog payDialog = new PayDialog();
                //payDialog.ShowDialog();
                ////Form frm = new Form();
                //payDialog.StartPosition = FormStartPosition.CenterParent;
                //payDialog.ShowDialog(this);
                using (frmInvoiceEdit edit = new frmInvoiceEdit())
                {
                    edit.ShowDialog();
                    newDiscount = edit.discount;
                    newDescription = edit.description;
                    Current.CurrentUser.Activities.Add(
                        new Activity("Modify Invoice",
                        "invoice No." + lblBillNo.Text + "-" + lblCustName.Text + " has been modified by " + Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname)
                        );
                }
            } // pane

            if (HotelDatabase.Bill.Update(BillID , newDiscount , newDescription))
            {
                lblDiscount.Text = newDiscount.ToString();
               lblTotal.Text =  ConvertDiscount(lblDiscount.Text, lblSubtotal.Text).ToString();
               lblAmount.Text = lblTotal.Text;
                if (newDescription != null)
                {
                    lblNote.Text = newDescription;
                }
            }
        }

        //private string deskTopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //// counter for number of snaps
        //private int snapCount = 0;

        //private void SaveControlImage(Control theControl)
        //{
        //    snapCount++;

        //    Bitmap controlBitMap = new Bitmap(theControl.Width, theControl.Height);
        //    Graphics g = Graphics.FromImage(controlBitMap);
        //    g.CopyFromScreen(PointToScreen(theControl.Location), new Point(0, 0), theControl.Size);

        //    // example of saving to the desktop
        //    controlBitMap.Save(deskTopPath + @"/snap_" + snapCount.ToString() + @".png", ImageFormat.Png);
        //}
        //Form f;
       // panel
        private void btnPay_Click(object sender, EventArgs e)
        {
            // //captureScreen();
            // ScreenCapture sc = new ScreenCapture();
            // // capture entire screen, and save it to a file
            // Image img = sc.CaptureScreen();
            // // display image in a Picture control named imageDisplay
            //// this.imageDisplay.Image = img;
            // // capture this window, and save it
            // sc.CaptureWindowToFile(this.Handle, "E:\\temp2.gif", ImageFormat.Gif);

            //SaveControlImage(this);

            //f = (this.Parent.Parent.Parent.Parent.Parent.Parent) as Form;
            //var g  = this.ParentForm;
            //f = this.ParentForm;

            // take a screenshot of the form and darken it:
            //Bitmap bmp = new Bitmap(this.f.ClientRectangle.Width, this.f.ClientRectangle.Height);
            //using (Graphics G = Graphics.FromImage(bmp))
            //{
            //    G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            //    G.CopyFromScreen(this.f.PointToScreen(new Point(0, 0)), new Point(0, 0), this.f.ClientRectangle.Size);
            //    double percent = 0.60;
            //    Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
            //    using (Brush brsh = new SolidBrush(darken))
            //    {
            //        G.FillRectangle(brsh, this.f.ClientRectangle);
            //    }
            //}
            var bmp = Theme.DarkBack(this.ParentForm);
            // put the darkened screenshot into a Panel and bring it to the front:
            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                this.ParentForm.Controls.Add(p);
                p.BringToFront();

                // display your dialog somehow:
                //PayDialog payDialog = new PayDialog();
                //payDialog.ShowDialog();
                ////Form frm = new Form();
                //payDialog.StartPosition = FormStartPosition.CenterParent;
                //payDialog.ShowDialog(this);
                if (payFlag)
                {
                    PayInfo.custName = lblCustName.Text;
                    PayInfo pi = new PayInfo();
                    pi.ShowDialog();
                }
                else
                {
                    PayDialog.Information.Clear();
                    PayDialog.Information.Add(lblTotal.Text);
                    PayDialog.Information.Add(lblCustName.Text);
                    PayDialog.BillID = BillID;
                    PayDialog payDialog = new PayDialog();
                    payDialog.ShowDialog();
                    if (payDialog.completeAction)
                    {
                        payFlag = true;
                        btnEdit.Enabled = false;
                        btnPay.Text = "Pay Info";
                        Current.CurrentUser.Activities.Add(new Activity("Pay Invoice", "Payment information of invoice No."+lblBillNo.Text+"-"+lblCustName.Text+" has been submited by " + Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));

                    }
                }
            } // panel will be disposed and the form will "lighten" again...


            //Enabled = false;
            //Form shadow = new Form();
            //shadow.MinimizeBox = false;
            //shadow.MaximizeBox = false;
            //shadow.ControlBox = false;
            //shadow.Text = "";
            //shadow.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //shadow.Size = this.Parent.Parent.Size;
            //shadow.BackColor = Color.Black;
            //shadow.Opacity = 0.3;
            //shadow.Show();
            //shadow.Location = this.Parent.Parent.Location;
            //shadow.Enabled = false;
            //// here you should use your own messageBox class!
            //Form msg = new Form();
            //Button btn = new Button() { Text = "OK" };
            //btn.Click += (ss, ee) => { msg.Close(); };
            //msg.Controls.Add(btn);
            //msg.FormClosed += (ss, ee) => { shadow.Close(); Enabled = true; };
            //msg.Size = new System.Drawing.Size(200, 100);
            //msg.StartPosition = FormStartPosition.Manual;
            //msg.Location = new Point(shadow.Left + (shadow.Width - msg.Width) / 2,
            //                         shadow.Top + (shadow.Height - msg.Height) / 2);
            //msg.ShowDialog();
        }
    }
}
