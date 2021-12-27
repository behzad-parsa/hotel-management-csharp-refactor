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
    public partial class ActionFood : Form
    {
        public int FoodID;
        public bool completeActionFlag = false;
        private bool addFlag;

        public enum Action
        {
            Add ,
            Edit
        }

        public ActionFood(Action action)
        {
            InitializeComponent();


            if (action == Action.Add)
            {
                addFlag = true;
                panelTop.BackColor = Color.FromArgb(67, 176, 92);
                btnSave.Text = "Submit";
                btnSave.BackColor = Color.FromArgb(67, 176, 92);
                picIcon.Image = Properties.Resources._392530_48;
                lblTitle.Text = "New";
            }
            else
            {
                addFlag = false;
                panelTop.BackColor = Color.FromArgb(77, 182, 172);
                btnSave.Text = "Save";
                btnSave.BackColor = Color.FromArgb(77, 182, 172);
                picIcon.Image = Properties.Resources._326602_32;
                lblTitle.Text = "Edit";
            }
            
        }

        private void ActionFood_Load(object sender, EventArgs e)
        {

            //-------------Load Edit ------------------
            if (!addFlag)
            {
                if (HotelDatabase.Food.SearchFood(FoodID))
                {
                    txtTitle.Text = HotelDatabase.Food.Title;
                    txtPrice.Text = HotelDatabase.Food.Price.ToString();
                    txtDecription.Text = HotelDatabase.Food.Description;
                }
                else
                {
                    PanelStatus("Unable To Complete Action", Status.Red);
                }
            }
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

        private int txtCount = 0;
        private bool validationFlag = false;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            //---Validation----
            TextBoxCheck(txtPrice, "");
            TextBoxCheck(txtTitle, "");


            if (txtCount == 2) 
            {
                bool isNumric = int.TryParse(txtPrice.Text, out int num);
                if (isNumric)
                {
                    validationFlag = true;
                }
                else
                {
                    PanelStatus("Price Must Be Numeric", Status.Red);
                }   
            }
            else
            {
                PanelStatus("Please Fill The Blank", Status.Red);
            }
            txtCount = 0;



            if (validationFlag)
            {
                validationFlag = false;

                //------- Add Part ------------
                if (addFlag)
                {
                    var res = HotelDatabase.Food.Insert(txtTitle.Text, Convert.ToInt32(txtPrice.Text), txtDecription.Text);

                    if (res>0)
                    {

                        PanelStatus("Action Completed Successfully", Status.Green);
                        completeActionFlag = true;
                        this.Dispose();

                    }
                    else
                    {
                        completeActionFlag = false;
                        PanelStatus("Unable To Complete Action --- Insert", Status.Red);
                    }
                }
                //----------  Edit Part -----------
                else
                {
                    if (HotelDatabase.Food.Update(FoodID , txtTitle.Text, Convert.ToInt32(txtPrice.Text), txtDecription.Text))
                    {
                        PanelStatus("Action Completed Successfully", Status.Green);
                        completeActionFlag = true;
                        this.Dispose();
                    }
                    else
	                {
                        completeActionFlag = false;
                        PanelStatus("Unable To Complete Action --- Update", Status.Red);
                    }
                }
            }
        }


        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
            txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            txtBox.ForeColor = Color.Black;
        }

        private void TextBoxLeave(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
        }
    }
}
