using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ForecastSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Abhijeet\Documents\Visual Studio 2015\Projects\ForecastSoftware\DB\LoginDB.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from dbo Where UserName= '"+textBox1.Text.Trim()+"' and Password ='"+textBox2.Text.Trim()+"'";
            SqlDataAdapter sda123 = new SqlDataAdapter(query, conn);
            DataTable dtb2345 = new DataTable();
            sda123.Fill(dtb2345);
            */

            if(textBox1.Text.Trim()=="abhijeet" && textBox2.Text.Trim() =="abhijeet")
            //if(dtb2345.Rows.Count==1)
            {
                SiteForm obj = new SiteForm();
                this.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
        }
    }
}
