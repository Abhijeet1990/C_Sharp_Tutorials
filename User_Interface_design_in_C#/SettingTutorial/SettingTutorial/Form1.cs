using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string x = Properties.Settings.Default.Setting4.ToString();
            string y = Properties.Settings.Default.Setting3.ToString();
            string a = Properties.Settings.Default.Setting2.ToString();
            string b = Properties.Settings.Default.Setting1.ToString();
            string c = Properties.Settings.Default.Setting.ToString();
            label1.Text = x;
            label2.Text = y;
            label3.Text = a;
            label4.Text = b;
            label5.Text = c;
        }
    }
}
