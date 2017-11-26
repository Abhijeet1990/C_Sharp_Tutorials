using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewUserControl
{
    public partial class GrandChildUserControl : UserControl
    {
        public int GrandChildID;
        public int ChildID;
        public static int count = 0;
        public int BlockID;
        public int SiteID;
        public event EventHandler textBoxChanged;

        public GrandChildUserControl(int x, int y, int z)
        {
            InitializeComponent();
            count++;
            this.GrandChildID = count;
            this.ChildID = x;
            this.BlockID = y;
            this.SiteID = z;
        }

        private void GrandchildNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxChanged != null)
                this.textBoxChanged(this, e);
        }
    }
}
