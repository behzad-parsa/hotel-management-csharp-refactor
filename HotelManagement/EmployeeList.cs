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
    public partial class EmployeeList : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();

        public EmployeeList()
        {
            InitializeComponent();
        }
        DataGridViewCheckBoxColumn c1;

        CheckBox ckBox;
        DataTable data;
        //string query = "Select * From \"Actor\" as a  , \"Customer\" as e Where e.Actid = a.id ";
        string originalQuery = "Select  e.id AS Eid , a.id As Aid , NationalCode, Firstname , Lastname , Gender , Birthday , Salary , HireDate  From Actor a  , Employee e Where e.ActID = a.ID ";
        string query = "Select  e.id AS Eid , a.id As Aid , NationalCode, Firstname , Lastname , Gender , Birthday , Salary , HireDate  From Actor a  , Employee e Where e.ActID = a.ID ";
        private void EmployeeList_Load(object sender, EventArgs e)
        {
            cmbKeyword.SelectedIndex = 0;

            ///ADD Branch Later
           //data = HotelDatabase.Database.Query("Select  e.id AS Eid , a.id As Aid , NationalCode, Firstname , Lastname , Gender , Birthday , Salary , HireDate  From Actor a  , Employee e Where e.ActID = a.ID ");
           // BindingSource bindingSource = new BindingSource();          
            ckBox = new CheckBox();

            //Get the column header cell bounds

            Rectangle rect =

                this.dgvEmployee.GetCellDisplayRectangle(0, -1, true);

            ckBox.Size = new Size(18, 18);

            //Change the location of the CheckBox to make it stay on the header
            ckBox.Location = rect.Location;
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);

            //Add the CheckBox into the DataGridView

            this.dgvEmployee.Controls.Add(ckBox);

            FilterData();
        }

        string genderMale = " And Gender = 'Male'";
        string genderFemale = " And Gender = 'Female'";
        private void RadioButtonValue(object sender , EventArgs e)
        {
            var rdb = sender as RadioButton;

            //query.IndexOf("Gender");
            if (query.Contains("Male"))
            {
                query = query.Replace(genderMale, "");

            }
            else if (query.Contains("Female"))
            {
                query = query.Replace(genderFemale, "");
            }

            if (rdb.Text == "Both")
            {

                if (query.Contains("Male"))
                {
                    query = query.Replace(genderMale, "");

                }
                else if (query.Contains("Female"))
                {
                    query = query.Replace(genderFemale, "");
                }
            }
            else if (rdb.Text == "Male")
            {
                query += genderMale;

            }
            else if (rdb.Text == "Female")
            {
                query += genderFemale;
            }
            FilterData();
        }

        private void FilterData()
        {
            var data  = HotelDatabase.Database.Query(query);
            dgvEmployee.DataSource = data;
            if (data != null)
            {
                dgvEmployee.Columns["Eid"].Visible = false;
                dgvEmployee.Columns["Aid"].Visible = false;
                dgvEmployee.Columns[0].Width = 28;
            }
            else
            {

            }
        }


        void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.dgvEmployee.RowCount; j++)
            {
                this.dgvEmployee[0, j].Value = this.ckBox.Checked;
            }
            this.dgvEmployee.EndEdit();
        }




        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
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




        private void bunifuCustomDataGrid1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //dgvEmployee.DataSource = data.Select("Firstname like 'Be%'");
            //DataTable tblFiltered =data.AsEnumerable()
            //.Where(row => row.Field<String>("Firstname") == "Beh")
            //.CopyToDataTable();
            //  dgvEmployee.DataSource = tblFiltered;

            var originalData = HotelDatabase.Database.Query(originalQuery);
            dgvEmployee.DataSource = originalData;
            dgvEmployee.Columns["Eid"].Visible = false;
            dgvEmployee.Columns["Aid"].Visible = false;
            dgvEmployee.Columns[0].Width = 28;

            txtKeyword.Text = "Keyword";
            txtMinSalary.Text = "Min";
            txtMaxSalary.Text = "Max";
            //dateBirthMin.Value = DateTime.Now;
            //dateHireMin.Value = DateTime.Now;
            //DataView dv1 = data.DefaultView;
            //dv1.RowFilter = "Firstname = 'Behzad' or Firstname Like 'kim*'";
            //DataTable dtNew = dv1.ToTable();
            //dgvEmployee.DataSource = dtNew;
        }



        string birthMin = " And Birthday >= ";
        string birthMax = " And Birthday <= ";
        string saveValueBirthMax;
        string saveValueBirthMin;
        private void dateBirthFirst_onValueChanged(object sender, EventArgs e)
        {
            if (dateBirthMin.Value > dateBirthMax.Value )
            {
                dateBirthMax.Value = dateBirthMin.Value.AddDays(1);
            }
            if (saveValueBirthMin != null && query.Contains(saveValueBirthMin))
            {
                query = query.Replace(saveValueBirthMin, "");
            }
            saveValueBirthMin = birthMin + "'" + dateBirthMin.Value.Date + "'";
            query = query + saveValueBirthMin;

            FilterData();

        }


        private void dateBirthSecond_onValueChanged(object sender, EventArgs e)
        {
            if (dateBirthMin.Value > dateBirthMax.Value)
            {
                dateBirthMax.Value = dateBirthMin.Value.AddDays(1);
            }
            if ( saveValueBirthMax != null &&  query.Contains(saveValueBirthMax))
            {
                query = query.Replace(saveValueBirthMax, "");
            }
           
            saveValueBirthMax = birthMax + "'" + dateBirthMax.Value.Date + "'";
            query = query + saveValueBirthMax ;

            FilterData();
        }

        string hireMin = " And HireDate >= ";
        string hireMax = " And HireDate <= ";
        string saveValueHireMax;
        string saveValueHireMin;

        //--------Hire-------------------------------------------------
        private void dateHireFirst_onValueChanged(object sender, EventArgs e)
        {
            if (dateHireMin.Value > dateHireMax.Value)
            {
                dateHireMax.Value = dateHireMin.Value.AddDays(1);
            }

            if (saveValueHireMin!=null && query.Contains(saveValueHireMin))
            {
                query = query.Replace(saveValueHireMin, "");
            }
            saveValueHireMin = hireMin + "'" + dateHireMin.Value.Date + "'";

            //saveValueMax = dateBirthMax.Value.Date;
            query += saveValueHireMin;

            FilterData();
        }

        private void dateHireSecond_onValueChanged(object sender, EventArgs e)
        {
            if (dateHireMin.Value > dateHireMax.Value)
            {
                dateHireMax.Value = dateHireMin.Value.AddDays(1);
            }

            if (saveValueHireMax != null && query.Contains(saveValueHireMax))
            {
                query = query.Replace(saveValueHireMax, "");
            }
            saveValueHireMax = hireMax + "'" + dateHireMax.Value.Date + "'";

            //saveValueMax = dateBirthMax.Value.Date;
            query += saveValueHireMax;      
            FilterData();

        }

        string saveValueTxtKeyword;
        private void txtKeyword_OnValueChanged(object sender, EventArgs e)
        {
            if(txtKeyword.Text != "")
            {
                //'a%'
                //saveValueTxtKeyword = " And "  + cmbKeyword.SelectedItem + "=" + "'" + txtKeyword.Text  +"'";
                if ( saveValueTxtKeyword != null && (query.Contains("NationalCode") || query.Contains("Firstname") || query.Contains("Lastname")))
                {
                    query = query.Replace(saveValueTxtKeyword, "");

                }
                saveValueTxtKeyword = " And " + cmbKeyword.SelectedItem + " LIKE" + "'" + txtKeyword.Text  + "%'";
                query += saveValueTxtKeyword;
            }
            else
            {
                if (saveValueTxtKeyword != null && (query.Contains("NationalCode") || query.Contains("Firstname") || query.Contains("Lastname")))
                {
                    query = query.Replace(saveValueTxtKeyword, "");
                }
            }
            FilterData();
        }

        string salaryMin = " And Salary >= ";
        string salaryMax = " And Salary <= ";
        string saveValueSalaryMin;
        string saveValueSalaryMax;
        private void txtMinSalary_OnValueChanged(object sender, EventArgs e)
        {         
            bool isNumric = Int32.TryParse(txtMinSalary.Text, out int num);
            if (txtMinSalary.Text != "" && isNumric)
            {
                if (saveValueSalaryMin != null && query.Contains(salaryMin))
                {
                    query = query.Replace(saveValueSalaryMin, "");
                }
                saveValueSalaryMin = salaryMin + txtMinSalary.Text + " ";
                query = query + saveValueSalaryMin;           
            }
            else if(isNumric || txtMinSalary.Text =="" || txtMinSalary.Text == "Min")
            {

                if (saveValueSalaryMin != null && query.Contains(salaryMin))
                {
                    query = query.Replace(saveValueSalaryMin, "");
                }
            }
            FilterData();
        }

        private void txtMaxSalary_OnValueChanged(object sender, EventArgs e)
        {
            bool isNumric = Int32.TryParse(txtMaxSalary.Text, out int num);
            if (txtMaxSalary.Text !="" && isNumric )
            {
                if (saveValueSalaryMax != null && query.Contains(salaryMax))
                {
                    query = query.Replace(saveValueSalaryMax, "");
                }
                saveValueSalaryMax = salaryMax + txtMaxSalary.Text + " ";
                query += saveValueSalaryMax;             
            }

            else if (isNumric || txtMaxSalary.Text == "" || txtMaxSalary.Text == "Min")
            {
                if (saveValueSalaryMax != null && query.Contains(salaryMax))
                {
                    query = query.Replace(saveValueSalaryMax, "");
                }
            }
            FilterData();
        }
    }
}
