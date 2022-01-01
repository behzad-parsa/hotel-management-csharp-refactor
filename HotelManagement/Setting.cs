using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Bunifu.Framework.UI;



namespace HotelManagement
{
    public partial class Setting : UserControl
    {

        GradientPanel panelLeft;
        GradientPanel panelTop;
        GradientPanel panelMoveSide;
        List<GradientPanel> panels = new List<GradientPanel>();
        public Setting()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (jpg , png , bmp ) | *.jpg;*.png;*.bmp |All Files |*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var img = Image.FromFile(openFileDialog1.FileName);
                if (Current.User.UpdateProfilePicture(ConvertPicToByte(img)))
                {
                    picPhoto.Image = img;
                }               
            }
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            //Loading User DAta
            lblBirth.Text = Current.User.Birth.ToString("MM / dd / yyyy");
            lblEducation.Text = Current.User.Education.ToString();
            lblEmail.Text = Current.User.Email;
            lblGender.Text = Current.User.Gender;
            lblHire.Text = Current.User.HireDate.ToString("MM / dd / yyyy");
            lblMobile.Text = Current.User.Mobile;
            lblName.Text =  Current.User.Firstname +" " + Current.User.Lastname;
            lblNC.Text = Current.User.NationalCode;
            lblRole.Text = Current.User.RoleTitle;
            lblSalary.Text = Current.User.Salary.ToString();
            lblUsername.Text = Current.User.Username;
            var lastSignin = HotelDatabase.User.GetLastSignin(Current.User.ID);
            if (lastSignin != DateTime.MinValue) lblLastSignIn.Text = lastSignin.ToString();

            MemoryStream ms = new MemoryStream(Current.User.Image); 
            picPhoto.Image = Image.FromStream(ms);


            HotelDatabase.Branch.SearchBranchWithID(Current.User.BranchID);
            lblBranch.Text = HotelDatabase.Branch.BranchName;

            //Get Access To Parants (Theme Part)      
            panelLeft = (this.Parent.Parent as frmMain).Controls["panelLeftSlide"] as GradientPanel;
            panelTop = (this.Parent.Parent as frmMain).Controls["panelTop"] as GradientPanel;
            //panelMoveSide = (this.Parent.Parent as frmMain).Controls["panelSide"] as GradientPanel;
            //var g = panelLeft.Controls.Find("panelSide", true);
             panelMoveSide = panelLeft.Controls["panelSide"] as GradientPanel;
            panels.Add(panelTop);
            panels.Add(panelLeft);     
            panels.Add(panelMoveSide);

            //Loading Login History
            var loginHistory = Current.User.GetLoginHistory();
            if (loginHistory != null)
            {
                lblEmpty.Visible = false;
                dgvLoginHistory.DataSource = loginHistory;
                dgvLoginHistory.Columns["#"].Width = 70;
                dgvLoginHistory.ClearSelection();
            }
            else
            {
                lblEmpty.Visible = true;
                dgvLoginHistory.DataSource = null;
            }

            //Loading Weather
            if (File.Exists("WeatherData.txt"))
            {
                var content = File.ReadAllText("WeatherData.txt");
                weatherDataContent = content.Split('-');
                lblCity.Text = weatherDataContent[1];
            }
            else
            {
                lblCity.Text = "Not Found";
            }
  
        }

        string[] weatherDataContent;

        private byte[] ConvertPicToByte(Image img)
        {
            MemoryStream Ms = new MemoryStream();
            img.Save(Ms, img.RawFormat);
            return Ms.GetBuffer();
        }

        private void bunifuCustomDataGrid1_SelectionChanged(object sender, EventArgs e)
        {
            dgvLoginHistory.ClearSelection();
        }

        string currentTheme;
        private void ActiveRadioButton(object sender , EventArgs e )
        {
            var rdb = sender as RadioButton;
            if (rdb.Checked)
            {
                //Theme(rdb.Text, panels);
                currentTheme = rdb.Text;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            var bmp = Theme.DarkBack(this.ParentForm);

            using (Panel p = new Panel())
            {
                p.Location = new Point(0, 0);
                p.Size = this.ParentForm.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                this.ParentForm.Controls.Add(p);
                p.BringToFront();

                using (EditSetting editSetting = new EditSetting())
                {
                    editSetting.ShowDialog();

                    if (editSetting.compeletFlag)
                    {
                        if(!string.IsNullOrEmpty(editSetting.username)) lblUsername.Text = editSetting.username;
                        Current.User.SearchUser(editSetting.username);
                        Current.User.Activities.Add(new Activity("Edit Profile Information", "information has been changed by " + Current.User.Firstname + " " + Current.User.Lastname));

                    }
                }
            }
        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            //Theme(currentTheme, panels);
            Theme.ChangeTheme(currentTheme, panels);
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
        }

        public static bool updateWeatherFlag = false;

        private void btnExchangeCity_Click(object sender, EventArgs e)
        {
            if (File.Exists("WeatherData.txt"))
            {
                var bmp = Theme.DarkBack(this.ParentForm);

                using (Panel p = new Panel())
                {
                    p.Location = new Point(0, 0);
                    p.Size = this.ParentForm.ClientRectangle.Size;
                    p.BackgroundImage = bmp;
                    this.ParentForm.Controls.Add(p);
                    p.BringToFront();

                    using (DialogCity dialogCity = new DialogCity())
                    {
                        dialogCity.ShowDialog();

                        if (dialogCity.city != null)
                        {
                            lblCity.Text = dialogCity.city.Name;
                            updateWeatherFlag = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Related Data Not Found ."  , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }
    }
}
