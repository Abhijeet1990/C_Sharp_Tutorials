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

namespace ChartControltutorial
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        private void LoadChart_Click(object sender, EventArgs e)
        {
            //this.chart1.Series["Values"].Points.AddXY("2:00 AM",34.56);
            //this.chart1.Series["Values"].Points.AddXY("3:00 AM", 45.56);
            //this.chart1.Series["Values"].Points.AddXY("4:00 AM", 67.56);
            //this.chart1.Series["Values"].Points.AddXY("5:00 AM", 35.56);
            //this.chart1.Series["Values"].Points.AddXY("6:00 AM", 19.56);
            //this.chart1.Series["Values"].Points.AddXY("7:00 AM", 28.56);
            //this.chart1.Series["Values"].Points.AddXY("8:00 AM", 78.56);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ABHIJEET-PC\SQLEXPRESS;Initial Catalog=ChartTesting;Integrated Security=True";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM ValuesTable";
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            foreach(DataRow r in data.Rows)
            {
                this.chart1.Series["Values"].Points.AddXY(r.Field<string>("Time"), r.Field<float>("Value"));
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Data Source=ABHIJEET-PC\SQLEXPRESS;Initial Catalog=ChartTesting;Integrated Security=True";

            //SqlCommand command = new SqlCommand();
            //command.Connection = conn;
            //command.CommandText = "SELECT * FROM Values";
            //DataTable data = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //adapter.Fill(data);
            //chart1.DataSource = data;

        }
    }
}
