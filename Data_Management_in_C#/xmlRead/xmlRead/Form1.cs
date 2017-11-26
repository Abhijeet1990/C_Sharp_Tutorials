using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace xmlRead
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> p1 = new List<Person>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Person>));
            p1.Add(new Person() { id = 1, name = "abhijeet" });
            p1.Add(new Person() { id = 2, name = "jacky" });
            using (FileStream fs = new FileStream(Environment.CurrentDirectory+"\\test.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, p1);
                MessageBox.Show("created");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> p1 = new List<Person>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Person>));
            
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\test.xml", FileMode.Open, FileAccess.Read))
            {
                p1 = serial.Deserialize(fs) as List<Person>;
                
            }
            dataGridView1.DataSource = p1;

        }
    }
}
