using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Product ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[2].Name = "Product Price";

            string[] row = new string[] { "1", "Product 1", "1000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "2", "Product 2", "2000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "3", "Product 3", "3000" };
            dataGridView1.Rows.Add(row);
            row = new string[] { "4", "Product 4", "4000" };
            dataGridView1.Rows.Add(row);

            //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            //dataGridView1.Columns.Add(chk);
            //chk.HeaderText = "Check Data";
            //chk.Name = "chk";
            //dataGridView1.Rows[2].Cells[3].Value = true;

            DataGridViewImageColumn ic = new DataGridViewImageColumn();
            Image i = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\visual studio 2015\\Projects\\PlantSettingForm\\PlantSettingForm\\Resources\\gen.ico");
            ic.HeaderText = "Img";
            ic.Image = i;
            ic.Name = "cImg";
            ic.Width = 100;
            dataGridView1.Columns.Add(ic);
            

        }
    }
}
