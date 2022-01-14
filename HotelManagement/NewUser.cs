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
using System.IO;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class NewUser : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        private readonly ActorService _actorService;
        private readonly BranchService _branchService;
        private readonly EmployeeService _employeeService;
        private readonly RoleService _roleService;
        private readonly UserService _userService;
        public NewUser()
        {
            InitializeComponent();

            _actorService = new ActorService();
            _branchService = new BranchService();
            _employeeService = new EmployeeService();
            _roleService = new RoleService();
            _userService = new UserService();
        }
        private void LoadRoleData()
        {
            string query = "Select role.id as Rid , ROW_NUMBER() over (Order By role.id) as # , Title  FRom Role";
            var data = HotelDatabase.Database.Query(query);

            dgvRole.DataSource = data;
            dgvRole.Columns["#"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvRole.Columns["Rid"].Visible = false;
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            LoadRoleData();
            EmployeeLabels(false);
        }

        private void SetProfilePicture(string gender , PictureBox pic)
        {
            if (gender == "Male")
            {
                pic.Image = Properties.Resources.employee_Profilemale;
            }
            else
            {
                pic.Image = Properties.Resources.user;
            }
        }

        
        private void btnSetPhoto_Click(object sender, EventArgs e)
        {
            picFileDialog.Filter = "Image Files (jpg , png , bmp ) | *.jpg;*.png;*.bmp |All Files |*.*";

            if (picFileDialog.ShowDialog() == DialogResult.OK)
            {
                picUser.Image = Image.FromFile(picFileDialog.FileName);
            }
        }

        private byte[] ConvertPicToByte(Image img)
        {
            MemoryStream Ms = new MemoryStream();
            img.Save(Ms, img.RawFormat);
            return Ms.GetBuffer();
        }

        private void EmployeeLabels(bool isFind)
        {
            if (!isFind)
            {
                lblNothing.Location = new Point(64, 227);
                lblNothing.Visible = true;
            }
            else
            {
                lblNothing.Visible = false;
            }
            foreach (var item in panelEmployee.Controls)
            {
                if (item is BunifuCustomLabel)
                {
                    var lbl = item as BunifuCustomLabel;
                    lbl.Visible = isFind;
                }
            }
        }

        private void btnSubmitUser_Click(object sender, EventArgs e)
        {
            if (isFindEmployee)
            {
                if (!updateFlag)
                {
                    //--------- Insert ---------------------------------------------
                    TextBoxCheck(txtUsername, "Username");
                    TextBoxCheck(txtPassword, "Password");
                    TextBoxCheck(txtConPass, "Confirm Password");

                    if (txtCount == 3)
                    {
                        if (txtPassword.Text != txtConPass.Text)
                        {
                            PanelStatus(panelStatusUser, "Password Not Match", Status.Red);
                            TextBoxColor(txtPassword, Status.Red);
                            TextBoxColor(txtConPass, Status.Red);
                        }
                        else
                        {
                            TextBoxColor(txtPassword, Status.Green);
                            TextBoxColor(txtConPass, Status.Green);
                            if (SelectedRoleID > 0)
                            {
                                ValidationFlag = true;
                            }
                            else
                            {
                                PanelStatus(panelStatusUser, "Role Not Selected", Status.Red);
                            }
                        }
                    }
                    else
                    {
                        PanelStatus(panelStatusUser, "Please Fill The Blank", Status.Red);
                    }
                    txtCount = 0;

                    if (ValidationFlag)
                    {
                        ValidationFlag = false;
                        var searchedUser = _userService.GetUser(txtUsername.Text.Trim().ToLower());
                        if (searchedUser is null)
                        {
                            HashPassword hashPassword = new HashPassword();
                            //var res = HotelDatabase.User.Insert(EmployeeID, SelectedRoleID, txtUsername.Text.Trim().ToLower(), hashPassword.ConvertPass(txtPassword.Text), ConvertPicToByte(picUser.Image), chbActive.Checked);
                            var user = new User()
                            {
                                EmployeeID = EmployeeID,
                                RoleID = SelectedRoleID,
                                Username = txtUsername.Text.Trim().ToLower(),
                                Password = hashPassword.ConvertPass(txtPassword.Text),
                                Image = ConvertPicToByte(picUser.Image),
                                Activate = chbActive.Checked
                            };
                            var resultInsertUser = _userService.InsertUser(user);
                            if (resultInsertUser)
                            {
                                PanelStatus(panelStatusUser, "Action Completed Successfully ", Status.Green);
                                panelInfo.Enabled = false;
                                Current.CurrentUser.Activities.Add(
                                    new Activity("submit New User", 
                                    "the User '"+ txtUsername.Text+"' has been submited by " + 
                                    Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));
                            }
                            else
                            {
                                PanelStatus(panelStatusUser, "Unable To Complete Action ", Status.Red);
                            }
                        }
                        else
                        {
                            PanelStatus(panelStatusUser, "Username Is Available", Status.Red);
                        }
                    }
                }
                else
                {
                    //update
                    TextBoxCheck(txtUsername, "Username");
                    bool passFlag = false;

                    if (txtCount == 1)
                    {
                        if (txtPassword.Text != "Password" || txtConPass.Text != "Confirm Password")
                        {                          
                            if (txtPassword.Text != txtConPass.Text)
                            {
                                PanelStatus(panelStatusUser, "Password Not Match", Status.Red);
                                TextBoxColor(txtPassword, Status.Red);
                                TextBoxColor(txtConPass, Status.Red);
                            }
                            else
                            {
                                TextBoxColor(txtPassword, Status.Green);
                                TextBoxColor(txtConPass, Status.Green);
                                passFlag = true;
                                ValidationFlag = true;
                            }
                        }
                        else
                        {
                            passFlag = false;
                            ValidationFlag = true;
                        }
                    }
                    else
                    {
                        PanelStatus(panelStatusUser, "Please Fill The Blank", Status.Red);
                    }

                    txtCount = 0;
                    var searchedUser = _userService.GetUser(txtUsername.Text.Trim().ToLower());
                    //If Changed
                    if (!isSameflag)
                    {
   
                        if (searchedUser != null)
                        {
                            PanelStatus(panelStatusUser, "Username Is Available", Status.Red);
                            ValidationFlag = false;
                        }                       
                    }

                    if (ValidationFlag)
                    {                        
                        ValidationFlag = false;
                        
                        if (SelectedRoleID < 0) 
                            SelectedRoleID = searchedUser.RoleID;
                            //SelectedRoleID = HotelDatabase.User.RoleID;

                        HashPassword hashPassword = new HashPassword();
                        bool updateResult;
                        var user = new User()
                        {
                            ID = UserID,
                            EmployeeID = EmployeeID,
                            RoleID = SelectedRoleID,
                            Username = txtUsername.Text.Trim().ToLower(),
                            Password = hashPassword.ConvertPass(txtPassword.Text),
                            Image = ConvertPicToByte(picUser.Image),
                            Activate = chbActive.Checked
                        };
                        if (passFlag)
                            // res = HotelDatabase.User.UpdateWithPass(UserID, EmployeeID, SelectedRoleID, txtUsername.Text.Trim().ToLower(), hp.ConvertPass(txtPassword.Text), ConvertPicToByte(picUser.Image), chbActive.Checked);                           
                            updateResult = _userService.UpdateUserWithPass(user);
                        else
                            //updateResult = HotelDatabase.User.Update(UserID, EmployeeID, SelectedRoleID, txtUsername.Text.Trim().ToLower(), ConvertPicToByte(picUser.Image), chbActive.Checked);
                            updateResult = _userService.UpdateUser(user); 
                                                  
                        if (updateResult)                            
                        {                               
                            PanelStatus(panelStatusUser, "Action Completed Successfully", Status.Green);                               
                            panelInfo.Enabled = false;                              
                            //panelInfo.Enabled = false;
                            
                            Current.CurrentUser.Activities.Add(
                                new Activity("change user information", "the User '"+ txtUsername.Text+"'s information has been changed by " + 
                                Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname));                         
                        }                   
                        else                            
                        {                             
                            PanelStatus(panelStatusUser, "Unable To Complete Action ", Status.Red);                          
                        }
                    }
                }
            }
            else
            {
                //Nothing
            }
        }


        private int EmployeeID= -1;
        //private int ActID = -1;
        private int UserID;
        private bool isFindEmployee = false;
        //private bool isFindUser = false;


        private string usernameValueCheck;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            panelStatusUser.Visible = false;
            Reset();

            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
            {
                //FindEmployee(); //issue
                var actor = _actorService.GetActor(txtNCSearch.Text);
                //var actor = _actorService.GetActor(ActID);
                var employee = _employeeService.GetEmployee(actor.ID, Current.CurrentUser.BranchID);
                //if (isFindEmployee && actor != null && employee != null)
                if (actor != null && employee != null)
                {
                    EmployeeID = employee.ID;
                    isFindEmployee = true;

                    lblName.Text = actor.Firstname + " " + actor.Lastname;
                    lblEducation.Text = employee.Education;
                    lblMobile.Text = actor.Mobile;
                    lblSalary.Text = employee.Salary.ToString();
                    lblGender.Text = actor.Gender;

                    var branch = _branchService.GetBranch(Current.CurrentUser.BranchID);
                    if (branch != null) 
                    {
                        lblBranch.Text = branch.BranchName;
                    }
                    var user = _userService.GetUser(EmployeeID);
                    if (user != null)
                    {
                        usernameValueCheck = user.Username;
                        //isFindUser = true;
                        txtUsername.Text = user.Username;
                        chbActive.Checked = user.Activate;
                        picUser.Image = Image.FromStream(new MemoryStream(user.Image));
                        panelNeedUpdate.Visible = true;

                        var role = _roleService.GetRole(user.RoleID);
                        lblRole.Text = role.Title;

                        UserID = user.ID;
                        PanelStatus(panelStatusUser, "User Was Successfully Found", Status.Green);
                        chbUpdate(true);
                    }
                    else
                    {
                        PanelStatus(panelStatusUser, "Employee Was Successfully Found", Status.Green);
                        Reset();
                        SetProfilePicture(lblGender.Text, picUser);
                        panelInfo.Enabled = true;
                        panelNeedUpdate.Visible = false;
                        chbUpdate(false);
                    }
                }
                else
                {
                    isFindEmployee = false;
                    EmployeeID = 0;
                    panelInfo.Enabled = false;
                    Reset();
                    PanelStatus(panelStatusUser, "No Person Found", Status.Red);                  
                }
            }        
            EmployeeLabels(isFindEmployee);
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

        private static int txtCount = 0;
        private bool ValidationFlag = false;

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
     
            if (txtBox.Name != "txtNCSearch")
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

        private void TextBoxClearBorderColor()
        {
            TextBoxColor(txtUsername, Status.Green);
            TextBoxColor(txtPassword, Status.Green);
            TextBoxColor(txtConPass, Status.Green);
        }

        int RoleID = -1;
        int SelectedRoleID = -1;
        private void dgvRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (panelInfo.Enabled == true)
            {
                lblRole.Text = dgvRole["Title", dgvRole.CurrentRow.Index].Value.ToString();
                SelectedRoleID = Convert.ToInt32(dgvRole["Rid", dgvRole.CurrentRow.Index].Value);
            }
        }

        private void dgvRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRole.CurrentRow != null)
            {
                RoleID = Convert.ToInt32(dgvRole["Rid", dgvRole.CurrentRow.Index].Value);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var bmp = Theme.DarkBack(this.ParentForm);

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                this.ParentForm.Controls.Add(p);
                p.BringToFront();

                using (ActionRole actionRole = new ActionRole(ActionRole.Action.Add))
                {
                    actionRole.ShowDialog();

                    if (actionRole.completeActionFlag)
                    {
                        LoadRoleData();
                        dgvRole.ClearSelection();
                    }
                }
            }        
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (RoleID < 0)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {
                var bmp = Theme.DarkBack(this.ParentForm);

                using (Panel p = new Panel())
                {
                    p.Location = new Point(0, 0);
                    p.Size = this.ParentForm.ClientRectangle.Size;
                    p.BackgroundImage = bmp;
                    this.ParentForm.Controls.Add(p);
                    p.BringToFront();

                    using (ActionRole actionRole = new ActionRole(ActionRole.Action.Edit))
                    {
                        actionRole.RoleID = RoleID;
                        actionRole.ShowDialog();

                        if (actionRole.completeActionFlag)
                        {
                            LoadRoleData();
                            int rowIndex = -1;

                            DataGridViewRow row = dgvRole.Rows
                                .Cast<DataGridViewRow>()
                                .Where(r => r.Cells["Rid"].Value.ToString().Equals(RoleID.ToString()))
                                .First();

                            rowIndex = row.Index;

                            dgvRole.ClearSelection();
                            dgvRole.Rows[rowIndex].Selected = true;
                        }
                    }
                }   
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (RoleID < 0)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {
                var res = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    //if (HotelDatabase.Role.Delete(RoleID))
                    if (_roleService.DeleteRole(RoleID))
                    {
                        LoadRoleData();
                        dgvRole.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Unable TO Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool updateFlag = false;

        private void chbUpdate(bool status)
        {
            if (status)
            {            
                panelInfo.Enabled = true;
                btnSubmitUser.Text = "Save";
                updateFlag = true;
            }
            else
            {
                btnSubmitUser.Text = "Submit";
                updateFlag = false;
            }
        }
     
        private void chbNeed_OnChange(object sender, EventArgs e)
        {
            if (chbNeed.Checked)
            {
                panelInfo.Enabled = true;
                btnSubmitUser.Text = "Save";
                updateFlag = true;
            }
            else
            {
                btnSubmitUser.Text = "Submit";
                panelInfo.Enabled = false;
                updateFlag = false;
            }
        }


        private void Reset()
        {
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.Gray;
            txtConPass.Text = "Confirm Password";
            txtConPass.ForeColor = Color.Gray;
            txtUsername.Text = "Username";
            txtUsername.ForeColor = Color.Gray;
            SelectedRoleID = -10;
            lblRole.Text = "Empty";
            SetProfilePicture("Male", picUser);
            chbActive.Checked = false;
            TextBoxClearBorderColor();
            panelInfo.Enabled = false;
            panelNeedUpdate.Visible = false;
            UserID = -10;
        }

        private bool isSameflag = true;
        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            if (chbNeed.Checked)
            {
                //if (txtUsername.Text.Trim().ToLower() == HotelDatabase.User.Username)
                if (txtUsername.Text.Trim().ToLower() == usernameValueCheck)
                {
                    isSameflag = true;
                }
                else
                {
                    isSameflag = false;
                }
            }
        }
    }
}
