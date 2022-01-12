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
    public partial class CardTransact : UserControl
    {
        public CardTransact()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string query = "Select t.id AS Tid ,   t.TransactionNumber , pm.Title as PaymentMethod , tt.Title As TransactionType  , a.AccountName+ CHAR(10)+CHAR(13) + a.Bank + ' - ' + a.AccountNumber Account , t.Amount , t.DateModified  ,t.Description"
              +"  From Transact t , Accounts a, PaymentMethod pm , TransactionType tt"
              +"  Where t.TransactionTypeID = tt.id AND t.PaymentMethodID = pm.id AND t.AccountID = a.id  ";
            var data =  HotelDatabase.Database.Query(query);
            dgvTransact.DataSource = data;
            dgvTransact.Columns["Tid"].Visible = false ;
            
        }

        private void CardTransact_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        int transID = -10;
        private void dgvTransact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (transID < 0)
            {
                MessageBox.Show("Select Row");

            }
            else
            {
                var dialogResult = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    if (HotelDatabase.Transact.Delete(transID))
                    {
                        PanelStatus("Action Completed Successfuly", Status.Green);
                        LoadData();
                        Current.User.Activities.Add(new Activity("Delete Transaction", "A Transaction has been deleted by " + Current.User.Firstname + " " + Current.User.Lastname));
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

                using (NewTransact newTrans = new NewTransact())
                {

                    newTrans.ShowDialog();
                    if (newTrans.completeFlag)
                    {
                        LoadData();
                        dgvTransact.ClearSelection();
                        Current.User.Activities.Add(
                            new Activity("Create New Transaction", "New Transaction has been created by " + Current.User.Firstname + " " + Current.User.Lastname)
                            );
                    }
                }
            } 
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (transID < 0)
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

                    using (EditTransact editTrans = new EditTransact())
                    {
                        editTrans.transID = transID;
                        editTrans.ShowDialog();

                        if (editTrans.completeFlag)
                        {
                            LoadData();
                            Current.User.Activities.Add(new Activity("Edit Transaction", "Transaction information has been changed by " + Current.User.Firstname + " " + Current.User.Lastname));
                        }
                        int rowIndex = -1;

                        DataGridViewRow row = dgvTransact.Rows
                            .Cast<DataGridViewRow>()
                            .Where(r => r.Cells["Tid"].Value.ToString().Equals(transID.ToString()))
                            .First();

                        rowIndex = row.Index;

                        dgvTransact.ClearSelection();
                        dgvTransact.Rows[rowIndex].Selected = true;
                    }
                }
            }
        }

        private void dgvTransact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTransact.CurrentRow != null)
            {
                transID = Convert.ToInt32(dgvTransact["Tid", dgvTransact.CurrentRow.Index].Value);
            }
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
