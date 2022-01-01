using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class PayInfo : Form
    {
        public PayInfo()
        {
            InitializeComponent();
        }
        public static string custName;
        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PayInfo_Load(object sender, EventArgs e)
        {
            string query = "Select b.*  , t.DateModified As Tdate, pm.Title AS PaymentType , a.* , t.* FRom Bill b , Transact t  , PaymentMethod pm , Accounts a " +
                "Where b.id = " + InvoiceDetail.BillID + "And b.TransactionID = t.id ANd " +
                "t.PaymentMethodID = pm.id ANd t.AccountID = a.id";

            var data =  HotelDatabase.Database.Query(query);
   
            lblCust.Text = custName;
            lblPaymentType.Text = data.Rows[0]["PaymentType"].ToString();
            lblAmount2.Text = data.Rows[0]["Amount"].ToString();
            lblTransNum2.Text = data.Rows[0]["TransactionNumber"].ToString();
            lblDatem.Text = data.Rows[0]["Tdate"].ToString();
            lblAccount2.Text = data.Rows[0]["Bank"].ToString() + " - " + data.Rows[0]["AccountName"].ToString() + "(" + data.Rows[0]["AccountNumber"].ToString() + ")";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
