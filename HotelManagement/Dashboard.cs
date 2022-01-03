using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OpenWeatherApi;
using System.IO;
using System.Net;
using System.IO.Compression;
using Newtonsoft.Json;
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class Dashboard : UserControl
    {
        private readonly BranchService _branchService;
        List<ActivityItem> lstActivityItem;

        public Dashboard()
        {
            InitializeComponent();
            lblTime.Text = DateTime.Now.ToString("hh:mm tt");
            _branchService = new BranchService();
        }

        private void LoadRecentActivity()
        {
            panelAcitvity.Controls.Clear();

            lstActivityItem = new List<ActivityItem>();
            int top = 0;
            if (Current.User.Activities.Count != 0)
            {
                lblEmptyRecent.Visible = false;

                foreach (var item in Current.User.Activities.OrderByDescending(x => x.Date))
                {
                    ActivityItem activityItem = new ActivityItem(item);
                    activityItem.Top = top;
                    top = activityItem.Bottom;
                    panelAcitvity.Controls.Add(activityItem);
                    lstActivityItem.Add(activityItem);
                }
                this.Refresh();

            }
            else
            {
                lblEmptyRecent.Visible = true;
            }

        }
        Timer checkActivity = new Timer();
        
        private void Dashboard_Load(object sender, EventArgs e)
        {
            
            //Communication.StartCheckInternetConnection();
            //if (Communication.InternetConnection)
            //{
            //    MessageBox.Show("Hello");
            //}
            LoadRecentActivity();
           // checkActivity.Interval = 3 * 60 * 1000;
            checkActivity.Interval = 1 * 60 * 1000;
            checkActivity.Tick += CheckActivity_Tick;
            checkActivity.Start();
            //int top = 0;
            //for (int i = 0; i < 20; i++)
            //{
            //    ActivityItem itemone = new ActivityItem();
            //    itemone.Top = top;
            //    top = itemone.Bottom;
            //    panelAcitvity.Controls.Add(itemone);
            //}
            //ActivityItem itemone = new ActivityItem();
            //ActivityItem item2 = new ActivityItem();
            //item2.Top = itemone.Bottom;
            //panelAcitvity.Controls.Add(itemone);
            //panelAcitvity.Controls.Add(item2);


            labelDate.Text = DateTime.Now.ToString("dddd dd, \nMMMM");
            //var h = GetLastUpdate();

            //var dif = DateTime.Now - h;

            //if (dif.Days > 0 )
            //{
            //    //Update And Write To File
            //}
            //else if (dif.Hours >= 3)
            //{
            //    //Update And Write To File
            //}

            //lblTemp.Text = string.Format("{0}°C", 27);
            //Get Weather

            //OpenWeatherAPI openWeather = new OpenWeatherAPI("");
            //var weatherDate = openWeather.query("2643743");
            //if (weatherDate != null)
            //{
            //    lblTemp.Text = weatherDate.Main.Temperature.CelsiusCurrent.ToString();
            //    lblStatus.Text = weatherDate.Weathers[0].Main;
            //}
            UpdateWeather();
            AggregateQuery();

            Timer weatherCheck = new Timer();
            weatherCheck.Interval = 4 * 60 * 60 * 1000;
            weatherCheck.Tick += WeatherCheck_Tick;
            weatherCheck.Start();
        }

        private void CheckActivity_Tick(object sender, EventArgs e)
        {
            LoadRecentActivity();
        }

        private void WeatherCheck_Tick(object sender, EventArgs e)
        {
            UpdateWeather();
        }
        //private DateTime GetLastUpdate()
        //{
        //    City targetCity;

        //    //DateTime date;
        //    if (File.Exists("WeatherData.txt"))
        //    {
        //        string content = File.ReadAllText("WeatherData.txt");
        //        string[] word = content.Split('-');
        //        lblTemp.Text = string.Format("{0}°C", word[1]);
        //        labelLast.Text = "Last Update On " + word[0];
        //        return Convert.ToDateTime(word[0]);
        //    }
        //    else
        //    {

        //        GetCityList(); 
        //        if (HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID))
        //        {
        //            var searchCity = OpenWeatherAPI.lstCity.Find(x => x.Name.ToLower() == HotelDatabase.Branch.City);
        //            if (searchCity == null)
        //            {
        //                //City Not Found ;
        //                MessageBox.Show("Your Branch City Was not found in the List !\n Search Manually On Setting Page");
        //                targetCity = OpenWeatherAPI.lstCity.Find(x => x.Name == "Tehran");
        //            }
        //            else
        //            {
        //                targetCity = searchCity;


        //            }
        //        }
        //        else
        //        {
        //            targetCity = null;

        //        }
        //       // File.WriteAllText("WeatherData.txt", DateTime.Now.ToString());
        //        string content = targetCity.ID.ToString() + "-" + targetCity.Name;
        //        File.WriteAllText("WeatherData.txt", content);
        //        return DateTime.Now.AddDays(-1);
        //    }

        //}
        private string GetLastContent()
        {
            try
            {
                City targetCity;
                GetCityList();
                if (File.Exists("WeatherData.txt"))
                {
                    return File.ReadAllText("WeatherData.txt"); ;
                }
                else
                {
                    string content;
                    var branch = _branchService.GetBranch(Current.User.BranchID);
                    if (branch != null)//HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID))
                    {
                        var searchCity = OpenWeatherAPI.lstCity.Find(x => x.Name.ToLower() == branch.City.ToLower());
                        if (searchCity == null)
                        {
                            //City Not Found ;
                            MessageBox.Show("Your Branch City Was not found in the List !\n Search Manually On Setting Page");
                            targetCity = OpenWeatherAPI.lstCity.Find(x => x.Name.ToLower() == "tehran");
                        }
                        else
                        {
                            targetCity = searchCity;
                        }
                    }
                    else
                    {
                        targetCity = null;
                    }
                    content = targetCity.ID.ToString() + "-" + targetCity.Name + "-" + "Temp" + "-" + "Status" + "-" + DateTime.Now.AddDays(-1);
                    File.WriteAllText("WeatherData.txt", content);
                    return content;
                }
            }
            catch 
            {
                return 0 + "-" + "Not Found" + "-" + "Temp" + "-" + "Status" + "-" + DateTime.Now;
            } 
        }

        private void UpdateWeather()
        {
           //[0] ID 
           //[1] Tehran
           //[2] Temp
           //[3] Status
           //[4] Last Update
            string[] content= GetLastContent().Split('-');

            City city = new City(Convert.ToInt32(content[0]), content[1]);
            string temp = content[2];
            string status = content[3];
            var lastUpdate = Convert.ToDateTime(content[4]);
            var duration = DateTime.Now - lastUpdate;

            if (duration.Days > 0 || duration.Hours>=3 || Setting.updateWeatherFlag)
            {
                OpenWeatherAPI openWeather = new OpenWeatherAPI("");

                var weatherDate = openWeather.query(city.ID.ToString());
                if (weatherDate != null)
                {
                    Setting.updateWeatherFlag = false;

                    temp = string.Format("{0}°C", Math.Round(weatherDate.Main.Temperature.CelsiusCurrent).ToString());
                    status = weatherDate.Weathers[0].Main;
                    lastUpdate = DateTime.Now;
                    

                    string contentWeather = city.ID.ToString() + "-" +city.Name+"-"+temp+"-"+status+"-"+lastUpdate;
                     File.WriteAllText("WeatherData.txt", contentWeather);
                }            
             }

            lblTemp.Text = temp;
            lblStatus.Text = status;
            SetWeatherPics(status);
            labelLast.Text = "Last Update On : " + lastUpdate.ToString("MM/dd/yyyy hh:mm tt");
            labelCity.Text = city.Name;
        }

        private void AggregateQuery()
        {
            string query = "Select Count( Distinct  res.CustomerID ) From Customer c  , Reservation res , [User] u  , Employee e Where c.ID = res.CustomerID And GETDATE() Between res.StartDate And res.EndDate  "+
                            "And res.UserID = u.ID And u.EmployeeID = e.ID And e.BranchID = " + Current.User.BranchID;

            var customerCount = HotelDatabase.Database.Query(query);
            if (customerCount != null && customerCount.Rows[0][0] != DBNull.Value) lblCustomer.Text = customerCount.Rows[0][0].ToString();

            //DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string date = DateTime.Now.Year.ToString()+"-"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString();
            query = "Select Sum(Amount) From Transact t , Accounts a Where t.AccountID = a.ID And a.BranchID = " + Current.User.BranchID + " And t.TransactionTypeID = 1   " +
                     " And t.DateModified Between '" + date + " 00:00:00' And '" + date + " 23:59:59'  ";
            var revenue = HotelDatabase.Database.Query(query);
            if ( revenue!= null && revenue.Rows[0][0] != DBNull.Value) lblRevenue.Text = string.Format("{0:n0}", Convert.ToInt32(revenue.Rows[0][0]));


            query = "select Count(r.ID) From Room r Where r.BranchID = " + Current.User.BranchID;
            var room = HotelDatabase.Database.Query(query);
            if (room != null &&  room.Rows[0][0] != DBNull.Value) lblRooms.Text = room.Rows[0][0].ToString();
        }

        private List<City> ReadJsonFile(string path)
        {
            try
            {
                List<City> lst = new List<City>();
                string[] jsonFile;
                if (File.Exists("IranCity.Json")) jsonFile = Directory.GetFiles(path, "IranCity.json");
                else jsonFile = Directory.GetFiles(path, "*.json");
                JsonSerializer serializer = new JsonSerializer();
                City city;
                using (FileStream s = File.Open(jsonFile[0], FileMode.Open))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    while (reader.Read())
                    {
                        // deserialize only when there's "{" character in the stream
                        if (reader.TokenType == JsonToken.StartObject)
                        {
                            city = serializer.Deserialize<City>(reader);
                            lst.Add(city);                          
                        }
                    }                
                }
                return lst;
            }
            catch 
            {
                return null ;
            }
        }
        private void GetCityList()
        {

            try
            {
                var path = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string directoryPath = path.Substring(6);
                List<City> lstCity;
                // var jsonFile = Directory.GetFiles(directoryPath, "*.json");
                if (File.Exists("IranCity.Json"))
                {
                    OpenWeatherAPI.lstCity = ReadJsonFile(directoryPath);                  
                }
                else
                {
                    //Download City List
                    using (var client = new WebClient())
                    {
                        client.DownloadFile("http://bulk.openweathermap.org/sample/city.list.json.gz", "city.list.json.gz");
                    }

                    //Decompress
                    DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);

                    foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
                    {
                        Decompress(fileToDecompress);
                    }

                    //ReadFile
                    //var jsonFile = Directory.GetFiles(directoryPath, "*.json");
                    //JsonSerializer serializer = new JsonSerializer();
                    //City city;
                    //using (FileStream s = File.Open(jsonFile[0], FileMode.Open))
                    //using (StreamReader sr = new StreamReader(s))
                    //using (JsonReader reader = new JsonTextReader(sr))
                    //{
                    //    while (reader.Read())
                    //    {

                    //        // deserialize only when there's "{" character in the stream
                    //        if (reader.TokenType == JsonToken.StartObject)
                    //        {
                    //            city = serializer.Deserialize<City>(reader);
                    //            if (city.Country == "IR")
                    //            {
                    //                OpenWeatherAPI.lstCity.Add(city);

                    //            }

                    //        }
                    //    }
                    //}
                    lstCity = ReadJsonFile(directoryPath);

                    lstCity = lstCity.FindAll(x => x.Country == "IR");
                    //File.Delete("*.json");
                    //Create New JSon File Includ IR Cities
                    var json = JsonConvert.SerializeObject(lstCity);
                    File.WriteAllText("IranCity.Json", json);
                }
            }
            catch 
            {
                ;
            }
        }
        public void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {            
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);                     
                    }
                }
            }           
        }

        private void SetWeatherPics(string status)
        {
            switch (status)
            {
                case "Thunderstorm":
                    picStatus.Image = Properties.Resources.storm;
                    break;

                case "Drizzle":
                    picStatus.Image = Properties.Resources.downpour;
                    break;
                
                case "Rain":
                    picStatus.Image = Properties.Resources.rain;
                    break;

                case "Snow":
                    picStatus.Image = Properties.Resources.snow;
                    break;

                case "Atmosphere":
                    picStatus.Image = Properties.Resources.waves;
                    break;

                case "Clouds":
                    picStatus.Image = Properties.Resources.cloud;
                    break;

                case "Clear":
                    TimeSpan start = new TimeSpan(18,0,0);
                    TimeSpan end = new TimeSpan(23, 59, 0);

                    TimeSpan start2 = new TimeSpan(0, 0, 0);
                    TimeSpan end2 = new TimeSpan(5, 0, 0);

                    if ((DateTime.Now.TimeOfDay > start && DateTime.Now.TimeOfDay<end ) || (DateTime.Now.TimeOfDay > start2 && DateTime.Now.TimeOfDay < end2) ) picStatus.Image = Properties.Resources.moon;
                    else picStatus.Image = Properties.Resources.sun;

                    break;

                default:
                    picStatus.Image = Properties.Resources.loading_circles;
                    break;
            }
        }


        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {
        }

        private void btnNote_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Notepad.exe");
            }
            catch 
            {
                MessageBox.Show("Doesn't Exist On This OS");
            }           
        }

        private void btnCal_Click(object sender, EventArgs e)
        {           
            try
            {
                Process.Start("Calc.exe");
            }
            catch
            {
                MessageBox.Show("Doesn't Exist On This OS");
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("WINWORD.EXE");
            }
            catch
            {
                MessageBox.Show("Doesn't Exist On This OS");
            }       
        }

        private void btnGoogle_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://google.com");
            }
            catch
            {

                MessageBox.Show("Doesn't Exist On This OS");
            }
        }
    }
}
