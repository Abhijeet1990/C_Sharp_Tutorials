using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using ForecastAppDatabase;
using ForecastWizardApplication.Infrastructure;

using ForecastWizardApplication.Views;
using ForecastWizardApplication.UserControls;

namespace ForecastWizardApplication
{
    public partial class BlockUserControl : UserControl
    {
        public List<string> ForecastTypeByBlockType = new List<string>();
        public List<string> BlockEnhancementList = new List<string>();
        public List<int> PossibleForecastId = new List<int>();
        public static int VariableCount = 0;

        public Form1 ParentForm { get; set; }

        public BlockUserControl()
        {
            InitializeComponent();
            if (BlockData._status == "Exist")
            {
                PopulateData();
                ForecastGroupBox.Visible = true;
            }

            CheckChkBx();
            PopulateTags();
        }

        public void PopulateData()
        {
            textBoxName.Text = Convert.ToString(BlockData._name);
            comboBoxConfig.Text = Convert.ToString(BlockData._typeConfig);
            comboBoxGTType.Text = Convert.ToString(BlockData._gasTurbineType);
            //We would also populate the Enhancement Selection and also the list of Forecast Added unto the Data Grid
            //For the Enhancement list the best place to search would be to connect with BlockWiseEnhancementSelection Table ..
            GetBlockEnhancementAndForecastList();
            // generateXML.Create(_siteNode);
        }

