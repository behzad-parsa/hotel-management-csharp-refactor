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
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;


namespace HotelManagement
{
    public partial class btnReportUser : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        public btnReportUser()
        {
            InitializeComponent();
        }

        private void LoadUserData()
        {

            //string query = "Select DISTINCT e.id as EmployeeID , a.id as ActID , u.id as UserID  , r.id as RoleID ,  NationalCode , Firstname +' '+ Lastname as Name , Username , r.Title as Role , Activate  From [User] u , Employee e , Actor a , Role r , Module m , AccessLevel al , BranchInfo bi " +
            //    " Where u.EmployeeID = e.ID And e.ActID = a.ID And u.RoleID = r.id And e.BranchID =  " +  Current.User.BranchID;


            //string query = " SELECT DISTINCT e.id as EmployeeID , a.id as ActID , u.id as UserID  , u.RoleID as RoleID ,  NationalCode , Firstname +' '+ Lastname as Name , Username , r.Title as Role , Activate  " +
            //    "FROM Employee e  " +
            //    "LEFT JOIN[User] u ON u.EmployeeID = e.ID " +
            //    "Inner Join Actor a On e.ActID = a.ID " +
            //    "left Join Role r on r.ID = u.RoleID " +
            //    "Where e.BranchID = " + Current.User.BranchID;

            string query = " SELECT DISTINCT e.id as EmployeeID , a.id as ActID , u.id as UserID  , u.RoleID as RoleID ,  NationalCode , Firstname +' '+ Lastname as Name , Username , r.Title as Role , Activate  , Education , Gender  , Salary  , Birthday , HireDate , Email , Tel+' | '+Mobile+' | '+Address as Contact   " +
              "FROM Employee e  " +
              "LEFT JOIN [User] u ON u.EmployeeID = e.ID " +
              "Inner Join Actor a On e.ActID = a.ID " +
              "left Join Role r on r.ID = u.RoleID " +
              "Where e.BranchID = " + Current.User.BranchID;

            var data = _userData = HotelDatabase.Database.Query(query);


            if (data != null)
            {


                lblEmptyUser.Visible = false;
                //dgvUser.AutoGenerateColumns = false;
                //BindingSource bs = new BindingSource();
                //bs.DataSource = data;
                dgvUser.DataSource = data;

                //dgvUser.Columns["NationalCode"].DisplayIndex = 0;
                //dgvUser.Columns["Name"].DisplayIndex = 1;
                //dgvUser.Columns["Username"].DisplayIndex = 2;
                //dgvUser.Columns["Role"].DisplayIndex = 3;
                ///dgvUser.Columns["Active"].DisplayIndex = 4;
                dgvUser.Columns["EmployeeID"].Visible = false;
                dgvUser.Columns["ActID"].Visible = false;
                dgvUser.Columns["UserID"].Visible = false;
                dgvUser.Columns["RoleID"].Visible = false;
                dgvUser.Columns["Education"].Visible = false;
                dgvUser.Columns["Salary"].Visible = false;
                dgvUser.Columns["Gender"].Visible = false;
                dgvUser.Columns["Birthday"].Visible = false;
                dgvUser.Columns["HireDate"].Visible = false;
                dgvUser.Columns["Email"].Visible = false;
                dgvUser.Columns["Contact"].Visible = false;
                //DataGridViewImageColumn c = new DataGridViewImageColumn();
                //c.Width = 10;
                //c.Name = "More";
                ////c.DataPropertyName = "m";
                //c.Image = Properties.Resources.next_page__1_;
                //c.ImageLayout = DataGridViewImageCellLayout.Normal;
                //c.HeaderText = "More Info";
                //dgvUser.Columns.Add(c);

            }
            else
            {
                dgvUser.DataSource = null;
                lblEmptyUser.Visible = true;
            }



        }
   
        private void LoadLoginHistory()
        {

            string query = " ; WITH Base AS( Select DISTINCT  log.id, Username, log.DateTime  From LoginHistory log, [User] u, Employee e, BranchInfo bi " +
                "Where  log.UserID = u.ID And u.EmployeeId = e.id And e.BranchID = "+ Current.User.BranchID + ")" +
                "SELECT Distinct ROW_NUMBER() OVER(ORDER BY id DESC) AS # , Username , DateTime FROM Base";

            var data = _historyData = HotelDatabase.Database.Query(query);

            if (data != null)
            {
                lblEmptyHistory.Visible = false;
                //dgvLoginHistory.Columns["#"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                //dgvLoginHistory.Columns[0].Width = 20;
                dgvLoginHistory.DataSource = data;
                //dgvLoginHistory.Columns["#"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                dgvLoginHistory.Columns[0].Width = 50;

            }
            else
            {
                lblEmptyHistory.Visible = true;
                dgvLoginHistory.DataSource = null;
            }
   


        }

