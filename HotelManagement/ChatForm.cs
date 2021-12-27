using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using User = HotelManagement.ChatInfo.User;
using Bunifu.Framework.UI;



namespace HotelManagement
{
    public partial class ChatForm : UserControl
    {
        public static ChatInfo.Chat chat = new ChatInfo.Chat();

        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        public ChatForm()
        {
            InitializeComponent();

        }

        //PVItem old = new PVItem();
        //OnlineUserItem oldOn = new OnlineUserItem();
        List<OnlineUserItem> lstOnlineItem = new List<OnlineUserItem>();
        private void LoadOnlineUser()
        {

            //int onlineCount = ChatInfo.DataKeeping.lstOnlineUser.Count;
            var lstOnline = chat.lstOnlineUser;
            if (lstOnline.Count != 0)
            {

                //OnlineUserItem b = new OnlineUserItem();
                //b.Top = 0;
                //panelOnline.Controls.Add(b);


                for (int i = 0; i <lstOnline.Count ; i++)
                {
                    //OnlineUserItem z = new OnlineUserItem();
                    //if (i == 0) z.Top = b.Bottom;
                    //else z.Top = oldOn.Bottom;
                    //panelOnline.Controls.Add(z);
                    //oldOn = z;
                    OnlineUserItem item = new OnlineUserItem(lstOnline[i]);
                    item.DoubleClick += new EventHandler(OnlineUserItem_DoubleClick);
                    if (i == 0)
                    {
                        //OnlineUserItem first = new OnlineUserItem(lstOnline[i]);
                        //first.Cursor = Cursors.Hand;
                        item.Top = 0;
                 
                    }
                    else
                    {
                        //OnlineUserItem second = new OnlineUserItem(lstOnline[i]);
                        //second.Cursor = Cursors.Hand;
                        item.Top = lstOnlineItem[lstOnlineItem.Count - 1].Bottom;
                        //lstOnlineItem.Add(second);
                        //panelOnline.Controls.Add(second);

                    }
                    lstOnlineItem.Add(item);
                    panelOnline.Controls.Add(item);

                }



            }




        }

