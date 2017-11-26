using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConditionalContent;
namespace ConditionalContent
{
    public partial class Configure : Form
    {
        //private static bool AI;
        //private static bool PF;
        //private static bool NL;

        public Configure(bool ai,bool pf,bool nl)
        {
            //Configure.AI = ai;
            //Configure.PF = pf;
            //Configure.NL = nl;
            InitializeComponent();
            if (ai)
            {
                Label l1 = new Label();
                l1.Text = "Anti Icing";
                l1.Location = new Point(l1.Location.X + 40, l1.Location.Y + 40);
                this.Controls.Add(l1);
                MessageBox.Show("AntiIcing");
            }
            if(pf)
            {
                Label l2 = new Label();
                l2.Text = "Peak Firing";
                l2.Location = new Point(l2.Location.X + 40, l2.Location.Y + 120);
                this.Controls.Add(l2);
                MessageBox.Show("Peak Firing");
            }
            if(nl)
            {
                Label l3 = new Label();
                l3.Text = "Normalized Load";
                l3.Location = new Point(l3.Location.X + 40, l3.Location.Y + 200);
                this.Controls.Add(l3);
                MessageBox.Show("Normalized Load");
            }
        }
    }
}
