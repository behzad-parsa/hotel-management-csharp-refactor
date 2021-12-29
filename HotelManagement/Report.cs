using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stimulsoft.Base;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;

namespace HotelManagement
{
    public class Report
    {



        public static void SetHotelComponents(StiReport report ,BranchSecond branch)
        {

            StiText txtHotelName = new StiText();
            txtHotelName = (StiText)report.GetComponentByName("txtHotelName");
            txtHotelName.Text = branch.BranchName + " " + "Hotel";
            //(StiText)report["txtHotelName"].te = "H";



            StiText txtUser = new StiText();
            txtUser = report.GetComponentByName("txtUser") as StiText;
            txtUser.Text = Current.User.Firstname + " " + Current.User.Lastname;

            StiText txtDateTime = new StiText();
            txtDateTime = report.GetComponentByName("txtDateTime") as StiText;
            txtDateTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");



            StiImage hotelImage = new StiImage();
            hotelImage = report.GetComponentByName("imgLogo") as StiImage;
            hotelImage.ImageBytes = branch.Logo;

            //StiImage star = new StiImage();
            //star.Image = Properties.Resources.star;
            //star.DockStyle = StiDockStyle.Left;

            StiPanel panelStar = new StiPanel();
            panelStar = report.GetComponentByName("panelStar") as StiPanel;
            //panelStar.Components.Add(star);
            int branchRate = Convert.ToInt32(branch.Rate);

            for (int i = 0; i < branchRate; i++)
            {
                StiImage imgStar = new StiImage();
                //imgStar.Name = "H"+i;
                //imgStar = (StiImage) report.GetComponentByName("H");
                imgStar.Width = imgStar.Height = 0.2;
                imgStar.Image = Properties.Resources.star;
                //imgStar.Left = (double)(i/10);
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

            //SetHotelComponents(report);

            StiReport report = new StiReport();
            report.Load(reportPath);
            //StiText txtTitle = new StiText();
            //txtTitle = report.GetComponentByName("txtTitle") as StiText;
            //txtTitle.Text = "Food Menu";


            Report.SetHotelComponents(report, Current.User.Branch);
            
            report.RegBusinessObject(businessObjName,businessObj );
            report.Compile();

            report.Show();

        }

    }
}