        DataTable _userData;
        DataTable _historyData;
        private void UserList_Load(object sender, EventArgs e)
        {
            LoadUserData();
            DataGridViewImageColumn c = new DataGridViewImageColumn();
            c.Width = 10;
            c.Name = "More";
            //c.DataPropertyName = "m";
            c.Image = Properties.Resources.next_page__1_;
            c.ImageLayout = DataGridViewImageCellLayout.Normal;
            c.HeaderText = "More Info";
            dgvUser.Columns.Add(c);



            LoadLoginHistory();

            //bunifuDropdown1.Items.Add("Helllo");
        }

        private void dgvUser_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
           // var h = dgvUser.Columns["More"];
            //dgvUser.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Blue;

            //if (h!=null && e.ColumnIndex == h.Index )
            //{
            //    //if (e.ColumnIndex == h.Index)
            //    //{

            //        dgvUser.Cursor = Cursors.Hand;





            //    //}

            //}





        }

        private void dgvUser_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //var h = dgvUser.Columns["More"];
            //if (h != null && e.ColumnIndex != h.Index)
            //{
            //    //if (e.ColumnIndex == h.Index)
            //    //{

            //    dgvUser.Cursor = Cursors.Default;





            //    //}

            //}


        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {


                var bmp = Theme.DarkBack(this.ParentForm);

                using (Panel p = new Panel())
                {
                    p.Location = new Point(0, 0);
                    p.Size = this.ParentForm.ClientRectangle.Size;
                    p.BackgroundImage = bmp;
                    this.ParentForm.Controls.Add(p);
                    p.BringToFront();

                    using (UserDetail us = new UserDetail())
                    {
                        us.ActorID = Convert.ToInt32(dgvUser["ActID", dgvUser.CurrentRow.Index].Value);

                        us.EmployeeID = Convert.ToInt32(dgvUser["EmployeeID", dgvUser.CurrentRow.Index].Value);

                        var obj = dgvUser["RoleID", dgvUser.CurrentRow.Index].Value;
                        if (obj != DBNull.Value) us.RoleID = Convert.ToInt32(obj);
                        else us.RoleID = -1;


                        obj = dgvUser["UserID", dgvUser.CurrentRow.Index].Value;
                        if (obj != DBNull.Value) us.UserID = Convert.ToInt32(obj);
                        else us.UserID = -1;


                        us.ShowDialog();
                        if (us.deleteEmployee)
                        {
                            //LoadUserData();
                            LoadUserData();
                            dgvUser.ClearSelection();

                        }

                    }

                }
                

            }
        }

        private void txtEmpNationalCode_OnValueChanged(object sender, EventArgs e)
        {
            if (_userData != null && cmbFilter.SelectedIndex != -1)
            {
                _userData.DefaultView.RowFilter = string.Format(cmbFilter.SelectedItem + " LIKE '%{0}%'", txtEmpNationalCode.Text);
            }
            
        }






        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
            //panelGuestStatus.Visible = false;

           txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);

          
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

            if (!string.IsNullOrEmpty(txtBox.Text))
            {
                txtBoxList.TryGetValue(txtBox, out string defualtText);
                txtBox.Text = defualtText;
                txtBox.ForeColor = Color.Gray;
            }


        }

        private void txtLoginHistory_OnValueChanged(object sender, EventArgs e)
        {
            if (_historyData != null)
            {
                _historyData.DefaultView.RowFilter = string.Format("Username LIKE '%{0}%'", txtLoginHistory.Text);
            }

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void btnReportFood_Click(object sender, EventArgs e)
        {

            //if (_userData != null && cmbFilter.SelectedIndex != -1)
            //{
            //    _userData.DefaultView.RowFilter = string.Format(cmbFilter.SelectedItem + " LIKE '%{0}%'", txtEmpNationalCode.Text);
            //}
            Current.User.Activities.Add(new Activity("Create New Report", "the report from User/Employee list has been created by " + Current.User.Firstname + " " + Current.User.Lastname));

            Report.Load("Report/UserReport.mrt"  , "User" , _userData);




        }
    }
}
