using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCompleteTextBoxTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            autoCOmpleteTextBox1.Location = new Point(0, label1.Bottom);
            //this.Controls.Add(autoCOmpleteTextBox1);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            string[] myList = new string[4];

            myList[0] = "One";
            myList[1] = "Two";
            myList[2] = "Three";
            myList[3] = "Four";
            

            autoCOmpleteTextBox1.listBox1.Items.AddRange(myList);
            this.Controls.Add(autoCOmpleteTextBox1.listBox1);
            autoCOmpleteTextBox1.dataGridView1.Columns.Add("Name", "Name");
            autoCOmpleteTextBox1.dataGridView1.Columns.Add("Description", "Description");
            this.Controls.Add(autoCOmpleteTextBox1.dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            autoCOmpleteTextBox1.dataGridView1.Columns.Add("Time", "Time");


        }
    }
}
