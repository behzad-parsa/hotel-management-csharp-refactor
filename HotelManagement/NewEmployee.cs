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
using HotelManagement.Services;
using HotelManagement.Models;

namespace HotelManagement
{
    public partial class NewEmployee : UserControl
    {

        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();

        private readonly ActorService _actorService;
        private readonly BranchService _branchService;
        private List<Branch> branches;
        private readonly EmployeeService _employeeService;
        public NewEmployee()
        {
            InitializeComponent();

            _actorService = new ActorService();
            _branchService = new BranchService();
            
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

            branches = _branchService.GetAllBranches();

            cmbBranch.DataSource = branches;
            cmbBranch.DisplayMember = "BranchName";
            
            var branch = branches.Find(x => x.ID == Current.User.BranchID);
            cmbBranch.SelectedItem = branch.BranchName ;
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
        
        private void btnSearch_Click(object sender, EventArgs e)
        {      
            panelStatusEmployee.Visible = false;
            Reset();

            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
            {
                searchFlag = true;
                var actor = _actorService.GetActor(txtNCSearch.Text);
                if (actor != null)//hotelmanametn.dfdf.SearchActor(txtNCSearch.Text))
                {
                    isFindActor = true;
                    ActID = actor.ID;
                    txtEmpFname.Text = actor.Firstname;
                    txtEmpLname.Text = actor.Lastname;
                    txtEmpTel.Text = actor.Tel;
                    txtEmpMobile.Text = actor.Mobile;
                    txtEmpCity.Text = actor.City;
                    txtEmpAddress.Text = actor.Address;
                    txtEmpEmail.Text = actor.Email;
                    cmbEmpNational.SelectedItem = actor.Nationality;
                    cmbEmpState.SelectedItem = actor.State;

                    if (actor.Gender == "Male") 
                        rdbEmpMale.Checked = true;
                    else 
                        rdbEmpFemale.Checked = true;

                    dateEmpBirth.Value = actor.Birthday;

                    var employee = _employeeService.GetEmployee(ActID);
                    if (employee != null)
                    {
                        isFindEmployee = true;

                        EmployeeID = employee.ID;
                        txtEducation.Text = employee.Education;
                        txtSalary.Text = employee.Salary.ToString();
                        dateHireEmp.Value = employee.HireDate;

                        //dicBranch.TryGetValue(HotelDatabase.Employee.BranchID, out string branchName);
                        //cmbBranch.SelectedItem = branchName ;                       

                        var branch = branches.Find(x => x.ID == employee.BranchID);
                        cmbBranch.SelectedItem = branch.BranchName;

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

                    Actor actor = new Actor()
                    {
                        Firstname = txtEmpFname.Text,
                        Lastname = txtEmpLname.Text,
                        Birthday = dateEmpBirth.Value.Date,
                        NationalCode = txtNCSearch.Text,
                        Nationality = cmbEmpNational.SelectedItem.ToString(),
                        Email = txtEmpEmail.Text,
                        Tel = txtEmpTel.Text,
                        Mobile = txtEmpMobile.Text,
                        Gender = RadioButtonResult(rdbEmpMale, rdbEmpFemale),
                        State = cmbEmpState.SelectedItem.ToString(),
                        City = txtEmpCity.Text,
                        Address = txtEmpAddress.Text
                    };
                    var resultActor = _actorService.InsertActor(actor);

                    if (resultActor) 
                    {
                        ActID = _actorService.LastInsertedId;

                        var branch = branches.SingleOrDefault(x => x == cmbBranch.SelectedItem);
                        //int employeeResult = HotelDatabase.Employee.Insert(ActID, branch.ID, txtEducation.Text, dateHireEmp.Value.Date, Convert.ToInt32(txtSalary.Text));
                        Employee employee = new Employee()
                        {
                            ActID = ActID,
                            BranchID = branch.ID,
                            Education = txtEducation.Text,
                            HireDate = dateHireEmp.Value.Date,
                            Salary = Convert.ToInt32(txtSalary.Text)

                        };

                        var employeeResult = _employeeService.InsertEmployee(employee);

                        if (employeeResult)
                        {
                            PanelStatus(panelStatusEmployee, "Action Completed Seccessfully", Status.Green);
                            panelBasic.Enabled = false;
                            panelContact.Enabled = false;
                            panelEmployment.Enabled = false;
                            //EmployeeID = employeeResult;
                            EmployeeID =_employeeService.LastInsertedId ;
                            searchFlag = false;

                            Current.User.Activities.Add(
                                new Activity("submit New Employee", "the Employee '"+txtEmpFname.Text +" " +
                                txtEmpLname.Text+"' has been submited by " + Current.User.Firstname + " " + Current.User.Lastname)
                                );
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

                    var branch = branches.SingleOrDefault(x => x == cmbBranch.SelectedItem);
                   // int employeeResult = HotelDatabase.Employee.Insert(ActID, branch.ID, txtEducation.Text, dateHireEmp.Value.Date, Convert.ToInt32(txtSalary.Text));
                    Employee employee = new Employee()
                    {
                        ActID = ActID,
                        BranchID = branch.ID,
                        Education = txtEducation.Text,
                        HireDate = dateHireEmp.Value.Date,
                        Salary = Convert.ToInt32(txtSalary.Text)
                    };
                    
                    var employeeResult = _employeeService.InsertEmployee(employee);
                    if (employeeResult)
                    {                     
                        PanelStatus(panelStatusEmployee, "Action Completed Seccessfully", Status.Green);
                        Current.User.Activities.Add(
                            new Activity(
                                "submit New Employee", "the Employee '" + txtEmpFname.Text + " " + 
                                txtEmpLname.Text + "' has been submited by " + 
                                Current.User.Firstname + " " + Current.User.Lastname)
                            );
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
                //-------- Update Mode ------------------------------------------------
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

                    Actor actor = new Actor()
                    {
                        ID = ActID,
                        Firstname = txtEmpFname.Text,
                        Lastname = txtEmpLname.Text,
                        Birthday = dateEmpBirth.Value.Date,
                        NationalCode = txtNCSearch.Text,
                        Nationality = cmbEmpNational.SelectedItem.ToString(),
                        Email = txtEmpEmail.Text,
                        Tel = txtEmpTel.Text,
                        Mobile = txtEmpMobile.Text,
                        Gender = RadioButtonResult(rdbEmpMale, rdbEmpFemale),
                        State = cmbEmpState.SelectedItem.ToString(),
                        City = txtEmpCity.Text,
                        Address = txtEmpAddress.Text
                    };
                    var resultUpdateActor = _actorService.UpdateActor(actor); 

                    if (resultUpdateActor)
                    {
                        var branch = branches.SingleOrDefault(x => x == cmbBranch.SelectedItem);
                        //var resultSecond = HotelDatabase.Employee.Update(EmployeeID, ActID, branch.ID, txtEducation.Text, dateHireEmp.Value, Convert.ToInt32(txtSalary.Text));
                        var employee = new Employee()
                        {
                            ID = EmployeeID,
                            ActID = ActID,
                            BranchID = branch.ID,
                            Education = txtEducation.Text,
                            HireDate = dateHireEmp.Value , 
                            Salary = Convert.ToInt32(txtSalary.Text)
                        };
                        var resultUpdate = _employeeService.UpdateEmployee(employee);
                        if (resultUpdate)
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
