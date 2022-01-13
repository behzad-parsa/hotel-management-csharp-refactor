using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class PayDialog : Form
    {
        private readonly AccountService _accountService;
        private readonly TransactService _transactService;

        private List<Account> branchAccountsList;
        private List<PaymentMethod> paymentMethodsList;
        private readonly List<RadioButton> radioButtonsList;

        public static List<string> Information = new List<string>();
        public static int BillID;
        public bool completeAction = false;
        public PayDialog()
        {
            InitializeComponent();

            _accountService = new AccountService();
            _transactService = new TransactService();

            radioButtonsList = new List<RadioButton>();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void PayDialog_Load(object sender, EventArgs e)
        {
            btnPay.Enabled = true;
            lblAmountPay.Text = Information[0];
            lblCustomerName.Text = Information[1];

            //------ Branch  -------
            branchAccountsList = _accountService.GetAllBranchAccounts(Current.User.BranchID);

            cmbAccount.DataSource = branchAccountsList;
            cmbAccount.DisplayMember = "AccountName";

            paymentMethodsList = _transactService.GetAllPaymentMethods();
            FillPanel(panelPaymentMethod, paymentMethodsList);

        }

        private void FillPanel<T>(Panel panel, List<T> list)
        {
            RadioButton previousRadioButton = null;
            foreach (var item in list)
            {
                RadioButton radioButton = new RadioButton
                {
                    Text = item.GetType().GetProperty("Title").GetValue(item, null) as string,

                };

                if (previousRadioButton != null)
                    radioButton.Location = new Point(
                            previousRadioButton.Location.X,
                            previousRadioButton.Location.Y + 40);

                panel.Controls.Add(radioButton);

                previousRadioButton = radioButton;

                radioButton.CheckedChanged += new EventHandler(RadioButton_CheckedChange);
                radioButtonsList.Add(radioButton);
            }
        }
        private void RadioButton_CheckedChange(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            radioButtonsList.Find(x => x == radioButton).Checked = radioButton.Checked;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            var accountID = branchAccountsList.SingleOrDefault(x => x == cmbAccount.SelectedItem).ID;
            var checkedRadioButton = radioButtonsList.Find(x => x.Checked);
            var paymentMethodID = paymentMethodsList.SingleOrDefault(x => x.Title == checkedRadioButton.Text).ID;
            var amount = Convert.ToDouble(Information[0]);    
           
            //var res =  HotelDatabase.Transact.Insert(accountID, paymentMethodID, 1,txtTransNum.Text, amount, txtDescription.Text);
            var transact = new Transact()
            {
                AccountID = accountID,
                PaymentMethodID = paymentMethodID,
                TransactionTypeID = 1,
                TransactionNumber = txtTransNum.Text,
                Amount = amount,
                Description = txtDescription.Text,
                DateModified = DateTime.Now
            };
            var resultInsert = _transactService.InsertTransact(transact);
            transact.ID = _transactService.LastInsertedId;
            if (resultInsert)
            {
                if (HotelDatabase.Bill.Update(BillID, transact.ID ))
                {
                    InvoiceDetail.TranID = transact.ID;
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
