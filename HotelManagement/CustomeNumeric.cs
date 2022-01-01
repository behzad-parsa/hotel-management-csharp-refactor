using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class CustomeNumeric : UserControl
    {
        public int Value { get; set; }
        public CustomeNumeric()
        {
            InitializeComponent();
        }
        public event EventHandler ValueChange;

        //#2
        protected virtual void OnValueChange()
        {
            ValueChange?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(txtTitle.Text);
            num+=1;
            txtTitle.Text = num.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(txtTitle.Text);
            num -= 1;
            txtTitle.Text = num.ToString();
        }

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {
            
            bool numeric = int.TryParse(txtTitle.Text,  out int num);
            if (!numeric)
            {
                
                txtTitle.Text = "0";
                
            }
            else
            {
                Value = Convert.ToInt32(txtTitle.Text);
                OnValueChange();
            }
        }

        private void CustomeNumeric_Load(object sender, EventArgs e)
        {

        }

        private void picSubtract_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(txtTitle.Text);
            num -= 1;
            txtTitle.Text = num.ToString();
        }
    }
}
