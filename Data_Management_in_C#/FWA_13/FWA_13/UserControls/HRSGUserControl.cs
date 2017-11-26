using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FWA_13.Infrastructure;

namespace FWA_13.UserControls
{
    public partial class HRSGUserControl : UserControl
    {
        public HRSGUserControl()
        {
            InitializeComponent();
            if (HRSGData._status == "Exist")
                PopulateData();
        }
        public void PopulateData()
        {
            textBoxLongName.Text = HRSGData._name.ToString();
            textBoxShortName.Text = HRSGData._acronym.ToString();
        }
    }
}