        public void PopulateTags()
        {
            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT Name,ObjectGroupID,Mandatory FROM PlantMasterVariable WHERE PlantObjectTypeID=2");

            int y = 0;
            var x = (from r in data.AsEnumerable()
                     select r[1]).Distinct().ToList();

            List<int> objectTypeIDList = new List<int>();
            foreach (var id in x)
            {
                GroupBox g = new GroupBox();
                DataTable d = new DataTable();
                d = HandleSqlQueries.HandleQueries(String.Format("select Name from ObjectGroups where ObjectGroupID = {0}", id));
                g.Text = d.Rows[0][0].ToString() + " Tags";
                g.AutoSize = true;

                for (int i = 0, j = 0; i < data.Rows.Count; i++)
                {
                    if (Convert.ToInt32(data.Rows[i][1]) == Convert.ToInt32(id))
                    {

                        GetPITagUserControl pi = new GetPITagUserControl();
                        pi.VariableMasterLabel.Text = data.Rows[i][0].ToString();
                        if (data.Rows[i][2].ToString() == "M")
                        {
                            pi.VariableMasterLabel.Font = new Font(pi.VariableMasterLabel.Font, System.Drawing.FontStyle.Bold);
                        }
                        g.Controls.Add(pi);
                        pi.Location = new Point(10, 25 * (j + 1));
                        j++;
                    }
                }
                BlockTagsGroupBox.Controls.Add(g);
                if (x.IndexOf(id) == 0)
                    g.Location = new Point(10, 20);
                else
                    g.Location = new Point(10, y);

                y = g.Bottom;

            }
            ForecastGroupBox.Location = new Point(10, BlockTagsGroupBox.Bottom);

        }
        public void GetBlockEnhancementAndForecastList()
        {
            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT BlockID,BlockEnhancementTypeID FROM BlockWiseEnhancementSelection WHERE BlockID=" + BlockData._blockID.ToString());
            List<int> BlockEnhancementTypeIDList = new List<int>();
            if (data.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                BlockEnhancementTypeIDList.Add((int)data.Rows[i][1]);
            }


            DataTable data2 = new DataTable();
            data2 = HandleSqlQueries.HandleQueries("SELECT ALIAS FROM BlockEnhancementType WHERE BlockEnhancementTypeID IN(" + String.Join(",", BlockEnhancementTypeIDList) + ")");

            for (int i = 0; i < data2.Rows.Count; i++)
            {
                this.BlockEnhancementList.Add(data2.Rows[i][0].ToString());
            }
            foreach (var id in this.BlockEnhancementList)
            {
                if (this.BlockEnhancementList.Contains("AI"))
                {
                    this.AntiIcingCheckBox.Checked = true;
                }
                if (this.BlockEnhancementList.Contains("IAH"))
                {
                    this.InletAirHeatingCheckBox.Checked = true;
                }
                if (this.BlockEnhancementList.Contains("CAT"))
                {
                    this.CombustionAutoTuningCheckBox.Checked = true;
                }
                if (this.BlockEnhancementList.Contains("PF"))
                {
                    this.PeakFiringCheckBox.Checked = true;
                }
                if (this.BlockEnhancementList.Contains("DB"))
                {
                    this.DuctBurnerCheckBox.Checked = true;
                }
                if (this.BlockEnhancementList.Contains("SI(DB)"))
                {
                    this.SPIWithDBCheckBox.Checked = true;
                }
                if (this.BlockEnhancementList.Contains("SI(NODB)"))
                {
                    this.SPIWithoutDBCheckBox.Checked = true;
                }
                if (BlockEnhancementList.Contains("EC"))
                {
                    this.comboBoxInletAirCool.SelectedIndex = 1;
                }
                else if (BlockEnhancementList.Contains("FOG"))
                {
                    this.comboBoxInletAirCool.SelectedIndex = 2;
                }
                else if (BlockEnhancementList.Contains("CHILL"))
                {
                    this.comboBoxInletAirCool.SelectedIndex = 3;
                }
                else if (BlockEnhancementList.Contains("CHILLTES"))
                {
                    this.comboBoxInletAirCool.SelectedIndex = 4;
                }

            }


            //Populate the DataGridView From the ForecastSelection Table
            DataTable data3 = new DataTable();
            data3 = HandleSqlQueries.HandleQueries("SELECT ForecastMasterByBlockType,Criteria,Name,Alias,BlockEnhancements FROM ForecastSelection WHERE BlockID =" + BlockData._blockID.ToString());

            for (int i = 0; i < data3.Rows.Count; i++)
            {
                BlockData.lname = data3.Rows[0][2].ToString();
                BlockData.sname = data3.Rows[0][3].ToString();


                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = data3.Rows[i][j].ToString();
                    //string name = data3[0][2].ToString();
                    if (j == 1)
                    {
                        if (data3.Rows[i][j].ToString() != "")
                        {
                            dataGridView1.Rows[i].Cells[j].Value = Properties.Resources.OK;
                            dataGridView1.Rows[i].Cells[j].ToolTipText = data3.Rows[i][j].ToString();
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells[j].Value = Properties.Resources.WarningCircle;
                            dataGridView1.Rows[i].Cells[j].ToolTipText = data3.Rows[i][j].ToString();
                        }

                    }

                }
            }



        }
        public void CheckChkBx()
        {
            //Checking checkBox is checked on form load
            if (InletAirHeatingCheckBox.Checked == true)
            {
                Common.CheckBox2 = "Checked";
            }
            else
            {
                Common.CheckBox2 = "Unchecked";
            }

            if (DuctBurnerCheckBox.Checked == true)
            {
                Common.CheckBox5 = "Checked";
            }
            else
            {
                Common.CheckBox5 = "Unchecked";
            }

            if (SPIWithoutDBCheckBox.Checked == true)
            {
                Common.CheckBox6 = "Checked";
            }
            else
            {
                Common.CheckBox6 = "Unchecked";
            }

            if (SPIWithDBCheckBox.Checked == true)
            {
                Common.CheckBox7 = "Checked";
            }
            else
            {
                Common.CheckBox7 = "Unchecked";
            }

            Common.InletAirCoolingSelectedIndex = comboBoxInletAirCool.SelectedIndex;


        }

