using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using User = HotelManagement.ChatInfo.User;
using Message = HotelManagement.ChatInfo.Message;
using HotelManagement.Services;


namespace HotelManagement
{
    namespace ChatInfo
    {
        public enum SendType
        {
            OnlineListRequest,
            DisconnectRequest,
            MessageToUser
        }
        public class DataKeeping
        {
            public static List<User> UserDataSaver = new List<User>();
        }

        public class Chat
        {
            private readonly UserService _userService = new UserService();
            Socket socClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            static readonly object _lock = new object();
            public bool IsConnect { get; private set; }
            //static List<User> lstUser = new List<User>();
            public List<User> lstOnlineUser = new List<User>();
            public List<User> lstDataSaver = new List<User>();
            public List<User> lstAll = new List<User>();
            public bool ConnectToChatServer()
            {
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint iep = new IPEndPoint(ip, 5050);
                try
                {
                    socClient.Connect(iep);

                    //Send Username To Server As Online User 
                    byte[] b = new byte[1024];
                    b = Encoding.Unicode.GetBytes(Current.CurrentUser.Username);
                    socClient.Send(b);
                    //--------------------------------------
                    //lstUser.Add(new User());

                    Thread Tr = new Thread(new ThreadStart(ReceiveMessage)) { IsBackground = true };
                    Tr.Start();

                    IsConnect = true;
                    return true;
                }
                catch (Exception e1)
                {
                    IsConnect = false;
                    return false;
                }
            }
            public bool DisconnectChatServer()
            {
                byte[] b = new byte[1024];
                b = Encoding.Unicode.GetBytes("MessageFormat To Disconnect From Server");
                socClient.Send(b);
                try
                {
                    if (socClient != null)
                    {
                        socClient.Shutdown(SocketShutdown.Both);
                        socClient.Close();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            private void ReceiveMessage()
            {
                try
                {
                    while (true)
                    {

                        byte[] b = new byte[1024];
                        int rcvB = socClient.Receive(b);
                        string msg = Encoding.Unicode.GetString(b, 0, rcvB);
                        string[] _msg;

                        if (msg.Substring(0, 3) == "Res")
                        {
                            _msg = msg.Split(new char[] { '%' }, 3);
                           
                            if (_msg[1] == "Online")
                            {
                                // _msg[2] =  _msg[2].Replace(Current.User.Username+"+", "");

                                string[] onlineUser = _msg[2].Split('+');
                                lstOnlineUser.Clear();
                                for (int i = 0; i < onlineUser.Length; i++)
                                {                                  
                                    if (onlineUser[i] != Current.CurrentUser.Username)
                                    {
                                        //var userInfo = HotelDatabase.User.SearchOnlineUser(onlineUser[i]);
                                        var userInfo = _userService.GetOnlineUser(onlineUser[i]);
                                        if(userInfo != null)
                                        {
                                            lstOnlineUser.Add(userInfo);
                                            if (!lstAll.Contains(userInfo))
                                            {
                                                lstAll.Add(userInfo);

                                            }
                                         }
                                    }
                                }                
                            }
                            else if (_msg[1] == "Disconnect")
                            {
                                //response = "%Res%Disconnect";
                            }
                        }
                        else if (msg.Substring(0, 3) == "Msg")
                        {
                            _msg = msg.Split(new char[] { '%' }, 4);
                            string[] msgSplitTime = _msg[3].Split(new char[] { '%' }, 2);
                            int userIndex = -1;
                            userIndex = lstDataSaver.IndexOf(lstDataSaver.Find(x => x.Username == _msg[1]));
                            if (userIndex > -1)
                            {
                                Message message = new Message(lstDataSaver[userIndex].ID, msgSplitTime[1], Convert.ToDateTime(msgSplitTime[0]));
                                lstDataSaver[userIndex].Message.Add(message);
                                ChatForm.q.Enqueue(message);
                            }
                            else
                            {
                                var user = lstAll.Find(x => x.Username == _msg[1]);
                                Message message = new Message(user.ID, msgSplitTime[1], Convert.ToDateTime(msgSplitTime[0]));
                                user.Message.Add(message);
                                lstDataSaver.Add(user);
                                ChatForm.q.Enqueue(message);
                            }
                        }
                    }
                }//End Try
                catch
                {
                    ;
                } //Catch
            }
            public void SendMessage(SendType sndType, string text , string receiver , DateTime date)
            {
                string msg = "";
                if (sndType == SendType.OnlineListRequest)
                {
                    msg = "Req%Online";
                }
                else if(sndType == SendType.DisconnectRequest)
                {
                    msg = "Req%Disconnect";
                }
                else
                {
                    //Msg%sender%receiver%Text%Time
                    msg = "Msg%" + Current.CurrentUser.Username + "%" + receiver + "%" + date+"%"+ text;
                    var user = lstOnlineUser.Find(x => x.Username == receiver);
                    if (user != null)
                    {
                        //string[] msgSplitTime = _msg[3].Split(new char[] { '%' }, 2);
                        lstOnlineUser.Remove(user);
                        user.Message.Add(new Message(Current.CurrentUser.ID , text, date));
                        lstOnlineUser.Add(user);
                    }
                }
                byte[] b = new byte[1024];
                b = Encoding.Unicode.GetBytes(msg);
                socClient.Send(b);
            }
        }

        public class User
        {

            public int ID { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }

            public string Branch { get; set; }

            public byte[] Image { get; set; }

            public List<Message> Message { get; set; }
            public User()
            {
                Message = new List<Message>();
            }
            public User(int id, string name, string username, string branch)
            {
                this.ID = id;
                this.Name = name;
                this.Branch = branch;
                this.Username = username;
                Message = new List<Message>(); 
            }
        }


        public class Message
        {
            public int ID { get; set; }
            public string Text { get; set; }
            public DateTime Date { get; set; }
            public bool Seen { get; set; }
            public Message()
            {
            }
            public Message(int id , string txt , DateTime time)
            {
                ID = id;
                Text = txt;
                Date = time;
            }
        }
    }
 
}
