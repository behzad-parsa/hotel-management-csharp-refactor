using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenWeatherApi;
using Bunifu.Framework.UI;
using System.IO;

namespace HotelManagement
{
    public partial class DialogCity : Form
    {
        public DialogCity()
        {
            InitializeComponent();
        }
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        DataTable dataCity;
        public City city;
        private void DialogCity_Load(object sender, EventArgs e)
        {
            //var g = OpenWeatherAPI.lstCity as DataTable;
            //var g = OpenWeatherAPI.lstCity.f
            //var g  = OpenWeatherAPI.lstCity.OrderBy(x=>x.Name)
            dataCity = new DataTable();
            //g.DataSet = OpenWeatherAPI.lstCity;
            //dgvCities.DataSource = OpenWeatherAPI.lstCity.OrderBy(x=>x.Name).ToList();
            var sortedList = OpenWeatherAPI.lstCity.OrderBy(x => x.Name).ToList();
            dataCity.Columns.Add("Id");
            dataCity.Columns.Add("Name");
            foreach (var item in sortedList)
            {
                dataCity.Rows.Add(item.ID, item.Name);

            }
            //dgvCities.Sort()

            dgvCities.DataSource = dataCity;
            dgvCities.Columns["Id"].Visible = false;
            //dgvCities.Columns["Country"].Visible = false;


        }
        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;

      
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

            if (txtBox.Text == null || txtBox.Text == "")
            {
                txtBoxList.TryGetValue(txtBox, out string defualtText);
                txtBox.Text = defualtText;
                txtBox.ForeColor = Color.DarkGray;
            }


        }
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
        private void txtEmpNationalCode_OnValueChanged(object sender, EventArgs e)
        {

            (dgvCities.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name Like '{0}%'", txtSearch.Text);

            
            //(dgvCities.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name Like '%{0}%'", txtSearch.Text);
        }

        private void dgvCities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32( dgvCities["Id", dgvCities.CurrentRow.Index].Value ) ;
           
            if (File.Exists("WeatherData.txt"))
            {
                city = OpenWeatherAPI.lstCity.Find(x => x.ID == id);

                string contentWeather = city.ID.ToString() + "-" + city.Name + "-" + "Temp" + "-" + "Status" + "-" + DateTime.Now;
                File.WriteAllText("WeatherData.txt", contentWeather);
                this.Dispose();

            }
            else
            {
                MessageBox.Show("Can't Complete Action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Dispose();


        }
    }
}
