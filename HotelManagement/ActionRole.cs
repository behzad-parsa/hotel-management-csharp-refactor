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
    public partial class ActionRole : Form
    {

        public int RoleID;

        public bool completeActionFlag = false;
        private bool addFlag;
        public enum Action
        {
            Add,
            Edit
        }
        public ActionRole(Action action)
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


        Dictionary<int, string> dicAllModules = new Dictionary<int, string>();
        Dictionary<int, string> dicRoles = new Dictionary<int, string>();
        List<int> lstChoosedModuleID = new List<int>();
        List<int> lstModules = new List<int>();
        Dictionary<CheckBox, KeyValuePair<int, string>> dicChb = new Dictionary<CheckBox, KeyValuePair<int, string>>();

        private void ActionRole_Load(object sender, EventArgs e)
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

                if (i != 1) chbModule.Location = new Point(chbModule.Location.X, dicChb.ElementAt(dicChb.Count - 1).Key.Location.Y + 50);
                dicChb.Add(chbModule, dicAllModules.ElementAt(i - 1));
                if (i < Math.Ceiling((double)dicAllModules.Count / 2) + 1) panelLeft.Controls.Add(chbModule);
                else
                {
                    //chbModule.Location = new Point(chbModule.Location.X, dicChb.ElementAt(0).Key.Location.Y);
                    if (i == Math.Ceiling((double)dicAllModules.Count / 2) + 1) chbModule.Location = new Point(chbModule.Location.X, 0);
                    panelRight.Controls.Add(chbModule);
                }
                //lstCheckBox.Add(chbModule);
                //if (i < 12) panelLeftFacility.Controls.Add(chbModule);
                //else
                //{
                //    if (i == 12) chbModule.Location = new Point(chbModule.Location.X, lstCheckBox[0].Location.Y);
                //    panelRightFacility.Controls.Add(chbModule);
                //}
            }
            //---------Edit
            if (!addFlag)
            {
                if (HotelDatabase.Role.SearchRoleID(RoleID) != null)
                {

                    txtRole.Text = HotelDatabase.Role.Title;

                    //var role = dicRoles.ElementAt(RoleID);
                    //RoleID = role.Key;
                    lstModules = HotelDatabase.AccessLevel.SearchAccessLevel(RoleID);
                    if (lstModules != null)
                    {
                        for (int i = 0; i < dicChb.Count; i++)
                        {
                            var module = dicChb.ElementAt(i).Value;
                            var id = module.Key;
                            var res = lstModules.Contains(id);
                            if (res)
                            {
                                var chb = dicChb.ElementAt(i).Key;
                                chb.Checked = true;
                            }

                        }
                    }

                }



            }
            
        }





        private void Reset()
        {
            foreach (var item in panelLeft.Controls)
            {
                if (item is CheckBox)
                {
                    var chb = item as CheckBox;
                    chb.Checked = false;

                }

            }
            foreach (var item in panelRight.Controls)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            TextBoxCheck(txtRole, "");
            
            if (txtCount == 1)
            {
                if (lstChoosedModuleID.Count != 0)
                {
                    validationFlag = true;
                }
                else
                {
                    PanelStatus(panelCustStatus , "Access level Not Specified", Status.Red);
                }
            }
            else
            {
                PanelStatus(panelCustStatus,"Please Fill The Blank", Status.Red);

            }
            txtCount = 0;

            if (validationFlag)
            {
                validationFlag = false;
                
                //------- Add Part ------------
                if (addFlag)
                {
                    int counter = 0;
                    var res = HotelDatabase.Role.Insert(txtRole.Text);

                    if (res > 0)
                    {

                        for (int i = 0; i < lstChoosedModuleID.Count; i++)
                        {
                            if (HotelDatabase.AccessLevel.Insert(res , lstChoosedModuleID[i]) >0)
                            {
                                counter++;
                            }
                        }
                        if (counter == lstChoosedModuleID.Count)
                        {
                            PanelStatus(panelCustStatus, "Action Completed Successfully", Status.Green);
                            completeActionFlag = true;
                            this.Dispose();
                        }
                        else
                        {
                            completeActionFlag = false;
                            PanelStatus(panelCustStatus, "Failed - InsertA", Status.Red);
                        }
                    }
                    else
                    {
                        completeActionFlag = false;
                        PanelStatus(panelCustStatus, "Failed --- InsertR", Status.Red);
                    }
                }
                //---------- The Edit Part -----------
                else
                {
                    int counter = 0;
                    if (HotelDatabase.AccessLevel.Delete(RoleID))
                    {
                        for (int i = 0; i < lstChoosedModuleID.Count; i++)
                        {
                            if (HotelDatabase.AccessLevel.Insert(RoleID, lstChoosedModuleID[i]) > 0)
                            {
                                counter++;
                            }
                        }
                        if (counter == lstChoosedModuleID.Count)
                        {

                            PanelStatus(panelCustStatus, "Completed ", Status.Green);       
                            completeActionFlag = true;
                            this.Dispose();
                        }
                    }
                    else
                    {
                        PanelStatus(panelCustStatus, "Failed -- Delete", Status.Red);
                    }
                }

            }
        }
    }
}
