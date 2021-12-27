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
using System.Threading;


namespace HotelManagement
{
    public partial class NewAccount : Form
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        public bool completeFlag = false;




        
        public NewAccount()
        {
            InitializeComponent();
        }

        private void NewAccount_Load(object sender, EventArgs e)
        {
            completeFlag = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
                //lblCustError.Text = text;

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
        private bool TextBoxCheck(BunifuMetroTextbox txtBox, string txt)
        {
            if (txtBox.Text == txt || txtBox.Text == "")
            {
                TextBoxColor(txtBox, Status.Red);
                return false;
            }
            //else if (txt == "National Code")
            //{
            //    TextBoxColor(txtBox, Status.blue);
            //    txtCount++;
            //    return true;
            //}
            else
            {
                TextBoxColor(txtBox, Status.Green);
                txtCount++;
                return true;

            }
        }
        private int txtCount = 0;
        private bool validFlag = false;
        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;


  
            txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            txtBox.ForeColor = Color.Black;
            if (!txtBoxList.ContainsKey(txtBox))
            {
                txtBoxList.Add(txtBox, txtBox.Text);
            }
            txtBoxList.TryGetValue(txtBox, out string defualtText);
            if (txtBox.Text == defualtText)
            {
                txtBox.Text = null;
            }


        }
        private void TextBoxLeave(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;

            if (txtBox.Text == null || txtBox.Text == "")
            {
                txtBoxList.TryGetValue(txtBox, out string defualtText);
                txtBox.Text = defualtText;
                txtBox.ForeColor = Color.Gray;
            }


        }
        private void TextBoxClearText()
        {
            foreach (Control items in panelCustLeft.Controls)
            {

                if (items is BunifuMetroTextbox )
                {
                    string text;
                    var item = items as BunifuMetroTextbox;
                    txtBoxList.TryGetValue(item, out text);

                    items.Text = text;

                }


            }

        }
        private void TextBoxClearBorderColor()
        {

            TextBoxColor(txtAccountName, Status.Green);
            TextBoxColor(txtAccountNumber, Status.Green);
            TextBoxColor(txtBalance, Status.Green);
            TextBoxColor(txtBank, Status.blue);
            TextBoxColor(txtDescription, Status.Green);


        }
        private void btnOk_Click(object sender, EventArgs e)
        {

            TextBoxCheck(txtAccountName, "Account Name");
            TextBoxCheck(txtAccountNumber, "Account Number");
            TextBoxCheck(txtBalance, "Balance");
            TextBoxCheck(txtBank, "Bank");


            if (txtCount == 4)
            {

                validFlag = true;
                if (txtDescription.Text == "Description")
                {
                    txtDescription.Text = null;

                }

            }
            else
            {
                PanelStatus("Please Fill The Blank" , Status.Red);
            }
            txtCount = 0;


            if (validFlag)
            {
                validFlag = false;
                ////----------Change Bracnch ID LAter-------------------
                var result = HotelDatabase.Account.Insert(1, txtAccountName.Text, txtAccountNumber.Text, txtBank.Text, Convert.ToDouble( txtBalance.Text ), txtDescription.Text);
                if (result>0)
                {
                    PanelStatus("Action Completed Successfuly", Status.Green);
                    completeFlag = true;
                    //    Thread.Sleep(3000);
                    //    this.Dispose();

                }

                else
                {
                    PanelStatus("Unable to Complete Action", Status.Red);
                }




            }

            //if (completeFlag)
            //{
            //    Thread.Sleep(3000);
            //    this.Dispose();
            //}


        }

        private void txtBalance_OnValueChanged(object sender, EventArgs e)
        {
            bool isNumeric = int.TryParse(txtBalance.Text, out int res);
            if (isNumeric)
            {
                double balance = Convert.ToDouble(txtBalance.Text);
                if (balance<0)
                {
                    txtBalance.Text = "0";

                }

            }
        }
    }
}
