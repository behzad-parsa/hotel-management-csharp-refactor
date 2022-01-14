using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using HotelManagement.Models;

namespace HotelManagement
{
    public class Report
    {

        public static void SetHotelComponents(StiReport report ,Branch branch)
        {
            StiText txtHotelName = new StiText();
            txtHotelName = (StiText)report.GetComponentByName("txtHotelName");
            txtHotelName.Text = branch.BranchName + " " + "Hotel";

            StiText txtUser = new StiText();
            txtUser = report.GetComponentByName("txtUser") as StiText;
            txtUser.Text = Current.CurrentUser.Firstname + " " + Current.CurrentUser.Lastname;

            StiText txtDateTime = new StiText();
            txtDateTime = report.GetComponentByName("txtDateTime") as StiText;
            txtDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");

            StiImage hotelImage = new StiImage();
            hotelImage = report.GetComponentByName("imgLogo") as StiImage;
            hotelImage.ImageBytes = branch.Logo;

            StiPanel panelStar = new StiPanel();
            panelStar = report.GetComponentByName("panelStar") as StiPanel;

            int branchRate = Convert.ToInt32(branch.Rate);

            for (int i = 0; i < branchRate; i++)
            {
                StiImage imgStar = new StiImage();

                imgStar.Width = imgStar.Height = 0.2;
                imgStar.Image = Properties.Resources.star;
                imgStar.Stretch = true;
                imgStar.DockStyle = StiDockStyle.Left;
                panelStar.Components.Add(imgStar);                            
            }

            StiText txtStateCity = new StiText();
            txtStateCity = report.GetComponentByName("txtStateCity") as StiText;
            txtStateCity.Text = branch.State + " , " + branch.City;

            StiText txtTel = new StiText();
            txtTel = report.GetComponentByName("txtTel") as StiText;
            txtTel.Text = branch.Tel;

            StiText txtFooter = new StiText();
            txtFooter = report.GetComponentByName("txtFooter") as StiText;
            txtFooter.Text = branch.State+" , "+branch.City+" | "+ branch.Address+" | " + branch.Tel;
        }

        public static void Load( string reportPath , string businessObjName , object businessObj )
        {
            StiReport report = new StiReport();
            report.Load(reportPath);
            Report.SetHotelComponents(report, Current.CurrentUser.Branch);          
            report.RegBusinessObject(businessObjName,businessObj);
            report.Compile();
            report.Show();
        }
    }
}
