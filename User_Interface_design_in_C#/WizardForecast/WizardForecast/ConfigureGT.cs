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
    public partial class ConfigureGT : Form
    {
        public ConfigureGT(bool AntiIcingCheck,bool PeakFiringCheck,
            bool SteamInjectionCheck,string SiteName,string BlockName,
            string objectAlias )
        {
            InitializeComponent();
            MessageBox.Show(SiteName);

            if(!AntiIcingCheck)
            {
                label8.Enabled = false;
                textBox7.Enabled = false;
            }
            if(!PeakFiringCheck)
            {
                label4.Enabled = false;
                textBox3.Enabled = false;
                button2.Enabled = false;
            }
            if(!SteamInjectionCheck)
            {
                label5.Enabled = false;
                textBox4.Enabled = false;
            }
            label1.Text += SiteName;
            label2.Text += BlockName;
            label10.Text += objectAlias;

        }
    }
}
