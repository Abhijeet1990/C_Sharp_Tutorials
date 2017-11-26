using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.imageMap1.AddRectangle("Generator", 0,130,60,190);
            //this.imageMap1.AddPolygon("Polygon", new Point[] { new Point(100, 100), new Point(180, 80), new Point(200, 140) });
            //this.imageMap1.AddElipse("Ellipse", 80, 100, 60);
            this.imageMap1.AddRectangle("GT", 100, 110, 210, 200);
            this.imageMap1.AddRectangle("HRSG", 260, 40, 400, 190);
            this.imageMap1.AddRectangle("ST", 410, 110, 510, 200);
        }

        private void imageMap1_RegionClick(int index, string key)
        {
            //MessageBox.Show("Region #" + index + ", " + key + ", clicked!", "Region Click");
            if(key=="Generator")
            {
                ConfigureGen gen = new ConfigureGen();
                gen.Show();
            }
            if (key == "GT")
            {
                ConfigureGT gt = new ConfigureGT();
                gt.Show();
            }
            if (key == "HRSG")
            {
                ConfigureHRSG hrsg = new ConfigureHRSG();
                hrsg.Show();
            }
            if (key == "ST")
            {
                ConfigureST st = new ConfigureST();
                st.Show();
            }

        }
    }
}
