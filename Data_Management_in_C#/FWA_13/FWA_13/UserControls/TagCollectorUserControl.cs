using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FWA_13.UserControls
{
    public partial class TagCollectorUserControl : UserControl
    {
        public TagCollectorUserControl()
        {
            InitializeComponent();
        }

        private void SelectTagButton_Click(object sender, EventArgs e)
        {
            Views.TagSelectionForm f = new Views.TagSelectionForm();
            f.Show();
        }
    }
}