        private void OnlineUserItem_DoubleClick(object sender , EventArgs e)
        {
            var item = sender as OnlineUserItem;
            AddToPV(item);


        }
        //static List<PVItem> lstPVItem = new List<PVItem>();
        List<PVItem> lstPVItem = new List<PVItem>();
        private void AddToPV(OnlineUserItem onlineItem)
        {
            var temp = lstPVItem.Find(x => x.user == onlineItem.user);
            if (temp == null)
            {
                PVItem item = new PVItem(onlineItem.user);
                item.MouseEnter += new EventHandler(PanelPV_MouseEnter);
                item.Click += new EventHandler(PanlePV_Click);
                item.MouseLeave += new EventHandler(PanelPV_MouseLeave);

                if (lstPVItem.Count != 0)
                {
                    item.Top = lstPVItem[lstPVItem.Count - 1].Bottom;

                }
                else
                {
                    item.Top = 0;


                }

                lstPVItem.Add(item);
                panelPV.Controls.Add(item);

            }
     
        }
        private void AddToPV(User user)
        {
            var temp = lstPVItem.Find(x => x.user == user);
            if (temp == null)
            {
                PVItem item = new PVItem(user);
                item.MouseEnter += new EventHandler(PanelPV_MouseEnter);
                item.Click += new EventHandler(PanlePV_Click);
                item.MouseLeave += new EventHandler(PanelPV_MouseLeave);

                if (lstPVItem.Count != 0)
                {
                    item.Top = lstPVItem[lstPVItem.Count - 1].Bottom;

                }
                else
                {
                    item.Top = 0;


                }

                lstPVItem.Add(item);
                panelPV.Controls.Add(item);

            }

        }
        public static Queue<ChatInfo.Message> q = new Queue<ChatInfo.Message>();
        private void LoadPanelPV()
        {

            //var senders = lstOnlineItem.FindAll(x => x.user.Message.Count > 0);
            var sender = chat.lstDataSaver.FindAll(x => x.Message.Count > 0);
            //var senders = ChatInfo.DataKeeping.UserDataSaver.FindAll(x => x.Message.Count > 0);

            foreach (var item in sender)
            {
                //if (lstOnlineItem.Contains())
                //{

                //}
                AddToPV(item);
                //var onItem = lstOnlineItem.Find(x => x.user.Username == item.Username);
                //if (onItem != null)
                //{
                //    AddToPV(onItem);
                //}
                //else
                //{
                //    OnlineUserItem o = new OnlineUserItem(item);
                //    AddToPV(o);
                //}

            }
            //var h= message.Text;
            //var g = q.Count;

        }
        private void Chat_Load(object sender, EventArgs e)
        {
            clickedPV = null;
            //ChatInfo.Chat

            //frmMain.chat.sn;
            //string g = "";
            //foreach (var item in ChatInfo.DataKeeping.lstOnlineUser)
            //{
            //    g += item.Name + "\n";

            //}

            ///chat.sndMcg(ChatInfo.SendType.OnlineListRequest, null);
            // MessageBox.Show(ChatInfo.DataKeeping.lstOnlineUser.Count.ToString());

            //PVItem p = new PVItem();
            //p.Top = 0;
            //panelPV.Controls.Add(p);
            ////p.Click += new EventHandler(PanelPV_Click);
            //p.MouseEnter += new EventHandler(PanelPV_MouseEnter);
            ////p.Leave += new EventHandler(PanelPV_Leave);
            //p.Click += new EventHandler(PanlePV_Click);
            ////p.MouseClick += new MouseEventHandler(Panel_Click);
            ////p.MouseHover += new EventHandler(PanelPV_Click);
            //p.MouseLeave += new EventHandler(PanelPV_MouseLeave);
            //// p.Leave += new EventHandler(PanelL_Click);

            //for (int i = 0; i < 8; i++)
            //{
            //    PVItem q = new PVItem();
            //    if (i == 0) q.Top = p.Bottom;
            //    else q.Top = old.Bottom;
            //    //panelPV.Controls.Add(q);
            //    //o.MouseClick += new MouseEventHandler(Panel_Click);
            //    q.MouseEnter += new EventHandler(PanelPV_MouseEnter);
            //    //o.Click += new EventHandler(Panel_Click);
            //    //o.MouseClick += new MouseEventHandler(PanelPV_Click);
            //    //o.MouseHover += new EventHandler(PanelPV_Click);
            //    //o.Leave += new EventHandler(PanelPV_Leave);
            //    q.Click += new EventHandler(PanlePV_Click);
            //    q.MouseLeave += new EventHandler(PanelPV_MouseLeave);
            //    panelPV.Controls.Add(q);
            //    old = q;

            //}


            //var h = chat.lstOnlineUser;

            //if (lstPVItem.Count != 0)
            //{
            //    foreach (var item in lstPVItem)
            //    {
            //        panelPV.Controls.Add(item);

            //    }
            //}


            LoadOnlineUser();
            LoadPanelPV();

            timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(checkNewMessage);
            timer1.Start();


        }
        Timer timer1;
        private void checkNewMessage(object sender , EventArgs e)
        {
            //var j = chat.lstOnlineUser;
            //if (message != null )
            //{
            //    q.Enqueue(message);
                
            //    //If New Message Rcevive
            //    if (clickedPV != null && message.ID == clickedPV.user.ID)
            //    {
                    
            //        AddMessage(message.Text, message.Date.TimeOfDay.ToString(), MsgType.In);
                   
            //    }

            //    //if User  Not in List ----- CHeckout Queue 
            //    var h = lstPVItem.Find(x => x.user.ID == message.ID);
            //    if (h == null)
            //    {
            //        AddToPV(lstOnlineItem.Find(x => x.user.ID == message.ID));

            //    }

            //    message = null;

            //}
            if (q.Count != 0)
            {
                var msg = q.Dequeue();
                if (clickedPV != null && msg.ID == clickedPV.user.ID)
                {

                    AddMessage(msg.Text, msg.Date.ToString("hh:mm tt"), MsgType.In);
                    var index =   lstPVItem.FindIndex(x=>x == clickedPV);
                    //lstPVItem[index].lastMsg= msg.Text;
                    lstPVItem[index].lblLastMessage.Text = msg.Text;
                    lstPVItem[index].lblTime.Text = msg.Date.ToString("hh:mm tt");
                    lstPVItem[index].Refresh();
                    //this.Refresh();
                }
                else
                {
                    var h = lstPVItem.Find(x => x.user.ID == msg.ID);
                    if (h == null)
                    {
                        AddToPV(chat.lstDataSaver.Find(x=>x.ID == msg.ID));

                    }
                }

                //if User  Not in List ----- CHeckout Queue 
                // var h = lstPVItem.Find(x => x.user.ID == message.ID);
                // if (h == null)
                // {
                //     AddToPV(lstOnlineItem.Find(x => x.user.ID == message.ID));

                // }

                //// message = null;


            }


        }





