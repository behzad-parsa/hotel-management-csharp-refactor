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
    public partial class NewEmployee : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        Dictionary<int, string> dicBranch = new Dictionary<int, string>();
        private int ActIDofEmployee;

        public NewEmployee()
        {
            InitializeComponent();
        }
     
        private void NewEmployee_Load(object sender, EventArgs e)
        {          
            cmbEmpNational.SelectedIndex = 0;
            cmbEmpState.SelectedIndex = 0;
            dateEmpBirth.Value = DateTime.Now;
            dateHireEmp.Value = DateTime.Now;
            panelBasic.Enabled = false;
            panelEmployment.Enabled = false;
            panelContact.Enabled = false;
            dicBranch = HotelDatabase.Branch.GetAllBranch();

            foreach (var item in dicBranch)
            {
                cmbBranch.Items.Add(item.Value);            
            }

            dicBranch.TryGetValue(Current.User.BranchID, out string branchName);
            cmbBranch.SelectedItem = branchName;
        }

        private enum Status
        {
            Green,
            Red,
            blue
        };
        
        private void PanelStatus(Control Panel , string text, Status status)
        {
            BunifuCircleProgressbar prgb  = null;
            BunifuCustomLabel lbl =null;
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

        private int txtCount = 0;
        private bool ValidationFlag = false;
        private bool isFindActor = false;

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;

            if (txtBox != txtNCSearch)
            {
                txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            }

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

        private string RadioButtonResult(RadioButton rdb1, RadioButton rdb2)
        {
            if (rdb1.Checked)
            {
                return rdb1.Text;
            }
            else
            {
                return rdb2.Text;
            }
        }
       
        private void TextBoxClearBorderColor()
        {
            TextBoxColor(txtEmpFname, Status.Green);
            TextBoxColor(txtEmpLname, Status.Green);
            TextBoxColor(txtEmpMobile, Status.Green);
            TextBoxColor(txtEmpCity, Status.Green);
            TextBoxColor(txtEmpEmail, Status.Green);
            TextBoxColor(txtEmpAddress, Status.Green);
            TextBoxColor(txtEmpTel, Status.Green);
            TextBoxColor(txtEducation, Status.Green);
            TextBoxColor(txtSalary, Status.Green);
        }


        private void Reset()
        {
            txtEmpFname.Text = "Firstname";
            txtEmpFname.ForeColor = Color.Gray;

            txtEmpLname.Text = "Lastname";
            txtEmpLname.ForeColor = Color.Gray;

            txtEmpMobile.Text = "Mobile Phone";
            txtEmpMobile.ForeColor = Color.Gray;

            txtEmpCity.Text = "City";
            txtEmpCity.ForeColor = Color.Gray;

            txtEmpEmail.Text = "Email";
            txtEmpEmail.ForeColor = Color.Gray;

            txtEmpAddress.Text = "Address";
            txtEmpAddress.ForeColor = Color.Gray;

            txtEmpTel.Text = "Home Phone";
            txtEmpTel.ForeColor = Color.Gray;

            txtEducation.Text = "Education";
            txtEducation.ForeColor = Color.Gray;

            txtSalary.Text = "Salary";
            txtSalary.ForeColor = Color.Gray;

            dateEmpBirth.Value = DateTime.Now.Date;
            dateHireEmp.Value = DateTime.Now;

            TextBoxClearBorderColor();
            ChbUpdate(false);
            ActID = -10;
            EmployeeID = -10;
        }

        private int ActID = -10;
        private int EmployeeID = -10;
        private bool isFindEmployee = false;
        private void btnEmpSearch_Click(object sender, EventArgs e)
        {
        }

        private void btnEmpSubmit_Click(object sender, EventArgs e)
        {
        }

        private void btnEmpInfoSubmit_Click(object sender, EventArgs e)
        {         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {      
            panelStatusEmployee.Visible = false;
            Reset();

            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
            {
                searchFlag = true;

                if (HotelDatabase.Actor.SearchActor(txtNCSearch.Text))
                {
                    isFindActor = true;
                    ActID = HotelDatabase.Actor.ID;
                    txtEmpFname.Text = HotelDatabase.Actor.Firstname;
                    txtEmpLname.Text = HotelDatabase.Actor.Lastname;
                    txtEmpTel.Text = HotelDatabase.Actor.Tel;
                    txtEmpMobile.Text = HotelDatabase.Actor.Mobile;
                    txtEmpCity.Text = HotelDatabase.Actor.City;
                    txtEmpAddress.Text = HotelDatabase.Actor.Address;
                    txtEmpEmail.Text = HotelDatabase.Actor.Email;
                    cmbEmpNational.SelectedItem = HotelDatabase.Actor.Nationality;
                    cmbEmpState.SelectedItem = HotelDatabase.Actor.State;

                    if (HotelDatabase.Actor.Gender == "Male") rdbEmpMale.Checked = true;
                    else rdbEmpFemale.Checked = true;

                    dateEmpBirth.Value = HotelDatabase.Actor.Birthday;

                    if (HotelDatabase.Employee.SearchEmployee(ActID))
                    {
                        isFindEmployee = true;

                        EmployeeID = HotelDatabase.Employee.ID;
                       
                        txtEducation.Text = HotelDatabase.Employee.Education;
                        txtSalary.Text = HotelDatabase.Employee.Salary.ToString();
                        dateHireEmp.Value = HotelDatabase.Employee.HireDate;

                        dicBranch.TryGetValue(HotelDatabase.Employee.BranchID, out string branchName);
                        cmbBranch.SelectedItem = branchName ;
                        
                        PanelStatus(panelStatusEmployee, "Employee Was Successfully Found", Status.Green);
                        ChbUpdate(true);
                        panelBasic.Enabled = true;
                        panelContact.Enabled = true;
                        panelEmployment.Enabled = true;
                    }
                    else
                    {
                        isFindEmployee = false;
                        PanelStatus(panelStatusEmployee, "Person Was Successfully Found", Status.Green);
                        ChbUpdate(false);
                        panelBasic.Enabled = false;
                        panelContact.Enabled = false;
                        panelEmployment.Enabled = true;
                    }
                }
                else
                {
                    //panelInfo.Enabled = false;
                    isFindActor = false;
                    isFindEmployee = false;
                    Reset();
                    panelBasic.Enabled = true;
                    panelContact.Enabled = true;
                    panelEmployment.Enabled = true;
                    PanelStatus(panelStatusEmployee , "No Person Found", Status.Red);
                }
            }
        }

        private bool updateFlag = false;
        private void ChbUpdate(bool status)
        {
            if (status)
            {
                panelUpdate.Visible = true;
                updateFlag = true;
                btnSubmitEmployee.Text = "Save";
            }
            else
            {
                panelUpdate.Visible = false;
                updateFlag = false;
                btnSubmitEmployee.Text = "Submit";
            }
        }

        private bool searchFlag = false;
        private void btnSubmitEmployee_Click(object sender, EventArgs e)
        {
            if (searchFlag && !isFindActor)
            {
                TextBoxCheck(txtEmpFname, "Firstname");
                TextBoxCheck(txtEmpLname, "Lastname");
                TextBoxCheck(txtEmpMobile, "Mobile Phone");
                TextBoxCheck(txtEmpCity, "City");
                TextBoxCheck(txtEmpEmail, "Email");
                TextBoxCheck(txtEmpAddress, "Address");
                TextBoxCheck(txtEmpTel, "Home Phone");
                TextBoxCheck(txtEducation, "Education");
                TextBoxCheck(txtSalary, "Salary");

                if (txtCount == 9 && txtNCSearch.Text != "" && txtNCSearch.Text != "National Code")
                {
                    if (dateEmpBirth.Value.Date != DateTime.Now.Date)
                    {
                        ValidationFlag = true;
                    }
                    else
                    {
                        PanelStatus(panelStatusEmployee ,  "Choose Birthday", Status.Red);
                    }
                }
                else
                {
                    PanelStatus(panelStatusEmployee, "Please Fill The Blank", Status.Red);
                }

                txtCount = 0;
                if (ValidationFlag)
                {
                    ValidationFlag = false;
                    var result = HotelDatabase.Actor.InsertAll(txtEmpFname.Text, txtEmpLname.Text, dateEmpBirth.Value.Date,
                     txtNCSearch.Text, cmbEmpNational.SelectedItem.ToString(), txtEmpEmail.Text, txtEmpTel.Text,
                     txtEmpMobile.Text, RadioButtonResult(rdbEmpMale, rdbEmpFemale), cmbEmpState.SelectedItem.ToString(), txtEmpCity.Text, txtEmpAddress.Text);
                    if (result > 0)
                    {
                        ActID = result;
                        var branch = dicBranch.ElementAt(cmbBranch.SelectedIndex);
                        int employeeResult = HotelDatabase.Employee.Insert(ActID, branch.Key, txtEducation.Text, dateHireEmp.Value.Date, Convert.ToInt32(txtSalary.Text));
                        if (employeeResult > 0)
                        {
                            PanelStatus(panelStatusEmployee, "Action Completed Seccessfully", Status.Green);
                            panelBasic.Enabled = false;
                            panelContact.Enabled = false;
                            panelEmployment.Enabled = false;
                            EmployeeID = employeeResult;
                            searchFlag = false;

                            Current.User.Activities.Add(new Activity("submit New Employee", "the Employee '"+txtEmpFname.Text+" " + txtEmpLname.Text+"' has been submited by " + Current.User.Firstname + " " + Current.User.Lastname));
                        }
                        else
                        {
                            PanelStatus(panelStatusEmployee, "Unable To Complete Action", Status.Red);
                        }
                    }
                    else
                    {
                        PanelStatus(panelStatusEmployee, "Unable to Complete Action - National Code Exist Already", Status.Red);
                    }
                }           
            }
            else if (isFindActor && !isFindEmployee)
            {
                TextBoxCheck(txtEducation, "Education");
                TextBoxCheck(txtSalary, "Salary");

                if (txtCount == 2)
                {
                    ValidationFlag = true;
                }
                else
                {
                    PanelStatus(panelStatusEmployee, "Please Fill The Blank", Status.Red);
                }

                txtCount = 0;
                if (ValidationFlag)
                {

                    ValidationFlag = false;
                    var branch = dicBranch.ElementAt(cmbBranch.SelectedIndex);
                    int employeeResult = HotelDatabase.Employee.Insert(ActID, branch.Key , txtEducation.Text, dateHireEmp.Value.Date, Convert.ToInt32(txtSalary.Text));
                    if (employeeResult > 0)
                    {                     
                        PanelStatus(panelStatusEmployee, "Action Completed Seccessfully", Status.Green);
                        Current.User.Activities.Add(new Activity("submit New Employee", "the Employee '" + txtEmpFname.Text + " " + txtEmpLname.Text + "' has been submited by " + Current.User.Firstname + " " + Current.User.Lastname));
                        panelEmployment.Enabled = false;
                        searchFlag = false;
                    }
                    else
                    {
                        PanelStatus(panelStatusEmployee, "Unable To Complete Action", Status.Red);
                    }
                }
            }
            else if (isFindActor && isFindEmployee)
            {
                //Update Mode
                TextBoxCheck(txtEmpFname, "Firstname");
                TextBoxCheck(txtEmpLname, "Lastname");
                TextBoxCheck(txtEmpMobile, "Mobile Phone");
                TextBoxCheck(txtEmpCity, "City");
                TextBoxCheck(txtEmpEmail, "Email");
                TextBoxCheck(txtEmpAddress, "Address");
                TextBoxCheck(txtEmpTel, "Home Phone");
                TextBoxCheck(txtEducation, "Education");
                TextBoxCheck(txtSalary, "Salary");

                if (txtCount == 9 && txtNCSearch.Text != "" && txtNCSearch.Text != "National Code")
                {
                    if (dateEmpBirth.Value.Date != DateTime.Now.Date)
                    {
                        ValidationFlag = true;
                    }
                    else
                    {
                        PanelStatus(panelStatusEmployee, "Choose Birthday", Status.Red);
                    }
                }
                else
                {
                    PanelStatus(panelStatusEmployee, "Please Fill The Blank", Status.Red);
                }

                txtCount = 0;
                if (ValidationFlag)
                {

                    ValidationFlag = false;

                    var result = HotelDatabase.Actor.UpdateAll(ActID , txtEmpFname.Text, txtEmpLname.Text, dateEmpBirth.Value.Date,
                    txtNCSearch.Text, cmbEmpNational.SelectedItem.ToString(), txtEmpEmail.Text, txtEmpTel.Text,
                    txtEmpMobile.Text, RadioButtonResult(rdbEmpMale, rdbEmpFemale), cmbEmpState.SelectedItem.ToString(), txtEmpCity.Text, txtEmpAddress.Text);

                    if (result)
                    {
                        var branch = dicBranch.ElementAt(cmbBranch.SelectedIndex);
                        var resultSecond = HotelDatabase.Employee.Update(EmployeeID, ActID, branch.Key, txtEducation.Text, dateHireEmp.Value, Convert.ToInt32(txtSalary.Text));
                        if (resultSecond)
                        {
                            PanelStatus(panelStatusEmployee, "Information Changed Successfully", Status.Green);
                            isFindActor = false;
                            isFindEmployee = false;
                            searchFlag = false;
                            panelBasic.Enabled = false;
                            panelContact.Enabled = false;
                            panelEmployment.Enabled = false;

                            Current.User.Activities.Add(
                                new Activity("Edit Employee Information", 
                                "the Employee '" + txtEmpFname.Text + " " + txtEmpLname.Text + "'s information has been changed by " + Current.User.Firstname + " " + Current.User.Lastname));
                        }
                        else
                        {
                            PanelStatus(panelStatusEmployee, "Unable To Complete Action", Status.Red);
                        }
                    }
                    else
                    {
                        PanelStatus(panelStatusEmployee, "Unable To Complete Action", Status.Red);
                    }
                }
            }
        }
    }
}
