using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FWA
{
    public partial class SiteUC : UserControl
    {
        public SiteUC()
        {
            InitializeComponent();

        }
        public event EventHandler ButtonClick;
        private void saveSiteButton_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.ButtonClick != null)
                this.ButtonClick(this, e);
        }
    }
}