        public void CheckChkBx(ref BlockTree bt)
        {
            //Checking checkBox is checked on form load
            if (InletAirHeatingCheckBox.Checked == true)
            {
                bt.chkbx1 = "Yes";
            }
            else
            {
                bt.chkbx1 = "No";
            }

            if (InletAirHeatingCheckBox.Checked == true)
            {
                // Common.CheckBox2 = "Checked";
                bt.chkbx2 = "Yes";
            }
            else
            {
                //Common.CheckBox2 = "Unchecked";
                bt.chkbx2 = "No";
            }

            if (CombustionAutoTuningCheckBox.Checked == true)
            {
                //Common.CheckBox3 = "Checked";
                bt.chkbx3 = "Yes";
            }
            else
            {
                //Common.CheckBox6 = "Unchecked";
                bt.chkbx3 = "No";
            }

            if (PeakFiringCheckBox.Checked == true)
            {
                //Common.CheckBox7 = "Checked";
                bt.chkbx4 = "Yes";
            }
            else
            {
                bt.chkbx4 = "No";
            }

            if (DuctBurnerCheckBox.Checked == true)
            {
                bt.chkbx5 = "Yes";
            }
            else
            {
                //Common.CheckBox7 = "Unchecked";
                bt.chkbx5 = "No";
            }

            if (SPIWithoutDBCheckBox.Checked == true)
            {
                bt.chkbx6 = "Yes";
            }
            else
            {
                //Common.CheckBox7 = "Unchecked";
                bt.chkbx6 = "No";
            }

            if (SPIWithDBCheckBox.Checked == true)
            {
                bt.chkbx7 = "Yes";
            }
            else
            {
                //Common.CheckBox7 = "Unchecked";
                bt.chkbx7 = "No";
            }
        }

        private void comboBoxConfig_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Connect with the Train Mapping Table and update the Block Types
            WizardDatabaseEntities db = new WizardDatabaseEntities();
            List<TrainMapping> TrainMappingLists = db.TrainMappings.ToList();

