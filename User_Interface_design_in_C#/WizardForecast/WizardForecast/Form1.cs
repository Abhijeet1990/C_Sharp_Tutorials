using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WizardForecast
{
    public partial class Form1 : Form
    {
        public bool AntiIcingCheck = false;
        public bool InletAirHeatingCheck = false;
        public bool PeakFiringCheck = false;
        public bool SteamInjectionCheck = false;
        public bool DuctBurnersCheck = false;
        public bool ForecastCheck = false;
        public bool CompressorMapCheck = false;
        public bool TESCheck = false;
        //public bool GTConfigured = false;
        //public bool GenConfigured = false;
        //public bool HRSGConfigured = false;
        //public bool STConfigured = false;
        //public bool ICConfigured = false;
        //public bool CondConfigured = false;
        public bool ObjectConfigured = false;
        public Form1()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=realtimepower.database.windows.net;Initial Catalog=RealTimePower;Integrated Security=False;User ID=abhijeetsahu;Password=@rtp2016saHu;Connect Timeout=15;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();
            
            string strCmd = "select SiteID,Name from Site";
            using (SqlCommand command = new SqlCommand(strCmd, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(strCmd, conn);

                DataSet ds = new DataSet();

                da.Fill(ds);
                command.ExecuteNonQuery();

                comboBox6.DisplayMember = ds.Tables[0].Columns[1].ToString();
                comboBox6.ValueMember = ds.Tables[0].Columns[0].ToString();
                comboBox6.DataSource = ds.Tables[0];
                comboBox6.Enabled = true;
            }
            
            string strFetchForecastCmd = "select Name from Forecast";
            using (SqlCommand command2 = new SqlCommand(strFetchForecastCmd, conn))
            {
                SqlDataAdapter da2 = new SqlDataAdapter(strFetchForecastCmd, conn);
                DataSet ForecastSet = new DataSet();
                da2.Fill(ForecastSet,"ForecastType");
                command2.ExecuteNonQuery();
                //dataGridView4.ReadOnly = true;
                //dataGridView4.DataMember = "ForecastType";
                //dataGridView4.AutoGenerateColumns = false;
                dataGridView4.DataSource = ForecastSet.Tables["ForecastType"];

            }
            System.Collections.ObjectModel.ReadOnlyCollection<TimeZoneInfo> timezoneInfo;
            timezoneInfo = TimeZoneInfo.GetSystemTimeZones();
            comboBox16.DataSource = timezoneInfo;




            this.comboBox1.SelectedIndexChanged +=
            new System.EventHandler(comboBox1_SelectedIndexChanged);
            //PopulateComboBox2();
            this.comboBox4.SelectedIndexChanged +=
            new System.EventHandler(comboBox4_SelectedIndexChanged);
            //string x = "1";
            //string strCmd2 = "select BlockID,Name from Block where SiteID='" + x + "'";
            //using (SqlCommand command = new SqlCommand(strCmd2, conn))
            //{
            //    SqlDataAdapter da = new SqlDataAdapter(strCmd2, conn);

            //    DataSet ds = new DataSet();

            //    da.Fill(ds);
            //    command.ExecuteNonQuery();
            //    dataGridView1.DataSource = ds.Tables[0];
            //    int row = ds.Tables[0].Rows.Count - 1;
            //    for (int r = 0; r <= row; r++)
            //    {
            //        dataGridView1.Rows.Add();

            //        dataGridView1.Rows[r].Cells[0].Value = ds.Tables[0].Rows[r].ItemArray[1];
            //    }
            //}
            //pictureBox2.ContextMenuStrip = contextMenuStrip1;
            //MessageBox.Show(comboBox6.SelectedText);
            //populateStatus();
            conn.Close();
        }

        public void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            comboBox4.Items.Clear();
            string[] simple = new string[] { "GT 1" };
            string[] OneOneSingleShaft = new string[] { "GT 1" };
            string[] OneOneMultipleShaft = new string[] { "GT 1", "ST 1" };
            string[] TwoOne = new string[] { "GT 1", "GT 2", "ST 1" };
            string[] ThreeOne = new string[] { "GT 1", "GT 2", "GT 3", "ST 1" };
     
            if ((string)comboBox1.SelectedItem == "Simple")
            {
                comboBox4.Items.AddRange(simple);
            }
            else if ((string)comboBox1.SelectedItem == "1 x 1 Single Shaft")
            {
                comboBox4.Items.AddRange(OneOneSingleShaft);
            }
            else if ((string)comboBox1.SelectedItem == "1 x 1 Dual Shaft")
            {
                comboBox4.Items.AddRange(OneOneMultipleShaft);
            }
            else if ((string)comboBox1.SelectedItem == "2 x 1")
            {
                comboBox4.Items.AddRange(TwoOne);
            }
            else if ((string)comboBox1.SelectedItem == "3 x 1")
            {
                comboBox4.Items.AddRange(ThreeOne);
            }

        }
        public void populateStatus()
        {
            /*connect with the database and confirm if all the
             *  Mandatory Plant Object Configuration
            are done.*/



            /*connect with the database and confirm 
             * if all the Forecast Type configuration are done*/




            /*connect with the database and confirm if all the Variables 
             * for the different Forecast 
            types are done*/   
             
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex > -1 && comboBox2.SelectedIndex > -1 && comboBox3.SelectedIndex > -1)
            {
                SitePage.ImageIndex = 2;
            }
            tabControl.SelectedTab = BlockPage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
            dataGridView2.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = ForecastPage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = VariablePage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = ModelPage;
        }


        public void populateIcon(int rowCount)
        {
            Image gen = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\Gen.bmp");
            Image gt = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\GT.ico");
            Image hrsg = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\HRSG.bmp");
            Image st = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\ST.ico");
            Image ic = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\IC.jpg");
            Image cond = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\Cond.ico");
            
            for (int i = 0; i < rowCount; i++)

            {

                if (dataGridView2[0,i].Value.ToString() == "Gas Turbine")
                {
                    dataGridView2[1,i].Value = gt;

                }
                else if (dataGridView2[0,i].Value.ToString() == "Generator")
                {
                    dataGridView2[1,i].Value = gen;

                }
                else if (dataGridView2[0,i].Value.ToString() == "HRSG")
                {
                    dataGridView2[1,i].Value = hrsg;

                }
                else if (dataGridView2[0, i].Value.ToString() == "Steam Turbine")
                {
                    dataGridView2[1, i].Value = st;

                }
                else if (dataGridView2[0, i].Value.ToString() == "Inlet Cooling")
                {
                    dataGridView2[1, i].Value = ic;

                }
                else if (dataGridView2[0, i].Value.ToString() == "Condenser")
                {
                    dataGridView2[1, i].Value = cond;

                }
            }
        }

        public void populateType(int rowCount)
        {
            ObjectType.Items.Clear();
            for (int i = 0; i < rowCount; i++)

            {

                if (dataGridView2[0, i].Value.ToString() == "Gas Turbine")
                {
                    DataGridViewComboBoxCell GTCell = 
                            (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
                    GTCell.DataSource = Enum.GetNames(typeof(GasTurbineType)).ToList();
                    ObjectType.Items.Add(GTCell);
                    

                }
                else if (dataGridView2[0, i].Value.ToString() == "Generator")
                {
                    DataGridViewComboBoxCell GenCell =
                            (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
                    GenCell.DataSource = Enum.GetNames(typeof(GeneratorType)).ToList();
                    ObjectType.Items.Add(GenCell);
                    

                }
                else if (dataGridView2[0, i].Value.ToString() == "HRSG")
                {
                    DataGridViewComboBoxCell HRSGCell = 
                            (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
                    HRSGCell.DataSource = Enum.GetNames(typeof(HRSGType)).ToList();
                    ObjectType.Items.Add(HRSGCell);
                    

                }
                else if (dataGridView2[0, i].Value.ToString() == "Steam Turbine")
                {
                    DataGridViewComboBoxCell STCell =
                            (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
                    STCell.DataSource = Enum.GetNames(typeof(SteamTurbineType)).ToList();
                    ObjectType.Items.Add(STCell);
                    

                }
                else if (dataGridView2[0, i].Value.ToString() == "Inlet Cooling")
                {
                    DataGridViewComboBoxCell ICCell =
                            (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
                    ICCell.DataSource = Enum.GetNames(typeof(InletCoolingType)).ToList();
                    ObjectType.Items.Add(ICCell);
                    

                }
                else if (dataGridView2[0, i].Value.ToString() == "Condenser")
                {
                    DataGridViewComboBoxCell CondCell =
                            (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
                    CondCell.DataSource = Enum.GetNames(typeof(CondenserType)).ToList();
                    ObjectType.Items.Add(CondCell);
                    

                }
            }

        }

        public void comboBox4_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((string)comboBox1.SelectedItem == "Simple")
            {
                if ((string)comboBox4.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);

                }
            }
            if ((string)comboBox1.SelectedItem == "1 x 1 Single Shaft")
            {
                if ((string)comboBox4.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[6];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    dataGridView2.Rows[3].Cells[0].Value = "HRSG";
                    dataGridView2.Rows[4].Cells[0].Value = "Steam Turbine";
                    dataGridView2.Rows[5].Cells[0].Value = "Condenser";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }
            }
            if ((string)comboBox1.SelectedItem == "1 x 1 Dual Shaft")
            {
                if ((string)comboBox4.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    dataGridView2.Rows[3].Cells[0].Value = "HRSG";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);

                }
                else if ((string)comboBox4.SelectedItem == "ST 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Steam Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Condenser";
                    dataGridView2.Rows[2].Cells[0].Value = "Generator";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);

                }
            }
            if ((string)comboBox1.SelectedItem == "2 x 1")
            {
                if ((string)comboBox4.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    dataGridView2.Rows[3].Cells[0].Value = "HRSG";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }
                else if ((string)comboBox4.SelectedItem == "GT 2")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    dataGridView2.Rows[3].Cells[0].Value = "HRSG";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }
                else if ((string)comboBox4.SelectedItem == "ST 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Steam Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Condenser";
                    dataGridView2.Rows[2].Cells[0].Value = "Generator";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }

            }
            if ((string)comboBox1.SelectedItem == "3 x 1")
            {
                if ((string)comboBox4.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    dataGridView2.Rows[3].Cells[0].Value = "HRSG";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }
                else if ((string)comboBox4.SelectedItem == "GT 2")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    dataGridView2.Rows[3].Cells[0].Value = "HRSG";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }
                else if ((string)comboBox4.SelectedItem == "GT 3")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    dataGridView2.Rows[3].Cells[0].Value = "HRSG";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }
                else if ((string)comboBox4.SelectedItem == "ST 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[3];
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Steam Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Condenser";
                    dataGridView2.Rows[2].Cells[0].Value = "Generator";
                    this.populateIcon(r.Length);
                    this.populateType(r.Length);
                }

            }
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            
            if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0,i].Value.ToString()=="Gas Turbine")
                {
                ConfigureGT confGT = new ConfigureGT(AntiIcingCheck,PeakFiringCheck,SteamInjectionCheck,comboBox6.Text,
                    textBox8.Text,dataGridView2[2,i].Value.ToString());
                confGT.Show(this);
                }
            if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Generator")
                {
                ConfigureGen confGT = new ConfigureGen(comboBox6.Text,
                    textBox8.Text, dataGridView2[2, i].Value.ToString());
                confGT.Show(this);
                
                }
            if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0,i].Value.ToString()=="HRSG")
                {
                ConfigureHRSG confGT = new ConfigureHRSG(DuctBurnersCheck, comboBox6.Text,
                    textBox8.Text, dataGridView2[2, i].Value.ToString());
                confGT.Show(this);
                
                }
            if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Steam Turbine")
                {
                ConfigureST confGT = new ConfigureST(comboBox6.Text,
                    textBox8.Text, dataGridView2[2, i].Value.ToString());
                confGT.Show(this);
                
                }
            if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Inlet Cooling")
                {
                ConfigureInletCooling confGT = new ConfigureInletCooling(comboBox6.Text,
                    textBox8.Text, dataGridView2[2, i].Value.ToString());
                confGT.Show(this);
                
                }
            if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Condenser")
                {
                ConfigureCondenser confGT = new ConfigureCondenser(comboBox6.Text,
                    textBox8.Text, dataGridView2[2, i].Value.ToString());
                confGT.Show(this);
                
                }

            
        }
        
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==1)
            tabControl.SelectedIndex = 4;
        }

        private bool ValidateBlockConfiguration()
        {
            bool BlockStatus = false;
            for (int i = 0; i < comboBox4.Items.Count; i++)
            {
                BlockStatus = BlockStatus & VerifyUnitConfiguration(comboBox4.Text);
            }
            return BlockStatus;
        }

        public bool VerifyUnitConfiguration(string test)
        {
            bool UnitStatus = false;
            for(int i=0;i<dataGridView2.RowCount;i++)
            {
                UnitStatus = UnitStatus & VerifyObjectConfiguration(i);
            }
            return UnitStatus;
        }
        public bool VerifyObjectConfiguration(int x)
        {
            bool ObjectStatus = false;
            if (ObjectConfigured)
            {
                ObjectStatus = true;
            }
            return ObjectStatus;

        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.SelectedIndex==-1)
            {
                MessageBox.Show("Select number of blocks");
            }
        }

        private void comboBox6_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("The Site Name cannot be empty");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (InletAirCooling.Checked)
            {
                AntiIcingCheck = true;
            }
            if (InletAirHeating.Checked)
            {
                InletAirHeatingCheck= true;
            }
            if (PeakFiring.Checked)
            {
                PeakFiringCheck = true;
            }
            if (SteamInjection.Checked)
            {
                SteamInjectionCheck = true;
            }
            if (DuctBurners.Checked)
            {
                DuctBurnersCheck = true;
            }
            if (Forecast.Checked)
            {
                ForecastCheck = true;
            }
            if (CompressorMap.Checked)
            {
                CompressorMapCheck = true;
            }
            if (TES.Checked)
            {
                TESCheck = true;
            }
           
        }

    }
}
