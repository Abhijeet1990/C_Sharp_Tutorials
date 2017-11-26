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
    public partial class AddForecastForm : Form
    {
        Form1 form;
        public AddForecastForm(Form1 f)
        {
            form = f;
            InitializeComponent();
        }

        private void AddForecastForm_Load(object sender, EventArgs e)
        {
            List<string> enhancementList = new List<string>();
            enhancementList = Form1.BlockEnhancementList; 
            if(enhancementList.Contains("AI"))
            {
                AntiIcingCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("IAH"))
            {
                InletAirHeatingCheckBox.Enabled = true;
            }
            if (enhancementList.Contains("EC")|| enhancementList.Contains("FOG")|| enhancementList.Contains("CHILL")||enhancementList.Contains("CHILLTES"))
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
            if (enhancementList.Contains("SI(DB)")||enhancementList.Contains("SI(NODB)"))
            {
                SteamPowerAugmentationCheckBox.Enabled = true;
            }
            
        }

        private void AddForecastOKButton_Click(object sender, EventArgs e)
        {
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
                if (Form1.BlockEnhancementList.Contains("SI(DB)"))
                {
                    BlockEnhancementScheduled.Add("SI(DB)");
                }
                else
                {
                    BlockEnhancementScheduled.Add("SI(NODB)");
                }

            }
            if (Form1.BlockEnhancementList.Contains("EC"))
            {
                BlockEnhancementScheduled.Add("EC");
            }
            if (Form1.BlockEnhancementList.Contains("FOG"))
            {
                BlockEnhancementScheduled.Add("FOG");
            }
            if (Form1.BlockEnhancementList.Contains("CHILL"))
            {
                BlockEnhancementScheduled.Add("CHILL");
            }
            if (Form1.BlockEnhancementList.Contains("CHILLTES"))
            {
                BlockEnhancementScheduled.Add("CHILLTES");
            }

            SqlConnection conn3 = new SqlConnection();
            conn3.ConnectionString = @"Server=tcp:realtimepower.database.windows.net,1433;Initial Catalog=ForecastAppDatabase;Persist Security Info=False;User ID=abhijeetsahu;Password=@rtp2016saHu;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conn3;
            command.CommandText = "SELECT * FROM ForecastMasterPossible WHERE BlockID = "+Form1.blockCount;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
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
                        if(word==id.ToString())
                        {
                            count++;
                        }
                    }
                    wordCount = words.Count();
                }
                if(BlockEnhancementScheduled.Count== count && BlockEnhancementScheduled.Count == wordCount && data.Rows[i][2].ToString().Contains(comboBox1.Text))
                {
                    selectedForecast += data.Rows[i][2];
                }
            }
            DataGridViewRow row = (DataGridViewRow)form.dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = comboBox1.Text;
            row.Cells[1].Value = LongNameTextBox.Text;
            row.Cells[2].Value = ShortNameTextBox.Text;
            row.Cells[3].Value = selectedForecast;
            form.dataGridView1.Rows.Add(row);
        }
    }
}
