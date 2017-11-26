using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDynamicUC
{
    public partial class LookUpTableForm : Form
    {
        public static int SiteID = 234;
        public static int PlantObjectTypeID = 4;
        public static int ObjectID = 34;
        public static int LookUpTableID = 1;
        public LookUpTableForm()
        {
            InitializeComponent();
        }

        private void AddTable_Click(object sender, EventArgs e)
        {
            DataGridView dgv = new DataGridView();
            dgv.Columns.Add("X values","X values");
            dgv.Columns.Add("Y values", "Y values");
            dgv.Location = new Point(20, AddTable.Bottom);
            dgv.EditingControlShowing += dataGridView1_EditingControlShowing;
            this.Controls.Add(dgv);
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            
        }

        private void SaveTable_Click(object sender, EventArgs e)
        {
            string StrQuery;
            foreach (Control c in this.Controls)
            {
                
                if(c.GetType().ToString()=="System.Windows.Forms.DataGridView")
                {
                    var dgv = (DataGridView)c;
                   
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(@"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                        {
                            using (SqlCommand comm = new SqlCommand())
                            {
                                comm.Connection = conn;
                                conn.Open();
                                for (int i = 0; i < dgv.Rows.Count-1; i++)
                                {
                                    
                                    StrQuery = @"INSERT INTO LookUpTables VALUES ("
                                        + LookUpTableID.ToString()+", "
                                        + SiteID.ToString()+", "
                                        + PlantObjectTypeID.ToString()+", "
                                        + ObjectID.ToString()+", "
                                        + dgv.Rows[i].Cells[0].Value.ToString() + ", "
                                        + dgv.Rows[i].Cells[1].Value.ToString() + ");";
                                    comm.CommandText = StrQuery;
                                    comm.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }


                }
            }
            
        }
    }
}
