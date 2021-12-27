using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class CardAccounts : UserControl
    {
        public CardAccounts()
        {
            InitializeComponent();
        }
        DataTable _data;
        private void LoadData()
        {
            //dgvAccount.Rows[1].Cells[0].Selected = false;

            
            string query = "Select * FRom Accounts";
            var data = HotelDatabase.Database.Query(query);
            _data = data;
            dgvAccount.DataSource = data;
            //var h = dgvAccount.Columns["Account"];
            //foreach (DataGridViewColumn item in dgvAccount.Columns)
            //{
            //    if (item.Index>1)
            //    {
            //        item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //    }

            //}
            dgvAccount.Columns["BranchID"].Visible = false;

            dgvAccount.Columns["ID"].Visible = false;
            //dgvAccount.Rows[5].Selected = true;
            //datagridviewim

        }
        private void CardAccounts_Load(object sender, EventArgs e)
        {
            LoadData();
           //dgvAccount.Rows[4].Selected = true;
           // dgvAccount.Refresh();
            //dgvAccount.Rows[2].Selected = true;
            //dgvAccount.Rows[0].Cells[4].Selected = false;
            //dgvAccount.Rows[1].Cells[0].Selected = false;
            ////dgvAccount.CurrentCell.Selected = false;
            //dgvAccount.ClearSelection();
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {




            var bmp = Theme.DarkBack(this.ParentForm);

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                this.ParentForm.Controls.Add(p);
                p.BringToFront();




                using (NewAccount newAccount = new NewAccount())
                {
                    newAccount.ShowDialog();
                    if (newAccount.completeFlag)
                    {
                        LoadData();
                        dgvAccount.ClearSelection();

                    }



                }

            }

        }

        private int accountID = -1;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if(index > 0)
            //{
            //    accountID = Convert.ToInt32(dgvAccount["ID", index].Value);
            //}
            if (accountID <0 )
            {
                MessageBox.Show("Select Row");

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




                    using (EditAccount editAccount = new EditAccount())
                    {
                        editAccount.accountID = accountID;
                        editAccount.ShowDialog();

                        if (editAccount.completeFlag)
                        {
                            LoadData();
                            dgvAccount.ClearSelection();

                        }
                    }

                }

         
            }

        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //accountID = Convert.ToInt32(_data.Rows[dgvAccount.CurrentRow.Index]["ID"]);
            //MessageBox.Show(accountID.ToString());
        }
        //int index = -1;
        
        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            //var h = sender as ;
            ////accountID = Convert.ToInt32(_data.Rows[h]["ID"]);
            //accountID = Convert.ToInt32(h["ID"]);

            //dgvAccount.sele
            //accountID = Convert.ToInt32(_data.Rows[dgvAccount.CurrentRow.Index]["ID"]);
            //MessageBox.Show(accountID.ToString());
            if (dgvAccount.CurrentRow != null)
            {
                //index = ;
                accountID = Convert.ToInt32(dgvAccount["ID", dgvAccount.CurrentRow.Index].Value);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //dgvAccount.Rows[5].Selected = true;
            //}
            if (accountID < 0)
            {
                MessageBox.Show("Select Row");

            }
            else
            {
                var res = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (HotelDatabase.Account.Delete(accountID))
                    {
                        PanelStatus("Action Completed Successfuly", Status.Green);
                        LoadData();
                    } 
                    else
                    {
                        PanelStatus("Unable to Complete Action", Status.Red);
                    }
                }

               
            }


        }




        private enum Status
        {
            Green,
            Red,
            blue
        };
        private void PanelStatus(string text, Status status)
        {
            panelCustStatus.Visible = true;
            lblCustError.Text = text;
            if (status == Status.Red)
            {
                prgbCustError.ProgressColor = Color.Red;
                lblCustError.ForeColor = Color.Red;
                //lblCustError.Text = text;

            }
            else if (status == Status.Green)
            {

                prgbCustError.ProgressColor = Color.Green;
                lblCustError.ForeColor = Color.Green;
                //lblCustError.Text = text;

            }
            else
            {
                prgbCustError.ProgressColor = Color.Blue;
                lblCustError.ForeColor = Color.Blue;

            }




        }

    }
}
