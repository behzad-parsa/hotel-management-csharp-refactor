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

        List<OnlineUserItem> lstOnlineItem = new List<OnlineUserItem>();
        private void LoadOnlineUser()
        {
            var lstOnline = chat.lstOnlineUser;
            if (lstOnline.Count != 0)
            {
                for (int i = 0; i <lstOnline.Count ; i++)
                {
                    OnlineUserItem item = new OnlineUserItem(lstOnline[i]);
                    item.DoubleClick += new EventHandler(OnlineUserItem_DoubleClick);
                    if (i == 0)
                    {
                        item.Top = 0;               
                    }
                    else
                    {
                        item.Top = lstOnlineItem[lstOnlineItem.Count - 1].Bottom;
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
            var sender = chat.lstDataSaver.FindAll(x => x.Message.Count > 0);

            foreach (var item in sender)
            {
                AddToPV(item);
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            clickedPV = null;

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
            if (q.Count != 0)
            {
                var msg = q.Dequeue();
                if (clickedPV != null && msg.ID == clickedPV.user.ID)
                {
                    AddMessage(msg.Text, msg.Date.ToString("hh:mm tt"), MsgType.In);
                    var index =   lstPVItem.FindIndex(x=>x == clickedPV);

                    lstPVItem[index].lblLastMessage.Text = msg.Text;
                    lstPVItem[index].lblTime.Text = msg.Date.ToString("hh:mm tt");
                    lstPVItem[index].Refresh();

                }
                else
                {
                    var h = lstPVItem.Find(x => x.user.ID == msg.ID);
                    if (h == null)
                    {
                        AddToPV(chat.lstDataSaver.Find(x=>x.ID == msg.ID));

                    }
                }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (clickedPV != null)
            {
                chat.sndMcg(ChatInfo.SendType.MessageToUser, txtMsg.Text, clickedPV.user.Username, DateTime.Now);
                AddMessage(txtMsg.Text, DateTime.Now.ToString("hh:mm tt"), MsgType.Out);
            }
            txtMsg.Text = "";
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

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;

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
