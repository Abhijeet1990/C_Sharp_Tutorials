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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Site site = new PlantSettingForm.Site();
            ////this.Close();
            //site.Show();
        }

        private void siteSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Site site = new PlantSettingForm.Site();
            //this.Close();
            site.Load += (s, ea) => {
                var wa = Screen.PrimaryScreen.WorkingArea;
                site.Location = new Point(wa.Left + 100, wa.Top + 50);
            };
            site.Show();
        }

        private void blockSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Block block = new PlantSettingForm.Block();
            //this.Close();
            block.Load += (s, ea) => {
                var wa = Screen.PrimaryScreen.WorkingArea;
                block.Location = new Point(wa.Left + 100, wa.Top + 50);
            };
            block.Show();
        }
    }
}
