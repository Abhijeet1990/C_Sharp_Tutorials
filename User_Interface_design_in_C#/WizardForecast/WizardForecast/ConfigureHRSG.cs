using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WizardForecast
{
    public partial class ConfigureHRSG : Form
    {
        public ConfigureHRSG(bool DuctBurnersCheck, string SiteName, string BlockName,
            string objectAlias)
        {
            InitializeComponent();
            label1.Text += SiteName;
            label2.Text += BlockName;
            label10.Text += objectAlias;
            if(!DuctBurnersCheck)
            {
                label3.Enabled = false;
                textBox2.Enabled = false;
                label4.Enabled = false;
                textBox3.Enabled = false;
                label8.Enabled = false;
                textBox7.Enabled = false;
            }
        }
    }
}
