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
    public partial class CondenserUserControl : UserControl
    {
        public CondenserUserControl()
        {
            InitializeComponent();
            if (CondenserData._status == "Exist")
                PopulateData();
        }

        public void PopulateData()
        {
            textBoxLongName.Text = CondenserData._name.ToString();
            textBoxShortName.Text = CondenserData._alias.ToString();
        }
    }
}
