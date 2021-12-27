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
    public partial class PayDialog : Form
    {
        public static List<string> Information = new List<string>();
        public static int BillID;
        public bool completeAction = false;
        public PayDialog()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //this.Dispose();
            this.Close();
        }

        Dictionary<int, string> lstAccount = new Dictionary<int, string>();
        Dictionary<int, string> lstPay = new Dictionary<int, string>();
        private void PayDialog_Load(object sender, EventArgs e)
        {

            btnPay.Enabled = true;


            lblAmountPay.Text = Information[0];
            lblCustomerName.Text = Information[1];

            ///------ BranchID -------
            lstAccount = HotelDatabase.Account.GetAccountList(1);
            foreach (var item in lstAccount)
            {
                cmbAccount.Items.Add(item.Value);
            }


            lstPay = HotelDatabase.Transact.GetPaymentMethod();
            int counter = 0;
            List<RadioButton> lstRadioButton = new List<RadioButton>();
            foreach (var item in lstPay)
            {
                
                RadioButton rdb = new RadioButton();
                rdb.Text = item.Value;
                rdb.CheckedChanged += new EventHandler(RadioButtonActive);
    
                panelPaymentMethod.Controls.Add(rdb);
                if (counter > 0)
                {
                    rdb.Location = new Point(lstRadioButton[lstRadioButton.Count - 1].Location.X , lstRadioButton[lstRadioButton.Count - 1].Location.Y + 40);


                }
                lstRadioButton.Add(rdb);
                counter++;
            }


        }
        private string checkedValue;
        private void RadioButtonActive(object sender , EventArgs e)
        {
            var rdb = sender as RadioButton;

            if (rdb.Checked)
            {

                checkedValue = rdb.Text;
            }

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var accountID = lstAccount.FirstOrDefault(x => x.Value == cmbAccount.SelectedItem.ToString()).Key;
            var paymentMethodID = lstPay.FirstOrDefault(x => x.Value == checkedValue).Key;
            //string txtDes;
            //string txtTransNumber;
            //if (txtTransNum.Text == null || txtTransNum.Text == "")
            //{
            //    txtTransNumber = DBNull.Value;

            //}
            var amount = Convert.ToDouble(Information[0]);

           // HotelDatabase.Transact.Insert(accountID, paymentMethodID, 1, HotelDatabase.Database.CheckNullInsert(txtTransNum.Text)  , amount , HotelDatabase.Database.CheckNullInsert(txtDescription));

           var res =  HotelDatabase.Transact.Insert(accountID, paymentMethodID, 1,txtTransNum.Text, amount, txtDescription.Text);

            if (res>0)
            {

                if (HotelDatabase.Bill.Update(BillID, res))
                {
                    InvoiceDetail.TranID = res;
                    lblStatus.Visible = true;
                    lblStatus.Text = "Successful";
                    lblStatus.ForeColor = Color.SpringGreen;
                    btnPay.Enabled = false;
                    completeAction = true;
                }
                else
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Failed";
                    lblStatus.ForeColor = Color.Red;
                }
               
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Failed";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
