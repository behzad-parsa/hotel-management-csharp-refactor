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

namespace HotelManagement
{
    public partial class UserDetail : Form
    {
        public int ActorID;
        public int RoleID;
        public int EmployeeID;
        public int UserID;
        public bool deleteEmployee = false;
       
        //public int 
        public UserDetail()
        {
            InitializeComponent();
        }

        private void UserDetail_Load(object sender, EventArgs e)
        {

            var resAct = HotelDatabase.Actor.SearchActorWithID(ActorID);

            var resEmployee = HotelDatabase.Employee.SearchEmployee(ActorID, Current.User.BranchID);
            var resBranch = HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID);

            //var resUser = HotelDatabase.User.SearchUser(EmployeeID);

            if (resAct > 0 && resEmployee)
            {


                lblName.Text = HotelDatabase.Actor.Firstname + " " + HotelDatabase.Actor.Lastname;

                lblNC.Text = HotelDatabase.Actor.NationalCode;
                lblGender.Text = HotelDatabase.Actor.Gender;
                lblBirth.Text = HotelDatabase.Actor.Birthday.Date.ToString("MM / dd / yyyy");
                lblNan.Text = HotelDatabase.Actor.Nationality;
                lblEmail.Text = HotelDatabase.Actor.Email;
                lblHome.Text = HotelDatabase.Actor.Tel;
                lblMobile.Text = HotelDatabase.Actor.Mobile;
                lblStateCity.Text = HotelDatabase.Actor.State + " , " + HotelDatabase.Actor.City;
                lblEducation.Text = HotelDatabase.Employee.Education;
                lblSalary.Text = HotelDatabase.Employee.Salary.ToString();
                lblHire.Text = HotelDatabase.Employee.HireDate.Date.ToString("MM / dd / yyyy") ;
                lblBranch.Text = HotelDatabase.Branch.BranchName;
                lblAddress.Text = HotelDatabase.Actor.Address;




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
                    if (lastSignIn!= DateTime.MinValue) lblLastSignIn.Text = lastSignIn.ToString();
                    else lblLastSignIn.Text = "Not Available";
                    lblUsername.Text = HotelDatabase.User.Username;

                     if (RoleID > 0 )
                     {
                        var Role = HotelDatabase.Role.SearchRoleID(RoleID);
                        var access = HotelDatabase.AccessLevel.SearchAccessLevel(RoleID);
                        if (Role != null) lblRole.Text = Role;
                        var modulList = HotelDatabase.Module.SearchModule(RoleID);
                         if (modulList != null)
                         {
                             for (int i = 0; i < modulList.Count; i++)
                             {
                                    //lblAccessRight.Text += modulList[i] + " | ";
                                 if (i < 3)
                                 {
                                    lblAccessLeft.Text += modulList[i] + " | ";
                                    if (i == 2)
                                    {
                                        lblAccessLeft.Text = lblAccessLeft.Text.Remove(lblAccessLeft.Text.Length - 3);

                                    }
                                 }
                                else
                                {
                                    lblAccessRight.Text += modulList[i] + " | ";
                                    if (i == modulList.Count - 1)
                                    {
                                        lblAccessRight.Text = lblAccessRight.Text.Remove(lblAccessRight.Text.Length - 3);

                                    }
                                }

                             }
                               // if(lblAccessLeft.Text != "") lblAccessLeft.Text = lblAccessLeft.Text.Remove(lblAccessLeft.Text.Length - 3);
                                //if(lblAccessRight.Text != "") lblAccessRight.Text = lblAccessRight.Text.Remove(lblAccessRight.Text.Length - 3);






                         }


                     }


                    //foreach (var item in modulList)
                    //{
                    //    lblAccessLeft.Text += item +" | ";
                    //}

                }
                else
                {


                    panelUser.Visible = false;
                    lblNothing.Visible = true;
                    panelParentUser.Controls.Add(lblNothing);
                    lblNothing.Location = new Point(182, 120);
                    SetProfilePicture(HotelDatabase.Actor.Gender);
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

 

        private void bunifuCustomLabel24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel22_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            ////if (RoleID < 0)
            ////{
            ////    MessageBox.Show("Please Select Row");
            ////}
            //else
            //{


            //}

            var res = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (HotelDatabase.Employee.Delete(EmployeeID))
                {
                    Current.User.Activities.Add(new Activity("Delete a Employee", "the Employee '" + lblName.Text + "' has been deleted by " + Current.User.Firstname + " " + Current.User.Lastname));

                    deleteEmployee = true;
                    this.Dispose();

                    //LoadRoleData();
                    //dgvRole.ClearSelection();
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
                    Current.User.Activities.Add(new Activity("Delete a User", "the User '" + lblName.Text + "-"+lblUsername.Text+"' has been deleted by " + Current.User.Firstname + " " + Current.User.Lastname));

                    this.Dispose();

                    //LoadRoleData();
                    //dgvRole.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
    }
}