        PVItem clickedPV;
        private void PanlePV_Click(object sender, EventArgs e)
        {
            var pan = sender as PVItem;

            if (clickedPV != null)
            {
                clickedPV.BackColor = Color.White;

            }

            pan.BackColor = Color.LightBlue;

            clickedPV = pan;


            var lstMsg = pan.user.Message.OrderBy(x => x.Date).ToList();
            if (lstMsg.Count != 0)
            {
                lstMessage.Clear();
                panelMessage.Controls.Clear();
               // MessageBox/
                //for (int i = 0; i < lstMsg.Count; i++)
                //{
                //    if (ls)
                //    {

                //    }
                //}
                foreach (var item in lstMsg)
                {
                    if (item.ID == pan.user.ID)
                    {
                        AddMessage(item.Text, item.Date.ToString("hh: mm tt"), MsgType.In);
                    }
                    else
                    {
                        AddMessage(item.Text, item.Date.ToString("hh:mm tt"), MsgType.Out);
                    }

                }

            }

       
           

        }

        int top = 10;
        List<Bubble> lstMessage = new List<Bubble>();
        private void AddMessage(string text , string time , MsgType msgType)
        {
            Bubble bbl = new Bubble(text , time , msgType);

            //bbl.Left = 10;
            //bbl.Top = top;
            //top = bbl.Bottom + 10;

            bbl.Size = new Size(475, 211);

            

            if (lstMessage.Count != 0)
            {

                if ( msgType == MsgType.In)
                {
                    var lastBubble = lstMessage.ElementAt(lstMessage.Count - 1);

                    bbl.Location = new Point(10, lastBubble.Bottom + 10);
                    lstMessage.Add(bbl);
                    panelMessage.Controls.Add(bbl);
                   



                }
                else
                {
                    var lastBubble = lstMessage.ElementAt(lstMessage.Count - 1);
  
                    bbl.Location = new Point(430 , lastBubble.Bottom + 10);
                    lstMessage.Add(bbl);
                    panelMessage.Controls.Add(bbl);
                }


            }


            else
            {
                if (msgType == MsgType.In)
                {
                   
                    bbl.Top = top;
                    bbl.Location = new Point(10, top);
                    panelMessage.Controls.Add(bbl);
                    lstMessage.Add(bbl);

                }
                else
                {
                    //bbl.Left = 10;
                    bbl.Top = top;
                    bbl.Location = new Point(430, top);
                    panelMessage.Controls.Add(bbl);
                    lstMessage.Add(bbl);
                }

            }




        }
        private void PanelPV_MouseEnter(object sender , EventArgs e)
        {
            var pan = sender as PVItem;

            

            if (pan != clickedPV)
            {
                pan.BackColor = Color.Pink;

            }
          

        }
        private void PanelPV_MouseLeave(object sender, EventArgs e)
        {
            var pan = sender as PVItem;

            

            if (pan != clickedPV)
            {
                pan.BackColor = Color.White;
            }


        }

        public static ChatInfo.Message message;
        Bubble oldBubble = new Bubble();
        //int counter = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(panelMessage.Top.ToString() + " " + panelMessage.Bottom.ToString());
            // Bubble b = new Bubble();
            // if (counter == 0) b.Top = 0;
            // else b.Top = oldBubble.Bottom + 1;
            //// b.Top = 0   ;
            // panelMessage.Controls.Add(b);
            // oldBubble = b;
            // counter++;
            

            if (clickedPV != null)
            {

                chat.sndMcg(ChatInfo.SendType.MessageToUser, txtMsg.Text, clickedPV.user.Username, DateTime.Now);
                AddMessage(txtMsg.Text, DateTime.Now.ToString("hh:mm tt"), MsgType.Out);

            }

            txtMsg.Text = "";
            //AddMessage("Hello", DateTime.Now.TimeOfDay.ToString(), MsgType.In);
            //AddMessage("Hello", DateTime.Now.TimeOfDay.ToString(), MsgType.Out);
        }

        private void txtMsg_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void ChatForm_Leave(object sender, EventArgs e)
        {
            if (clickedPV != null)
            {
                clickedPV.BackColor = Color.White;
            }
            timer1.Stop();
            panelMessage.Controls.Clear();
        }
        //private void PanelLl_Click(object sender, EventArgs e)
        //{
        //    var pan = sender as PanelPV;



        //    if (pan == clilckedPanel)
        //    {
        //        pan.BackColor = Color.White;
        //    }


        //}

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
            //if (txtBox != txtNCSearch)
            //{
            //    txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);

       

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
                txtBox.ForeColor = Color.Gray;
            }


        }
    }
}
