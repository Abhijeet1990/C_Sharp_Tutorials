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


namespace ForecastListGeneration
{
    public partial class Form1 : Form
    {
        public static int blockCount = 1;
        int siteCount = 1;
        public List<string> ForecastTypeByBlockType = new List<string>();
        public List<int> PossibleForecastId = new List<int>();

        public static List<string> BlockEnhancementList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void AddForecastButton_Click(object sender, EventArgs e)
        {
            AddForecastForm f = new AddForecastForm(this);
            BindingSource bs = new BindingSource();
            bs.DataSource = ForecastTypeByBlockType;
            f.comboBox1.DataSource = bs;
            f.Show();
        }

        private void DuctBurnerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(DuctBurnerCheckBox.Checked)
            {
                SPIwithDuctBurners.Enabled = true;
            }
        }

        private void comboBoxConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT Alias,Name FROM ForecastMasterByBlockTypeConfiguration WHERE BlockTypeID ="+(comboBoxConfig.SelectedIndex+1);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            ForecastTypeByBlockType.Clear();
            //List<string> ForecastTypeByBlockType = new List<string>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                ForecastTypeByBlockType.Add(data.Rows[i][0].ToString() +" "+ data.Rows[i][1].ToString());

            }
            

        }

        private void SaveEnhancementButton_Click(object sender, EventArgs e)
        {
            BlockEnhancementList.Clear();
            if (AntiIcingcheckBox.Checked)
                BlockEnhancementList.Add("AI");
            if (InletAirHeating.Checked)
                BlockEnhancementList.Add("IAH");
            if (CombustionAutoTuningCheckBox.Checked)
                BlockEnhancementList.Add("CAT");
            if (PeakFiringCheckBox.Checked)
                BlockEnhancementList.Add("PF");
            if (DuctBurnerCheckBox.Checked)
                BlockEnhancementList.Add("DB");
            if (SteamPowerAugmentation.Checked)
                BlockEnhancementList.Add("SI(NODB)");
            if (SPIwithDuctBurners.Checked)
                BlockEnhancementList.Add("SI(DB)");
            switch (comboBoxInletAirCool.SelectedIndex)
            {
                case 1:
                    BlockEnhancementList.Add("EC");
                    break;
                case 2:
                    BlockEnhancementList.Add("FOG");
                    break;
                case 3:
                    BlockEnhancementList.Add("CHILL");
                    break;
                case 4:
                    BlockEnhancementList.Add("CHILLTES");
                    break;

            }
             //Now this List would generate the Possible list of Forecast Master for this Block

             //Get the Block EnhancementTypeID from the table
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            command.CommandText = "SELECT BlockEnhancementTypeID,Alias FROM BlockEnhancementType";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            List<int> BlockEnhancementTypeID = new List<int>();
            foreach (string id in BlockEnhancementList)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if(id==data.Rows[i][1].ToString())
                    {
                        BlockEnhancementTypeID.Add(Convert.ToInt32(data.Rows[i][0]));
                    }

                }
            }
            //blockCount
            //Insert into the BlockWiseEnhancementSelection Table
            DataTable BlockWiseEnhancementSelection = new DataTable();
            BlockWiseEnhancementSelection.Columns.Add("BlockID", typeof(int));
            BlockWiseEnhancementSelection.Columns.Add("EnhancementID", typeof(int));
            BlockWiseEnhancementSelection.Columns.Add("SiteID", typeof(int));
            for (int i = 0; i < BlockEnhancementTypeID.Count; i++)
            {
                DataRow r = BlockWiseEnhancementSelection.NewRow();
                r["BlockID"] = blockCount;
                r["EnhancementID"] = BlockEnhancementTypeID.ElementAt(i);
                r["SiteID"] = siteCount;
                BlockWiseEnhancementSelection.Rows.Add(r);
            }
            int x;
            string sql1 = "DELETE From BlockWiseEnhancementSelection";
            string sql2 = "INSERT BlockWiseEnhancementSelection (BlockID,BlockEnhancementTypeID,SiteID) VALUES (@A,@B,@C)";
            conn.Open();
            SqlCommand cmd1 = conn.CreateCommand();
            //SqlCommand cmd2 = conn.CreateCommand();
            cmd1.CommandText = sql1;
            cmd1.ExecuteNonQuery();
            //cmd2.CommandText = sql2;
            foreach (DataRow r in BlockWiseEnhancementSelection.Rows)
            {
                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = sql2;
                cmd2.Parameters.AddWithValue("@A", r["BlockID"]);
                cmd2.Parameters.AddWithValue("@B", r["EnhancementID"]);
                cmd2.Parameters.AddWithValue("@C", r["SiteID"]);
                x = cmd2.ExecuteNonQuery();
                //MessageBox.Show(x.ToString());
            }


            //Utilize the Forecast master list BlockEnhancementTypeID to filter the ForecastID by Enhancement
            
            DataTable data2 = new DataTable();
            SqlCommand command2 = new SqlCommand();
            command2.Connection = conn;
            command2.CommandText = "SELECT ForecastMasterID,BlockEnhancementTypeID FROM ForecastMasterEnhancementMapping";
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            adapter2.Fill(data2);


            /*LINQ Example
             * var results = from myRow in myDataTable.AsEnumerable()
                             where myRow.Field<int>("RowNo") == 1
                             select myRow;
                             */

            //Generate the List of Possible Forecast Based on the BlockEnhancementTypeID
            var Mapping = new Dictionary<int, List<int>>();

            var distinctForecastID = (from row in data2.AsEnumerable()
                                     select row[0]).Distinct();

            MessageBox.Show("Test");

            foreach(var id in distinctForecastID)
            {
                var enhancementList = from row in data2.AsEnumerable()
                                      where (int)row[0] == (int)id
                                      select row[1];
                //MessageBox.Show(enhancementList.Count().ToString());
                Mapping.Add(Convert.ToInt32(id), enhancementList.Cast<int>().ToList());
            }

            

            

            foreach(var id in Mapping)
                {
                //MessageBox.Show(id.Value.Count.ToString());
                if(id.Value.Intersect(BlockEnhancementTypeID).Count()==id.Value.Count())
                    {
                    PossibleForecastId.Add(id.Key);
                    }
                }

            DataTable data3 = new DataTable();
            SqlCommand command3 = new SqlCommand();
            command3.Connection = conn;
            command3.CommandText = "SELECT  ForecastMasterByEnhancement,Name FROM ForecastMasterByEnhancement_Temp WHERE ForecastMasterByEnhancement IN ("+String.Join(",",PossibleForecastId)+")";
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            adapter3.Fill(data3);
            //PossibleForecastID contain all the forecast list Based on the Enhancement Selection

            //ForecastTypeByBlockType contains all the string for Block Types... 

            List<string> PossibleForecastName = new List<string>();

            List<string> CompletePossibleForecastList = new List<string>();
            for (int i = 0; i < data3.Rows.Count; i++)
            {
                PossibleForecastName.Add(data3.Rows[i][1].ToString());
            }
            foreach(var id in ForecastTypeByBlockType)
            {
                foreach(var id2 in PossibleForecastName)
                {
                    CompletePossibleForecastList.Add(id + " " + id2);
                }
            }


            //Insert the CompletePossibleForecastList into the Database 
            
            string sql3 = "DELETE From ForecastMasterPossible";
            string sql4 = "INSERT ForecastMasterPossible (ForecastMasterID,BlockID,ForecastName) VALUES (@A,@B,@C)";
//            conn.Open();
            SqlCommand cmd3 = conn.CreateCommand();
            //SqlCommand cmd2 = conn.CreateCommand();
            cmd3.CommandText = sql3;
            cmd3.ExecuteNonQuery();
            //cmd2.CommandText = sql2;
            foreach(var id in CompletePossibleForecastList)
            {
               
                SqlCommand cmd4 = conn.CreateCommand();
                cmd4.CommandText = sql4;
                cmd4.Parameters.AddWithValue("@A", CompletePossibleForecastList.IndexOf(id)+1);
                cmd4.Parameters.AddWithValue("@B", blockCount);
                cmd4.Parameters.AddWithValue("@C", id.ToString());
                cmd4.ExecuteNonQuery();
            }

            

        }
    }
}
