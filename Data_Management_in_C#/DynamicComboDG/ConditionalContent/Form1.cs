using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConditionalContent
{
    public partial class Form1 : Form
    {
        public bool AntiIcing = false;
        public bool PeakFiring = false;
        public bool NormalizedLoad = false;
        public Form1()
        {
            InitializeComponent();
            
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            
            Configure c = new Configure(AntiIcing,PeakFiring,NormalizedLoad);
            MessageBox.Show(AntiIcing.ToString());
            MessageBox.Show(PeakFiring.ToString());
            MessageBox.Show(NormalizedLoad.ToString());
            c.Show(this);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                AntiIcing = true;
            }
            if (checkBox2.Checked)
            {
                PeakFiring = true;
            }
            if (checkBox3.Checked)
            {
                NormalizedLoad = true;
            }
        }
    }
}
