using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class EditTransact : Form
    {
        private readonly AccountService _accountService;
        private readonly TransactService _transactService;

        public int transID;
        public bool completeFlag = false;

        private List<Account> branchAccountsList;
        private List<PaymentMethod> paymentMethodsList;
        private List<TransactionType> transactionTypesList;
        
        private readonly List<RadioButton> radioButtonsList;
        public EditTransact()
        {
            InitializeComponent();

            _accountService = new AccountService();
            _transactService = new TransactService();

            radioButtonsList = new List<RadioButton>();
        }

        private void EditTransact_Load(object sender, EventArgs e)
        {
            //-------- Branch ----------------------------
            branchAccountsList = _accountService.GetAllBranchAccounts(Current.CurrentUser.BranchID);

            cmbAccount.DataSource = branchAccountsList;
            cmbAccount.DisplayMember = "AccountName";

            // PaymentMethod ---------------------
            paymentMethodsList = _transactService.GetAllPaymentMethods();
            FillPanel(panelPaymentMethod , paymentMethodsList);

            //TransactionType ----------------------------
            transactionTypesList = _transactService.GetAllTransactionTypes();
            FillPanel(panelType , transactionTypesList);

            var transact = _transactService.GetTransact(transID);

            if (transact != null)
            {
                txtAmount.Text = transact.Amount.ToString();
                txtTransNum.Text = transact.TransactionNumber ?? string.Empty;
                txtDescription.Text = transact.Description ?? string.Empty;

                var account = branchAccountsList.SingleOrDefault(x => x.ID == transact.AccountID);
                cmbAccount.SelectedItem = account;


                var paymentMethod = paymentMethodsList.SingleOrDefault(x => x.ID == transact.PaymentMethodID);
                var paymentRadioButton = radioButtonsList.Find(x => x.Text == paymentMethod.Title);
                paymentRadioButton.Checked = true;


                var transactionType = transactionTypesList.Find(x => x.ID == transact.TransactionTypeID);
                var transactTypeRadioButton = radioButtonsList.Find(x => x.Text == transactionType.Title);
                transactTypeRadioButton.Checked = true;              
            }            
        }

        private void FillPanel<T>(Panel panel, List<T> list)
        {
            RadioButton previousRadioButton = null ;
            foreach (var item in list)
            {
                RadioButton radioButton = new RadioButton
                {
                    Text = item.GetType().GetProperty("Title").GetValue(item, null) as string,
                    //Location = new Point()
                };
                
                if(previousRadioButton != null)
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

        private enum Status
        {
            Green,
            Red,
            blue
        };
        private void PanelStatus(string text, Status status)
        {
            panelCustStatus.Visible = true;
            lblCustError.Text = text;
            if (status == Status.Red)
            {
                prgbCustError.ProgressColor = Color.Red;
                lblCustError.ForeColor = Color.Red;
            }
            else if (status == Status.Green)
            {

                prgbCustError.ProgressColor = Color.Green;
                lblCustError.ForeColor = Color.Green;
            }
            else
            {
                prgbCustError.ProgressColor = Color.Blue;
                lblCustError.ForeColor = Color.Blue;
            }
        }

        private void TextBoxColor(BunifuMetroTextbox txtBox, Status status)
        {
            if (status == Status.Red)
            {
                txtBox.BorderColorIdle = Color.Red;
            }
            else if (status == Status.Green)
            {
                txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            }
            else
            {
                txtBox.BorderColorIdle = Color.FromArgb(128, 128, 128);
            }
        }
        private int txtCount;
        private bool validationFlag = false;

        private bool TextBoxCheck(BunifuMetroTextbox txtBox, string txt)
        {
            if (txtBox.Text == txt || txtBox.Text == "")
            {
                TextBoxColor(txtBox, Status.Red);
                return false;
            }
            else
            {
                TextBoxColor(txtBox, Status.Green);
                txtCount++;
                return true;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //--------   Validation     
            if (txtAmount.Text != null && txtAmount.Text != "")
            {
                bool isNumeric = double.TryParse(txtAmount.Text, out double num);
                if (isNumeric)
                {
                    validationFlag = true;
                }
                else
                {
                    PanelStatus("Amount Must Be Numric", Status.Red);
                }
            }
            else
            {
                TextBoxCheck(txtAmount, "");
                PanelStatus("Please Fill The Blank", Status.Red);
            }

            if (validationFlag)
            {
                validationFlag = false;

                var accountID = branchAccountsList.SingleOrDefault(x => x == cmbAccount.SelectedItem).ID;
                //Technincally We have Two Active Radio Button : one in paymentMethods Another on TransactionsType
                //First , paymentMethods Fill and the Second, transactionType fill the RadioButtonLists , So the order is fixed  
                var checkedRadioButtons = radioButtonsList.FindAll(x => x.Checked); 
                var paymentMethodID = paymentMethodsList.SingleOrDefault(x => x.Title == checkedRadioButtons[0].Text).ID; 
                var transactionTypeID = transactionTypesList.SingleOrDefault(x => x.Title == checkedRadioButtons[1].Text).ID;

                var transact = new Transact()
                {
                    ID = transID,
                    AccountID = accountID,
                    PaymentMethodID = paymentMethodID,
                    TransactionTypeID = transactionTypeID,
                    TransactionNumber = txtTransNum.Text,
                    Amount = Convert.ToDouble(txtAmount.Text),
                    Description = txtDescription.Text,
                    DateModified = DateTime.Now
                };
                var resultUpdate = _transactService.UpdateTransact(transact);
                if (resultUpdate)
                {
                    PanelStatus("Action Completed Successfuly", Status.Green);
                    completeFlag = true;
                    this.Dispose();
                }
                else
                {
                    PanelStatus("Unable to Complete Action", Status.Red);
                }
            }
        }
    }
}
