using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FWD;

namespace FWA
{
    
    public partial class Form1 : Form
    {
        FWDEntities db;
        SiteUC siteUserControl;
        BlockUC blockUserControl;
        //GasTurbineUC gasTurbineUserControl;
        GasTurbineUC gasTurbineUserControl;
        SteamTurbineUC steamTurbineUserControl;
        GeneratorUC generatorUserControl;
        HRSGUC HRSGUserControl;
        CondenserUC condenserUserControl;
        List<BlockUC> blockUserControlList = new List<BlockUC>();

        List<GasTurbineUC> gasTurbineUserControlList = new List<GasTurbineUC>();
        

        GroupBox ForecastTypeGroupBox;
        GroupBox AmbientAirGroupBox = new GroupBox();
        GroupBox CompressedInletAirGroupBox = new GroupBox();
        GroupBox CompressorGroupBox = new GroupBox();
        GroupBox CombusterShellGroupBox = new GroupBox();
        GroupBox FuelGasGroupBox = new GroupBox();
        GroupBox TurbineGroupBox = new GroupBox();
        GroupBox NormalizedLoadGroupBox = new GroupBox();
        GroupBox SteamPowerAugmentationGroupBox = new GroupBox();
        public static int blockCount; 
        public Form1()
        {
            InitializeComponent();
            siteUserControl = new SiteUC();
            blockUserControl = new BlockUC();
            gasTurbineUserControl = new GasTurbineUC();
            steamTurbineUserControl = new SteamTurbineUC();
            generatorUserControl = new GeneratorUC();
            HRSGUserControl = new HRSGUC();
            condenserUserControl = new CondenserUC();

            //Place the Forecast Type GroupBox at a particular location.. Like after the
            
         
            /////For Other Tags///////////////////////////////////////////////////////////////////////////

            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(siteUserControl);
            splitContainer1.Panel2.VerticalScroll.Enabled = true;
            //splitContainer1.Panel2.HorizontalScroll.Enabled = false;
            //siteUserControl.Dock = DockStyle.None;
            treeView1.ContextMenuStrip = ContextMenu;
            siteUserControl.ButtonClick+= new EventHandler(UserControl_ButtonClick);
        }

        protected void PopulateGTTags(GasTurbineUC gasTurbineUserControl)
        {
            //Place AmbientAirGroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            AmbientAirGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AmbientAirGroupBox.Text = "Ambient Air Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(AmbientAirGroupBox);
            AmbientAirGroupBox.Location = new Point(20, 20);
            TagCollectorUC[] AmbientAirTag = new TagCollectorUC[4];
            for (int i = 0; i < AmbientAirTag.Length; i++)
            {
                AmbientAirTag[i] = new TagCollectorUC();
            }
            AmbientAirTag[0].VariableName.Text = "Temperature (Dry Bulb)";
            AmbientAirTag[1].VariableName.Text = "Temperature (Wet Bulb)";
            AmbientAirTag[2].VariableName.Text = "Relative Humidity";
            AmbientAirTag[3].VariableName.Text = "Ambient Pressure";
            for (int i = 0; i < AmbientAirTag.Length; i++)
            {
                AmbientAirGroupBox.Controls.Add(AmbientAirTag[i]);
                if (i == 0)
                {
                    AmbientAirTag[i].Location = new Point(20, 20);
                }
                else
                {
                    AmbientAirTag[i].Location = new Point(20, AmbientAirTag[i - 1].Bottom);
                }
                AmbientAirTag[i].TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);
            }
            //Place Compressed Inlet Air GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            CompressedInletAirGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CompressedInletAirGroupBox.Text = "Compressed Inlet Air Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(CompressedInletAirGroupBox);
            CompressedInletAirGroupBox.Location = new Point(20, AmbientAirGroupBox.Bottom);
            TagCollectorUC[] CompressedInletAirTag = new TagCollectorUC[3];
            for (int i = 0; i < CompressedInletAirTag.Length; i++)
            {
                CompressedInletAirTag[i] = new TagCollectorUC();
            }
            CompressedInletAirTag[0].VariableName.Text = "Temperature";
            CompressedInletAirTag[1].VariableName.Text = "Specific Humidity";
            CompressedInletAirTag[2].VariableName.Text = "Differential Pressure";

