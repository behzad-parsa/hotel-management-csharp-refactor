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
    public partial class EditRole : UserControl
    {
        public EditRole()
        {
            InitializeComponent();
        }

        Dictionary<int, string> dicModules = new Dictionary<int, string>();
        Dictionary<int, string> dicRoles = new Dictionary<int, string>();
        List<int> lstChoosedModuleID = new List<int>();
        List<int> lstModules = new List<int>();
        Dictionary<CheckBox, KeyValuePair<int, string>> dicChb = new Dictionary<CheckBox, KeyValuePair<int, string>>();
        private int RoleID;
        private void LoadData()
        {
            dicRoles = HotelDatabase.Role.GetAllRoles();
            dicModules = HotelDatabase.Module.GetAllModules();

            foreach (var item in dicRoles)
            {

                cmbRole.Items.Add(item.Value);


            }

        }
     
        private void EditRole_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            LoadData();


            //----Access Panel-----------

            for (int i = 1; i < dicModules.Count + 1 ; i++)
            {
                CheckBox chbModule = new CheckBox();
                chbModule.CheckedChanged += new EventHandler(CheckBoxSelected);
                chbModule.AutoSize = false;
                chbModule.Width = 268;
                chbModule.Text = dicModules[i];
                
                if (i != 1) chbModule.Location = new Point(chbModule.Location.X, dicChb.ElementAt(dicChb.Count-1).Key.Location.Y + 40);
                dicChb.Add(chbModule, dicModules.ElementAt(i-1));
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
        

        private void cmbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            //var h = dicRoles.FirstOrDefault(x => x.Value== cmbRole.SelectedItem.ToString()).Key;
            Reset();
            var role = dicRoles.ElementAt(cmbRole.SelectedIndex);
            RoleID = role.Key;
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
   
            //MessageBox.Show(role.Key.ToString());
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int counter = 0;
            if (HotelDatabase.AccessLevel.Delete(RoleID))
            {
                for (int i = 0; i < lstChoosedModuleID.Count; i++)
                {
                    if (HotelDatabase.AccessLevel.Insert(RoleID , lstChoosedModuleID[i]) > 0)
                    {

                        counter++;
                    }



                }
                if (counter == lstChoosedModuleID.Count)
                {

                    PanelStatus(panelStatus, "Completed ", Status.Green);
                }






            }
            else
            {
                //MessageBox.Show()
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
