using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewExpt
{
    public partial class Form1 : Form
    {
        public static int NewSiteCount = 0;
        public static int NewBlockClickCount=0;
        public static bool InletAirCoolingCheck = false;
        public static bool InletAirHeatingCheck = false;
        public static bool PeakFiringCheck = false;
        public static bool SteamInjectionCheck = false;
        public static bool DuctBurnersCheck = false;
        public static bool ForecastCheck = false;
        public static bool LowLoadForecastCheck = false;
        public static bool CompressorMapCheck = false;
        public static bool TESCheck = false;
        //TreeNode mySelectedNode = new TreeNode();
        //treeView1.SelectedNode = mySelectedNode;
        //public int GasTurbineTypeSelectedIndex;
        public Form1()
        {
            InitializeComponent();
            //this.comboBox2.SelectedIndexChanged +=
            //new System.EventHandler(comboBox2_SelectedIndexChanged);
            GasTurbineTypeComboBox.DataSource = Enum.GetNames(typeof(GTType)).ToList();
            //UnitAliasTextBox.Text = "abhijeet";
            
        }

        private void BlockTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigureUnitsComboBox.Items.Clear();
            string[] simple = new string[] { "GT 1" };
            string[] OneOneSingleShaft = new string[] { "GT 1" };
            string[] OneOneMultipleShaft = new string[] { "GT 1", "ST 1" };
            string[] TwoOne = new string[] { "GT 1", "GT 2", "ST 1" };
            string[] ThreeOne = new string[] { "GT 1", "GT 2", "GT 3", "ST 1" };

            if ((string)BlockTypeComboBox.SelectedItem == "Simple")
            {
                ConfigureUnitsComboBox.Items.AddRange(simple);
                
                
            }
            else if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Single Shaft")
            {
                ConfigureUnitsComboBox.Items.AddRange(OneOneSingleShaft);
                
                
            }
            else if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Dual Shaft")
            {
                ConfigureUnitsComboBox.Items.AddRange(OneOneMultipleShaft);
                
                   
                
            }
            else if ((string)BlockTypeComboBox.SelectedItem == "2 x 1")
            {
                ConfigureUnitsComboBox.Items.AddRange(TwoOne);
                
                   
                
            }
            else if ((string)BlockTypeComboBox.SelectedItem == "3 x 1")
            {
                ConfigureUnitsComboBox.Items.AddRange(ThreeOne);
                

                
            }
        }

        private void AddSiteButton_Click(object sender, EventArgs e)
        {
            if (SiteNameTextBox.Text != "" && BlockCountComboBox.SelectedIndex > -1 && GasTurbineTypeComboBox.SelectedIndex > -1)
            {
                //MessageBox.Show("Test");
                treeView1.Nodes[0].SelectedImageIndex = 2;
                //SitePage.ImageIndex = 2;
            }
            treeView1.Nodes[0].Nodes.Clear();
            treeView1.Nodes[0].Text = SiteNameTextBox.Text;
           
            tabControl1.SelectedIndex = 1;
            //NewBlockClickCount++;
            NewSiteCount++;
        }

        

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var BlockTag = e.Node.Tag;
            //if (BlockTag == null || !(BlockTag is Block)) return;
            if (BlockTag is Block)
            {
                e.Node.SelectedImageIndex = 0;
                var BlockObject = (Block)BlockTag;
                //MessageBox.Show(BlockObject.BlockType);
                tabControl1.TabPages[1].Text = e.Node.Text;
                BlockAliasTextBox.Text = BlockObject.Alias;
                BlockNameTextBox.Text = BlockObject.Name;
                foreach(var item in BlockTypeComboBox.Items)
                { if(string.Compare(item.ToString(),BlockObject.BlockType)==0)
                        BlockTypeComboBox.SelectedItem = item;
                }
                
                InletAirCooling.Checked = BlockObject.InletAirCoolingCheck;
                InletAirHeating.Checked = BlockObject.InletAirHeatingCheck;
                PeakFiring.Checked = BlockObject.PeakFiringCheck;
                SteamInjection.Checked = BlockObject.SteamInjectionCheck;
                LowLoadForecastCheckBox.Checked = BlockObject.LOLForecastCheck;
                Forecast.Checked = BlockObject.HOLForecastCheck;
                CompressorMap.Checked = BlockObject.CompressorMapCheck;
                TES.Checked = BlockObject.TESCheck;
                foreach (var item in ConfigureUnitsComboBox.Items)
                {
                    if (string.Compare(item.ToString(), BlockObject.ConfigureUnitComboBox) == 0)
                        ConfigureUnitsComboBox.SelectedItem = item;
                }
                
            }
            //
            if(e.Node.Parent.Text=="Configure Units" || BlockTag is Train)
            {
                
                var UnitObject = (Train)BlockTag;
                e.Node.SelectedImageIndex = 0;
                //MessageBox.Show(UnitObject.BlockType);
                tabControl1.TabPages[1].Text = e.Node.Parent.Parent.Text;
                BlockAliasTextBox.Text = UnitObject.BlockAlias;
                BlockNameTextBox.Text = UnitObject.BlockName;
                foreach (var item in BlockTypeComboBox.Items)
                {
                    if (string.Compare(item.ToString(), UnitObject.BlockType) == 0)
                        BlockTypeComboBox.SelectedItem = item;
                }

                InletAirCooling.Checked = UnitObject.InletAirCoolingCheck;
                InletAirHeating.Checked = UnitObject.InletAirHeatingCheck;
                PeakFiring.Checked = UnitObject.PeakFiringCheck;
                SteamInjection.Checked = UnitObject.SteamInjectionCheck;
                LowLoadForecastCheckBox.Checked = UnitObject.LOLForecastCheck;
                Forecast.Checked = UnitObject.HOLForecastCheck;
                CompressorMap.Checked = UnitObject.CompressorMapCheck;
                TES.Checked = UnitObject.TESCheck;
                UnitAliasTextBox.Text = UnitObject.TrainAlias;
                ConfigureUnitsComboBox.SelectedIndex = e.Node.Index;
                
            }
           
            //if (e.Node.Text == "Variable")
            //{
            //    tabControl1.SelectedIndex = 2;
            //}
            //if (e.Node.Text == "Forecast")
            //{
            //    tabControl1.SelectedIndex = 3;
            //}
            //if (e.Node.Text == "Configure Units")
            //{
            //    tabControl1.SelectedIndex = 1;
            //}
        }

        private void AddBlockButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            

            TreeNode BlockNode = new TreeNode();
            BlockNode.Text = BlockAliasTextBox.Text;
            BlockNode.Tag = new Block
            {
                Alias = BlockAliasTextBox.Text,
                Name=BlockNameTextBox.Text,
                BlockType = BlockTypeComboBox.SelectedItem.ToString(),
                SiteID = (byte)NewSiteCount,
                InletAirCoolingCheck = InletAirCooling.Checked,
                InletAirHeatingCheck = InletAirHeating.Checked,
                PeakFiringCheck = PeakFiring.Checked,
                SteamInjectionCheck = SteamInjection.Checked,
                DuctBurnersCheck = DuctBurners.Checked,
                LOLForecastCheck = LowLoadForecastCheckBox.Checked,
                HOLForecastCheck = Forecast.Checked,
                CompressorMapCheck = CompressorMap.Checked,
                TESCheck = TES.Checked,
                ConfigureUnitComboBox = ConfigureUnitsComboBox.SelectedItem.ToString()
            };
            //MessageBox.Show(BlockTypeComboBox.SelectedItem.ToString());
            treeView1.Nodes[0].Nodes.Add(BlockNode);
            TreeNode ConfigureNode = new TreeNode();
            TreeNode ForecastNode = new TreeNode();
            TreeNode VariableNode = new TreeNode();
            ConfigureNode.Text = "Configure Units";
            ConfigureNode.Name = "Configure";
            VariableNode.Text = "Variable";
            VariableNode.Name = "Variable";
            ForecastNode.Text = "Forecast";
            ForecastNode.Name = "Forecast";
            BlockNode.Nodes.Add(ConfigureNode);
            BlockNode.Nodes.Add(VariableNode);
            BlockNode.Nodes.Add(ForecastNode);
            treeView1.ExpandAll();

            for (int i = 0; i < ConfigureUnitsComboBox.Items.Count; i++)
            {
                TreeNode g = new TreeNode();
                g.Text = ConfigureUnitsComboBox.GetItemText(ConfigureUnitsComboBox.Items[i])+" ("+UnitAliasTextBox.Text+')';
                g.Tag = new Train
                {
                    BlockAlias = BlockAliasTextBox.Text,
                    BlockName = BlockNameTextBox.Text,
                    BlockType = BlockTypeComboBox.SelectedItem.ToString(),
                    SiteID = (byte)NewSiteCount,
                    InletAirCoolingCheck = InletAirCooling.Checked,
                    InletAirHeatingCheck = InletAirHeating.Checked,
                    PeakFiringCheck = PeakFiring.Checked,
                    SteamInjectionCheck = SteamInjection.Checked,
                    DuctBurnersCheck = DuctBurners.Checked,
                    LOLForecastCheck = LowLoadForecastCheckBox.Checked,
                    HOLForecastCheck = Forecast.Checked,
                    CompressorMapCheck = CompressorMap.Checked,
                    TESCheck = TES.Checked,
                    ConfigureUnitComboBox = ConfigureUnitsComboBox.SelectedItem.ToString(),
                    TrainAlias = UnitAliasTextBox.Text
                };

                ConfigureNode.Nodes.Add(g);
            }
            //reset all the content of the tabPage
            dataGridView2.Rows.Clear();
            BlockAliasTextBox.Clear();
            BlockNameTextBox.Clear();
            InletAirCooling.Checked = false;
            InletAirHeating.Checked = false;
            PeakFiring.Checked = false;
            SteamInjection.Checked = false;
            DuctBurners.Checked = false;
            Forecast.Checked = false;
            LowLoadForecastCheckBox.Checked = false;
            CompressorMap.Checked = false;
            TES.Checked = false;
            ConfigureUnitsComboBox.SelectedIndex = -1;
            BlockTypeComboBox.SelectedIndex = -1;

            NewBlockClickCount++;
            //MessageBox.Show(NewBlockClickCount.ToString());
            
            
        }

        private void SiteSaveButton_Click(object sender, EventArgs e)
        {
            
            using (var db = new RealTimePowerContext())
            {
                var name = SiteNameTextBox.Text;
                var acronym = SiteAcronymTextBox.Text;
                var location = SiteLocationTextBox.Text;
                var latitude = float.Parse(SiteLatitudeTextBox.Text);
                var longitude = float.Parse(SiteLongitudeTextBox.Text);
                var elevation = float.Parse(SiteElevationTextBox.Text);
                var timezone = TimezoneComboBox.SelectedText;
                //bool useMetric = UseMetricUnitsCheckBox.Checked;
                var Site = new Site
                {
                    Acronym = acronym,
                    Name = name,
                    Location = location,
                    Latitude = latitude,
                    Longitude = longitude,
                    Elevation = elevation,
                    Timezone = timezone
                    //UseMetricUnits = useMetric
                };
                db.Sites.Add(Site);
                db.SaveChanges();
                
            }
        }

        private void ConfigureUnitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)BlockTypeComboBox.SelectedItem == "Simple")
            {
                if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 1")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                    }
                    else if(InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[2].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[2].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);

                }
            }
            if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Single Shaft")
            {
                if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 1")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[5].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[6].Cells[0].Value = "Inlet Heating";
                    }
                    else if (InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[5].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[5].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
            }
            if ((string)BlockTypeComboBox.SelectedItem == "1 x 1 Dual Shaft")
            {
                if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 1")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else if (InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);

                }
                else if ((string)ConfigureUnitsComboBox.SelectedItem == "ST 1")
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
                if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 1")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else if (InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 2")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else if (InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitsComboBox.SelectedItem == "ST 1")
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
                if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 1")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else if (InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 2")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else if (InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitsComboBox.SelectedItem == "GT 3")
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
                    if (InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        dataGridView2.Rows[4].Cells[0].Value = "Inlet Heating";
                    }
                    else if (InletAirCoolingCheck && !InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Cooling";
                        len--;
                    }
                    else if (!InletAirCoolingCheck && InletAirHeatingCheck)
                    {
                        dataGridView2.Rows[3].Cells[0].Value = "Inlet Heating";
                        len--;
                    }
                    else
                    {
                        len--;
                        len--;
                    }
                    this.populateIcon(len);
                    //this.populateType(r.Length);
                }
                else if ((string)ConfigureUnitsComboBox.SelectedItem == "ST 1")
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            try
            {

                if (e.ColumnIndex == dataGridView2.Columns["ConfigureObject"].Index && dataGridView2[0, i].Value.ToString() == "Gas Turbine")
                {
                    ConfigureGT confGT = new ConfigureGT(InletAirHeatingCheck, InletAirCoolingCheck, PeakFiringCheck, SteamInjectionCheck,
                        BlockAliasTextBox.Text, dataGridView2[2, i].Value.ToString());
                    confGT.PopulateGasTurbineType(GasTurbineTypeComboBox.SelectedIndex);
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

        private void BlockAliasTextBox_TextChanged(object sender, EventArgs e)
        {
            //treeView1.Nodes[0].Nodes[NewBlockClickCount - 1].Text = BlockAliasTextBox.Text;
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (LowLoadForecastCheckBox.Checked)
            {
                LowLoadForecastCheck = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (TreeNode RootNode in treeView1.Nodes)
            {
                RootNode.ContextMenuStrip = contextMenuStrip1;
                foreach(TreeNode ChildNode in RootNode.Nodes)
                {
                    ChildNode.ContextMenuStrip = contextMenuStrip1;
                }
            }
        }

        private void SaveBlockButton_Click(object sender, EventArgs e)
        {
            if (BlockTypeComboBox.SelectedIndex>-1 && BlockAliasTextBox.Text!="")
            {
                //MessageBox.Show(treeView1.Nodes[0].Nodes["1"].Text.ToString());
                treeView1.Nodes[0].Nodes[NewBlockClickCount-1].ImageIndex = 0;
                //MessageBox.Show(treeView1.Nodes[0].Nodes["1"].ImageIndex.ToString());                    
            }
        }

        private void UnitAliasTextBox_TextChanged(object sender, EventArgs e)
        {
            //treeView1.Nodes[0].Nodes
            
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

            //if (mySelectedNode != null && mySelectedNode.Parent != null)
            //{
            //    treeView1.SelectedNode = mySelectedNode;
            //    treeView1.LabelEdit = true;
            //    if (!mySelectedNode.IsEditing)
            //    {
            //        mySelectedNode.BeginEdit();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No tree node selected or selected node is a root node.\n" +
            //       "Editing of root nodes is not allowed.", "Invalid selection");
            //}
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            //mySelectedNode = treeView1.GetNodeAt(e.X, e.Y);
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Label.Length > 0)
                {
                    if (e.Label.IndexOfAny(new char[] { '@', '.', ',', '!' }) == -1)
                    {
                        // Stop editing without canceling the label change.
                        e.Node.EndEdit(false);
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\n" +
                           "The invalid characters are: '@','.', ',', '!'",
                           "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    /* Cancel the label edit action, inform the user, and 
                       place the node in edit mode again. */
                    e.CancelEdit = true;
                    MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                       "Node Label Edit");
                    e.Node.BeginEdit();
                }
            }
        }
    }
}
