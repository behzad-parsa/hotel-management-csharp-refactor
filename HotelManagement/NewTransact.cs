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

namespace HotelManagement
{
    public partial class NewTransact : Form
    {
        public bool completeFlag = false ;
        Dictionary<int, string> lstAccount = new Dictionary<int, string>();
        Dictionary<int, string> lstPaymentType = new Dictionary<int, string>();
        Dictionary<int, string> lstTranactionType = new Dictionary<int, string>();

        public NewTransact()
        {
            InitializeComponent();
        }

        private void NewTransact_Load(object sender, EventArgs e)
        {
            //----cmb Account | Branch Later ------

            lstAccount = HotelDatabase.Account.GetAccountList(1);
            foreach (var item in lstAccount)
            {
                cmbAccount.Items.Add(item.Value);
            }
            //----- PaymentMethod ---------------------
            
            lstPaymentType = HotelDatabase.Transact.GetPaymentMethod();
            FillPanel(panelPaymentMethod, lstPaymentType, false);

            //int counter = 0;
            //List<RadioButton> lstRadioButton = new List<RadioButton>();
            //foreach (var item in lstPaymentType)
            //{
            //    RadioButton rdb = new RadioButton();
            //    rdb.Text = item.Value;
            //    rdb.CheckedChanged += new EventHandler(RadioButtonActivePay);
            //    panelPaymentMethod.Controls.Add(rdb);
            //    if (counter > 0)
            //    {
            //        rdb.Location = new Point(lstRadioButton[lstRadioButton.Count - 1].Location.X, lstRadioButton[lstRadioButton.Count - 1].Location.Y + 40);
            //    }
            //    lstRadioButton.Add(rdb);
            //    counter++;
            //}


            //TransactionType
            lstTranactionType = HotelDatabase.Transact.GetTransactionType();
            FillPanel(panelType, lstTranactionType, true);
            //int counter2 = 0;
            //List<RadioButton> lstRadioButton2 = new List<RadioButton>();
            //foreach (var item in lstTranactionType)
            //{

            //    RadioButton rdb = new RadioButton();
            //    rdb.Text = item.Value;
            //    rdb.CheckedChanged += new EventHandler(RadioButtonActiveTrans);

            //    panelType.Controls.Add(rdb);
            //    if (counter2 > 0)
            //    {
            //        rdb.Location = new Point(lstRadioButton2[lstRadioButton2.Count - 1].Location.X, lstRadioButton2[lstRadioButton2.Count - 1].Location.Y + 40);


            //    }
            //    lstRadioButton2.Add(rdb);
            //    counter2++;
            //}
        }

        private void FillPanel(Panel panel , Dictionary<int ,string> lst , bool isType)
        {
            int counter = 0;
            List<RadioButton> lstRadioButton = new List<RadioButton>();

            foreach (var item in lst)
            {
                RadioButton rdb = new RadioButton();
                rdb.Text = item.Value;
                if (isType)
                {
                    rdb.CheckedChanged += new EventHandler(RadioButtonActiveTrans);
                }
                else
                {
                    rdb.CheckedChanged += new EventHandler(RadioButtonActivePay);
                }
                
                panel.Controls.Add(rdb);
                if (counter > 0)
                {
                    rdb.Location = new Point(lstRadioButton[lstRadioButton.Count - 1].Location.X, lstRadioButton[lstRadioButton.Count - 1].Location.Y + 40);
                }
                lstRadioButton.Add(rdb);
                counter++;
            }
        }

        private string checkedValuePaymentType;
        private string checkValueTransType;
        private void RadioButtonActivePay(object sender, EventArgs e)
        {
            var rdb = sender as RadioButton;

            if (rdb.Checked)
            {
                checkedValuePaymentType  = rdb.Text;
            }
        }

        private void RadioButtonActiveTrans(object sender, EventArgs e)
        {
            var rdb = sender as RadioButton;

            if (rdb.Checked)
            {
                checkValueTransType = rdb.Text;
            }
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
                //lblCustError.Text = text;
            }
            else
            {
                prgbCustError.ProgressColor = Color.Blue;
                lblCustError.ForeColor = Color.Blue;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
        private void btnOk_Click(object sender, EventArgs e)
        {
            //---Validation

            if (txtAmount.Text != null && txtAmount.Text != "")
            {
                bool isNumeric = double.TryParse(txtAmount.Text, out double num);

                if (isNumeric)
                {
                    validationFlag = true;
                }
                else
                {
                    PanelStatus("Amount Must Be Numric" , Status.Red);
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
                var accountID = lstAccount.FirstOrDefault(x => x.Value == cmbAccount.SelectedItem.ToString()).Key;
                var paymentMethodID = lstPaymentType.FirstOrDefault(x => x.Value == checkedValuePaymentType).Key;
                var transactionTypeID = lstTranactionType.FirstOrDefault(x => x.Value == checkValueTransType).Key;
                var res = HotelDatabase.Transact.Insert(accountID, paymentMethodID, transactionTypeID, txtTransNum.Text, Convert.ToDouble(txtAmount.Text), txtDescription.Text);
                if (res>0)
                {
                    PanelStatus("Action Completed Successfuly", Status.Green);
                    completeFlag = true;
                }
                else
                {
                    PanelStatus("Unable to Complete Action", Status.Red);
                }
            }
        }
    }
}
