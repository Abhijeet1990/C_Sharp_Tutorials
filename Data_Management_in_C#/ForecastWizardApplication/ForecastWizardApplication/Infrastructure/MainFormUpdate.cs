using ForecastAppDatabase;
using ForecastWizardApplication.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ForecastWizardApplication.Infrastructure
{
    class MainFormUpdate
    {
        int siteID = 0; int blockID = 0;
        //Inserting value into site 
        public CustomNode InsertSite(SiteUserControl siteUserControl, int lA, SiteNode _siteNode, CustomNode cNode) //, ref SiteNode _siteNode, CustomNode cNode
        {
            using (var db = new WizardDatabaseEntities())
            {
                Random rnd = new Random();
                int CId = rnd.Next(1, 1000);
                var name = siteUserControl.textBoxLongName.Text;
                var acronym = siteUserControl.textBoxShortName.Text;
                var latitude = float.Parse(siteUserControl.textBoxLatitude.Text);
                var longitude = float.Parse(siteUserControl.textBoxLongitude.Text);
                var elevation = float.Parse(siteUserControl.textBoxElevation.Text);
                var Interval = Convert.ToString(siteUserControl.comboBoxInterval.SelectedItem);
                var Duration = Convert.ToString(siteUserControl.comboBoxDuration.SelectedItem);
                var ArchiveInterval = Convert.ToString(siteUserControl.comboBoxArchiveInterval.SelectedItem);
                var ArchiveDuration = Convert.ToString(siteUserControl.comboBoxArchiveDuration.SelectedItem);
                var GridFrequency = Convert.ToString(siteUserControl.comboBoxGridFrequency.SelectedItem);
                var HeatRateUnits = Convert.ToString(siteUserControl.comboBoxHeatRateUnits.SelectedItem);
                var HeatRateCalculation = Convert.ToString(siteUserControl.comboBoxHeatRateCalculation.SelectedItem);

                //int Cid= random.Next(1000);
                var Site = new Site
                {
                    Acronym = acronym,
                    Name = name,
                    Latitude = latitude,
                    Longitude = longitude,
                    Elevation = elevation,
                    CustomerID = CId,
                    Interval=Interval,
                    Duration=Duration,
                    ArchiveInterval=ArchiveInterval,
                    Archive_Duration=ArchiveDuration,
                    Grid_Frequency=GridFrequency,
                    Heat_Rate_Units=HeatRateUnits,
                    Heat_Rate_Calculation=HeatRateCalculation

                };
                db.Sites.Add(Site);
                db.SaveChanges();
               
                //GSiteId = Site.SiteID;
                _siteNode._id = Site.SiteID;
                siteID = Site.SiteID;
                _siteNode._name = Site.Acronym;
                _siteNode._latitude = Site.Latitude;
                _siteNode._elevation = Site.Elevation;
                _siteNode._longitude = Site.Longitude;
                _siteNode._comboBoxInterval = Site.Interval;
                _siteNode._comboBoxDuration = Site.Duration;
                _siteNode._comboBoxArchiveInterval = Site.ArchiveInterval;
                _siteNode._comboBoxArchiveDuration = Site.Archive_Duration;
                _siteNode._comboBoxGridFrequency = Site.Grid_Frequency;
                _siteNode._comboBoxHeatRateUnits = Site.Heat_Rate_Units;
                _siteNode._comboBoxHeatRateCalculation = Site.Heat_Rate_Calculation;

                _siteNode.level = Convert.ToString(lA);
                _siteNode._site = new List<BlockTree>();

                cNode._tText = Site.Acronym;
                cNode._tTag = Convert.ToInt32(Site.SiteID);
                cNode._tName = "Site";
                cNode._tStateImageKey = Convert.ToString(lA);
                cNode._tLevel = Convert.ToString(lA);
                return cNode;
            }
        }

        //update site table code
        public CustomNode UpdateSite(SiteUserControl siteUserControl, int lA, SiteNode _siteNode, CustomNode cNode) //, ref SiteNode _siteNode, CustomNode cNode
        {
            using (var dbs = new WizardDatabaseEntities())
            {
                var name = siteUserControl.textBoxLongName.Text;
                var acronym = siteUserControl.textBoxShortName.Text;
                var Interval = Convert.ToString(siteUserControl.comboBoxInterval.SelectedItem);
                var Duration = Convert.ToString(siteUserControl.comboBoxDuration.SelectedItem);
                var ArchiveInterval = Convert.ToString(siteUserControl.comboBoxArchiveInterval.SelectedItem);
                var ArchiveDuration = Convert.ToString(siteUserControl.comboBoxArchiveDuration.SelectedItem);
                var GridFrequency = Convert.ToString(siteUserControl.comboBoxGridFrequency.SelectedItem);
                var HeatRateUnits = Convert.ToString(siteUserControl.comboBoxHeatRateUnits.SelectedItem);
                var HeatRateCalculation = Convert.ToString(siteUserControl.comboBoxHeatRateCalculation.SelectedItem);
                var latitude = float.Parse(siteUserControl.textBoxLatitude.Text);
                var longitude = float.Parse(siteUserControl.textBoxLongitude.Text);
                var elevation = float.Parse(siteUserControl.textBoxElevation.Text);
                int tag = _siteNode._id;
                var site = dbs.Sites.SingleOrDefault(b => b.SiteID == tag);
                if (site != null)
                {
                    site.Name = name;
                    site.Acronym = acronym;
                    site.Latitude = latitude;
                    site.Longitude = longitude;
                    site.Elevation = elevation;
                    site.Interval=Interval;
                    site.Duration=Duration;
                    site.ArchiveInterval=ArchiveInterval;
                    site.Archive_Duration=ArchiveDuration;
                    site.Grid_Frequency=GridFrequency;
                    site.Heat_Rate_Units=HeatRateUnits;
                    site.Heat_Rate_Calculation = HeatRateCalculation;
                    dbs.SaveChanges();
                }
                cNode._tText = site.Acronym;
                _siteNode._name = site.Name;
                _siteNode._latitude = site.Latitude;
                _siteNode._longitude = site.Longitude;
                _siteNode._elevation = site.Elevation;
                _siteNode._comboBoxInterval = site.Interval;
                _siteNode._comboBoxDuration = site.Duration;
                _siteNode._comboBoxArchiveInterval = site.ArchiveInterval;
                _siteNode._comboBoxArchiveDuration = site.Archive_Duration;
                _siteNode._comboBoxGridFrequency = site.Grid_Frequency ;
                _siteNode._comboBoxHeatRateUnits = site.Heat_Rate_Units ;
                _siteNode._comboBoxHeatRateCalculation = site.Heat_Rate_Calculation;
            }
            return cNode;
        }


        public CustomNode InsertBlock(BlockUserControl blockUserControl, int lB, ref BlockTree _blockNode, ref SiteNode _siteNode, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var acronym = blockUserControl.textBoxName.Text;
                var name = blockUserControl.textBoxName.Text;
                var blockType = blockUserControl.comboBoxConfig.SelectedItem.ToString();
                var gasTurbineType = blockUserControl.comboBoxGTType.SelectedItem.ToString();
                var Block = new Block
                {
                    SiteID = _siteNode._id,
                    Acronym = acronym,
                    Name = name,
                    BlockType = blockType,
                    GasTurbineType = gasTurbineType,
                };
                db.Blocks.Add(Block);
                db.SaveChanges();
                blockID = Block.BlockID;
                _blockNode._typeConfig = Block.BlockType;

                cNode._tText = Block.Acronym;
                cNode._tTag = Block.BlockID;
                cNode._tName = "Block";
                //cNode._tStateImageKey = Convert.ToString(lA);

                _blockNode = new BlockTree
                {
                    _blockID = blockID,
                    _acronym = Block.Acronym,
                    _gasTurbineType = gasTurbineType,
                    _name = Block.Name,
                    _typeConfig = blockType,
                    _gasTurbineTree = new List<GasTurbineTree>(),
                    _steamTurbineTree = new List<SteamTurbineTree>(),
                    level = _siteNode.level + "." + Convert.ToString(lB)
                };
                lB++;
                //bt.Add(_blockNode);
                _siteNode._site.Add(_blockNode);
                blockUserControl.CheckChkBx(ref _blockNode);

            }
            return cNode;
        }

        public CustomNode UpdateBlock(BlockUserControl blockUserControl, ref BlockTree _blockNode, CustomNode cNode, ref SiteNode _siteNode, int bid)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var acronym = blockUserControl.textBoxName.Text;
                var name = blockUserControl.textBoxName.Text;
                var blockType = blockUserControl.comboBoxConfig.SelectedItem.ToString();
                var Blk = db.Blocks.SingleOrDefault(b => b.BlockID == bid);
                if (Blk != null)
                {
                    Blk.Acronym = acronym;
                    Blk.Name = name;
                    db.SaveChanges();
                }
                //TraverseTreeView.SelectedNode.Text = Blk.Acronym;
                //adding updated value with class
                cNode._tText = Blk.Acronym;
                _blockNode._acronym = Blk.Acronym;
                _blockNode._name = Blk.Acronym;
                blockUserControl.CheckChkBx(ref _blockNode);
            }
            return cNode;
        }


        //Inserting GasTurbine
        public CustomNode InsertGasturbine(GasTurbineUserControl gasTurbineUserControl, int BlockId, int SiteID, ref CustomNode cNode)
        {
            //CustomNode cNode = new CustomNode();   --Test
            using (var db = new WizardDatabaseEntities())
            {
                var gasTurbineType = "Test";
                var name = gasTurbineUserControl.txtGasTurbineLongName.Text;
                var acronym = gasTurbineUserControl.txtGasTurbineShortName.Text;
                var blockId = BlockId;
                var siteId = SiteID;
                var GasTurbine = new GasTurbine
                {
                    GasTurbineType = gasTurbineType,
                    BlockID = blockId,
                    SiteID = siteId,
                    Acronym = acronym,
                    Name = name
                    //GasTurbineID=
                };
                db.GasTurbines.Add(GasTurbine);
                db.SaveChanges();
                cNode._tName = GasTurbine.Name;
                cNode._tText = GasTurbine.Acronym;
                cNode._tTag = GasTurbine.GasTurbineID;
            }
            return cNode;
        }

        //Updating GasTurbine
        public CustomNode UpdateGasturbine(GasTurbineUserControl gasTurbineUserControl, int gId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var name = gasTurbineUserControl.txtGasTurbineLongName.Text;
                var acronym = gasTurbineUserControl.txtGasTurbineShortName.Text;
                var gas = db.GasTurbines.SingleOrDefault(b => b.GasTurbineID == gId);
                if (gas != null)
                {
                    gas.Acronym = acronym;
                    gas.Name = name;
                    db.SaveChanges();
                }
                cNode._tText = gas.Acronym;
                cNode._tName = gas.Name;
            }
            return cNode;
        }

        //Inserting SteamTurbine
        public CustomNode InsertSteamTurbine(SteamTurbineUserControl steamTurbineUserControl, int BlockId, int SiteID, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var name = steamTurbineUserControl.textBoxLongName.Text;
                var acronym = steamTurbineUserControl.textBoxShortName.Text;
                var blockId = BlockId;
                var siteId = SiteID;
                var steamTurbine = new SteamTurbine
                {
                    BlockID = blockId,
                    SiteID = siteId,
                    Acronym = acronym,
                    Name = name
                };
                db.SteamTurbines.Add(steamTurbine);
                db.SaveChanges();
                cNode._tText = steamTurbine.Acronym;
                cNode._tName = steamTurbine.Name;
                cNode._tTag = steamTurbine.SteamTurbineID;
            }
            return cNode;
        }

        //Updating SteamTurbine
        public CustomNode UpdateSteamTurbine(SteamTurbineUserControl steamTurbineUserControl, int sId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var name = steamTurbineUserControl.textBoxLongName.Text;
                var acronym = steamTurbineUserControl.textBoxShortName.Text;
                var steam = db.SteamTurbines.SingleOrDefault(b => b.SteamTurbineID == sId);
                if (steam != null)
                {
                    steam.Acronym = acronym;
                    steam.Name = name;
                    //gas.BlockType = blockType;
                    db.SaveChanges();
                }
                db.SteamTurbines.Add(steam);
                db.SaveChanges();
                cNode._tText = steam.Acronym;
                cNode._tName = steam.Name;
            }
            return cNode;
        }

        //Inserting CTGenerator
        public CustomNode InsertCTGenerator(GeneratorUserControl generatorUserControl, int BlockId, int SiteID, int GTId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var alias = generatorUserControl.textBoxShortName.Text;
                var name = generatorUserControl.textBoxLongName.Text;
                var generator = new Generator
                {
                    Alias = alias,
                    BlockID = blockID,
                    SiteID = siteID,
                    Name = name,
                    GasTurbineID = GTId
                };
                db.Generators.Add(generator);
                db.SaveChanges();
                cNode._tText = generator.Alias;
                cNode._tName = generator.Name;
                cNode._tTag = generator.GeneratorID;
            }
            return cNode;
        }

        //Update CTGenerator
        public CustomNode UpdateCTGenerator(GeneratorUserControl generatorUserControl, int CTId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var alias = generatorUserControl.textBoxShortName.Text;
                var name = generatorUserControl.textBoxLongName.Text;
                var ctGen = db.Generators.SingleOrDefault(g => g.GeneratorID == CTId);
                if (ctGen != null)
                {
                    ctGen.Name = name;
                    ctGen.Alias = alias;
                    db.SaveChanges();
                }
                cNode._tText = ctGen.Alias;
                cNode._tName = ctGen.Name;
            }
            return cNode;
        }

        //Inserting STGenerator
        public CustomNode InsertSTGenerator(GeneratorUserControl generatorUserControl, int BlockId, int Gid, int SteamId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var alias = generatorUserControl.textBoxShortName.Text;
                var name = generatorUserControl.textBoxLongName.Text;
                var generator = new Generator
                {
                    Alias = alias,
                    BlockID = blockID,
                    SiteID = siteID,
                    Name = name,
                    SteamTurbineID = SteamId
                };
                db.Generators.Add(generator);
                db.SaveChanges();
                cNode._tText = generator.Alias;
                cNode._tName = generator.Name;
                cNode._tTag = generator.GeneratorID;
            }
            return cNode;
        }


        //Updating STGenerator
        public CustomNode UpdateSTGenerator(GeneratorUserControl generatorUserControl, int SteamId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var alias = generatorUserControl.textBoxShortName.Text;
                var name = generatorUserControl.textBoxLongName.Text;
                var ctGen = db.Generators.SingleOrDefault(g => g.SteamTurbineID == SteamId);
                if (ctGen != null)
                {
                    ctGen.Name = name;
                    ctGen.Alias = alias;
                    db.SaveChanges();
                }
                cNode._tText = ctGen.Alias;
                cNode._tName = ctGen.Name;
            }
            return cNode;
        }

        //Inserting HRSG
        public CustomNode InsertHrsg(HRSGUserControl hrsgUserControl, int BlockId, int SId, int GTId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var alias = hrsgUserControl.textBoxShortName.Text;
                var name = hrsgUserControl.textBoxLongName.Text;
                var hrsg = new HRSG
                {
                    Acronym = alias,
                    BlockID = BlockId,
                    SiteID = SId,
                    Name = name,
                    GasTurbineID = GTId
                };
                db.HRSGs.Add(hrsg);
                db.SaveChanges();
                cNode._tText = hrsg.Acronym;
                cNode._tName = hrsg.Name;
                cNode._tTag = hrsg.HRSGID;
            }
            return cNode;
        }

        //Updating HRSG
        public CustomNode UpdateHrsg(HRSGUserControl hrsgUserControl, int hrsgID, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var acronym = hrsgUserControl.textBoxShortName.Text;
                var name = hrsgUserControl.textBoxLongName.Text;
                var hrs = db.HRSGs.SingleOrDefault(s => s.HRSGID == hrsgID);
                if (hrs != null)
                {
                    hrs.Name = name;
                    hrs.Acronym = acronym;
                    db.SaveChanges();
                }
                cNode._tText = hrs.Acronym;
                cNode._tName = hrs.Name;
            }
            return cNode;
        }

        //Inserting Condenser
        public CustomNode InsertCondenser(CondenserUserControl condenserUserControl, int BlockId, int SId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var shortName = condenserUserControl.textBoxShortName.Text;
                var longName = condenserUserControl.textBoxLongName.Text;
                var blockId = BlockId;
                var siteId = SId;
                var condenser = new Condenser
                {
                    Alias = shortName,
                    Name = longName,
                    BlockID = blockId,
                    SiteID = siteId,
                };
                db.Condensers.Add(condenser);
                db.SaveChanges();
                cNode._tText = condenser.Alias;
                cNode._tName = condenser.Name;
                cNode._tTag = condenser.CondenserID;
            }
            return cNode;
        }

        //Updating Condenser
        public CustomNode UpdateCondenser(CondenserUserControl condenserUserControl, int condenId, ref CustomNode cNode)
        {
            using (var db = new WizardDatabaseEntities())
            {
                var acronym = condenserUserControl.textBoxShortName.Text;
                var name = condenserUserControl.textBoxLongName.Text;
                var conden = db.Condensers.SingleOrDefault(s => s.CondenserID == condenId);
                if (conden != null)
                {
                    conden.Name = name;
                    conden.Alias = acronym;
                    db.SaveChanges();
                }
                cNode._tText = conden.Alias;
                cNode._tName = conden.Name;
            }
            return cNode;
        }
    }
}
