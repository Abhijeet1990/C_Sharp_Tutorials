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
using ForecastWizardApplication.Infrastructure;
using RTP.Controls;
using System.Text.RegularExpressions;

namespace ForecastWizardApplication.Views
{

    public partial class AddForecastForm : Form
    {
        BlockUserControl buc { get; set; }
        Form1 parentform { get; set; }

        AutoCompleteTextBox CriteriaTextBox = new AutoCompleteTextBox();

        public string SearchString = string.Empty;  // To pass updated searched value to parent page

        public static int selectionID = 0;
        public AddForecastForm(BlockUserControl f)
        {
            buc = f;
            InitializeComponent();
        }

        public AddForecastForm(BlockUserControl f, string searchString, int BlockID)
        {
            buc = f;
            this.SearchString = searchString;

            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT Description FROM PossiblePlantMasterVariable where BlockID=" + BlockID.ToString());
            String[] list = new String[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                list[i] = data.Rows[i][0].ToString();
                //list.Add(data.Rows[i][0].ToString());
            }
            CriteriaTextBox.Multiline = true;
            CriteriaTextBox.Width = 350;
            CriteriaTextBox.Height = 120;
            CriteriaTextBox.Variables = list;
            InitializeComponent();
        }
        private void AddForecastForm_Load(object sender, EventArgs e)
        {
            List<string> enhancementList = new List<string>();
            enhancementList = buc.BlockEnhancementList;
            if (enhancementList.Contains("AI"))
            {
                AntiIcingCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("IAH"))
            {
                InletAirHeatingCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("EC") || enhancementList.Contains("FOG") || enhancementList.Contains("CHILL") || enhancementList.Contains("CHILLTES"))
            {
                InletAirCoolingCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("CAT"))
            {
                CombustionAutoTuningCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("PF"))
            {
                PeakFiringCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("DB"))
            {
                DuctBurnersCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("SI(DB)") || enhancementList.Contains("SI(NODB)"))
            {
                SteamPowerAugmentationCheckBox.Enabled = true;
            }

            //Create the Auto Complete TextBox for Criteria
            //CriteriaTextBox = new AutoCompleteTextBox();
            CriteriaTextBox.Location = new Point(20, 20);
            CriteriaGroupBox.Controls.Add(CriteriaTextBox);
        }

        private void AddForecastOKButton_Click(object sender, EventArgs e)
        {
            selectionID += 1;
            //First connect with the table ForecastMasterPossible and then filter the list of Forecast List
            List<string> BlockEnhancementScheduled = new List<string>();

            BlockEnhancementScheduled.Clear();
            if (AntiIcingCheckBox.Checked)
                BlockEnhancementScheduled.Add("AI");
            if (InletAirHeatingCheckBox.Checked)
                BlockEnhancementScheduled.Add("IAH");
            if (CombustionAutoTuningCheckBox.Checked)
                BlockEnhancementScheduled.Add("CAT");
            if (PeakFiringCheckBox.Checked)
                BlockEnhancementScheduled.Add("PF");
            if (DuctBurnersCheckBox.Checked)
                BlockEnhancementScheduled.Add("DB");
            if (SteamPowerAugmentationCheckBox.Checked)
            {
                if (buc.BlockEnhancementList.Contains("SI(DB)"))
                {
                    BlockEnhancementScheduled.Add("SI(DB)");
                }
                else
                {
                    BlockEnhancementScheduled.Add("SI(NODB)");
                }

            }
            if (buc.BlockEnhancementList.Contains("EC"))
            {
                BlockEnhancementScheduled.Add("EC");
            }
            if (buc.BlockEnhancementList.Contains("FOG"))
            {
                BlockEnhancementScheduled.Add("FOG");
            }
            if (buc.BlockEnhancementList.Contains("CHILL"))
            {
                BlockEnhancementScheduled.Add("CHILL");
            }
            if (buc.BlockEnhancementList.Contains("CHILLTES"))
            {
                BlockEnhancementScheduled.Add("CHILLTES");
            }


            if (VerifyExpression())
            {
                SearchString = CriteriaTextBox.Text;
            }

            DataTable data = new DataTable();
            data = HandleSqlQueries.HandleQueries("SELECT * FROM ForecastMasterPossible WHERE BlockID = " + BlockData._blockID.ToString());
            string selectedForecast = "";
            string[] separators = { " ", "+" };
            //Filter the content of the table to produle one forecast type based on config and checkbox selections
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int count = 0;
                int wordCount = 0;
                foreach (var id in BlockEnhancementScheduled)
                {
                    var code = data.Rows[i][2].ToString().Split(new[] { "BASE" }, StringSplitOptions.None)[1];
                    string[] words = code.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        if (word == id.ToString())
                        {
                            count++;
                        }
                    }
                    wordCount = words.Count();
                }
                if (BlockEnhancementScheduled.Count == count && BlockEnhancementScheduled.Count == wordCount && data.Rows[i][2].ToString().Contains(ConfigurationComboBox.Text))
                {
                    selectedForecast += data.Rows[i][2];
                }
            }
            DataGridViewRow row = (DataGridViewRow)buc.dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = ConfigurationComboBox.Text;
            //row.Cells[0].ToolTipText = CriteriaTextBox.Text;
            row.Cells[2].Value = LongNameTextBox.Text;
            row.Cells[3].Value = ShortNameTextBox.Text;
            row.Cells[4].Value = selectedForecast;
            buc.dataGridView1.Rows.Add(row);

