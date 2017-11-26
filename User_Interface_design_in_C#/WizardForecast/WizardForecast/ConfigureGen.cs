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
    public partial class ConfigureGen : Form
    {
        public ConfigureGen(string SiteName, string BlockName,
            string objectAlias)
        {
            InitializeComponent();
            label1.Text += SiteName;
            label2.Text += BlockName;
            label10.Text += objectAlias;
        }
    }
}
