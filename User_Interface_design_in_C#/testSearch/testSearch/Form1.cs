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

namespace testSearch
{
    public partial class Form1 : Form
    {
        public static DataTable fixedtable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT Tag,Descriptor,EngUnits from dbo.PiSnapshot";
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            dataGridView1.DataSource = data;
            fixedtable = (DataTable)dataGridView1.DataSource;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            var words = (word.Split(delimiterChars)).ToList();
            DataTable tempdata = new DataTable();
            //DataTable data = new DataTable();
            
            tempdata= (DataTable)dataGridView1.DataSource;
            var matched = tempdata.AsEnumerable().Where(row => words
                               .All(w => (row["Tag"].ToString().ToLower() + " " + row["Descriptor"].ToString().ToLower()
                                   + " " + row["EngUnits"].ToString().ToLower()).Contains(w.ToLower())));

            DataTable filteredData = matched.Any() ? matched.CopyToDataTable() : tempdata.Clone();
            dataGridView1.DataSource = filteredData;
            if(word=="")
            {
                dataGridView1.DataSource = fixedtable;
            }
            
        }
    }
}
