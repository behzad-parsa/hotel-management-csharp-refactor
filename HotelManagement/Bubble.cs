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
    public partial class Bubble : UserControl
    {

      


        public MsgType Type { get; private set; }
        public Bubble()
        {
            InitializeComponent();
        }

        public Bubble(string msg , string time ,MsgType msgType )
        {
            InitializeComponent();

            Type = msgType;
            lblMsg.Text = msg;
            lblTime.Text = time;

            if (msgType == MsgType.In)
            {
                this.BackColor = Color.LightBlue;

            }
            else
            {
                this.BackColor = Color.MediumVioletRed;   
                

            }
            SetHeight();




        }

        private void SetHeight()
        {

            Size maxSize = new Size(495, int.MaxValue);
            Graphics g = CreateGraphics();
            SizeF size = g.MeasureString(lblMsg.Text, lblMsg.Font, lblMsg.Width);

            lblMsg.Height = int.Parse(Math.Round(size.Height + 2, 0).ToString());
            lblTime.Top = lblMsg.Bottom +10 ;
            this.Height = lblTime.Bottom + 10;




        }

        private void Bubble_Resize(object sender, EventArgs e)
        {
            SetHeight();
        }
    }

    public enum MsgType
    {
        In,
        Out
    }
}