            switch (this.comboBoxConfig.SelectedIndex)
            {
                case 0:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 1 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 1 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 1:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 2 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 2 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 2:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 3 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 3 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 3:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 4 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 4 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 4:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 5 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 5 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;

                        break;
                    }

            }

            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT Alias,Name FROM ForecastMasterByBlockTypeConfiguration WHERE BlockTypeID =" + (comboBoxConfig.SelectedIndex + 1).ToString());
            this.ForecastTypeByBlockType.Clear();
            //List<string> ForecastTypeByBlockType = new List<string>();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                this.ForecastTypeByBlockType.Add(data.Rows[i][0].ToString() + " " + data.Rows[i][1].ToString());

            }


        }

        private void OncheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (AntiIcingCheckBox.Checked == true)
            {
                Common.CheckBox1 = "Checked";
            }
            else
            {
                Common.CheckBox1 = "Unchecked";
            }
        }

        private void OncheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (InletAirHeatingCheckBox.Checked == true)
            {
                Common.CheckBox2 = "Checked";
            }
            else
            {
                Common.CheckBox2 = "Unchecked";
            }
        }

        private void OncheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CombustionAutoTuningCheckBox.Checked == true)
            {
                Common.CheckBox3 = "Checked";
            }
            else
            {
                Common.CheckBox3 = "Unchecked";
            }
        }

        private void OncheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (PeakFiringCheckBox.Checked == true)
            {
                Common.CheckBox4 = "Checked";
            }
            else
            {
                Common.CheckBox4 = "Unchecked";
            }
        }

        private void OncheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            SPIWithDBCheckBox.Enabled = true;
            if (DuctBurnerCheckBox.Checked == true)
            {
                Common.CheckBox5 = "Checked";
            }
            else
            {
                Common.CheckBox5 = "Unchecked";
            }
        }

        private void OncheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (SPIWithoutDBCheckBox.Checked == true)
            {
                Common.CheckBox6 = "Checked";
            }
            else
            {
                Common.CheckBox6 = "Unchecked";
            }
        }

        private void OncheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (SPIWithDBCheckBox.Checked == true)
            {
                Common.CheckBox7 = "Checked";
            }
            else
            {
                Common.CheckBox7 = "Unchecked";
            }
        }

        private void AddForecastButton_Click(object sender, EventArgs e)
        {
            AddForecastForm Forecast = new AddForecastForm(this, "", BlockData._blockID);
            BindingSource bs = new BindingSource();
            bs.DataSource = this.ForecastTypeByBlockType;
            Forecast.ConfigurationComboBox.DataSource = bs;
            Forecast.Show();
        }

        public void UpdateEnhancement(BlockUserControl b, int blockID)
        {
            b.BlockEnhancementList.Clear();
            if (b.AntiIcingCheckBox.Checked)
                b.BlockEnhancementList.Add("AI");
            if (b.InletAirHeatingCheckBox.Checked)
                b.BlockEnhancementList.Add("IAH");
            if (b.CombustionAutoTuningCheckBox.Checked)
                b.BlockEnhancementList.Add("CAT");
            if (b.PeakFiringCheckBox.Checked)
                b.BlockEnhancementList.Add("PF");
            if (b.DuctBurnerCheckBox.Checked)
                b.BlockEnhancementList.Add("DB");
            if (b.SPIWithoutDBCheckBox.Checked)
                b.BlockEnhancementList.Add("SI(NODB)");
            if (b.SPIWithDBCheckBox.Checked)
                b.BlockEnhancementList.Add("SI(DB)");
            switch (b.comboBoxInletAirCool.SelectedIndex)
            {
                case 1:
                    b.BlockEnhancementList.Add("EC");
                    break;
                case 2:
                    b.BlockEnhancementList.Add("FOG");
                    break;
                case 3:
                    b.BlockEnhancementList.Add("CHILL");
                    break;
                case 4:
                    b.BlockEnhancementList.Add("CHILLTES");
                    break;
            }
            //Now this List would generate the Possible list of Forecast Master for this Block

            //Get the Block EnhancementTypeID from the table
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT BlockEnhancementTypeID,Alias FROM BlockEnhancementType");
            List<int> BlockEnhancementTypeID = new List<int>();
            foreach (string id in this.BlockEnhancementList)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (id == data.Rows[i][1].ToString())
                    {
                        BlockEnhancementTypeID.Add(Convert.ToInt32(data.Rows[i][0]));
                    }

                }
            }

            //Insert into the BlockWiseEnhancementSelection Table
            DataTable BlockWiseEnhancementSelection = new DataTable();
            BlockWiseEnhancementSelection.Columns.Add("BlockID", typeof(int));
            BlockWiseEnhancementSelection.Columns.Add("EnhancementID", typeof(int));
            BlockWiseEnhancementSelection.Columns.Add("SiteID", typeof(int));
            for (int i = 0; i < BlockEnhancementTypeID.Count; i++)
            {
                DataRow r = BlockWiseEnhancementSelection.NewRow();
                r["BlockID"] = blockID;
                r["EnhancementID"] = BlockEnhancementTypeID.ElementAt(i);
                r["SiteID"] = Form1.GSiteId;
                BlockWiseEnhancementSelection.Rows.Add(r);
            }


            //conn.Open();
            try
            {
                string sql = "INSERT BlockWiseEnhancementSelection (BlockID,BlockEnhancementTypeID,SiteID) VALUES (@A,@B,@C)";
                using (SqlConnection conn = new SqlConnection(Connection.getConnectionString()))
                {
                    SqlCommand com = new SqlCommand(sql, conn);
                    conn.Open();
                    foreach (DataRow r in BlockWiseEnhancementSelection.Rows)
                    {
                        com.Parameters.AddWithValue("@A", r["BlockID"]);
                        com.Parameters.AddWithValue("@B", r["EnhancementID"]);
                        com.Parameters.AddWithValue("@C", r["SiteID"]);
                        if (com.ExecuteNonQuery() > 0)
                        {
                            com.Parameters.Clear();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //string sql2 = "INSERT BlockWiseEnhancementSelection (BlockID,BlockEnhancementTypeID,SiteID) VALUES (@A,@B,@C)";
            //foreach (DataRow r in BlockWiseEnhancementSelection.Rows)
            //{
            //    SqlCommand cmd2 = conn.CreateCommand();
            //    cmd2.CommandText = sql2;
            //    cmd2.Parameters.AddWithValue("@A", r["BlockID"]);
            //    cmd2.Parameters.AddWithValue("@B", r["EnhancementID"]);
            //    cmd2.Parameters.AddWithValue("@C", r["SiteID"]);
            //    cmd2.ExecuteNonQuery();
            //    //MessageBox.Show(x.ToString());
            //}


            //Utilize the Forecast master list BlockEnhancementTypeID to filter the ForecastID by Enhancement

            DataTable data2 = new DataTable();
            data2 = HandleSqlQueries.HandleQueries("SELECT ForecastMasterID,BlockEnhancementTypeID FROM ForecastMasterEnhancementMapping");

            /*LINQ Example
             * var results = from myRow in myDataTable.AsEnumerable()
                             where myRow.Field<int>("RowNo") == 1
                             select myRow;
                             */

            //Generate the List of Possible Forecast Based on the BlockEnhancementTypeID
            var Mapping = new Dictionary<int, List<int>>();

            var distinctForecastID = (from row in data2.AsEnumerable()
                                      select row[0]).Distinct();

            //MessageBox.Show("Test");

            foreach (var id in distinctForecastID)
            {
                var enhancementList = from row in data2.AsEnumerable()
                                      where (int)row[0] == (int)id
                                      select row[1];
                //MessageBox.Show(enhancementList.Count().ToString());
                Mapping.Add(Convert.ToInt32(id), enhancementList.Cast<int>().ToList());
            }

            foreach (var id in Mapping)
            {
                //MessageBox.Show(id.Value.ToString()+ id.Value.Intersect(BlockEnhancementTypeID).ToString());
                if (id.Value.Intersect(BlockEnhancementTypeID).Count() == id.Value.Count())
                {
                    b.PossibleForecastId.Add(id.Key);
                }
            }

            DataTable data3 = new DataTable();
            data3 = HandleSqlQueries.HandleQueries("SELECT  ForecastMasterByEnhancement, Name FROM ForecastMasterByEnhancement_Temp WHERE ForecastMasterByEnhancement IN(" + String.Join(", ", b.PossibleForecastId) + ")");
            //PossibleForecastID contain all the forecast list Based on the Enhancement Selection

            //ForecastTypeByBlockType contains all the string for Block Types... 

            List<string> PossibleForecastName = new List<string>();

            List<string> CompletePossibleForecastList = new List<string>();
            for (int i = 0; i < data3.Rows.Count; i++)
            {
                PossibleForecastName.Add(data3.Rows[i][1].ToString());
            }
            foreach (var id in ForecastTypeByBlockType)
            {
                foreach (var id2 in PossibleForecastName)
                {
                    CompletePossibleForecastList.Add(id + " " + id2);
                }
            }
            try
            {
                string sql = "INSERT ForecastMasterPossible (ForecastMasterID,BlockID,ForecastName) VALUES (@A,@B,@C)";
                using (SqlConnection conn = new SqlConnection(Connection.getConnectionString()))
                {
                    SqlCommand com = new SqlCommand(sql, conn);
                    conn.Open();
                    foreach (var id in CompletePossibleForecastList)
                    {
                        com.Parameters.AddWithValue("@A", CompletePossibleForecastList.IndexOf(id) + 1);
                        com.Parameters.AddWithValue("@B", blockID);
                        com.Parameters.AddWithValue("@C", id.ToString());
                        if (com.ExecuteNonQuery() > 0)
                        {
                            com.Parameters.Clear();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //string sql4 = "INSERT ForecastMasterPossible (ForecastMasterID,BlockID,ForecastName) VALUES (@A,@B,@C)";
            //foreach (var id in CompletePossibleForecastList)
            //{

            //    SqlCommand cmd4 = conn.CreateCommand();
            //    cmd4.CommandText = sql4;
            //    cmd4.Parameters.AddWithValue("@A", CompletePossibleForecastList.IndexOf(id) + 1);
            //    cmd4.Parameters.AddWithValue("@B", blockID);
            //    cmd4.Parameters.AddWithValue("@C", id.ToString());
            //    cmd4.ExecuteNonQuery();
            //}

            //update all the forecast into forecast table

            //Update the PlantMasterVariable_Temp
            UpdatePlantMasterVariable(b.BlockEnhancementList, blockID);

            //We need to work on updating the PlantVariableMasterPossible Table where we update Based on the config and the plant object type..
            //If the PlantObjectTypeID = 3 i.e. Generator Then create n+1 generator variables for nx1 Block type
            //If the PlantObjectTypeID = 4 or 6 i.e. Gas Turbine or HRSG create n times the variables for nx1 BlockType
            UpdatePlantMasterPossible(blockID);


        }

        public void UpdatePlantMasterVariable(List<string> BlockEnhancementList, int blockID)
        {
            List<string> NewBlockEnhancementList = new List<string>();
            foreach (var item in BlockEnhancementList)
            {
                NewBlockEnhancementList.Add("'" + item + "'");
            }
            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT  EnhancementTypeName,PlantMasterVariableID,Mandatory FROM EnhancementUniquePlantMasterVariable WHERE EnhancementTypeName IN (" + String.Join(",", NewBlockEnhancementList) + ")");
            List<int> PossibleVariableMasterID = new List<int>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                PossibleVariableMasterID.Add((int)data.Rows[i][1]);
            }
            DataTable data2 = new DataTable();
            data2 = HandleSqlQueries.HandleQueries("SELECT  PlantMasterVariableID,Name,Description,PlantObjectTypeID,ObjectGroupID,Mandatory FROM PlantMasterVariable WHERE (UniqueID=0) OR (PlantMasterVariableID IN (" + String.Join(",", PossibleVariableMasterID) + "))");

            DataTable data3 = new DataTable();

            //We need to insert this into PlantMasterVariable_Temp
            try
            {
                string sql = "INSERT PlantMasterVariable_Temp (PlantMasterVariableID,BlockID,Alias,Description,PlantObjectTypeID,ObjectGroupID,Mandatory) VALUES (@A,@B,@C,@D,@E,@F,@G)";
                using (SqlConnection conn = new SqlConnection(Connection.getConnectionString()))
                {
                    SqlCommand com = new SqlCommand(sql, conn);
                    conn.Open();
                    foreach (DataRow Row in data2.Rows)
                    {
                        com.Parameters.AddWithValue("@A", Row[0]);
                        com.Parameters.AddWithValue("@B", blockID);
                        com.Parameters.AddWithValue("@C", Row[1]);
                        com.Parameters.AddWithValue("@D", Row[2]);
                        com.Parameters.AddWithValue("@E", Row[3]);
                        com.Parameters.AddWithValue("@F", Row[4]);
                        com.Parameters.AddWithValue("@G", Row[5]);
                        if (com.ExecuteNonQuery() > 0)
                        {
                            com.Parameters.Clear();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //string insertcmd = "INSERT PlantMasterVariable_Temp (PlantMasterVariableID,BlockID,Alias,Description,PlantObjectTypeID,ObjectGroupID,Mandatory) VALUES (@A,@B,@C,@D,@E,@F,@G)";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //conn.Open();
            //foreach (DataRow Row in data2.Rows)
            //{
            //    SqlCommand cmd2 = conn.CreateCommand();
            //    cmd2.CommandText = insertcmd;
            //    cmd2.Parameters.AddWithValue("@A", Row[0]);
            //    cmd2.Parameters.AddWithValue("@B", blockID);
            //    cmd2.Parameters.AddWithValue("@C", Row[1]);
            //    cmd2.Parameters.AddWithValue("@D", Row[2]);
            //    cmd2.Parameters.AddWithValue("@E", Row[3]);
            //    cmd2.Parameters.AddWithValue("@F", Row[4]);
            //    cmd2.Parameters.AddWithValue("@G", Row[5]);

            //    cmd2.ExecuteNonQuery();
            //    //MessageBox.Show(x.ToString());
            //}
        }

        public void UpdatePlantMasterPossible(int blockID)
        {

            //We need to work on updating the PlantVariableMasterPossible Table where we update Based on the config and the plant object type..
            //If the PlantObjectTypeID = 3 i.e. Generator Then create n+1 generator variables for nx1 Block type
            //If the PlantObjectTypeID = 4 or 6 i.e. Gas Turbine or HRSG create n times the variables for nx1 BlockType

            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT  * FROM PlantMasterVariable_Temp where BlockID =" + blockID.ToString());

            DataTable newData = new DataTable();
            foreach (DataRow Row in data.Rows)
            {
                Functions.InsertRow(blockID, Row, this.comboBoxConfig.SelectedIndex);
            }

        }

        private void DeleteForecastButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
            //Delete it from the Database table too

        }

        public void ShowForecastGroup()
        {
            ForecastGroupBox.Visible = true;
        }
    }
}
