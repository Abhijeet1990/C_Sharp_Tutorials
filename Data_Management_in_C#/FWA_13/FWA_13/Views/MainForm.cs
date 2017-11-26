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
using FWA_13.Infrastructure;
using FWA_13.UserControls;
using static FWA_13.BlockUserControl;

namespace FWA_13
{
    public partial class MainForm : Form
    {
        ForecastAppDatabaseEntities db;
        SiteUserControl siteUserControl = new SiteUserControl();
        BlockUserControl blockUserControl = new BlockUserControl();
        GasTurbineUserControl gasTurbineUserControl = new GasTurbineUserControl();
        GeneratorUserControl generatorUserControl = new GeneratorUserControl();
        HRSGUserControl hrsgUserControl = new HRSGUserControl();
        SteamTurbineUserControl steamTurbineUserControl = new SteamTurbineUserControl();
        CondenserUserControl condenserUserControl = new CondenserUserControl();
        static bool spiChecked;
        //HRSGUserControl hrsgUserControl = new HRSGUserControl();
        int GTNode = 0;
        int STNode = 0;
        int GTCount = 1;
        string SiteName;
        string BlockName;
        string GTName;
        int GSiteId = 0;
        int GBlock = 0;
        public MainForm()
        {
            InitializeComponent();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(siteUserControl);
            siteUserControl.Dock = DockStyle.Left;
            splitContainer1.Panel2.Controls.Add(saveButton);
            saveButton.Dock = DockStyle.None;

            TraverseTreeView.ContextMenuStrip = contextMenuStrip1;
            db = new ForecastAppDatabaseEntities();
            List<Site> SiteList = db.Sites.ToList();
        }
        int flag = 0;

        protected void SteamPowerInjectionChecked(object sender, bool check)
        {
            if(check)
            { spiChecked = true; }
            else { spiChecked = false; }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            
            //Inserting data in Site table
            if (TraverseTreeView.SelectedNode.Name == "Root")
            {
                //TraverseTreeView.SelectedNode.Text = siteUserControl.textBoxShortName.Text;
                using (var db = new ForecastAppDatabaseEntities())
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
                    };
                    db.Sites.Add(Site);
                    db.SaveChanges();
                    GSiteId = Site.SiteID;
                    TraverseTreeView.SelectedNode.Text = Site.Acronym;
                    SiteName = Site.Acronym;
                    TraverseTreeView.SelectedNode.Tag = GSiteId;
                    //i = (GSiteId + "S").ToString();
                }
            }

            //Inserting data into Block table
            if (TraverseTreeView.SelectedNode.Text == "Block" || TraverseTreeView.SelectedNode.Text == BlockName)
            {
                using (var db = new ForecastAppDatabaseEntities())
                {
                    var acronym = blockUserControl.textBoxName.Text;
                    var name = blockUserControl.textBoxName.Text;
                    var blockType = blockUserControl.comboBoxConfig.SelectedItem.ToString();
                    var Block = new Block
                    {
                        SiteID = GSiteId,
                        Acronym = acronym,
                        Name = name,
                        BlockType = blockType,
                    };
                    db.Blocks.Add(Block);
                    db.SaveChanges();
                    GBlock = Block.BlockID;
                    TraverseTreeView.SelectedNode.Text = Block.Acronym;
                    TraverseTreeView.SelectedNode.Tag = GBlock;
                    TraverseTreeView.SelectedNode.Name = "Block";
                    BlockName = Block.Acronym;
                }
            }

            //Inserting data into GasTurbine table
            if (TraverseTreeView.SelectedNode.Text.Contains("GasTurbine"))
            {
                using (var db = new ForecastAppDatabaseEntities())
                {
                    var gasTurbineType = "Test";
                    var name = gasTurbineUserControl.txtGasTurbineLongName.Text;
                    var acronym = gasTurbineUserControl.txtGasTurbineShortName.Text;
                    var blockId = GBlock;
                    var siteId = GSiteId;
                    var GasTurbine = new GasTurbine
                    {
                        GasTurbineType = gasTurbineType,
                        BlockID = blockId,
                        SiteID = siteId,
                        Acronym = acronym,
                        Name = name
                    };
                    db.GasTurbines.Add(GasTurbine);
                    db.SaveChanges();
                    GTName = GasTurbine.Name;
                    int GTid = GasTurbine.GasTurbineID;
                    //TreeView tv = new TreeView();
                    //tv.Nodes.Add(GTid, GTName);
                    TraverseTreeView.SelectedNode.Text = GTName;
                    TraverseTreeView.SelectedNode.Tag = GTid;
                    TraverseTreeView.SelectedNode.Name = "GasTurbine";
                }
            }

