using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class UserDetail : Form
    {
        public int ActorID;
        public int RoleID;
        public int EmployeeID;
        public int UserID;
        public bool deleteEmployee = false;
        private readonly ActorService _actorService;
        private readonly BranchService _branchService;
        private readonly EmployeeService _employeeService;
        private readonly RoleService _roleService;
        private readonly AccessLevelService _accessLevelService;
        private readonly ModuleService _moduleService;
        public UserDetail()
        {
            InitializeComponent();
            _actorService = new ActorService();
            _branchService = new BranchService();
            _employeeService = new EmployeeService();
            _roleService = new RoleService();
            _accessLevelService = new AccessLevelService();
            _moduleService = new ModuleService();
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {
            //var resAct = actor.SearchActorWithID(ActorID);
            var actor = _actorService.GetActor(ActorID);
            //var resEmployee = HotelDatabase.Employee.SearchEmployee(ActorID, Current.User.BranchID);
            var employee = _employeeService.GetEmployee(ActorID, Current.CurrentUser.BranchID);
            //var resBranch = HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID);
            var branch = _branchService.GetBranch(Current.CurrentUser.BranchID);
            //if (resAct > 0 && resEmployee)
            if (actor != null && employee != null)
            {
                lblName.Text = actor.Firstname + " " + actor.Lastname;
                lblNC.Text = actor.NationalCode;
                lblGender.Text = actor.Gender;
                lblBirth.Text = actor.Birthday.Date.ToString("MM / dd / yyyy");
                lblNan.Text = actor.Nationality;
                lblEmail.Text = actor.Email;
                lblHome.Text = actor.Tel;
                lblMobile.Text = actor.Mobile;
                lblStateCity.Text = actor.State + " , " + actor.City;
                lblEducation.Text = employee.Education;
                lblSalary.Text = employee.Salary.ToString();
                lblHire.Text = employee.HireDate.Date.ToString("MM / dd / yyyy") ;
                lblBranch.Text = branch.BranchName;
                lblAddress.Text = actor.Address;


                //if (modulList != null)
                //{
                //    for (int i = 0; i < modulList.Count; i++)
                //    {
                //        lblAccessRight.Text += modulList[i] + " | ";
                //        if (i < 3)
                //        {
                //            lblAccessLeft.Text += modulList[i] + " | ";
                //            if (i == 2)
                //            {
                //                lblAccessLeft.Text = lblAccessLeft.Text.Remove(lblAccessLeft.Text.Length - 3);

                //            }
                //        }
                //        else
                //        {
                //            lblAccessRight.Text += modulList[i] + " | ";
                //            if (i == modulList.Count - 1)
                //            {
                //                lblAccessRight.Text = lblAccessRight.Text.Remove(lblAccessRight.Text.Length - 3);

                //            }
                //        }

                    //}

                if (UserID > 0 )
                {
                    
                    var resUser = HotelDatabase.User.SearchUser(EmployeeID);
                    picPhoto.Image = Image.FromStream(new MemoryStream(HotelDatabase.User.Image));
                    ActivatePic(HotelDatabase.User.Activate);

                    var lastSignIn = HotelDatabase.User.GetLastSignin(UserID);
                    if (lastSignIn!= DateTime.MinValue) 
                        lblLastSignIn.Text = lastSignIn.ToString();
                    else 
                        lblLastSignIn.Text = "Not Available";

                    lblUsername.Text = HotelDatabase.User.Username;

                     if (RoleID > 0 )
                     {
                        //var Role = HotelDatabase.Role.SearchRoleID(RoleID);
                        var role = _roleService.GetRole(RoleID);
                        //var access = HotelDatabase.AccessLevel.SearchAccessLevel(RoleID);
                        //var accessLevle = HotelDatabase.AccessLevel.SearchAccessLevel(RoleID);
                        if (role != null) 
                            lblRole.Text = role.Title;

                        //var modulList = HotelDatabase.Module.SearchModule(RoleID);
                        var moduleList = _accessLevelService.GetRoleAuthorities(RoleID);
                         //if (modulList != null)
                         if (moduleList != null)
                         {
                             for (int i = 0; i < moduleList.Count; i++)
                             {
                                 if (i < 3)
                                 {
                                    lblAccessLeft.Text += moduleList[i] + " | ";
                                    if (i == 2)
                                    {
                                        lblAccessLeft.Text = lblAccessLeft.Text.Remove(lblAccessLeft.Text.Length - 3);
                                    }
                                 }
                                else
                                {
                                    lblAccessRight.Text += moduleList[i] + " | ";
                                    if (i == moduleList.Count - 1)
                                    {
                                        lblAccessRight.Text = lblAccessRight.Text.Remove(lblAccessRight.Text.Length - 3);
                                    }
                                }

                             }   
                         }
                     }
                }
                else
                {
                    panelUser.Visible = false;
                    lblNothing.Visible = true;
                    panelParentUser.Controls.Add(lblNothing);
                    lblNothing.Location = new Point(182, 120);
                    SetProfilePicture(actor.Gender);
                    lblRole.Text = "Not Available";
                }                   
            }
        }

        private void ActivatePic(bool value)
        {
            if (value)
            {
                picActivate.Image = Properties.Resources.check;
            }
            else
            {
                picActivate.Image = Properties.Resources.close__1_;
            }
        }

        private void SetProfilePicture(string gender)
        {
            if (gender == "Male")
            {
                picPhoto.Image = Properties.Resources.employee_Profilemale;
            }
            else
            {
                picPhoto.Image = Properties.Resources.user;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {

            var dialogResult = MessageBox.Show(
                "Are You Sure You Want To Delete This Record ?", 
                "Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );

            if (dialogResult == DialogResult.Yes)
            {
                var resultDeleteEmployee = _employeeService.DeleteEmployee(EmployeeID);
                if (resultDeleteEmployee)
                {
                    Current.CurrentUser.Activities.Add(
                        new Activity("Delete a Employee", "the Employee '" + lblName.Text + "' has been deleted by " +
                        Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname)
                        );
                    deleteEmployee = true;
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (HotelDatabase.User.Delete(UserID))
                {
                    deleteEmployee = true;
                    Current.CurrentUser.Activities.Add(
                            new Activity("Delete a User", "the User '" + lblName.Text + "-"+ 
                            lblUsername.Text+"' has been deleted by " + Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname)
                        );
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
