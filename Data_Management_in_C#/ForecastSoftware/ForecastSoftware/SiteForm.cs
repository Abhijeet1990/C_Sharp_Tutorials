using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using ForecastSoftware;
using static ForecastSoftware.DataStructure;

namespace ForecastSoftware
{
    public partial class SiteForm : Form
    {
        public SiteForm()
        {
            InitializeComponent();

            List<Site> site = new List<Site>();
            site.Add(new Site { Acronym="ATA",SiteId=1});
            site.Add(new Site { Acronym = "GATA",SiteId=2 });
            site.Add(new Site { Acronym = "ENTO",SiteId=3 });
            site.Add(new Site { Acronym = "ONCORE",SiteId=4 });
            site.Add(new Site { Acronym = "DATA",SiteId=5 });

            //var names = site.Select(p => p.Acronym);
            //BindingSource bindingSource1 = new BindingSource();
            //bindingSource1.DataSource = site.Select(p => p.Acronym) ;
            //comboBox1.DataSource = bindingSource1.DataSource;
            comboBox1.DataSource = site;
            comboBox1.DisplayMember = "Acronym";
            comboBox1.ValueMember = "Acronym";




        }

        private void blockSelection_Click(object sender, EventArgs e)
        {
            BlockForm obj = new BlockForm(comboBox1.SelectedValue);
            this.Hide();
            obj.Show();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.Show();
        }
    }
    }

