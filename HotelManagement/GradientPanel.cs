using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HotelManagement
{
    public class GradientPanel : Panel
    {
        public Color ColorLeft { get; set; }
        public Color ColorRight{ get; set; }



        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush linearGradientBrush =
            new LinearGradientBrush(this.ClientRectangle, ColorLeft, ColorRight, 45);

            ColorBlend cblend = new ColorBlend(2);
            cblend.Colors = new Color[2] { ColorLeft, ColorRight };
            cblend.Positions = new float[2] { 0f, 1f };

            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);

            base.OnPaint(e);
        }











    }
}
