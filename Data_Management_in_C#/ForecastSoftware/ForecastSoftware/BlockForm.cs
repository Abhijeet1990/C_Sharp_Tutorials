using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ForecastSoftware.DataStructure;

namespace ForecastSoftware
{
    public partial class BlockForm : Form
    {
        private object selectedValue;


        public BlockForm(object selectedValue)
        {
            InitializeComponent();
            this.selectedValue = selectedValue;
            label1.Text = "Blocks for SITE " + this.selectedValue.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ForecastForm obj = new ForecastForm(pictureBox1.AccessibleName);
            this.Hide();
            obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ForecastForm obj = new ForecastForm(pictureBox2.AccessibleName);
            this.Hide();
            obj.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ForecastForm obj = new ForecastForm(pictureBox3.AccessibleName);
            this.Hide();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SiteForm obj = new SiteForm();
            this.Hide();
            obj.Show();
        }

        
    }
}
