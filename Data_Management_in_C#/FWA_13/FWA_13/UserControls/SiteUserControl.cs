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

namespace FWA_13
{
    public partial class SiteUserControl : UserControl
    {
        public SiteUserControl()
        {
            InitializeComponent();
            if (BlockData._status == "Exist")
                PopulateData();
        }
        public void PopulateData()
        {
            textBoxLongName.Text = SiteData._name.ToString();
            textBoxShortName.Text = SiteData._acronym.ToString();
        }
    }
}
