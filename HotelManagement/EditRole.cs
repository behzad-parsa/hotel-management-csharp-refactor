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
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class EditRole : UserControl
    {
        //Dictionary<int, string> dicModules = new Dictionary<int, string>();
        //Dictionary<int, string> dicRoles = new Dictionary<int, string>();
        private List<Module> modulesList ;
        private List<Role> rolesList;

        private readonly ModuleService _moduleService;
        private readonly RoleService _roleService;
        private readonly AccessLevelService _accessLevelService;

        //List<int> lstChoosedModuleID = new List<int>();
        private List<Module> checkedModulesList;
       // List<int> lstModules = new List<int>();

        //Dictionary<CheckBox, KeyValuePair<int, string>> dicChb = new Dictionary<CheckBox, KeyValuePair<int, string>>();
        private Dictionary<CheckBox, Module> moduleCheckboxesDictionary;

        private int RoleID;

        public EditRole()
        {
            InitializeComponent();

            _moduleService = new ModuleService();
            _roleService = new RoleService();
            _accessLevelService = new AccessLevelService();
        }

        private void LoadData()
        {
            //dicRoles = HotelDatabase.Role.GetAllRoles();
            //dicModules = HotelDatabase.Module.GetAllModules();
            modulesList = _moduleService.GetAllModules();
            rolesList = _roleService.GetAllRoles();
            moduleCheckboxesDictionary = new Dictionary<CheckBox, Module>();
            checkedModulesList = new List<Module>();
            //foreach (var item in dicRoles)
            //{
            //    cmbRole.Items.Add(item.Value);
            //}
            cmbRole.DataSource = rolesList;
            cmbRole.DisplayMember = "Title";
        }
     
        private void EditRole_Load(object sender, EventArgs e)
        {
            

            btnSave.Enabled = false;
            LoadData();

            //----Access Panel-----------

            for (int i = 1; i < modulesList.Count + 1 ; i++)
            {
                CheckBox chbModule = new CheckBox();
                chbModule.CheckedChanged += new EventHandler(CheckBoxSelected);
                chbModule.AutoSize = false;
                chbModule.Width = 268;
                chbModule.Text = modulesList[i].Title;
                
                if (i != 1) 
                    chbModule.Location = new Point(
                        chbModule.Location.X, 
                        moduleCheckboxesDictionary.ElementAt(moduleCheckboxesDictionary.Count-1).Key.Location.Y + 40);
                
                //moduleCheckboxesDictionary.Add(chbModule, dicModule.ElementAt(i-1));
                moduleCheckboxesDictionary.Add(chbModule, modulesList[i-1]);
                panelAccess.Controls.Add(chbModule);
            }
        }
        

        private void cmbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            Reset();

            //var role = dicRoles.ElementAt(cmbRole.SelectedIndex);
            var role = rolesList.SingleOrDefault(r=> r == cmbRole.SelectedItem);
            RoleID = role.ID;
            //lstModules = HotelDatabase.AccessLevel.SearchAccessLevel(RoleID);
            var roleAuhoritiesList = _accessLevelService.GetRoleAuthorities(RoleID);
            if (roleAuhoritiesList != null)
            {
                for (int i = 0; i < moduleCheckboxesDictionary.Count; i++)
                {
                    var module = moduleCheckboxesDictionary.ElementAt(i).Value;
                    //var id = module.Key;
                    //var res = lstModules.Contains(id);
                    //var result = roleAuhoritiesList.SingleOrDefault(m=>m == module)
                    if (roleAuhoritiesList.Contains(module))
                    {
                        var chb = moduleCheckboxesDictionary.ElementAt(i).Key;
                        chb.Checked = true;
                    }
                }
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
            moduleCheckboxesDictionary.TryGetValue(checkBox, out Module module);
            
            if (checkBox.Checked)
            {
                checkedModulesList.Add(module);
            }
            else
            {
               checkedModulesList.Remove(module);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int counter = 0;

            //if (HotelDatabase.AccessLevel.Delete(RoleID))
            if (_accessLevelService.DeleteAccessLevel(RoleID))
            {
                for (int i = 0; i < checkedModulesList.Count; i++)
                {
                    var accessLevel = new AccessLevel()
                    {
                        RoleID = RoleID,
                        ModuleID = checkedModulesList[i].ID
                    };
                    //if (HotelDatabase.AccessLevel.Insert(RoleID , lstChoosedModuleID[i]) > 0)
                    if (_accessLevelService.InsertAccessLevel(accessLevel))
                    {
                        counter++;
                    }
                }
                if (counter == checkedModulesList.Count)
                {
                    PanelStatus(panelStatus, "Completed ", Status.Green);
                }
            }
            else
            {
                PanelStatus(panelStatus, "Failed -- Delete", Status.Red);
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
    }
}
