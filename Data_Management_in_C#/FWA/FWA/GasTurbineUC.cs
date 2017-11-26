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
    public partial class GasTurbineUC : UserControl
    {
        public static int count =0;
        public int storesCount;
        public GasTurbineUC()
        {
            count++;
            this.storesCount = count;
            InitializeComponent();
        }
    }
}
