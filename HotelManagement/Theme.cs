using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Bunifu.Framework.UI;

namespace HotelManagement
{
    public class Theme
    {
        private static void ChangeLabelForColor( GradientPanel panel ,  int red , int green , int blue)
        {
            foreach (var item in panel.Controls)
            {
                if (item is BunifuCustomLabel)
                {
                    var lbl = item as BunifuCustomLabel;
                    lbl.ForeColor = Color.FromArgb(red, green, blue);
                }
            }    
        }

        private static void ChangeIcons(GradientPanel panel , string color)
        {
            var power = panel.Controls["btnPower"] as BunifuImageButton;
            var logout = panel.Controls["btnLogout"] as BunifuImageButton;
            var size = panel.Controls["btnSize"] as BunifuImageButton;
            var form = panel.FindForm();

            if (color == "White")
            {
                power.Image = Properties.Resources.powerW;
                logout.Image = Properties.Resources.LogW;
                if (form.WindowState == FormWindowState.Normal) size.Image = Properties.Resources.maxW;
                else size.Image = Properties.Resources.minW;
            }
            else if(color == "Black")
            {
                power.Image = Properties.Resources.powerB;
                logout.Image = Properties.Resources.logB;
                if (form.WindowState == FormWindowState.Normal) size.Image = Properties.Resources.maxB;
                else size.Image = Properties.Resources.minB;
            }          
        }

        //0 top
        //1 left
        //2move side

        public static void ChangeTheme(string name, List<GradientPanel> panels)
        {
            switch (name)
            {
                case "Default":
                    panels[0].BackColor = Color.FromArgb(60, 141, 188);
                    ChangeLabelForColor(panels[0] , 255, 255, 255);
                    ChangeIcons(panels[0], "White");

                    panels[1].BackColor = Color.FromArgb(49, 70, 89);
                    panels[2].BackColor = Color.Empty;
                    panels[2].ColorLeft = Color.FromArgb(79, 172, 254);
                    panels[2].ColorRight = Color.FromArgb(0, 242, 254);
                    // panels[2].BackColor = Color.FromArgb(42, 88, 173);
                    //this.Parent.Parent.Refresh();
                    break;

                case "Theme 2":
                    panels[0].BackColor = Color.FromArgb(255, 255, 255);
                    ChangeLabelForColor(panels[0], 16, 16, 16);
                    ChangeIcons(panels[0], "Black");
                    panels[1].BackColor = Color.FromArgb(142, 121, 186);
                    panels[2].ColorLeft = Color.Empty;
                    panels[2].ColorRight = Color.Empty;
                    panels[2].BackColor = Color.FromArgb(107, 207, 234);            
                    break;

                case "Theme 3":
                    panels[0].BackColor = Color.FromArgb(255, 255, 255);
                    ChangeLabelForColor(panels[0], 16, 16, 16);
                    ChangeIcons(panels[0], "Black");
                    panels[1].BackColor = Color.FromArgb(63, 148, 219);
                    panels[2].ColorLeft = Color.Empty;
                    panels[2].ColorRight = Color.Empty;
                    panels[2].BackColor = Color.FromArgb(42, 88, 173);
                    break;
            }
        }

        public static Bitmap DarkBack(Control form)
        {       
            Bitmap bmp = new Bitmap(form.ClientRectangle.Width, form.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(form.PointToScreen(new Point(0, 0)), new Point(0, 0), form.ClientRectangle.Size);
                double percent = 0.60;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, form.ClientRectangle);
                }
            }
            return bmp;
        }

        public static string LastTime(DateTime date)
        {
            var duration = DateTime.Now - date;
            string lastTime = string.Empty;

            if (duration.Days > 7)
            {
                lastTime = date.ToString("ddd, dd MMM yyy HH");
            }
            else if (duration.Days == 7)
            {
                lastTime = "ONE WEEK AGO";

            }
            else if (duration.Days < 7 && duration.Days > 1)
            {
                lastTime = duration.Days.ToString() + " DAYS AGO";
            }
            else if (duration.Days == 1)
            {
                lastTime = "Yesterday";
            }
            else if (duration.Days == 0)
            {
                if (duration.Hours > 0)
                {
                    lastTime = duration.Hours.ToString() + " HOURS AGO";

                }
                else if (duration.Minutes >= 1)
                {
                    lastTime = duration.Minutes.ToString() + " MINUTES AGO";
                }
                else
                {
                    lastTime = "Just Now";
                }
            }

            return lastTime ;
        }

    }
}
