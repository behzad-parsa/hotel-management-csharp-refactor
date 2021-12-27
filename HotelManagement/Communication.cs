using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Kavenegar.Models;
using Kavenegar.Utils;
using Kavenegar;
using System.Threading;



namespace HotelManagement
{
    public class Communication
    {
        private object _lock = new object();
        private object _lockSms = new object();
        public  Queue<Email> queueEmail = new Queue<Email>();
        public  Queue<Sms> queueSms = new Queue<Sms>();
        public static bool InternetConnection;

        Thread threadEmail;
        Thread threadSms;
        public Communication()
        {
            threadEmail = new Thread(new ThreadStart(SendMailThread)) { IsBackground = true };
            threadSms = new Thread(new ThreadStart(SendSmsThread)) { IsBackground = true };
        }
        //public static void StartCheckInternetConnection()
        //{
        //    Thread checkConnection = new Thread(new ThreadStart(CheckInternetConnection)) { IsBackground = true };
        //    checkConnection.Start();
        //}
        public static void CheckInternetConnection()
        {

            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    InternetConnection = true;
                }
            }
            catch
            {
                InternetConnection = false;
            }
        }
        public void StartThread()
        {
            try
            {


                if (!threadEmail.IsAlive)
                {
                    threadEmail.Start();

                }
                if (!threadSms.IsAlive)
                {
                    threadSms.Start();

                }

            }
            catch 
            {

                ;
            }




        }
        //public void StopThread()
        //{
        //    try
        //    {


        //        if (threadEmail.IsAlive)
        //        {
        //            threadEmail.s()

        //        }

        //    }
        //    catch
        //    {

        //        ;
        //    }




        //}

        public static bool SendMail(string To  , string name , string subject , string body)
        {

            try
            {
                
                var fromAddress = new MailAddress("behzad065@gmail.com", "Hotel Managment Software");
                var toAddress = new MailAddress(To, name);
                const string fromPassword = "";


                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }



                return true;

            }
            catch 
            {

                return false ;
            }
       




        }
        public static bool SendSMS(string receiverNumber, string text)
        {
            try
            {
                KavenegarApi smsApi = new KavenegarApi("");
                 var res = smsApi.Send("100065995", receiverNumber, text);


                return true;
            }
            catch 
            {

                return false;
            }




        }
   
        

        private void SendMailThread()
        {
            try
            {
                while (true)
                {
                    lock (_lock)
                    {



                        if (queueEmail.Count != 0)
                        {

                            var email = queueEmail.Dequeue();
                            queueEmail.Enqueue(email);

                            //if (!SendMail(email.Receiver, email.Name, email.Subject, email.Body))
                            //{

                            //    queueEmail.Enqueue(email);


                            //}


                        }


                    }

                }

            }
            catch 
            {
                ;
                
            }

        }
        private void SendSmsThread()
        {
            try
            {
                while (true)
                {
                    lock (_lockSms)
                    {



                        if (queueSms.Count != 0)
                        {

                            var sms = queueSms.Dequeue();
                            SendSMS(sms.Receiver, sms.Body);

                            //if (!SendSMS(sms.Receiver,sms.Body))
                            //{

                            //    queueSms.Enqueue(sms);


                            //}


                        }


                    }

                }

            }
            catch
            {
                ;

            }

        }
    }

    public class Email
    {
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Name { get; set; }

        public string Body { get; set; }

        public Email(string receiver, string name, string subject, string body)
        {
            this.Receiver = receiver;
            this.Subject = subject;
            this.Name = name;
            this.Body = body;


        }



    }

    public class Sms
    {
        public string Receiver { get; set; }


        public string Body { get; set; }

        public Sms(string receiver, string body)
        {
            this.Receiver = receiver;
            this.Body = body;


        }


    }
}
