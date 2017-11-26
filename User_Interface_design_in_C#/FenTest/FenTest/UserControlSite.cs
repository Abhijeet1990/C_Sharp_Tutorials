using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FenTest
{
    public partial class UserControlSite : UserControl
    {
        public UserControlSite()
        {
            InitializeComponent();
        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            NewForm f1 = new NewForm();
            f1.label1.Text = this.comboBox1.Text;
            f1.Show();
        }
    }
}