            for (int i = 0; i < CompressedInletAirTag.Length; i++)
            {
                CompressedInletAirGroupBox.Controls.Add(CompressedInletAirTag[i]);
                if (i == 0)
                {
                    CompressedInletAirTag[i].Location = new Point(20, 20);
                }
                else
                {
                    CompressedInletAirTag[i].Location = new Point(20, CompressedInletAirTag[i - 1].Bottom);
                }
                CompressedInletAirTag[i].TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);
            }


            //Compressor GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            CompressorGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CompressorGroupBox.Text = "Compressor Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(CompressorGroupBox);
            CompressorGroupBox.Location = new Point(20, CompressedInletAirGroupBox.Bottom);
            TagCollectorUC CompressorTag = new TagCollectorUC();
            CompressorTag.VariableName.Text = "Inlet Guide Vane Angle";
            CompressorGroupBox.Controls.Add(CompressorTag);
            CompressorTag.Location = new Point(20, 20);
            CompressorTag.TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);

            //Place Combustor shell..Similarly we need to do for other tags
            CombusterShellGroupBox.AutoSize = true;
            CombusterShellGroupBox.Text = "Combustor Shell Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(CombusterShellGroupBox);
            CombusterShellGroupBox.Location = new Point(20, CompressorGroupBox.Bottom);
            TagCollectorUC[] CombusterShellTag = new TagCollectorUC[2];
            for (int i = 0; i < CombusterShellTag.Length; i++)
            {
                CombusterShellTag[i] = new TagCollectorUC();
            }
            CombusterShellTag[0].VariableName.Text = "Pressure";
            CombusterShellTag[1].VariableName.Text = "Temperature";

            for (int i = 0; i < CombusterShellTag.Length; i++)
            {
                CombusterShellGroupBox.Controls.Add(CombusterShellTag[i]);
                if (i == 0)
                {
                    CombusterShellTag[i].Location = new Point(20, 20);
                }
                else
                {
                    CombusterShellTag[i].Location = new Point(20, CombusterShellTag[i - 1].Bottom);
                }
                CombusterShellTag[i].TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);
            }

            //FuelGas GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            FuelGasGroupBox.AutoSize = true;
            FuelGasGroupBox.Text = "Fuel Gas Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(FuelGasGroupBox);
            FuelGasGroupBox.Location = new Point(20, CombusterShellGroupBox.Bottom);
            TagCollectorUC FuelGasTag = new TagCollectorUC();
            FuelGasTag.VariableName.Text = "Energy Input Rate";
            FuelGasGroupBox.Controls.Add(FuelGasTag);
            FuelGasTag.Location = new Point(20, 20);
            FuelGasTag.TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);


            //Place TurbineGroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags

            TurbineGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TurbineGroupBox.Text = "Turbine Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(TurbineGroupBox);
            TurbineGroupBox.Location = new Point(20, FuelGasGroupBox.Bottom);
            TagCollectorUC[] TurbineTag = new TagCollectorUC[4];
            for (int i = 0; i < TurbineTag.Length; i++)
            {
                TurbineTag[i] = new TagCollectorUC();
            }
            TurbineTag[0].VariableName.Text = "Temp Control Flag";
            TurbineTag[1].VariableName.Text = "Blade Path Temp";
            TurbineTag[2].VariableName.Text = "Exhaust Gas Temp";
            TurbineTag[3].VariableName.Text = "Exhaust Gas Diff Press";
            for (int i = 0; i < TurbineTag.Length; i++)
            {
                TurbineGroupBox.Controls.Add(TurbineTag[i]);
                if (i == 0)
                {
                    TurbineTag[i].Location = new Point(20, 20);
                }
                else
                {
                    TurbineTag[i].Location = new Point(20, TurbineTag[i - 1].Bottom);
                }
                TurbineTag[i].TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);
            }

            //NormalizedLoad GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            NormalizedLoadGroupBox.AutoSize = true;
            NormalizedLoadGroupBox.Text = "Normalized Load Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(NormalizedLoadGroupBox);
            NormalizedLoadGroupBox.Location = new Point(20, TurbineGroupBox.Bottom);
            TagCollectorUC NormalizedLoadTag = new TagCollectorUC();
            NormalizedLoadTag.VariableName.Text = "Normalized Load";
            NormalizedLoadGroupBox.Controls.Add(NormalizedLoadTag);
            NormalizedLoadTag.Location = new Point(20, 20);
            NormalizedLoadTag.TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);



            //Place SteamPowerAugmentationGroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags

            SteamPowerAugmentationGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SteamPowerAugmentationGroupBox.Text = "Steam Power Augmentation Tags";
            gasTurbineUserControl.GasTurbineTagsGroupBox.Controls.Add(SteamPowerAugmentationGroupBox);
            SteamPowerAugmentationGroupBox.Location = new Point(20, NormalizedLoadGroupBox.Bottom);
            TagCollectorUC[] SteamPowerAugmentationTag = new TagCollectorUC[4];
            for (int i = 0; i < SteamPowerAugmentationTag.Length; i++)
            {
                SteamPowerAugmentationTag[i] = new TagCollectorUC();
            }
            SteamPowerAugmentationTag[0].VariableName.Text = "Isolator Valve Closed";
            SteamPowerAugmentationTag[1].VariableName.Text = "Steam Temperature";
            SteamPowerAugmentationTag[2].VariableName.Text = "Steam Pressure";
            SteamPowerAugmentationTag[3].VariableName.Text = "Steam Mass Flow Rate";
            for (int i = 0; i < SteamPowerAugmentationTag.Length; i++)
            {
                SteamPowerAugmentationGroupBox.Controls.Add(SteamPowerAugmentationTag[i]);
                if (i == 0)
                {
                    SteamPowerAugmentationTag[i].Location = new Point(20, 20);
                }
                else
                {
                    SteamPowerAugmentationTag[i].Location = new Point(20, SteamPowerAugmentationTag[i - 1].Bottom);
                }
                SteamPowerAugmentationTag[i].TagSelectButtonClicked += new EventHandler(TagSelectorButtonClicked);
            }
            SteamPowerAugmentationGroupBox.Enabled = false;
        }
        protected void TagSelectorButtonClicked(object sender,EventArgs e)
        {
            TagSelectionForm form = new TagSelectionForm();
            form.Show();
        }
        protected void SteamPowerAugDBChecked(object sender,EventArgs e, BlockUC blockUserControl,GroupBox ForecastTypeGroupBox)
        {
            this.populateForecastTypeSPADB(blockUserControl,ForecastTypeGroupBox);
        }
        protected void SteamPowerAugChecked(object sender,EventArgs e,BlockUC blockUserControl, GroupBox ForecastTypeGroupBox)
        {
            blockUserControl.SteamPowerAugDBCheckBox.Enabled = true;
            this.populateForecastTypeSPA(blockUserControl, ForecastTypeGroupBox);
            if (blockUserControl.SteamPowerAugCheckBox.Checked)
            { this.SteamPowerAugmentationGroupBox.Enabled = true; }
            else { this.SteamPowerAugmentationGroupBox.Enabled = false; }
            
        }
        protected void DuctBurnerChecked(object sender, EventArgs e,BlockUC blockUserControl, GroupBox ForecastTypeGroupBox)
            {
            
            this.populateForecastTypeDB(blockUserControl,ForecastTypeGroupBox);
            }
        protected void UserControl_ButtonClick(object sender, EventArgs e)
        {
            //handle the event 
            if (treeView1.SelectedNode.Name == "Root")
            {
                treeView1.SelectedNode.Text = siteUserControl.textBoxShortName.Text;
                using (var db = new FWDEntities())
                {
                    var name = siteUserControl.textBoxLongName.Text;
                    var acronym = siteUserControl.textBoxShortName.Text;

                    var latitude = float.Parse(siteUserControl.textBoxLatitude.Text);
                    var longitude = float.Parse(siteUserControl.textBoxLongitude.Text);
                    var elevation = float.Parse(siteUserControl.textBoxElevation.Text);

                    //bool useMetric = UseMetricUnitsCheckBox.Checked;
                    var Site = new Site
                    {
                        Acronym = acronym,
                        Name = name,

                        Latitude = latitude,
                        Longitude = longitude,
                        Elevation = elevation

                        //UseMetricUnits = useMetric
                    };
                    db.Sites.Add(Site);
                    db.SaveChanges();

                }
            }
        }
        protected void UserControl_SelectedConfig(object sender, EventArgs e,BlockUC blockUserControl,GroupBox ForecastTypeGroupBox)
        {
            MessageBox.Show(treeView1.SelectedNode.Index.ToString());
            db = new FWDEntities();
            List<TrainMapping> TrainMappingLists = db.TrainMappings.ToList();
            treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Clear();
            //switch (this.blockUserControlList.ElementAt(treeView1.SelectedNode.Index).comboBoxConfig.SelectedIndex)
            switch (blockUserControl.comboBoxConfig.SelectedIndex)
            {
                case 0:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 1 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 1 select c).Max(c => c.SteamTurbineID);
                        //MessageBox.Show(GTCount.ToString());
                        for (int i = 0; i < GTCount; i++)
                        {
                            TreeNode GasTurbineNode = new TreeNode();
                            GasTurbineNode.Text = "GasTurbine" + (i + 1).ToString();
                            GasTurbineNode.Name = GasTurbineNode.Text;
                            treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(GasTurbineNode);
                            TreeNode GTGeneratorNode = new TreeNode("GT Generator");
                            TreeNode HRSGNode = new TreeNode("HRSG");
                            GasTurbineNode.Nodes.Add(GTGeneratorNode);
                            GasTurbineNode.Nodes.Add(HRSGNode);


                            //Create the Gas Turbine Control

                            gasTurbineUserControl = new GasTurbineUC();
                            this.gasTurbineUserControlList.Add(gasTurbineUserControl);

                        }
                        TreeNode SteamTurbineNode = new TreeNode();
                        SteamTurbineNode.Text = "SteamTurbine1";
                        SteamTurbineNode.Name = SteamTurbineNode.Text;
                        treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(SteamTurbineNode);
                        TreeNode STGeneratorNode = new TreeNode("ST Genertaor");
                        TreeNode CondenserNode = new TreeNode("Condenser");
                        SteamTurbineNode.Nodes.Add(STGeneratorNode);
                        SteamTurbineNode.Nodes.Add(CondenserNode);
                        break;
                    }
                case 1:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 2 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 2 select c).Max(c => c.SteamTurbineID);
                        //MessageBox.Show(GTCount.ToString());
                        for (int i = 0; i < GTCount; i++)
                        {
                            TreeNode GasTurbineNode = new TreeNode();
                            GasTurbineNode.Text = "GasTurbine" + (i + 1).ToString();
                            GasTurbineNode.Name = GasTurbineNode.Text;
                            treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(GasTurbineNode);
                            TreeNode GTGeneratorNode = new TreeNode("GT Generator");
                            TreeNode HRSGNode = new TreeNode("HRSG");
                            GasTurbineNode.Nodes.Add(GTGeneratorNode);
                            GasTurbineNode.Nodes.Add(HRSGNode);
                            gasTurbineUserControl = new GasTurbineUC();
                            this.gasTurbineUserControlList.Add(gasTurbineUserControl);
                        }
                        TreeNode SteamTurbineNode = new TreeNode();
                        SteamTurbineNode.Text = "SteamTurbine1";
                        SteamTurbineNode.Name = SteamTurbineNode.Text;
                        treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(SteamTurbineNode);
                        TreeNode STGeneratorNode = new TreeNode("ST Genertaor");
                        TreeNode CondenserNode = new TreeNode("Condenser");
                        SteamTurbineNode.Nodes.Add(STGeneratorNode);
                        SteamTurbineNode.Nodes.Add(CondenserNode);
                        break;
                    }
                case 2:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 3 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 3 select c).Max(c => c.SteamTurbineID);
                        //MessageBox.Show(GTCount.ToString());
                        for (int i = 0; i < GTCount; i++)
                        {
                            TreeNode GasTurbineNode = new TreeNode();
                            GasTurbineNode.Text = "GasTurbine" + (i + 1).ToString();
                            GasTurbineNode.Name = GasTurbineNode.Text;
                            treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(GasTurbineNode);
                            TreeNode GTGeneratorNode = new TreeNode("GT Generator");
                            TreeNode HRSGNode = new TreeNode("HRSG");
                            GasTurbineNode.Nodes.Add(GTGeneratorNode);
                            GasTurbineNode.Nodes.Add(HRSGNode);
                            gasTurbineUserControl = new GasTurbineUC();
                            this.gasTurbineUserControlList.Add(gasTurbineUserControl);
                        }
                        TreeNode SteamTurbineNode = new TreeNode();
                        SteamTurbineNode.Text = "SteamTurbine1";
                        SteamTurbineNode.Name = SteamTurbineNode.Text;
                        treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(SteamTurbineNode);
                        TreeNode STGeneratorNode = new TreeNode("ST Genertaor");
                        TreeNode CondenserNode = new TreeNode("Condenser");
                        SteamTurbineNode.Nodes.Add(STGeneratorNode);
                        SteamTurbineNode.Nodes.Add(CondenserNode);
                        break;
                    }
                case 3:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 4 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 4 select c).Max(c => c.SteamTurbineID);
                        //MessageBox.Show(GTCount.ToString());
                        for (int i = 0; i < GTCount; i++)
                        {
                            TreeNode GasTurbineNode = new TreeNode();
                            GasTurbineNode.Text = "GasTurbine" + (i + 1).ToString();
                            GasTurbineNode.Name = GasTurbineNode.Text;
                            treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(GasTurbineNode);
                            TreeNode GTGeneratorNode = new TreeNode("GT Generator");
                            TreeNode HRSGNode = new TreeNode("HRSG");
                            GasTurbineNode.Nodes.Add(GTGeneratorNode);
                            GasTurbineNode.Nodes.Add(HRSGNode);

                            gasTurbineUserControl = new GasTurbineUC();
                            this.gasTurbineUserControlList.Add(gasTurbineUserControl);
                        }
                        TreeNode SteamTurbineNode = new TreeNode();
                        SteamTurbineNode.Text = "SteamTurbine1";
                        SteamTurbineNode.Name = SteamTurbineNode.Text;
                        treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(SteamTurbineNode);
                        TreeNode STGeneratorNode = new TreeNode("ST Genertaor");
                        TreeNode CondenserNode = new TreeNode("Condenser");
                        SteamTurbineNode.Nodes.Add(STGeneratorNode);
                        SteamTurbineNode.Nodes.Add(CondenserNode);
                        break;
                    }
                case 4:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 5 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 5 select c).Max(c => c.SteamTurbineID);
                        //MessageBox.Show(GTCount.ToString());
                        for (int i = 0; i < GTCount; i++)
                        {
                            TreeNode GasTurbineNode = new TreeNode();
                            GasTurbineNode.Text = "GasTurbine" + (i + 1).ToString();
                            GasTurbineNode.Name = GasTurbineNode.Text;
                            treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(GasTurbineNode);
                            TreeNode GTGeneratorNode = new TreeNode("GT Generator");
                            TreeNode HRSGNode = new TreeNode("HRSG");
                            GasTurbineNode.Nodes.Add(GTGeneratorNode);
                            GasTurbineNode.Nodes.Add(HRSGNode);
                            gasTurbineUserControl = new GasTurbineUC();
                            this.gasTurbineUserControlList.Add(gasTurbineUserControl);
                        }
                        TreeNode SteamTurbineNode = new TreeNode();
                        SteamTurbineNode.Text = "SteamTurbine1";
                        SteamTurbineNode.Name = SteamTurbineNode.Text;
                        treeView1.Nodes[0].Nodes[blockCount - 1].Nodes.Add(SteamTurbineNode);
                        TreeNode STGeneratorNode = new TreeNode("ST Genertaor");
                        TreeNode CondenserNode = new TreeNode("Condenser");
                        SteamTurbineNode.Nodes.Add(STGeneratorNode);
                        SteamTurbineNode.Nodes.Add(CondenserNode);
                        break;
                    }
            }
           

            this.PopulateForecastType(blockUserControl,ForecastTypeGroupBox);
        }
        private void PopulateForecastType(BlockUC blockUserControl, GroupBox ForecastTypeGroupBox)
        {
            

            switch (blockUserControl.comboBoxConfig.SelectedIndex)
            {
                case 0:
                    {
                        ForecastTypeUC f1 = new ForecastTypeUC();
                        f1.ForecastTypeCheckBox.Text = "Base Load";
                        ForecastTypeGroupBox.Controls.Add(f1);
                        f1.Location = new Point(20, 20);
                        blockUserControl.Controls.Add(ForecastTypeGroupBox);

                        
                        //if (this.blockUserControl.DuctBurnerCheckBox.Checked == true &&
                        //    this.blockUserControl.SteamPowerAugCheckBox.Checked == true &&
                        //        this.blockUserControl.SteamPowerAugDBCheckBox.Checked == true)
                        //{
                        //    ForecastTypeUC f3 = new ForecastTypeUC();
                        //    f3.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                        //    this.blockUserControl.BlockForecastGroup.Controls.Add(f3);
                        //}
                        //if(
                        //    this.blockUserControl.SteamPowerAugCheckBox.Checked == true &&
                        //        this.blockUserControl.SteamPowerAugDBCheckBox.Checked == false)
                        //{
                        //    ForecastTypeUC f4 = new ForecastTypeUC();
                        //    f4.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Steam Power Augmentation";
                        //    this.blockUserControl.BlockForecastGroup.Controls.Add(f4);
                        //}
                        break;
                    }
                case 1:
                    {
                        ForecastTypeUC f1 = new ForecastTypeUC();
                        f1.ForecastTypeCheckBox.Text = "1x1 Base Load";
                        ForecastTypeGroupBox.Controls.Add(f1);
                        f1.Location = new Point(20, 20);
                        blockUserControl.Controls.Add(ForecastTypeGroupBox);
                        break;
                    }
                case 2:
                    {
                        ForecastTypeUC f1 = new ForecastTypeUC();
                        f1.ForecastTypeCheckBox.Text = "1x1 Base Load";
                        ForecastTypeGroupBox.Controls.Add(f1);
                        f1.Location = new Point(20, 20);
                        blockUserControl.Controls.Add(ForecastTypeGroupBox);
                        break;
                    }
                case 3:
                    {
                        ForecastTypeUC f1 = new ForecastTypeUC();
                        f1.ForecastTypeCheckBox.Text = "1x1 Base Load";
                        ForecastTypeGroupBox.Controls.Add(f1);
                        f1.Location = new Point(20, 20);
                        

                        ForecastTypeUC f2 = new ForecastTypeUC();
                        f2.ForecastTypeCheckBox.Text = "2x1 Base Load";
                        ForecastTypeGroupBox.Controls.Add(f2);
                        f2.Location = new Point(20, 50);
                        blockUserControl.Controls.Add(ForecastTypeGroupBox);
                        break;
                    }
                case 4:
                    {
                        ForecastTypeUC f1 = new ForecastTypeUC();
                        f1.ForecastTypeCheckBox.Text = "1x1 Base Load";
                        ForecastTypeGroupBox.Controls.Add(f1);
                        f1.Location = new Point(20, 20);

                        ForecastTypeUC f2 = new ForecastTypeUC();
                        f2.ForecastTypeCheckBox.Text = "2x1 Base Load";
                        ForecastTypeGroupBox.Controls.Add(f2);
                        f2.Location = new Point(20, 50);

                        ForecastTypeUC f3 = new ForecastTypeUC();
                        f3.ForecastTypeCheckBox.Text = "3x1 Base Load";
                        ForecastTypeGroupBox.Controls.Add(f3);
                        f3.Location = new Point(20, 80);
                        blockUserControl.Controls.Add(ForecastTypeGroupBox);
                        break;
                    }
            }
            
        }
        private void populateForecastTypeDB(BlockUC blockUserControl, GroupBox ForecastTypeGroupBox)
        {
            //MessageBox.Show(blockCount.ToString());

            switch (blockUserControl.comboBoxConfig.SelectedIndex)
            {
                case 0:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 50);
                        }
                        break;
                    }
                case 1:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 50);
                        }
                        break;
                    }
                case 2:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 50);
                        }
                        break;
                    }
                case 3:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 80);

                            ForecastTypeUC f3 = new ForecastTypeUC();
                            f3.ForecastTypeCheckBox.Text = "2x1 Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f3);
                            f3.Location = new Point(20, 110);
                        }
                        break;
                    }
                case 4:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 110);

                            ForecastTypeUC f3 = new ForecastTypeUC();
                            f3.ForecastTypeCheckBox.Text = "2x1 Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f3);
                            f3.Location = new Point(20, 140);

                            ForecastTypeUC f4 = new ForecastTypeUC();
                            f4.ForecastTypeCheckBox.Text = "3x1 Base Load + Max Duct Burners";
                            ForecastTypeGroupBox.Controls.Add(f4);
                            f4.Location = new Point(20, 170);
                        }
                        break;
                    }
            }
        }
        private void populateForecastTypeSPA(BlockUC blockUserControl, GroupBox ForecastTypeGroupBox)
        {
            switch (blockUserControl.comboBoxConfig.SelectedIndex)
            {
                case 0:
                    {
                        if (blockUserControl.SteamPowerAugCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 80);
                        }
                        break;
                    }
                case 1:
                    {
                        if (blockUserControl.SteamPowerAugCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 80);
                        }
                        break;
                    }
                case 2:
                    {
                        if (blockUserControl.SteamPowerAugCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 80);
                        }
                        break;
                    }
                case 3:
                    {
                        if (blockUserControl.SteamPowerAugCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 140);

                            ForecastTypeUC f3 = new ForecastTypeUC();
                            f3.ForecastTypeCheckBox.Text = "2x1 Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f3);
                            f3.Location = new Point(20, 170);
                        }
                        break;
                    }
                case 4:
                    {
                        if (blockUserControl.SteamPowerAugCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 200);

                            ForecastTypeUC f3 = new ForecastTypeUC();
                            f3.ForecastTypeCheckBox.Text = "2x1 Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f3);
                            f3.Location = new Point(20, 230);

                            ForecastTypeUC f4 = new ForecastTypeUC();
                            f4.ForecastTypeCheckBox.Text = "3x1 Base Load + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f4);
                            f4.Location = new Point(20, 260);
                        }
                        break;
                    }
            }
        }
        private void populateForecastTypeSPADB(BlockUC blockUserControl, GroupBox ForecastTypeGroupBox)
        {
            switch (blockUserControl.comboBoxConfig.SelectedIndex)
            {
                case 0:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 110);
                        }
                        break;
                    }
                case 1:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 110);
                        }
                        break;
                    }
                case 2:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 110);
                        }
                        break;
                    }
                case 3:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 200);

                            ForecastTypeUC f3 = new ForecastTypeUC();
                            f3.ForecastTypeCheckBox.Text = "2x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f3);
                            f3.Location = new Point(20, 230);
                        }
                        break;
                    }
                case 4:
                    {
                        if (blockUserControl.DuctBurnerCheckBox.Checked == true)
                        {
                            //MessageBox.Show(this.blockUserControl.comboBoxConfig.SelectedIndex.ToString());
                            ForecastTypeUC f2 = new ForecastTypeUC();
                            f2.ForecastTypeCheckBox.Text = "1x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f2);
                            f2.Location = new Point(20, 290);

                            ForecastTypeUC f3 = new ForecastTypeUC();
                            f3.ForecastTypeCheckBox.Text = "2x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f3);
                            f3.Location = new Point(20, 320);

                            ForecastTypeUC f4 = new ForecastTypeUC();
                            f4.ForecastTypeCheckBox.Text = "3x1 Base Load + Max Duct Burners + Max Steam Power Augmentation";
                            ForecastTypeGroupBox.Controls.Add(f4);
                            f4.Location = new Point(20, 350);
                        }
                        break;
                    }
            }
        }
        private void AddBlockMenu_Click(object sender, EventArgs e)
        {
            TreeNode BlockNode = new TreeNode("Block");
            treeView1.Nodes[0].Nodes.Add(BlockNode);
            BlockUC blockUserControl = new BlockUC();


            ForecastTypeGroupBox = new GroupBox();
            //this.ForecastTypeGroupBox.Controls.Clear();
            ForecastTypeGroupBox.AutoSize = true;
            ForecastTypeGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ForecastTypeGroupBox.Text = "Base Load Net MW and Heat Rate Forecasts";
            blockUserControl.Controls.Add(ForecastTypeGroupBox);
            ForecastTypeGroupBox.Location = new Point(30, 420);

            //UserControl_SelectedConfig
            blockUserControl.ConfigComboSelected += new EventHandler((sender1, e1) => UserControl_SelectedConfig(sender1, e1, blockUserControl, ForecastTypeGroupBox));
            //blockUserControl.DuctBurnerCheckBoxChecked += new EventHandler(DuctBurnerChecked);
            blockUserControl.DuctBurnerCheckBoxChecked += new EventHandler((sender1,e1)=>DuctBurnerChecked(sender1,e1,blockUserControl, ForecastTypeGroupBox));
            blockUserControl.SteamPowerAugCheckBoxChecked += new EventHandler((sender1, e1) => SteamPowerAugChecked(sender1, e1, blockUserControl, ForecastTypeGroupBox));
            blockUserControl.SteamPowerAugDBCheckBoxChecked += new EventHandler((sender1, e1) => SteamPowerAugDBChecked(sender1, e1, blockUserControl, ForecastTypeGroupBox));
            this.blockUserControlList.Add(blockUserControl);
            blockCount++;

            
        }
        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            //MessageBox.Show(e.Node.Text.Substring(0,3));
            if (e.Node.Name == "Root")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(siteUserControl);

            }
            else if (e.Node.Parent.Name == "Root")
            {
                splitContainer1.Panel2.Controls.Clear();
                foreach (var id in this.blockUserControlList)
                {
                    if (id.storesCount == e.Node.Index + 2)
                    {
                        splitContainer1.Panel2.Controls.Add(id);
                    }
                }
            }
            else if(e.Node.Text.Substring(0,3) == "Gas")
            {
                splitContainer1.Panel2.Controls.Clear();
                //splitContainer1.Panel2.Controls.Add(gasTurbineUserControl);
                foreach (var id in this.gasTurbineUserControlList)
                {
                    //MessageBox.Show(id.storesCount.ToString());
                    if (id.storesCount == e.Node.Index + 2)
                    {
                        splitContainer1.Panel2.Controls.Add(id);
                        PopulateGTTags(id);
                    }
                }
            }
            else if (e.Node.Text.Substring(0, 3) == "Ste")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(steamTurbineUserControl);
            }
            else if (e.Node.Text.Substring(0, 3) == "ST " || e.Node.Text.Substring(0, 3) == "GT ")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(generatorUserControl);
            }
            else if (e.Node.Text.Substring(0, 4) == "HRSG")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(HRSGUserControl);
            }
            else if (e.Node.Text.Substring(0, 4) == "Cond")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(condenserUserControl);
            }
        }
        /*
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "Root")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(siteUserControl);

            }
            else if (e.Node.Parent.Name == "Root")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(blockUserControl);
            }
            else if (e.Node.Text.Substring(0, 3) == "Gas")
            {
                splitContainer1.Panel2.Controls.Clear();
                //gasTurbineUserControl.Dock = DockStyle.Fill;
                foreach (var id in this.gasTurbineUserControlList)
                {
                    if (id.storesCount == e.Node.Index + 2)
                    {
                        splitContainer1.Panel2.Controls.Add(id);
                        PopulateGTTags(id);
                    }
                }
                    
            }
            else if (e.Node.Text.Substring(0, 3) == "Ste")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(steamTurbineUserControl);
            }
            else if (e.Node.Text.Substring(3, 3) == "Gen")
            {
                splitContainer1.Panel2.Controls.Clear();
                
                splitContainer1.Panel2.Controls.Add(generatorUserControl);
            }
            else if (e.Node.Text.Substring(0, 4) == "HRSG")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(HRSGUserControl);
            }
            else if (e.Node.Text.Substring(0, 4) == "Cond")
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(condenserUserControl);
            }
        }
        */
    }
}
