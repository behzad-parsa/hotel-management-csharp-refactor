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

            string query = "Select * FRom Accounts";
            var data = HotelDatabase.Database.Query(query);
            _data = data;
            dgvAccount.DataSource = data;
            dgvAccount.Columns["BranchID"].Visible = false;

            dgvAccount.Columns["ID"].Visible = false;


        }
        private void CardAccounts_Load(object sender, EventArgs e)
        {
            LoadData();         
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
        }
     
        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow != null)
            {
                accountID = Convert.ToInt32(dgvAccount["ID", dgvAccount.CurrentRow.Index].Value);
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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
            }
            else if (status == Status.Green)
            {
                prgbCustError.ProgressColor = Color.Green;
                lblCustError.ForeColor = Color.Green;
            }
            else
            {
                prgbCustError.ProgressColor = Color.Blue;
                lblCustError.ForeColor = Color.Blue;
            }
        }
    }
}
