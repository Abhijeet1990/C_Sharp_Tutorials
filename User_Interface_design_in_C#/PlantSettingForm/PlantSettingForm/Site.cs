using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantSettingForm
{
    public partial class Site : Form
    {
        public Site()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewSite ns = new NewSite();
            this.Close();
            ns.Load += (s, ea) => {
                var wa = Screen.PrimaryScreen.WorkingArea;
                ns.Location = new Point(wa.Left + 100, wa.Top + 50);
            };
            ns.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Block block = new Block();
            this.Close();
            block.Load += (s, ea) => {
                var wa = Screen.PrimaryScreen.WorkingArea;
                block.Location = new Point(wa.Left + 100, wa.Top + 50);
            };
            block.Show();
        }
    }
}
