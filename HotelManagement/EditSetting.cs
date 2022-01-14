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
using HotelManagement.Services;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class EditSetting : Form
    {
        private readonly UserService _userService;

        public bool compeletFlag = false;
        public string username;
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        public EditSetting()
        {
            InitializeComponent();

            _userService = new UserService();
        }

        private void EditSetting_Load(object sender, EventArgs e)
        {
            txtUsername.Text = Current.CurrentUser.Username;
            btnSave.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void brnSave_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "" && txtUsername.Text != null && txtUsername.Text != Current.CurrentUser.Username)
            {
                var user = _userService.GetUser(txtUsername.Text);
                if (user is null)
                {
                    if (Current.CurrentUser.UpdateUsername(txtUsername.Text))
                    {
                        PanelStatus("Information Change Successfully", Status.Green);
                        username = txtUsername.Text;
                        compeletFlag = true;
                    }
                    else
                    {
                        PanelStatus("Unabel To Complete Action", Status.Red);
                    }                
                }
                else
                {
                    PanelStatus("Username Is Taken , Try Another", Status.Red);
                }       
            }
            else
            {
                TextBoxCheck(txtUsername, "");
                PanelStatus("Please Fill The Blank", Status.Red);
            }

            if (txtPass.Text != null  && txtPass.Text != "")
            {
                if (txtConfirmPass.Text != null && txtConfirmPass.Text != "")
                {
                    if (txtConfirmPass.Text ==  txtPass.Text)
                    {
                        HashPassword hp = new HashPassword();
                        if (Current.CurrentUser.UpdatePassword(hp.ConvertPass(txtPass.Text)))
                        {
                            PanelStatus("Information Change Successfully", Status.Green);
                            compeletFlag = true;
                        }
                        else
                        {
                            PanelStatus("Unabel To Complete Action", Status.Red);
                        }
                    }
                    else
                    {
                        TextBoxCheck(txtConfirmPass, "");
                        TextBoxCheck(txtPass, "");
                        PanelStatus("The passwords Not Match", Status.Red);
                    }
                }
                else
                {
                    TextBoxCheck(txtConfirmPass, "");
                    PanelStatus("Please Fill The Blank", Status.Red);
                }
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

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtPass_OnValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

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
                txtBox.ForeColor = Color.DarkGray;
            }
        }
    }
}
