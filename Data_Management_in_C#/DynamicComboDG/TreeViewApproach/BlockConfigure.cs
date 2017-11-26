using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewApproach
{
    public partial class BlockConfigure : UserControl
    {
        public bool InletAirCoolingCheck = false;
        public bool InletAirHeatingCheck = false;
        public bool PeakFiringCheck = false;
        public bool SteamInjectionCheck = false;
        public bool DuctBurnersCheck = false;
        public bool ForecastCheck = false;
        public bool CompressorMapCheck = false;
        public bool TESCheck = false;
        
        public BlockConfigure()
        {
            InitializeComponent();
            this.BlockTypeComboBox.SelectedIndexChanged +=
            new System.EventHandler(BlockTypeComboBox_SelectedIndexChanged);
            //PopulateComboBox2();
            this.ConfigureUnitComboBox.SelectedIndexChanged +=
            new System.EventHandler(ConfigureUnitComboBox_SelectedIndexChanged);
    
        }

        public void BlockTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ConfigureUnitComboBox.Items.Clear();
            string[] simple = new string[] { "GT 1" };
            string[] OneOneSingleShaft = new string[] { "GT 1" };
            string[] OneOneMultipleShaft = new string[] { "GT 1", "ST 1" };
            string[] TwoOne = new string[] { "GT 1", "GT 2", "ST 1" };
            string[] ThreeOne = new string[] { "GT 1", "GT 2", "GT 3", "ST 1" };
            //Form1 f = new Form1();
            //MessageBox.Show(f.WizardTree.Nodes[0].Text);

            if ((string)BlockTypeComboBox.SelectedItem == "Simple")
            {
                ConfigureUnitComboBox.Items.AddRange(simple);

            }
            else if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Single Shaft")
            {
                ConfigureUnitComboBox.Items.AddRange(OneOneSingleShaft);
            }
            else if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Dual Shaft")
            {
                ConfigureUnitComboBox.Items.AddRange(OneOneMultipleShaft);
            }
            else if ((string)BlockTypeComboBox.SelectedItem == "2 x 1")
            {
                ConfigureUnitComboBox.Items.AddRange(TwoOne);
            }
            else if ((string)BlockTypeComboBox.SelectedItem == "3 x 1")
            {
                ConfigureUnitComboBox.Items.AddRange(ThreeOne);
            }

        }
        public void ConfigureUnitComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((string)BlockTypeComboBox.SelectedItem == "Simple")
            {
                if ((string)ConfigureUnitComboBox.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[4];
                    int len = r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);

                }
            }
            if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Single Shaft")
            {
                if ((string)ConfigureUnitComboBox.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[7];
                    int len = r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "HRSG";
                    dataGridView2.Rows[3].Cells[0].Value = "Steam Turbine";
                    dataGridView2.Rows[4].Cells[0].Value = "Condenser";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[5].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[6].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
            }
            if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Dual Shaft")
            {
                if ((string)ConfigureUnitComboBox.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[5];
                    int len = r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "HRSG";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);

                }
                else if ((string)ConfigureUnitComboBox.SelectedItem == "ST 1")
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
                    //this.populateType(r.Length);

                }
            }
            if ((string)BlockTypeComboBox.SelectedItem == "2 x 1")
            {
                if ((string)ConfigureUnitComboBox.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[5];
                    int len = r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "HRSG";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitComboBox.SelectedItem == "GT 2")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[5];
                    int len = r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "HRSG";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(r.Length);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitComboBox.SelectedItem == "ST 1")
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
                    //this.populateType(r.Length);
                }

            }
            if ((string)BlockTypeComboBox.SelectedItem == "3 x 1")
            {
                if ((string)ConfigureUnitComboBox.SelectedItem == "GT 1")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[5];
                    int len =r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "HRSG";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitComboBox.SelectedItem == "GT 2")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[5];
                    int len = r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "HRSG";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitComboBox.SelectedItem == "GT 3")
                {
                    dataGridView2.Rows.Clear();
                    DataRow[] r = new DataRow[5];
                    int len = r.Length;
                    for (int i = 0; i < r.Length; i++)
                    {
                        dataGridView2.Rows.Add(r[i]);
                    }
                    dataGridView2.Rows[0].Cells[0].Value = "Gas Turbine";
                    dataGridView2.Rows[1].Cells[0].Value = "Generator";
                    dataGridView2.Rows[2].Cells[0].Value = "HRSG";
                    if (InletAirCoolingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                    }
                    else
                    {
                        len--;
                    }
                    if (InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else
                    {
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitComboBox.SelectedItem == "ST 1")
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
                    //this.populateType(r.Length);
                }

            }
        }

        public void populateIcon(int rowCount)
        {
            Image gen = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\Gen.bmp");
            Image gt = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\GT.ico");
            Image hrsg = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\HRSG.bmp");
            Image st = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\ST.ico");
            Image ic = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\IC.jpg");
            Image cond = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\Cond.ico");
            Image ih = Image.FromFile("C:\\Users\\Abhijeet\\Documents\\Visual Studio 2015\\Projects\\WizardForecast\\WizardForecast\\IH.ico");
            for (int i = 0; i < rowCount; i++)

            {

                if (dataGridView2[0, i].Value.ToString() == "Gas Turbine")
                {
                    dataGridView2[1, i].Value = gt;

                }
                else if (dataGridView2[0, i].Value.ToString() == "Generator")
                {
                    dataGridView2[1, i].Value = gen;

                }
                else if (dataGridView2[0, i].Value.ToString() == "HRSG")
                {
                    dataGridView2[1, i].Value = hrsg;

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
                else if (dataGridView2[0, i].Value.ToString() == "Inlet Heating")
                {
                    dataGridView2[1, i].Value = ih;

                }
            }
        }


        //public void populateType(int rowCount)
        //{
        //    ObjectType.Items.Clear();
        //    for (int i = 0; i < rowCount; i++)

        //    {

        //        if (dataGridView2[0, i].Value.ToString() == "Gas Turbine")
        //        {
        //            DataGridViewComboBoxCell GTCell =
        //                    (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
        //            GTCell.DataSource = Enum.GetNames(typeof(GasTurbineType)).ToList();
        //            ObjectType.Items.Add(GTCell);


        //        }
        //        else if (dataGridView2[0, i].Value.ToString() == "Generator")
        //        {
        //            DataGridViewComboBoxCell GenCell =
        //                    (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
        //            GenCell.DataSource = Enum.GetNames(typeof(GeneratorType)).ToList();
        //            ObjectType.Items.Add(GenCell);


        //        }
        //        else if (dataGridView2[0, i].Value.ToString() == "HRSG")
        //        {
        //            DataGridViewComboBoxCell HRSGCell =
        //                    (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
        //            HRSGCell.DataSource = Enum.GetNames(typeof(HRSGType)).ToList();
        //            ObjectType.Items.Add(HRSGCell);


        //        }
        //        else if (dataGridView2[0, i].Value.ToString() == "Steam Turbine")
        //        {
        //            DataGridViewComboBoxCell STCell =
        //                    (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
        //            STCell.DataSource = Enum.GetNames(typeof(SteamTurbineType)).ToList();
        //            ObjectType.Items.Add(STCell);


        //        }
        //        else if (dataGridView2[0, i].Value.ToString() == "Inlet Cooling")
        //        {
        //            DataGridViewComboBoxCell ICCell =
        //                    (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
        //            ICCell.DataSource = Enum.GetNames(typeof(InletCoolingType)).ToList();
        //            ObjectType.Items.Add(ICCell);


        //        }
        //        else if (dataGridView2[0, i].Value.ToString() == "Condenser")
        //        {
        //            DataGridViewComboBoxCell CondCell =
        //                    (DataGridViewComboBoxCell)(dataGridView2.Rows[i].Cells[3]);
        //            CondCell.DataSource = Enum.GetNames(typeof(CondenserType)).ToList();
        //            ObjectType.Items.Add(CondCell);


        //        }
        //    }

        //}

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            try
            {

                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Gas Turbine")
                {
                    ConfigureGT confGT = new ConfigureGT(InletAirHeatingCheck, InletAirCoolingCheck, PeakFiringCheck, SteamInjectionCheck,
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.Show(this);
                }
                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Generator")
                {
                    ConfigureGenerator confGT = new ConfigureGenerator(
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.Show(this);

                }
                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "HRSG")
                {
                    ConfigureHRSG confGT = new ConfigureHRSG(DuctBurnersCheck,
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.Show(this);

                }
                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Steam Turbine")
                {
                    ConfigureST confGT = new ConfigureST(
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.Show(this);

                }
                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Inlet Cooling")
                {
                    ConfigureInletCooling confGT = new ConfigureInletCooling(
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.Show(this);

                }
                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Condenser")
                {
                    ConfigureCondenser confGT = new ConfigureCondenser(
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.Show(this);

                }
                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Inlet Cooling")
                {
                    ConfigureInletHeating confGT = new ConfigureInletHeating(
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.Show(this);

                }
            }
            catch
            {
                MessageBox.Show("Fill the Mandatory Fields");
            }
        }

        private void InletAirCooling_CheckedChanged(object sender, EventArgs e)
        {
            if (InletAirCooling.Checked)
            {
                InletAirCoolingCheck = true;
            }
        }

        private void InletAirHeating_CheckedChanged(object sender, EventArgs e)
        {
            if (InletAirHeating.Checked)
            {
                InletAirHeatingCheck = true;
            }
        }

        private void PeakFiring_CheckedChanged(object sender, EventArgs e)
        {
            if (PeakFiring.Checked)
            {
                PeakFiringCheck = true;
            }
        }

        private void SteamInjection_CheckedChanged(object sender, EventArgs e)
        {
            if (SteamInjection.Checked)
            {
                SteamInjectionCheck = true;
            }
        }

        private void DuctBurners_CheckedChanged(object sender, EventArgs e)
        {

            if (DuctBurners.Checked)
            {
                DuctBurnersCheck = true;
            }
        }

        private void Forecast_CheckedChanged(object sender, EventArgs e)
        {
            if (Forecast.Checked)
            {
                ForecastCheck = true;
            }
        }

        private void CompressorMap_CheckedChanged(object sender, EventArgs e)
        {
            if (CompressorMap.Checked)
            {
                CompressorMapCheck = true;
            }
        }

        private void TES_CheckedChanged(object sender, EventArgs e)
        {
            if (TES.Checked)
            {
                TESCheck = true;
            }
        }

        //private void BlockConfigure_Load(object sender, EventArgs e)
        //{

        //}
    }
}
