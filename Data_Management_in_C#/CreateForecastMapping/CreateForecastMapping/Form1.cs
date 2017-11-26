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
namespace CreateForecastMapping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=ABHIJEET-PC\SQLEXPRESS;Initial Catalog=ForecastDatabase;Integrated Security=True";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM ForecastMaster";
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            dataGridView1.DataSource = data;

            SqlCommand command2 = new SqlCommand();
            command2.Connection = conn;
            command2.CommandText = "SELECT * FROM BlockEnhancementType";
            DataTable data2 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            adapter2.Fill(data2);
            dataGridView2.DataSource = data2;


            //testobjlist[i].m.Contains(testobjlist2[j].m
            DataTable data3 = new DataTable();
            data3.Columns.Add("ForecastID",typeof(int));
            data3.Columns.Add("EnhancementTypeID", typeof(int));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data2.Rows.Count; j++)
                {
                    
                    if(data.Rows[i][1].ToString().Contains(data2.Rows[j][2].ToString()))
                    {

                        DataRow r = data3.NewRow();
                        r["ForecastID"] = data.Rows[i][0];
                        r["EnhancementTypeID"] = data2.Rows[j][0];
                        data3.Rows.Add(r);
                    }
                }
            }
            dataGridView3.DataSource = data3;


            int x;

            string sql = "INSERT ForecastByEnhancement (BaseLoadForecastID,BlockEnhancementID) VALUES (@A, @B)";
            conn.Open();
            foreach (DataRow r in data3.Rows)
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@A", r["ForecastID"]);
                cmd.Parameters.AddWithValue("@B", r["EnhancementTypeID"]);
                x = cmd.ExecuteNonQuery();
                //MessageBox.Show(x.ToString());
            }
            conn.Close();


        }

        
    }
}
