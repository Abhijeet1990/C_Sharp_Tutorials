using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForecastWizardApplication.Infrastructure;

namespace ForecastWizardApplication.UserControls
{
    public partial class SteamTurbineUserControl : UserControl
    {
        public SteamTurbineUserControl()
        {
            InitializeComponent();
            if (SteamTurbineData._status == "Exist")
                PopulateData();
        }

        public void PopulateData()
        {
            textBoxLongName.Text = SteamTurbineData._name.ToString();
            textBoxShortName.Text = SteamTurbineData._acronym.ToString();
        }
    }
}

