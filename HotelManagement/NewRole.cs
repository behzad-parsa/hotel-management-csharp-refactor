using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;



namespace HotelManagement
{
    public partial class NewRole : UserControl
    {
        public NewRole()
        {
            InitializeComponent();
        }

        Dictionary<int, string> dicAllModules = new Dictionary<int, string>();
        //Dictionary<int, string> dicRoles = new Dictionary<int, string>();
        List<int> lstChoosedModuleID = new List<int>();
        List<int> lstModules = new List<int>();
        Dictionary<CheckBox, KeyValuePair<int, string>> dicChb = new Dictionary<CheckBox, KeyValuePair<int, string>>();
        private int RoleID;






        private void NewRole_Load(object sender, EventArgs e)
        {
            dicAllModules = HotelDatabase.Module.GetAllModules();




            //----Access Panel-----------

            for (int i = 1; i < dicAllModules.Count + 1; i++)
            {
                CheckBox chbModule = new CheckBox();
                chbModule.CheckedChanged += new EventHandler(CheckBoxSelected);
                chbModule.AutoSize = false;
                chbModule.Width = 268;
                chbModule.Text = dicAllModules[i];

                if (i != 1) chbModule.Location = new Point(chbModule.Location.X, dicChb.ElementAt(dicChb.Count - 1).Key.Location.Y + 40);
                dicChb.Add(chbModule, dicAllModules.ElementAt(i - 1));
                panelAccess.Controls.Add(chbModule);
                //lstCheckBox.Add(chbModule);
                //if (i < 12) panelLeftFacility.Controls.Add(chbModule);
                //else
                //{
                //    if (i == 12) chbModule.Location = new Point(chbModule.Location.X, lstCheckBox[0].Location.Y);
                //    panelRightFacility.Controls.Add(chbModule);
                //}
            }



        }





        private void Reset()
        {
            foreach (var item in panelAccess.Controls)
            {
                if (item is CheckBox)
                {
                    var chb = item as CheckBox;
                    chb.Checked = false;

                }

            }
        }
        private void CheckBoxSelected(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            //  var id = dicModules.FirstOrDefault(x => x.Value == checkBox.Text).Key;
            dicChb.TryGetValue(checkBox, out KeyValuePair<int, string> temp);
            var id = temp.Key;
            if (checkBox.Checked)
            {


                lstChoosedModuleID.Add(id);


            }
            else
            {

                lstChoosedModuleID.Remove(id);



            }



        }









        private enum Status
        {
            Green,
            Red,
            blue
        };

        private void PanelStatus(Control Panel, string text, Status status)
        {
            BunifuCircleProgressbar prgb = null;
            BunifuCustomLabel lbl = null;
            Panel.Visible = true;
            foreach (Control item in Panel.Controls)
            {
                if (item is BunifuCustomLabel)
                {
                    lbl = item as BunifuCustomLabel;

                }
                else
                {
                    prgb = item as BunifuCircleProgressbar;

                }

            }

            lbl.Text = text;
            if (status == Status.Red)
            {
                prgb.ProgressColor = Color.Red;
                lbl.ForeColor = Color.Red;


            }
            else if (status == Status.Green)
            {

                prgb.ProgressColor = Color.Green;
                lbl.ForeColor = Color.Green;


            }
            else
            {
                prgb.ProgressColor = Color.Blue;
                lbl.ForeColor = Color.Blue;

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

        private void btnSub_Click(object sender, EventArgs e)
        {
            TextBoxCheck(txtRole , "");

            if (txtCount ==1)
            {

                validationFlag = true;


            }
            else
            {
                PanelStatus(panelStatus, "Please Fill The Blank", Status.Red);
            }
            txtCount = 0;

            if (validationFlag)
            {
                int counter = 0;
                validationFlag = false;
                var res = HotelDatabase.Role.Insert(txtRole.Text);
                if (res>0)
                {
                    for (int i = 0; i <  lstChoosedModuleID.Count; i++)
                    {

                        if (HotelDatabase.AccessLevel.Insert(res , lstChoosedModuleID[i]) >0)
                        {


                            counter++;
                        }
                        if (counter == lstChoosedModuleID.Count)
                        {
                            PanelStatus(panelStatus, "Completed ", Status.Green);

                        }
                        else
                        {
                            PanelStatus(panelStatus, "Failed", Status.Red);
                        }

                    }
                    


                }
                else
                {
                    PanelStatus(panelStatus, "Failed -- Insert", Status.Red);
                }

            }




        }
    }
}
