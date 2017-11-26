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
    public partial class TagCollectorUC : UserControl
    {
        public TagCollectorUC()
        {
            InitializeComponent();
        }
        public event EventHandler TagSelectButtonClicked;
        private void SelectTagButton_Click(object sender, EventArgs e)
        {
            if (this.TagSelectButtonClicked != null)
                this.TagSelectButtonClicked(this, e);
        }
    }
}
