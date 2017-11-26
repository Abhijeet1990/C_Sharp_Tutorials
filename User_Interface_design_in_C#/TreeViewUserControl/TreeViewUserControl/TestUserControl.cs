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
    public partial class TestUserControl : UserControl
    {
        public int SiteCount = 1;
        public TestUserControl()
        {
            InitializeComponent();
        }

        private void SiteSaveButton_Click(object sender, EventArgs e)
        {
            using (var db = new ABC())
            {
                var name = textBox1.Text;
                //var siteid = this.SiteCount;
                var Site = new Site
                {
                    SiteID = this.SiteCount,
                    Name = name
                    //UseMetricUnits = useMetric
                };
                db.Sites.Add(Site);
                db.SaveChanges();

            }
        }
    }
}
