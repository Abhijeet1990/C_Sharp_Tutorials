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
using ForecastWizardApplication.UserControls;
using ForecastWizardApplication.Infrastructure;

namespace ForecastWizardApplication.Views
{
    public partial class FormPITagSelect2 : Form
    {
        GetPITagUserControl g = null;
        public static DataTable fixedtable;
        public string selectedTag = null;
        public string selectedEngUnits = null;
        public bool tagSelected;
        public FormPITagSelect2(GetPITagUserControl uc)
        {
            InitializeComponent();
            selectedTag = "";
            selectedEngUnits = "";
            tagSelected = false;
            this.g = uc;
        }

        private void AddForecastForm2_Load(object sender, EventArgs e)
        {
            try 
            {
                string sql = "SELECT Tag,Descriptor,EngUnits from dbo.PiSnapshot";
                using (SqlConnection conn = new SqlConnection(Connection.getConnectionString()))
                {
                    SqlCommand com = new SqlCommand(sql, conn);
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(com);
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;
                    fixedtable = (DataTable)dataGridView1.DataSource;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Data Source=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //SqlCommand command = new SqlCommand();
            //command.Connection = conn;
            //command.CommandText = "SELECT Tag,Descriptor,EngUnits from dbo.PiSnapshot";
            //DataTable data = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //adapter.Fill(data);
            //dataGridView1.DataSource = data;
            //fixedtable = (DataTable)dataGridView1.DataSource;
        }
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string word = searchTextBox.Text;
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            var words = (word.Split(delimiterChars)).ToList();
            DataTable tempdata = new DataTable();
            //DataTable data = new DataTable();

            tempdata = (DataTable)dataGridView1.DataSource;
            var matched = tempdata.AsEnumerable().Where(row => words
                               .All(w => (row["Tag"].ToString().ToLower() + " " + row["Descriptor"].ToString().ToLower()
                                   + " " + row["EngUnits"].ToString().ToLower()).Contains(w.ToLower())));

            DataTable filteredData = matched.Any() ? matched.CopyToDataTable() : tempdata.Clone();
            dataGridView1.DataSource = filteredData;
            if (word == "")
            {
                dataGridView1.DataSource = fixedtable;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                selectedTag = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                selectedEngUnits = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                tagSelected = true;
                this.g.PassValue(selectedTag, selectedEngUnits);

            }
            this.Close();
        }
    }
}