            if (CriteriaTextBox.Text != string.Empty)
            {
                row.Cells[1].Value = Properties.Resources.OK;
                row.Cells[1].ToolTipText = CriteriaTextBox.Text;
            }
            else
            {
                row.Cells[1].Value = Properties.Resources.WarningCircle;
                row.Cells[1].ToolTipText = CriteriaTextBox.Text;
            }
            string selectedConfig = ConfigurationComboBox.Text.Substring(ConfigurationComboBox.Text.IndexOf(' ')).Remove(0, 1);


            //The requirement is at building the Forecast Selection Table
            string JoinedBlockEnhancement = this.JoinedBlockEnhancement(BlockEnhancementScheduled);

            //Get the Train ID for the Forecast selection from the ForecastMasterByBlockTypeConfiguration Table
            DataTable data2 = new DataTable();
            data2 = HandleSqlQueries.HandleQueries("Select TrainID from ForecastMasterByBlockTypeConfiguration where BlockTypeID = " + (buc.comboBoxConfig.SelectedIndex + 1) + " and Name LIKE '" + selectedConfig + "'");
            string TrainID = data2.Rows[0][0].ToString();


            //Insert into ForecastSelection Table
            DataTable ForecastSelectionTable = new DataTable();
            ForecastSelectionTable.Columns.Add("SelectionID", typeof(int));
            ForecastSelectionTable.Columns.Add("Name", typeof(string));
            ForecastSelectionTable.Columns.Add("Alias", typeof(string));
            ForecastSelectionTable.Columns.Add("BlockID", typeof(int));
            ForecastSelectionTable.Columns.Add("ForecastMasterByBlockType", typeof(string));
            ForecastSelectionTable.Columns.Add("BlockEnhancements", typeof(string));
            ForecastSelectionTable.Columns.Add("TrainID", typeof(string));
            ForecastSelectionTable.Columns.Add("Criteria", typeof(string));

            DataRow r = ForecastSelectionTable.NewRow();
            r["SelectionID"] = selectionID;
            r["Name"] = LongNameTextBox.Text;
            r["Alias"] = ShortNameTextBox.Text;
            r["BlockID"] = BlockData._blockID;
            r["ForecastMasterByBlockType"] = selectedConfig;
            r["BlockEnhancements"] = JoinedBlockEnhancement;
            r["TrainID"] = TrainID;
            r["Criteria"] = CriteriaTextBox.Text;
            ForecastSelectionTable.Rows.Add(r);

