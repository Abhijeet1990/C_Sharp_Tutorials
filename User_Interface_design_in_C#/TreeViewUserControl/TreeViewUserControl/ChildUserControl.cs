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
    public partial class ChildUserControl : UserControl
    {
        public event EventHandler textBoxChanged;
        public int ChildID;
        public static int count=0;
        public int BlockID;
        public int SiteID;
        public Boolean TestingCheckBoxChecked=false;
        public event EventHandler GrandchildNodeCBChanged;
        public List<GrandChildUserControl> GCUCList = new List<GrandChildUserControl>();
        public ChildUserControl(int x,int y)
        {
            InitializeComponent();
            count++;
            this.ChildID=count;
            this.BlockID = x;
            this.SiteID = y;
        }

        private void childNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxChanged != null)
                this.textBoxChanged(this, e);
        }

        private void childSaveButton_Click(object sender, EventArgs e)
        {
            using (var db = new ABC())
            {
                var name = childNameTextBox.Text;
                //var siteid = this.SiteCount;
                var Child = new Child
                {
                    ChildID = this.ChildID,
                    Name = name,
                    SiteID = this.SiteID,
                    BlockID=this.BlockID
                    //UseMetricUnits = useMetric
                };
                db.Children.Add(Child);
                db.SaveChanges();

            }
        }

        private void isCompleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(isCompleteCheckBox.Checked)
            {
                this.TestingCheckBoxChecked = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.GrandchildNodeCBChanged != null)
                this.GrandchildNodeCBChanged(this, e);
        }
    }
}
