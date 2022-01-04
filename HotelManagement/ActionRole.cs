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
    public partial class ActionRole : Form
    {
        private readonly RoleService _roleService;
        private readonly ModuleService _moduleService;
        private readonly AccessLevelService _accessLevelService;

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

            _accessLevelService = new AccessLevelService();
            _moduleService = new ModuleService();
            _roleService = new RoleService();

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


        //Dictionary<int, string> dicAllModules = new Dictionary<int, string>();
        private List<Module> modulesList;
        //Dictionary<int, string> dicRoles = new Dictionary<int, string>();
        //List<int> lstChoosedModuleID = new List<int>();
        private List<Module> checkedModulesList;
        //List<int> lstModules = new List<int>();
        private List<Module> roleAuthoritiesList ;


        //Dictionary<CheckBox, KeyValuePair<int, string>> dicChb = new Dictionary<CheckBox, KeyValuePair<int, string>>();
        private Dictionary<CheckBox, Module> checkBoxesDictionary;

        private void ActionRole_Load(object sender, EventArgs e)
        {
            //dicAllModules = HotelDatabase.Module.GetAllModules();
            checkBoxesDictionary = new Dictionary<CheckBox, Module>();
            modulesList = _moduleService.GetAllModules();
            checkedModulesList = new List<Module>();
            //----Access Panel-----------

            //for (int i = 1; i < dicAllModules.Count + 1; i++)
            //{
            //    CheckBox chbModule = new CheckBox();
            //    chbModule.CheckedChanged += new EventHandler(CheckBoxSelected);
            //    chbModule.AutoSize = false;
            //    chbModule.Width = 268;
            //    chbModule.Text = dicAllModules[i];

            //    if (i != 1) chbModule.Location = new Point(chbModule.Location.X, dicChb.ElementAt(dicChb.Count - 1).Key.Location.Y + 50);
            //    dicChb.Add(chbModule, dicAllModules.ElementAt(i - 1));
            //    if (i < Math.Ceiling((double)dicAllModules.Count / 2) + 1) panelLeft.Controls.Add(chbModule);
            //    else
            //    {
            //        //chbModule.Location = new Point(chbModule.Location.X, dicChb.ElementAt(0).Key.Location.Y);
            //        if (i == Math.Ceiling((double)dicAllModules.Count / 2) + 1) chbModule.Location = new Point(chbModule.Location.X, 0);
            //        panelRight.Controls.Add(chbModule);
            //    }

            //}
            for (int i = 1; i < modulesList.Count + 1; i++)
            {
                CheckBox chbModule = new CheckBox();
                chbModule.CheckedChanged += new EventHandler(CheckBoxSelected);
                chbModule.AutoSize = false;
                chbModule.Width = 268;
                chbModule.Text = modulesList[i].Title;
                
                if (i != 1) 
                    chbModule.Location = new Point(
                        chbModule.Location.X, 
                        checkBoxesDictionary.ElementAt(checkBoxesDictionary.Count - 1).Key.Location.Y + 50
                        );
                   // chbModule.Location = new Point(chbModule.Location.X, modulesList[modulesList-1].lo );
                                                                           
                checkBoxesDictionary.Add(chbModule, modulesList[i - 1]);
                
                if (i < Math.Ceiling((double)modulesList.Count / 2) + 1) 
                    panelLeft.Controls.Add(chbModule);
                else
                {
                    
                    if (i == Math.Ceiling((double)modulesList.Count / 2) + 1) 
                        chbModule.Location = new Point(chbModule.Location.X, 0);
                    
                    panelRight.Controls.Add(chbModule);
                }

            }

            //---------Edit
            if (!addFlag)
            {
                var role = _roleService.GetRole(RoleID);
                //if (HotelDatabase.Role.SearchRoleID(RoleID) != null)
                if (role != null)
                {
                    //txtRole.Text = HotelDatabase.Role.Title;
                    txtRole.Text = role.Title;

                    //var role = dicRoles.ElementAt(RoleID);
                    //RoleID = role.Key;

                    //lstModules = HotelDatabase.AccessLevel.SearchAccessLevel(RoleID);
                    roleAuthoritiesList = _accessLevelService.GetRoleAuthorities(RoleID);
                    if(roleAuthoritiesList != null) //(lstModules != null)
                    {
                        for (int i = 0; i < checkBoxesDictionary.Count; i++)
                        {
                            var module = checkBoxesDictionary.ElementAt(i).Value;
                            //var id = module.ID;
                            //var res = lstModule.Contains(id);
                            //var res = roleAuthoritiesList.Contains(id);
                            if (roleAuthoritiesList.Contains(module))//(res)
                            {
                                var checkBox = checkBoxesDictionary.ElementAt(i).Key;
                                checkBox.Checked = true;
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
            //checkBoxesDictionary.TryGetValue(checkBox, out KeyValuePair<int, string> temp);
            checkBoxesDictionary.TryGetValue(checkBox, out Module module);
            //var id = temp.key;
            if (checkBox.Checked)
            {
                checkedModulesList.Add(module);
            }
            else
            {
                checkedModulesList.Remove(module);
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
                if (checkedModulesList.Count != 0)
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
                    var role = new Role()
                    {
                        Title = txtRole.Text
                    };
                    var resultInsertRole = _roleService.InsertRole(role);
                    if (resultInsertRole)
                    {

                        for (int i = 0; i < checkedModulesList.Count; i++)
                        {
                            AccessLevel accessLevel = new AccessLevel()
                            {
                                RoleID = _roleService.LastInsertedId,
                                ModuleID = checkedModulesList[i].ID
                            };
                            //if (HotelDatabase.AccessLevel.Insert(_roleService.LastInsertedId , checkedModuleLists[i]) >0)
                            if (_accessLevelService.InsertAccessLevel(accessLevel))
                            {
                                counter++;
                            }
                        }
                        if (counter == checkedModulesList.Count)
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
                    //if (HotelDatabase.AccessLevel.Delete(RoleID))
                    if (_accessLevelService.DeleteAccessLevel(RoleID))
                    {
                        for (int i = 0; i < checkedModulesList.Count; i++)
                        {
                            AccessLevel accessLevel = new AccessLevel()
                            {
                                RoleID = RoleID,
                                ModuleID = checkedModulesList[i].ID
                            };
                            //if (HotelDatabase.AccessLevel.Insert(RoleID, checkedModulesList[i]) > 0)
                            if (_accessLevelService.InsertAccessLevel(accessLevel))
                            {
                                counter++;
                            }
                        }
                        if (counter == checkedModulesList.Count)
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