            //Inserting data into SteamTurbine table
            if (TraverseTreeView.SelectedNode.Text == "Steam Turbine")
            {
                using (var db = new ForecastAppDatabaseEntities())
                {
                    var name = steamTurbineUserControl.textBoxLongName.Text;
                    var acronym = steamTurbineUserControl.textBoxShortName.Text;
                    var blockId = GBlock;
                    var siteId = GSiteId;
                    var steamTurbine = new SteamTurbine
                    {
                        BlockID = blockId,
                        SiteID = siteId,
                        Acronym = acronym,
                        Name = name
                    };
                    db.SteamTurbines.Add(steamTurbine);
                    db.SaveChanges();
                    GTName = steamTurbine.Name;
                    int GTid = steamTurbine.SteamTurbineID;
                    //TreeView tv = new TreeView();
                    //tv.Nodes.Add(GTid, GTName);
                    TraverseTreeView.SelectedNode.Text = GTName;
                    TraverseTreeView.SelectedNode.Tag = GTid;
                    TraverseTreeView.SelectedNode.Name = "SteamTurbine";
                }
            }

            //Inserting data into Generator table
            //|| TraverseTreeView.SelectedNode.Text == GasTurbineName
            if (TraverseTreeView.SelectedNode.Text == "CT Generator")
            {
                using (var db = new ForecastAppDatabaseEntities())
                {
                    var alias = generatorUserControl.textBoxShortName.Text;
                    var name = generatorUserControl.textBoxLongName.Text;
                    var blockId = GBlock;
                    var siteId = GSiteId;
                    var generator = new Generator
                    {
                        Alias = alias,
                        BlockID = blockId,
                        SiteID = siteId,
                        Name = name
                    };
                    db.Generators.Add(generator);
                    db.SaveChanges();
                    int _genID = generator.GeneratorID;
                    TraverseTreeView.SelectedNode.Text = generator.Name;
                    TraverseTreeView.SelectedNode.Tag = _genID;
                    TraverseTreeView.SelectedNode.Name = "Generator";
                }
            }

            //Inserting data into Generator table
            //|| TraverseTreeView.SelectedNode.Text == GasTurbineName
            if (TraverseTreeView.SelectedNode.Text == "ST Generator")
            {
                using (var db = new ForecastAppDatabaseEntities())
                {
                    var alias = generatorUserControl.textBoxShortName.Text;
                    var name = generatorUserControl.textBoxLongName.Text;
                    var blockId = GBlock;
                    var siteId = GSiteId;
                    var generator = new Generator
                    {
                        Alias = alias,
                        BlockID = blockId,
                        SiteID = siteId,
                        Name = name
                    };
                    db.Generators.Add(generator);
                    db.SaveChanges();
                    int _genID = generator.GeneratorID;
                    TraverseTreeView.SelectedNode.Text = generator.Name;
                    TraverseTreeView.SelectedNode.Tag = _genID;
                    TraverseTreeView.SelectedNode.Name = "Generator";
                }
            }

            //Inserting data into HRSG table
            if (TraverseTreeView.SelectedNode.Text == "HRSG")
            {
                using (var db = new ForecastAppDatabaseEntities())
                {
                    var acronym = hrsgUserControl.textBoxShortName.Text;
                    var name = hrsgUserControl.textBoxLongName.Text;
                    var ductBurners = 12;//hrsgUserControl.txtDuctBurner.Text;
                    var blockId = GBlock;
                    var siteId = GSiteId;
                    var hrsg = new HRSG
                    {
                        Acronym = acronym,
                        Name = name,
                        DuctBurners = Convert.ToByte(ductBurners),
                        BlockID = blockId,
                        SiteID = siteId,
                    };
                    db.HRSGs.Add(hrsg);
                    db.SaveChanges();
                    int _hrId = hrsg.HRSGID;
                    TraverseTreeView.SelectedNode.Text = hrsg.Name;
                    TraverseTreeView.SelectedNode.Tag = _hrId;
                    TraverseTreeView.SelectedNode.Name = "HRSG";
                }
            }