            //Insert only when it does not exist in the Forecast table..have to look over this
            //DataTable ForecastBufferTable = new DataTable();
            try
            {
                string sql = "INSERT ForecastSelection (SelectionID,Name,Alias,BlockID,ForecastMasterByBlockType,BlockEnhancements,TrainID,Criteria) VALUES (@A,@B,@C,@D,@E,@F,@G,@H)";
                using (SqlConnection conn = new SqlConnection(Connection.getConnectionString()))
                {
                    SqlCommand com = new SqlCommand(sql, conn);
                    conn.Open();
                    foreach (DataRow forecastRow in ForecastSelectionTable.Rows)
                    {
                        com.Parameters.AddWithValue("@A", forecastRow["SelectionID"]);
                        com.Parameters.AddWithValue("@B", forecastRow["Name"]);
                        com.Parameters.AddWithValue("@C", forecastRow["Alias"]);
                        com.Parameters.AddWithValue("@D", forecastRow["BlockID"]);
                        com.Parameters.AddWithValue("@E", forecastRow["ForecastMasterByBlockType"]);
                        com.Parameters.AddWithValue("@F", forecastRow["BlockEnhancements"]);
                        com.Parameters.AddWithValue("@G", forecastRow["TrainID"]);
                        com.Parameters.AddWithValue("@H", forecastRow["Criteria"]);
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

            //Update the Mandatory Status in the PossiblePlantMasterVariable Table
            //First Check the selection ID from the Forecast Selection Table
            //Get the Block Enhancement List from that table
            //Get the PlantVariableMasterID for which the Mandatory Type is M(C)...
            //Search through the PossiblePlantMasterVariable table based on the Train ID and column whose mandatory values are  M(C)..
            //if the PlantVariableMasterID with M(C) convert them to M.

            Functions.UpdateMandatoryStatus(BlockData._blockID);

        }

        public string JoinedBlockEnhancement(List<string> BlockEnhancementScheduled)
        {
            string joinedstring = "";
            if (BlockEnhancementScheduled.Count > 0)
            {
                foreach (var item in BlockEnhancementScheduled)
                {
                    joinedstring += item + ",";
                }
            }
            return joinedstring;
        }
        private void AddForecastForm_Shown(object sender, EventArgs e)
        {
            // Put cursor in ready position to continue typing
            CriteriaTextBox.Focus();

            if (!string.IsNullOrEmpty(SearchString))
                CriteriaTextBox.SelectionStart = SearchString.Length;
        }


        private bool VerifyExpression()
        {
            DataTable dataTable = new DataTable();
            dataTable.Rows.Add();

            List<string> invalidColumns = new List<string>();

            try
            {
                if (CriteriaTextBox.Text == string.Empty) return true;

                // Get all the variables within brackets to prepopulate data table column headers.
                var matches = Regex.Matches(CriteriaTextBox.Text, @"(?<=\[)[^]]*(?=\])").Cast<Match>().Select(m => m.Value).ToList();

                // Checking if all matches are in AutoCompleteVariables.
                invalidColumns = matches.Except(CriteriaTextBox.Variables.ToList()).ToList();

                if (invalidColumns.Count() > 0) throw new Exception();

                // Adding variables as column headers but check for duplicates
                foreach (var match in matches)
                    if (!dataTable.Columns.Contains(match))
                        dataTable.Columns.Add(match.ToString());

                // Try using datacolumn expression to verify okay
                dataTable.Columns.Add("Test", typeof(double), CriteriaTextBox.Text);
                return true;
            }

            catch (Exception ex)
            {
                if (invalidColumns.Count > 0)
                    MessageBox.Show(string.Format("The variables \"{0}\" do not exist", string.Join(",", invalidColumns.ToArray())
                        , "Invalid variables"), "Invalid variables", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                    if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.Message, "Error in expression", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "Error in expression", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
    }

}
