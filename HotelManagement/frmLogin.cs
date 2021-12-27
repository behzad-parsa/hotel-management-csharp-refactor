using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Threading;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace HotelManagement
{
    public partial class frmLogin : Form
    {
        Timer timer1 = new Timer();
        Timer timer2 = new Timer();
        Timer timer3 = new Timer();
        Label lblPage = new Label();
        Timer timerProgress = new Timer();
        public frmLogin()
        {
            InitializeComponent();
            this.Size = new Size(426, 703);
            //pictureBox2.Image = Properties.Resources.icons8_Eye_96px_1;
        }

        //Move Location On Runing
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        TimeSpan startTime = new TimeSpan(0, 9, 0);
        Timer timerReset = new Timer();
        TimeSpan oneSecond = new TimeSpan(0, 0, 1);
        private void frmLogin_Load(object sender, EventArgs e)
        {
            //LblErrorFrogot.Visible = false;
            timer1.Tick += new EventHandler(timer1_go);
            timer2.Tick += new EventHandler(timer2_go);
            timer3.Tick += new EventHandler(timer3_go);

            timer1.Interval = 10;
            timer2.Interval = 5;
            timer3.Interval = 1000;
            timer1.Start();
            PasswordVisibility(true);
            //pictureLock.Image = Properties.Resources.padlock;
            timerReset.Interval = 1000;
            timerReset.Tick += TimerReset_Tick;



            timerProgress.Interval = 2000;
            timerProgress.Tick += TimerProgress_Tick;
        }

        private void TimerReset_Tick(object sender, EventArgs e)
        {
            startTime = startTime.Subtract(oneSecond) ;
            lblTime.Text = startTime.ToString();
            if (startTime == new TimeSpan(0,0,0))
            {

                //LoginPanelAnimation();
                //step1Flag = false;
                //btnCheck.ButtonText = "Check";
                //labelHeader.Text = "Enter Your Email :";
                //lblTime.Visible = false;
                //timerReset.Stop();
                //startTime = new TimeSpan(0, 9, 0);
                //pictureLock.Image = Properties.Resources.login;
                ResetForgotPanel();

            }
        }

        private int count =2;

        private void TimerProgress_Tick(object sender, EventArgs e)
        {
            var timer = sender as Timer;

 
             prgWaiting.Visible = false; 
            
            //prgWaiting.Visible = true;

            
           
        }

        private void timer1_go(object sender , EventArgs e)
        {
            LogoPosition();

        }
        private void ResetForgotPanel()
        {

            LoginPanelAnimation();
            step1Flag = false;
            btnCheck.ButtonText = "Check";
            labelHeader.Text = "Enter Your Email :";
            lblTime.Visible = false;
            timerReset.Stop();
            startTime = new TimeSpan(0, 9, 0);
            pictureLock.Image = Properties.Resources.login;
            sendAgainFlag = false;
            LblErrorFrogot.Visible = false;
        }

        private void timer2_go(object sender , EventArgs e)
        {
            if (lblPage.Text == "Forgot The Password ?")
            {
                ForgotPassPanelAnimation();
                pictureLock.Image = Properties.Resources.password;

            }
            if(lblPage.Text=="Login")
            {
                //LoginPanelAnimation();

                //pictureLock.Image = Properties.Resources.login;
                ResetForgotPanel();



            }


        }

        private int countDownTime ;
        private void timer3_go(object sender, EventArgs e)
        {
            countDownTime--;
            if (countDownTime == 0)
            {
                timer1.Stop();
                new frmMain().Show();
                this.Hide();
            }
                //pictureLock.Image = Properties.Resources.unlock;


            }

        int go = 1;
        private void LogoPosition()
        {
            if (panel1.Left == 0 )
            {

                pictureLock.Top += go;

                if (pictureLock.Top>50)
                {
                    timer1.Stop();
                }

            }

            if (panel2.Left ==0)
            {

                pictureLock.Top -= go;
                if (pictureLock.Top <34)
                {

                    timer1.Stop();

                }

            }

        }

        void line()
        {
            if (panel1.Left == 0)
            {
                bunifuSeparator2.LineThickness = 2;
                bunifuSeparator2.LineColor = Color.FromArgb(0, 173, 239);
                bunifuSeparator1.LineThickness = 1;
                bunifuSeparator1.LineColor = Color.Silver;
            }
            if (panel2.Left == 0)
            {
                bunifuSeparator2.LineThickness = 1;
                bunifuSeparator2.LineColor = Color.Silver;
                bunifuSeparator1.LineThickness = 2;
                bunifuSeparator1.LineColor = Color.FromArgb(0, 173, 239);
            }
        }

       

        //slide panel
        int move_speed = 20;
        void ForgotPassPanelAnimation()
        {
            if (panel2.Left > 0)
            {
                timer1.Start();
                line();

                panel1.Left -= move_speed;
                panel2.Left -= move_speed;
                if (panel2.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }
        private void LoginPanelAnimation()
        {
            if (panel1.Left < 0)
            {
                timer1.Start();
                line();

                panel2.Left += move_speed;
                panel1.Left += move_speed;
                if (panel1.Left == 0)
                {
                    timer2.Stop();
                }
            }
        }



        private void LblCLickMethod(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            lblPage = lbl;
            timer2.Start();

           
        }

        private void PasswordVisibility(bool status)
        {
            if (status)
            {
                //textBox2.PasswordChar = '\0';
                //pictureBox2.Image = Properties.Resources.show;
                txtPassword.isPassword = false;
                pictureEye.Image = Properties.Resources.Invisible;


            }
            else
            {
                txtPassword.isPassword = true;
                pictureEye.Image = Properties.Resources.Eye;

            }

        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            

            if (txtPassword.isPassword)
            {
                //textBox2.PasswordChar = '\0';
                //pictureBox2.Image = Properties.Resources.show;
                //txtPassword.isPassword = false;
                //pictureEye.Image = Properties.Resources.Invisible;
                PasswordVisibility(true);

            }
            else
            {
                //txtPassword.isPassword = true;
                //pictureEye.Image = Properties.Resources.Eye;
                PasswordVisibility(false);
            }

        }




        void TextBoxes_Enter(object sender, EventArgs e)
        {
            Control control = sender as Control;
            control.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            
            txtUsername.ForeColor = Color.Black;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ( (txtUsername.Text == null || txtUsername.Text == "" ) && (txtPassword.Text == null || txtPassword.Text == "") )
            {
                txtUsername.LineIdleColor = Color.Red;
                txtPassword.LineIdleColor = Color.Red;
                lblErrorLogin.Visible = true;
                lblErrorLogin.Text = "Please Fill The Blank";


            }
            else
            {
                if (txtUsername.Text == null || txtUsername.Text == "")
                {
                    lblErrorLogin.Visible = true;
                    lblErrorLogin.Text = "Username Cannot Be Null";
                    txtUsername.LineIdleColor = Color.Red;



                }

                else if (txtPassword.Text == null || txtPassword.Text == "")
                {
                    lblErrorLogin.Visible = true;
                    lblErrorLogin.Text = "Password Cannot Be Null";
                    txtPassword.LineIdleColor = Color.Red;



                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                   // Current.User.Username = txtUsername.Text.ToLower();
                    //Check The Username
                    if (Current.User.SearchUser(txtUsername.Text.ToLower().Trim()))
                    {

                        HashPassword hashPass = new HashPassword();
                        

                        //Check The Password
                        if (hashPass.ComparePass(Current.User.Password, txtPassword.Text))
                        {

                            //Check The Activate
                            if (Current.User.Activate == true)
                            {
                                //NextPage
                                //countDownTime = 5;
                               // pictureLock.Image = Properties.Resources.unlock;
                                Current.User.InsertLoginHistory();
                                //timer3.Start();

                                //using (frmMain main = new frmMain())
                                //{
                                    new frmMain().Show();
                                    this.Hide();

                                    //main.Show();
                                    ////this.Hide();
                                //}


                                //timer3.Stop();


                            }
                            else
                            {
                                lblErrorLogin.Visible = true;
                                lblErrorLogin.Text = "Access Denied \nYour Activation has been Canceled .";
                            }
                            
                   

                        }
                        else
                        {
                            lblErrorLogin.Visible = true;
                            lblErrorLogin.Text = "Username Or Password Is Wrong";
                        }

                       

                    }
                    else
                    {
                        lblErrorLogin.Visible = true;
                        lblErrorLogin.Text = "Username Or Password Is Wrong";
                    }


                    this.Cursor = Cursors.Default;
                }

            }

          





        }

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {
            lblErrorLogin.Visible = false;
            txtUsername.LineIdleColor = Color.FromArgb(0, 173, 239); ;
            txtUsername.ForeColor = Color.Black;
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            lblErrorLogin.Visible = false;
            txtPassword.LineIdleColor = Color.FromArgb(0, 173, 239); ;
            txtPassword.ForeColor = Color.Black;

        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.ForeColor = Color.Black;
        }
        private string GenerateStrCode()
        {

            string str = "qwertyuiopasdfghjklzxcvbnm1234567890";
            string rndStr ="" ;

            Random rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                rndStr += str[rnd.Next(0 , str.Length-1)];
            }




            return rndStr;
        }
        private string GeneratePassCode()
        {

            string str = "qwertyuiopasdfghjklzxcvbnm1234567890";
            string rndStr = "";

            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                rndStr += str[rnd.Next(0, str.Length - 1)];
            }




            return rndStr;
        }

        string rndStr;
        bool step1Flag = false;
        bool sendAgainFlag= false;
        string saveEmail;
        private bool validationFlag = false;
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!sendAgainFlag)
            {
                if (txtForgotEmail.Text != "Email" && !string.IsNullOrEmpty(txtForgotEmail.Text))
                {

                    validationFlag = true;


                }
                else
                {

                    LabelStatus(LblErrorFrogot, "Please Fill The Blank", Status.Red);
                    txtForgotEmail.LineIdleColor = Color.Red;
                }



                if (validationFlag)
                {
                    validationFlag = false;
                    if (Current.User.SearchUserEmail(txtForgotEmail.Text))
                    {
                        rndStr = GenerateStrCode();
                        string body = "Your Confirmation Code is: \n " + rndStr;


                        if (Communication.SendMail(txtForgotEmail.Text.Trim(), Current.User.Username, "Confirm Code", body))
                        {
                            saveEmail = txtForgotEmail.Text.Trim();
                            //txtForgotEmail.HintText = "";
                            labelHeader.Text = "Enter The Code :";
                            btnCheck.ButtonText = "Send Again";
                            //LblErrorFrogot.Visible = true;
                            
                            //txtForgotEmail.HintText = "Confirm Code";

                            txtForgotEmail.Text = null;
                            sendAgainFlag = true;
                            lblTime.Visible = true;
                            timerReset.Start();
                            step1Flag = true;
                            LabelStatus(LblErrorFrogot, "The Code Was Sent, Please Check Your Mail", Status.Green);

                        }
                        else
                        {

                            LabelStatus(LblErrorFrogot, "Unable To Complete Action", Status.Red);
                        }

                    }
                    else
                    {

                        LabelStatus(LblErrorFrogot, "Couldn't Find This Mail", Status.Red);
                    }



                }


            }

            else
            {
                rndStr = GenerateStrCode();
                string body = "Your Confirmation Code is: \n " + rndStr;


                if (Communication.SendMail(saveEmail, Current.User.Username, "Confirm Code", body))
                {
                    //txtForgotEmail.HintText = "";
                    //labelHeader.Text = "Enter The Code :";
                   // btnCheck.ButtonText = "Send Again";
                    
                    txtForgotEmail.Text = null;
                    //txtForgotEmail.HintText = "Confirm Code";
                    lblTime.Visible = true;
                    startTime = new TimeSpan(0, 9, 0);
                    
                    timerReset.Start();
                    step1Flag = true;
                    LabelStatus(LblErrorFrogot, "The Code Was Sent, Check Your Mail", Status.Green);
                    //saveEmail = txtForgotEmail.Text.Trim();
                }
                else
                {

                    LabelStatus(LblErrorFrogot, "Unable To Complete Action", Status.Red);
                }
            }





        }
        public enum Status
        {
            Red,
            Green

        }

        private void LabelStatus(Control lbl  , string text, Status status)
        {
            lbl.Visible = true;
            lbl.Text = text;
            if (status ==  Status.Red)
            {
                lbl.ForeColor = Color.Brown;


            }
            else
            {
                lbl.ForeColor = Color.Cyan;
                
            }




        } 


        private void txtForgotEmail_OnValueChanged(object sender, EventArgs e)
        {
            LblErrorFrogot.Visible = false;
            if (step1Flag)
            {
                step1Flag = false;

                //timerProgress.Stop();
               // prgWaiting.Visible = true;
                
                //timerProgress.Start();
                if (txtForgotEmail.Text == rndStr)
                {

                    //Current.User.UpdatePassword();

                    var pass = GeneratePassCode();
                    HashPassword hp = new HashPassword();
                    if (Current.User.UpdatePassword(hp.ConvertPass(pass)))
                    {
                        string body = "Dear , " + Current.User.Username + "\n\n" + "Your Password Has Been Changed :\t" + pass;
                        Communication.SendMail(saveEmail, Current.User.Username, "New Password", body);

                        LabelStatus(LblErrorFrogot, "Confirmed ,\n Check Your Mail To Get New Password", Status.Green);
                        timerReset.Stop();
                    }
                    //behzad.afb2012 @gmail.com




                }
                else
                {
                    //prgWaiting.Visible = false;
                    //timerProgress.Interval = 1000;
                    //timerProgress.Start();
                }
               // timerProgress.Stop();
            }
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
