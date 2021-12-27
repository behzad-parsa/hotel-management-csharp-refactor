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
    public partial class NewBook : UserControl
    {

        public static int statusFlag = -1;
        public static int backFalg = -1;
       // public static int currentCustomerID; // Wrong -- THis is Act Id Check that Later .. It must be Cust ID
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        public static Customer customerInfo;

        //private int customerID;
        //private enum Status
        //{
        //    Green , 
        //    Red , 
        //    blue
        //};

        private enum Step
        {
            Back,
            Forward
         
        };
        public NewBook()
        {
            InitializeComponent();
   
        }
        private void NewBook_Load(object sender, EventArgs e)
        {
            CardCustomerDetail customerDetail = new CardCustomerDetail();
            customerDetail.Left = panelContainerInside.Width / 2 - customerDetail.Width / 2;
            customerDetail.Top = 10;
            //car.Left = 80;
           // this.ClientSize.Width / 2 - _thePanel.Size.Width / 2
            panelContainerInside.Controls.Clear();
            panelContainerInside.Controls.Add(customerDetail);



            //CardBookDetail car = new CardBookDetail();


            //panelContainerInside.Controls.Clear();
            //panelContainerInside.Controls.Add(car);

            btnNext.Visible = false;

            
        }

  





       

        private void panelContainerInside_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void panelContainerInside_ControlRemoved(object sender, ControlEventArgs e)
        {

            
        }


        private void StepChange(int level , Step status)
        {
            if (status == Step.Back)
            {

                if (level == 1)
                {
                    picS.Image = Properties.Resources.play_button_blue;
                    lineOne.LineColor = Color.FromArgb(0, 109, 240);
                    picOne.Image = Properties.Resources.OneBluee;
                    lineTwo.LineColor = Color.FromArgb(221, 221, 221);
                    picTwo.Image = Properties.Resources.twoG;
                    lineThree.LineColor = Color.FromArgb(221, 221, 221); ;
                    picThree.Image = Properties.Resources.threeG;
                }
                else if (level == 2)
                {
                    picTwo.Image = Properties.Resources.TwoBluee;
                    picThree.Image = Properties.Resources.threeG;
                    lineThree.LineColor = Color.FromArgb(221, 221, 221);
                    lineTwo.LineColor = Color.FromArgb(0, 109, 240);
                }
                //else if (level == 3)
                //{
                //    picThree.Image = Properties.Resources._1288812_64;
                //    lineTwo.LineColor = Color.FromArgb(33, 173, 140);
                //    picThree.Image = Properties.Resources._1288812_64;
                //}

            }
            else if (status == Step.Forward)
            {
                if (level == 1)
                {
                    picS.Image = Properties.Resources.play_button_green;
                    lineOne.LineColor = Color.FromArgb(33, 173, 140);
                    picOne.Image = Properties.Resources.success;

                    picTwo.Image = Properties.Resources.TwoBluee;
                    lineTwo.LineColor = Color.FromArgb(0, 109, 240); //blue
                }
                else if(level == 2)
                {


                    
                    picTwo.Image = Properties.Resources.success;
                    lineTwo.LineColor = Color.FromArgb(33, 173, 140);
                    picThree.Image = Properties.Resources.ThreeBluee;
                    lineThree.LineColor = Color.FromArgb(0, 109, 240);

                }
                else if(level == 3)
                {
                    picThree.Image = Properties.Resources.success;
                }

            }

        }
        private void btnNext_Click(object sender, EventArgs e)
        {


            if (customerInfo!= null && statusFlag == 1)
            {


                StepChange(1, Step.Forward);
                CardGuestDetail guestDetail = new CardGuestDetail();

                guestDetail.Left = panelContainerInside.Width / 2 - guestDetail.Width / 2 ;
                guestDetail.Top = 10;
                panelContainerInside.Controls.Clear();
                panelContainerInside.Controls.Add(guestDetail);

            }
            else if (statusFlag == 2)
            {
                StepChange(2, Step.Forward);
                CardBookDetail bookDetail = new CardBookDetail();
                bookDetail.Left = panelContainerInside.Width / 2 - bookDetail.Width / 2;
                bookDetail.Top = 10;
                panelContainerInside.Controls.Clear();
                panelContainerInside.Controls.Add(bookDetail);

            }



        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            if (backFalg == 1)
            {
                statusFlag = 1;
                StepChange(1, Step.Back);
                
                CardCustomerDetail customerDetail= new CardCustomerDetail(customerInfo);
                customerDetail.Left = panelContainerInside.Width / 2 - customerDetail.Width / 2;
                customerDetail.Top = 10;
                panelContainerInside.Controls.Clear();
                panelContainerInside.Controls.Add(customerDetail);
            }
            else if (backFalg == 2)
            {
                //statusFlag = 2;
                StepChange(2, Step.Back);
                CardGuestDetail guestDetail = new CardGuestDetail();
                guestDetail.Left = panelContainerInside.Width / 2 - guestDetail.Width / 2;
                guestDetail.Top = 10;
                panelContainerInside.Controls.Clear();
                panelContainerInside.Controls.Add(guestDetail);

            }





        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            NewBook.customerInfo = null;
            StepChange(1, Step.Back);
            CardCustomerDetail customerDetail = new CardCustomerDetail();
            customerDetail.Left = panelContainerInside.Width / 2 - customerDetail.Width / 2;
            customerDetail.Top = 10;
            panelContainerInside.Controls.Clear();
            panelContainerInside.Controls.Add(customerDetail);
        }
    }
}