            //Inserting data into Condenser table
            if (TraverseTreeView.SelectedNode.Text == "Condenser")
            {
                using (var db = new ForecastAppDatabaseEntities())
                {
                    var shortName = condenserUserControl.textBoxShortName.Text;
                    var longName = condenserUserControl.textBoxLongName.Text;
                    var blockId = GBlock;
                    var siteId = GSiteId;
                    var condenser = new Condenser
                    {
                        Alias = shortName,
                        Name = longName,
                        BlockID = blockId,
                        SiteID = siteId,
                    };
                    db.Condensers.Add(condenser);
                    db.SaveChanges();
                    int _condenserId = condenser.CondenserID;
                    TraverseTreeView.SelectedNode.Text = condenser.Alias;
                    TraverseTreeView.SelectedNode.Tag = _condenserId;
                    TraverseTreeView.SelectedNode.Name = "Condenser";
                }
            }
        }

        int nodeInc = 0;

        private void AddBlockMenuItem_Click(object sender, EventArgs e)
        {
            if (TraverseTreeView.SelectedNode.Text == SiteName)
            {
                TraverseTreeView.Nodes[0].Nodes.Add("Block");
            }
            else if (TraverseTreeView.SelectedNode.Text == BlockName)
            {
                
                int GTCount1 = BlockConfiguration.GTCount1;
                MessageBox.Show(GTCount1.ToString());
                for (int i = 0; i < GTCount1; i++)
                {
                    //TreeNode GasTurbineNode = new TreeNode();
                    string GasTurbineNode = "";
                    GasTurbineNode = "GasTurbine" + (GTCount).ToString();
                    TreeNode node = new TreeNode(GasTurbineNode);
                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes.Add(node);
                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add("CT Generator");
                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add("HRSG");
                    GTNode = GTNode + 1;
                    GTCount++;
                }

                if (BlockConfiguration.STCount1 != 0)
                {
                    STNode = GTNode;
                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes.Add("Steam Turbine");
                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[STNode].Nodes.Add("ST Generator");
                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[STNode].Nodes.Add("Condenser");
                    GTNode = STNode + 1;
                }
                GTNode = 0;
                nodeInc++;
            }
        }

        private void TraverseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //string BlkName1 = TraverseTreeView.Nodes[0].Nodes[0].Text;
            int tIndex = TraverseTreeView.SelectedNode.Level;
            string nn = TraverseTreeView.SelectedNode.Name;
            //Getting selected node Id from db
            //i = TraverseTreeView.SelectedNode.Tag.ToString();
            //After selecting on Site 
            if (tIndex == 0 || TraverseTreeView.SelectedNode.Text == "Site")
            {
                if (TraverseTreeView.SelectedNode.Text != "Site")
                {
                    siteUserControl.Controls.Clear();
                    int _siID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                    using (var db = new ForecastAppDatabaseEntities())
                    {
                        var data = from s in db.Sites
                                   where s.SiteID == _siID
                                   select s;
                        var st = data.FirstOrDefault<Site>();
                        SiteData._name = st.Name;
                        SiteData._acronym = st.Acronym;
                        //SiteData._blockID = st.SiteID;
                    }
                    SiteData._status = "Exist";
                }
                siteUserControl = new SiteUserControl();
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(siteUserControl);
                siteUserControl.Dock = DockStyle.Left;
                splitContainer1.Panel2.Controls.Add(saveButton);
                saveButton.Dock = DockStyle.None;
            }

            //After selecting on block
            else if (tIndex == 1 || TraverseTreeView.SelectedNode.Text == "Block")
            {
                BlockData._status = "New";
                //Checking block is exist or not
                if (TraverseTreeView.SelectedNode.Text != "Block")
                {
                    blockUserControl.Controls.Clear();
                    int _blkID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                    using (var db = new ForecastAppDatabaseEntities())
                    {
                        var data = from b in db.Blocks
                                   where b.BlockID == _blkID
                                   select b;
                        var blk = data.FirstOrDefault<Block>();
                        BlockData._name = blk.Name;
                        BlockData._acronym = blk.Acronym;
                        BlockData._blockID = blk.BlockID;
                        BlockData._typeConfig = blk.BlockType;
                    }
                    BlockData._status = "Exist";
                }
                blockUserControl = new BlockUserControl();
                blockUserControl.SteamPowerInjectionChecked+= new SteamPowerInjectionCheckedHandler((object sender1, Status s) => SteamPowerInjectionChecked(sender1, s.spiChecked));
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(blockUserControl);
                blockUserControl.Dock = DockStyle.Left;
                splitContainer1.Panel2.Controls.Add(saveButton);
                saveButton.Dock = DockStyle.None;

            }
            //After selecting on GasTurbine
            else if (tIndex == 2 || TraverseTreeView.SelectedNode.Text == "GasTurbine1" || TraverseTreeView.SelectedNode.Text == "GasTurbine2" || TraverseTreeView.SelectedNode.Text == "GasTurbine3")
            {
                if (nn == "GasTurbine" || TraverseTreeView.SelectedNode.Text == "GasTurbine1" || TraverseTreeView.SelectedNode.Text == "GasTurbine2" || TraverseTreeView.SelectedNode.Text == "GasTurbine3")
                {
                    GasTurbineData._status = "New";
                    MessageBox.Show(TraverseTreeView.SelectedNode.Text);
                    //Checking block is exist or not
                    //if (TraverseTreeView.SelectedNode.Text != "GasTurbine1")
                    if (TraverseTreeView.SelectedNode.Tag != null)
                    {
                        int _gtID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        gasTurbineUserControl.Controls.Clear();
                        using (var db = new ForecastAppDatabaseEntities())
                        {
                            var data = from g in db.GasTurbines
                                       where g.GasTurbineID == _gtID
                                       select g;
                            var gt = data.FirstOrDefault<GasTurbine>();
                            GasTurbineData._name = gt.Name;
                            GasTurbineData._acronym = gt.Acronym;
                            GasTurbineData._gasTurbineID = gt.GasTurbineID;
                        }
                        GasTurbineData._status = "Exist";
                    }
                    //gasTurbineUserControl = new Gas_Turbine_Attributes();
                    gasTurbineUserControl = new GasTurbineUserControl();
                    if(spiChecked)
                    {
                        gasTurbineUserControl.SteamPowerAugmentationGroupBox.Enabled = true;
                    }
                    else
                    {
                        gasTurbineUserControl.SteamPowerAugmentationGroupBox.Enabled = false;
                    }
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(gasTurbineUserControl);
                    gasTurbineUserControl.Dock = DockStyle.Left;
                    splitContainer1.Panel2.Controls.Add(saveButton);
                    saveButton.Dock = DockStyle.None;
                }
            }

            else if (tIndex == 3 || TraverseTreeView.SelectedNode.Text == "HRSG")
            {
                if (nn == "HRSG" || TraverseTreeView.SelectedNode.Text == "HRSG")
                {
                    HRSGData._status = "New";
                    //Checking block is exist or not
                    if (TraverseTreeView.SelectedNode.Text != "HRSG")
                    {
                        int _hrID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        hrsgUserControl.Controls.Clear();
                        using (var db = new ForecastAppDatabaseEntities())
                        {
                            var data = from g in db.HRSGs
                                       where g.HRSGID == _hrID
                                       select g;
                            var hr = data.FirstOrDefault<HRSG>();
                            HRSGData._name = hr.Name;
                            HRSGData._acronym = hr.Acronym;
                            HRSGData._hrsgID = hr.HRSGID;
                        }
                        HRSGData._status = "Exist";
                    }
                    hrsgUserControl = new HRSGUserControl();
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(hrsgUserControl);
                    hrsgUserControl.Dock = DockStyle.Left;
                    splitContainer1.Panel2.Controls.Add(saveButton);
                    saveButton.Dock = DockStyle.None;
                }
            }

            if (tIndex == 3 || TraverseTreeView.SelectedNode.Text == "CT Generator")
            {
                if (nn == "Generator" || TraverseTreeView.SelectedNode.Text == "CT Generator")
                {
                    GeneratorData._status = "New";
                    //Checking block is exist or not
                    if (TraverseTreeView.SelectedNode.Text != "CT Generator")
                    {
                        int _gtID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        generatorUserControl.Controls.Clear();
                        using (var db = new ForecastAppDatabaseEntities())
                        {
                            var data = from g in db.Generators
                                       where g.GeneratorID == _gtID
                                       select g;
                            var gt = data.FirstOrDefault<Generator>();
                            GeneratorData._name = gt.Name;
                            GeneratorData._alias = gt.Alias;
                            GeneratorData._generatorID = gt.GeneratorID;
                        }
                        HRSGData._status = "Exist";
                    }
                    //gasTurbineUserControl = new Gas_Turbine_Attributes();
                    generatorUserControl = new GeneratorUserControl();
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(generatorUserControl);
                    generatorUserControl.Dock = DockStyle.Left;
                    splitContainer1.Panel2.Controls.Add(saveButton);
                    saveButton.Dock = DockStyle.None;
                }
            }

            if (tIndex == 3 || TraverseTreeView.SelectedNode.Text == "ST Generator")
            {
                if (nn == "Generator" || TraverseTreeView.SelectedNode.Text == "ST Generator")
                {
                    GeneratorData._status = "New";
                    //Checking block is exist or not
                    if (TraverseTreeView.SelectedNode.Text != "ST Generator")
                    {
                        int _gtID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        generatorUserControl.Controls.Clear();
                        using (var db = new ForecastAppDatabaseEntities())
                        {
                            var data = from g in db.Generators
                                       where g.GeneratorID == _gtID
                                       select g;
                            var gt = data.FirstOrDefault<Generator>();
                            GeneratorData._name = gt.Name;
                            GeneratorData._alias = gt.Alias;
                            GeneratorData._generatorID = gt.GeneratorID;
                        }
                        GeneratorData._status = "Exist";
                    }
                    //gasTurbineUserControl = new Gas_Turbine_Attributes();
                    generatorUserControl = new GeneratorUserControl();
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(generatorUserControl);
                    generatorUserControl.Dock = DockStyle.Left;
                    splitContainer1.Panel2.Controls.Add(saveButton);
                    saveButton.Dock = DockStyle.None;
                }
            }

            //After selecting on SteamTurbine
            else if (tIndex == 2 || TraverseTreeView.SelectedNode.Text == "Steam Turbine")
            {
                if (nn == "SteamTurbine" || TraverseTreeView.SelectedNode.Text == "Steam Turbine")
                {
                    SteamTurbineData._status = "New";
                    //Checking block is exist or not
                    //if (TraverseTreeView.SelectedNode.Text != "GasTurbine1")
                    if (TraverseTreeView.SelectedNode.Tag != null)
                    {
                        int _stID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        steamTurbineUserControl.Controls.Clear();
                        using (var db = new ForecastAppDatabaseEntities())
                        {
                            var data = from s in db.SteamTurbines
                                       where s.SteamTurbineID == _stID
                                       select s;
                            var gt = data.FirstOrDefault<SteamTurbine>();
                            SteamTurbineData._name = gt.Name;
                            SteamTurbineData._acronym = gt.Acronym;
                            SteamTurbineData._steamTurbineID = gt.SteamTurbineID;
                        }
                        SteamTurbineData._status = "Exist";
                    }
                    //gasTurbineUserControl = new Gas_Turbine_Attributes();
                    steamTurbineUserControl = new SteamTurbineUserControl();
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(steamTurbineUserControl);
                    steamTurbineUserControl.Dock = DockStyle.Left;
                    splitContainer1.Panel2.Controls.Add(saveButton);
                    saveButton.Dock = DockStyle.None;
                }
            }

            //After selecting Condenser
            if (tIndex == 3 || TraverseTreeView.SelectedNode.Text == "Condenser")
            {
                if (nn == "Condenser" || TraverseTreeView.SelectedNode.Text == "Condenser")
                {
                    CondenserData._status = "New";
                    //Checking block is exist or not
                    if (TraverseTreeView.SelectedNode.Text != "Condenser")
                    {
                        int _conID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        condenserUserControl.Controls.Clear();
                        using (var db = new ForecastAppDatabaseEntities())
                        {
                            var data = from c in db.Condensers
                                       where c.CondenserID == _conID
                                       select c;
                            var ct = data.FirstOrDefault<Condenser>();
                            CondenserData._name = ct.Name;
                            CondenserData._alias = ct.Alias;
                            CondenserData._condenserID = ct.CondenserID;
                        }
                        CondenserData._status = "Exist";
                    }
                    //gasTurbineUserControl = new Gas_Turbine_Attributes();
                    condenserUserControl = new CondenserUserControl();
                    splitContainer1.Panel2.Controls.Clear();
                    splitContainer1.Panel2.Controls.Add(condenserUserControl);
                    condenserUserControl.Dock = DockStyle.Left;
                    splitContainer1.Panel2.Controls.Add(saveButton);
                    saveButton.Dock = DockStyle.None;
                }
            }

        }
    }
}
