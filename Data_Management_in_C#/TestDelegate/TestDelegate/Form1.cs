using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        protected void UpdateStatus(object o, Data d)
        {
            foreach(var stats in d.Statuses)
            {
                MessageBox.Show(stats);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Publisher p = new Publisher();
            this.Controls.Add(p);
            //create a subsrciber for the event in the 
            p.Onchecked += new OnCheckedEventHandler((object o, Data d) => this.showData.Text+= d.Text);
            p.OnSelectedCBIndex += new OnCheckedEventHandler((o, d) => MessageBox.Show(d.Text));
            p.OnSelectedGBCheckBox += new OnCheckedEventHandler((o, d) => UpdateStatus(o, d));
        }
    }
}
