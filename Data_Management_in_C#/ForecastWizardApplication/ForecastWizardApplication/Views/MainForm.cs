using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ForecastAppDatabase;
using ForecastWizardApplication.UserControls;
using ForecastWizardApplication.Infrastructure;
using System.Xml;
using System.Collections;
using System.Xml.Linq;
using ForecastWizardApplication.Views;

namespace ForecastWizardApplication
{
    public partial class Form1 : Form
    {
        WizardDatabaseEntities db;
        public SiteUserControl siteUserControl = new SiteUserControl();
        BlockUserControl blockUserControl = new BlockUserControl();
        GasTurbineUserControl gasTurbineUserControl = new GasTurbineUserControl();
        GeneratorUserControl generatorUserControl = new GeneratorUserControl();
        HRSGUserControl hrsgUserControl = new HRSGUserControl();
        SteamTurbineUserControl steamTurbineUserControl = new SteamTurbineUserControl();
        CondenserUserControl condenserUserControl = new CondenserUserControl();
        //HRSGUserControl hrsgUserControl = new HRSGUserControl();
        int GTNode = 0;
        int STNode = 0;
        int GTCount = 1;

        public string SiteName;
        public string BlockName;
        public string GTName;
        public static int GSiteId = 0;
        public static int GBlock = 0;
        public static int GasTurbineId = 0;
        public int SteamTurbineID = 0;
        public static string GBlockType = "";
        public int lA = 0, lB = 0, lC = 0, lD = 0;
        public SiteNode _siteNode = new SiteNode();
        public BlockTree _blockNode = new BlockTree();
        public GasTurbineTree _gasTurbineNode = new GasTurbineTree();
        public SteamTurbineTree _steamTurbineNode = new SteamTurbineTree();
        public CTGeneratorTree _ctGeneratorNode = new CTGeneratorTree();
        public HRSGTree _hrsgNode = new HRSGTree();
        public STGeneratorTree _stGeneratorNode = new STGeneratorTree();
        public CondenserTree _condenserTreeNode = new CondenserTree();
        public GenerateXML generateXML = new GenerateXML();
        public TreeNode node;
        CustomNode cNode = new CustomNode();
        int cID = 2;

        MainFormUpdate mainform = new MainFormUpdate();
        public Form1()
        {
            InitializeComponent();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(siteUserControl);
            siteUserControl.Dock = DockStyle.Left;
            splitContainer1.Panel2.Controls.Add(saveButton);
            saveButton.Dock = DockStyle.None;

            TraverseTreeView.ContextMenuStrip = contextMenuStrip1;
            db = new WizardDatabaseEntities();
            List<Site> SiteList = db.Sites.ToList();
            PopulateControls();
        }

        //Generating treeview from the db
        public void PopulateControls()
        {
            if (cID == 188)
            {
                using (var db = new WizardDatabaseEntities())
                {
                    //var site = (from g in db.GasTurbines where g.SiteID == _siteNode._id select g);
                    var data = from s in db.Sites
                               where s.CustomerID == cID
                               select s;
                    var st = data.FirstOrDefault<Site>();
                    GSiteId = st.SiteID;
                    siteUserControl.comboBox1.DisplayMember = "st1";
                    siteUserControl.textBoxShortName.Text = Convert.ToString(st.Acronym);
                    siteUserControl.textBoxLongName.Text = Convert.ToString(st.Name);
                    siteUserControl.textBoxLatitude.Text = Convert.ToString(st.Latitude);
                    siteUserControl.textBoxLongitude.Text = Convert.ToString(st.Longitude);
                    siteUserControl.textBoxElevation.Text = Convert.ToString(st.Elevation);
                    siteUserControl.comboBoxInterval.Text = Convert.ToString(st.Interval);
                    siteUserControl.comboBoxDuration.Text = Convert.ToString(st.Duration);
                    siteUserControl.comboBoxArchiveInterval.Text = Convert.ToString(st.ArchiveInterval);
                    siteUserControl.comboBoxArchiveDuration.Text = Convert.ToString(st.Archive_Duration);
                    siteUserControl.comboBoxGridFrequency.Text = Convert.ToString(st.Grid_Frequency);
                    siteUserControl.comboBoxHeatRateUnits.Text = Convert.ToString(st.Heat_Rate_Units);
                    siteUserControl.comboBoxHeatRateCalculation.Text = Convert.ToString(st.Heat_Rate_Calculation);
                    //siteUserControl.
                    _siteNode._id = Convert.ToInt32(st.SiteID);
                    _siteNode._name = Convert.ToString(st.Name);
                    _siteNode._latitude = Convert.ToSingle(st.Latitude);
                    _siteNode._longitude = Convert.ToSingle(st.Longitude);
                    _siteNode._elevation = Convert.ToSingle(st.Elevation);
                    _siteNode._comboBoxInterval = Convert.ToString(st.Interval);
                    _siteNode._comboBoxDuration = Convert.ToString(st.Duration);
                    _siteNode._comboBoxArchiveInterval = Convert.ToString(st.ArchiveInterval);
                    _siteNode._comboBoxArchiveDuration = Convert.ToString(st.Archive_Duration);
                    _siteNode._comboBoxGridFrequency = Convert.ToString(st.Grid_Frequency);
                    _siteNode._comboBoxHeatRateUnits = Convert.ToString(st.Heat_Rate_Units);
                    _siteNode._comboBoxHeatRateCalculation = Convert.ToString(st.Heat_Rate_Calculation);
                    _siteNode.level = Convert.ToString(lA);

                    TreeNode n = new TreeNode();
                    n.Text = _siteNode._name;

                    n.Tag = Convert.ToInt32(_siteNode._id);
                    n.Name = Convert.ToString(_siteNode._name);
                    TraverseTreeView.Nodes.Add(n);

                    //TraverseTreeView.Nodes.Add(st.Name);
                    SiteName = st.Name;
                    _siteNode._site = new List<BlockTree>();
                }

                using (var db = new WizardDatabaseEntities())
                {
                    //Adding Block enhancement 
                    //var data = (from h in db.BlockWiseEnhancementSelections where h.   == _siteNode._id select c);
                    //if (data.Count() > 0)
                    //{

                    //}

                    var data = (from c in db.Blocks where c.SiteID == _siteNode._id select c);
                    if (data.Count() > 0)
                    {
                        //Adding block nodes
                        foreach (var row in data)
                        {
                            _blockNode = new BlockTree
                            {
                                _blockID = row.BlockID,
                                _acronym = row.Acronym.Trim(),
                                _name = row.Acronym,
                                _typeConfig = row.BlockType,
                                _gasTurbineTree = new List<GasTurbineTree>(),
                                _steamTurbineTree = new List<SteamTurbineTree>(),
                                level = _siteNode.level + "." + Convert.ToString(lB)
                            };
                            lB++;
                            GBlock = Convert.ToInt32(_blockNode._blockID);
                            _siteNode._site.Add(_blockNode);
                            TreeNode n = new TreeNode();
                            n.StateImageKey = _blockNode.level;
                            n.Text = _blockNode._acronym;
                            n.Tag = Convert.ToInt32(_blockNode._blockID);
                            n.Name = Convert.ToString(_blockNode._name);
                            TraverseTreeView.Nodes[0].Nodes.Add(n);

                            //adding gasturbine
                            var dataG = (from g in db.GasTurbines where g.BlockID == _blockNode._blockID select g);
                            if (dataG.Count() > 0)
                            {
                                foreach (GasTurbine row1 in dataG)
                                {
                                    _gasTurbineNode = gasTurbineTreeNode(nodeInc, row1, true);
                                    lC++;
                                    //adding CTGenerator inside GasTurbine
                                    var dataGen = (from gn in db.Generators where gn.GasTurbineID == _gasTurbineNode._gtId select gn);
                                    if (dataGen.Count() > 0)
                                    {
                                        foreach (var rowGen in dataGen)
                                        {
                                            n = new TreeNode();
                                            _ctGeneratorNode = new CTGeneratorTree
                                            {
                                                _ctGeneratorName = rowGen.Name,
                                                _genId = rowGen.GeneratorID,
                                                level = _ctGeneratorNode.level + "." + Convert.ToString(lD)
                                            };
                                            n = new TreeNode();
                                            n.Text = _ctGeneratorNode._ctGeneratorName;
                                            n.Tag = Convert.ToInt32(_ctGeneratorNode._genId);
                                            n.Name = "CTGenerator";
                                            n.StateImageKey = _stGeneratorNode.level;
                                            TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                            lD++;
                                            _gasTurbineNode._cTGeneratorTree = _ctGeneratorNode;
                                        }
                                    }
                                    else
                                    {
                                        _ctGeneratorNode = new CTGeneratorTree
                                        {
                                            _ctGeneratorName = "CTGenerator",
                                            level = _gasTurbineNode.level + "." + Convert.ToString(lD)
                                        };
                                        n = new TreeNode();
                                        n.Text = _ctGeneratorNode._ctGeneratorName;
                                        n.StateImageKey = _ctGeneratorNode.level;
                                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                        lD++;
                                        _gasTurbineNode._cTGeneratorTree = _ctGeneratorNode;
                                    }

                                    //adding HRSG inside GasTurbine
                                    var dataHrsg = (from hr in db.HRSGs where hr.GasTurbineID == _gasTurbineNode._gtId select hr);
                                    if (dataHrsg.Count() > 0)
                                    {
                                        foreach (var rowHR in dataHrsg)
                                        {
                                            n = new TreeNode();
                                            _hrsgNode = new HRSGTree
                                            {
                                                _hrsgName = rowHR.Name,
                                                _hrsgId = rowHR.HRSGID,
                                                level = _hrsgNode.level + "." + Convert.ToString(lD)
                                            };
                                            n = new TreeNode();
                                            n.Text = _hrsgNode._hrsgName;
                                            n.StateImageKey = _hrsgNode.level;
                                            n.Tag = Convert.ToInt32(_hrsgNode._hrsgId);
                                            n.Name = "HRSG";
                                            TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n); //GTNode
                                            lD++;
                                            GTNode = GTNode + 1;
                                            _gasTurbineNode._hRSGTree = _hrsgNode;
                                        }
                                    }

                                    else
                                    {
                                        _hrsgNode = new HRSGTree
                                        {
                                            _hrsgName = "HRSG",
                                            level = _gasTurbineNode.level + "." + Convert.ToString(lD)
                                        };
                                        n = new TreeNode();
                                        n.Text = _hrsgNode._hrsgName;
                                        n.StateImageKey = _hrsgNode.level;
                                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                        lD--;
                                        GTNode = GTNode + 1;
                                        _gasTurbineNode._hRSGTree = _hrsgNode;
                                    }
                                    _blockNode._gasTurbineTree.Add(_gasTurbineNode);
                                }
                            }

                            //Adding gasturbine node inside the block if user not added(All gasturbine nodes)
                            else
                            {
                                //var dataConfig = (from dc in db.Blocks where dc.SiteID == _siteNode._id select dc);  //for block table
                                int GTCount1 = 0;
                                if (_blockNode._typeConfig == "2X1 Multi-Shaft Combined Cycle")
                                    GTCount1 = 2;
                                else if (_blockNode._typeConfig == "3X1 Multi-Shaft Combined Cycle")
                                    GTCount1 = 3;
                                else
                                    GTCount1 = 1;

                                for (int i = 0; i < GTCount1; i++)
                                {
                                    _gasTurbineNode = gasTurbineTreeNode(nodeInc, null);
                                    lC++;

                                    _ctGeneratorNode = new CTGeneratorTree
                                    {
                                        _ctGeneratorName = "CTGenerator",
                                        level = _gasTurbineNode.level + "." + Convert.ToString(lD)
                                    };
                                    n = new TreeNode();
                                    n.Text = _ctGeneratorNode._ctGeneratorName;
                                    n.StateImageKey = _ctGeneratorNode.level;
                                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                    lD++;

                                    _hrsgNode = new HRSGTree
                                    {
                                        _hrsgName = "HRSG",
                                        level = _gasTurbineNode.level + "." + Convert.ToString(lD)
                                    };
                                    n = new TreeNode();
                                    n.Text = _hrsgNode._hrsgName;
                                    n.StateImageKey = _hrsgNode.level;
                                    TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                    lD--;

                                    _gasTurbineNode._cTGeneratorTree = _ctGeneratorNode;
                                    _gasTurbineNode._hRSGTree = _hrsgNode;
                                    _blockNode._gasTurbineTree.Add(_gasTurbineNode);
                                    GTNode = GTNode + 1;
                                    GTCount++;
                                }
                            }

                            //adding steam turbine node inside Block
                            var dataST = (from st in db.SteamTurbines where st.BlockID == _blockNode._blockID select st);
                            if (dataST.Count() > 0)
                            {
                                foreach (SteamTurbine rowSt in dataST)
                                {
                                    _steamTurbineNode = steamTurbineTreeNode(nodeInc, rowSt, true);
                                    lC++;

                                    //adding STGenerator inside the SteamTurbine
                                    var dataSTGen = (from stg in db.Generators where stg.SteamTurbineID == _steamTurbineNode._stId select stg);
                                    if (dataSTGen.Count() > 0)
                                    {
                                        foreach (var rowstg in dataSTGen)
                                        {
                                            _stGeneratorNode = new STGeneratorTree
                                            {
                                                _stGeneratorName = rowstg.Name,
                                                _stgenId = rowstg.GeneratorID,
                                                level = _stGeneratorNode.level + "." + Convert.ToString(lD)
                                            };
                                            n = new TreeNode();
                                            n.Text = _stGeneratorNode._stGeneratorName;
                                            n.Tag = Convert.ToInt32(_stGeneratorNode._stgenId);
                                            n.Name = "STGenerator";
                                            n.StateImageKey = _stGeneratorNode.level;
                                            TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                            lD++;
                                            _steamTurbineNode.sTGeneratorTreeSteam = _stGeneratorNode;
                                        }
                                    }

                                    //Adding STGenerator inside Steam Turbine if user not added
                                    else
                                    {
                                        n = new TreeNode();
                                        n.StateImageKey = _steamTurbineNode.level;
                                        n.Text = _steamTurbineNode._steamTurbineName;
                                        //TraverseTreeView.Nodes[0].Nodes[0].Nodes.Add(n);  //nodeInc=1

                                        _stGeneratorNode = new STGeneratorTree
                                        {
                                            _stGeneratorName = "STGenerator",
                                            level = _steamTurbineNode.level + "." + Convert.ToString(lD)
                                        };
                                        n = new TreeNode();
                                        n.Text = _stGeneratorNode._stGeneratorName;
                                        n.StateImageKey = _stGeneratorNode.level;
                                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                        lD++;
                                    }

                                    //adding Condenser inside the SteamTurbine
                                    var dataSTCon = (from stc in db.Condensers where stc.BlockID == _blockNode._blockID select stc);
                                    if (dataSTCon.Count() > 0)
                                    {
                                        foreach (var rowstc in dataSTCon)
                                        {
                                            n = new TreeNode();
                                            _condenserTreeNode = new CondenserTree
                                            {
                                                _CondenserName = rowstc.Name,
                                                _condenId = rowstc.CondenserID,
                                                level = _condenserTreeNode.level + "." + Convert.ToString(lD)
                                            };
                                            n = new TreeNode();
                                            n.Text = _condenserTreeNode._CondenserName;
                                            n.Tag = Convert.ToInt32(_condenserTreeNode._condenId);
                                            n.Name = "Condenser";
                                            n.StateImageKey = _condenserTreeNode.level;
                                            TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                            lD++;
                                            _steamTurbineNode._condenserTree = _condenserTreeNode;
                                            GTNode = STNode + 1;
                                        }
                                    }

                                    //Adding Condenser inside Steam Turbine dynamically if user not added
                                    else
                                    {
                                        n = new TreeNode();
                                        n.StateImageKey = _condenserTreeNode.level;
                                        n.Text = _condenserTreeNode._CondenserName;
                                        _condenserTreeNode = new CondenserTree
                                        {
                                            _CondenserName = "Condenser",
                                            level = _condenserTreeNode.level + "." + Convert.ToString(lD)
                                        };
                                        n = new TreeNode();
                                        n.Text = _condenserTreeNode._CondenserName;
                                        n.StateImageKey = _condenserTreeNode.level;
                                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                        lD++;
                                        _steamTurbineNode._condenserTree = _condenserTreeNode;
                                        GTNode = STNode + 1;
                                    }
                                }
                                _blockNode._steamTurbineTree.Add(_steamTurbineNode);
                            }

                            //Adding steamturbine node inside the block if user not added
                            else
                            {
                                STNode = GTNode + 1;
                                _steamTurbineNode = steamTurbineTreeNode(nodeInc, null);
                                _stGeneratorNode = new STGeneratorTree
                                {
                                    _stGeneratorName = "STGenerator",
                                    level = _steamTurbineNode.level + "." + Convert.ToString(lD)
                                };
                                n = new TreeNode();
                                n.Text = _stGeneratorNode._stGeneratorName;
                                n.StateImageKey = _stGeneratorNode.level;
                                TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                lD++;
                                _condenserTreeNode = new CondenserTree
                                {
                                    _CondenserName = "Condenser",
                                    level = _steamTurbineNode.level + "." + Convert.ToString(lD)
                                };
                                n = new TreeNode();
                                n.Text = _condenserTreeNode._CondenserName;
                                n.StateImageKey = _condenserTreeNode.level;
                                TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                                lD--;
                                _steamTurbineNode._condenserTree = _condenserTreeNode;
                                _steamTurbineNode.sTGeneratorTreeSteam = _stGeneratorNode;
                                _blockNode._steamTurbineTree.Add(_steamTurbineNode);
                                GTNode = STNode + 1;
                            }
                            lC = 0;
                            GTNode = 0;
                            nodeInc++;
                        }
                    }
                }
                generateXML.Create(_siteNode);
            }
            else
            {
                TreeNode n = new TreeNode();
                n.Text = "Site";
                TraverseTreeView.Nodes.Add(n);
            }
        }
        int nodeInc = 0;

        //In The SaveButton Now We generate XML FIle As we goes on
        private void saveButton_Click(object sender, EventArgs e)
        {
            string[] levels = TraverseTreeView.SelectedNode.StateImageKey.Split('.');
            //Inserting data & updating in Site table
            if (TraverseTreeView.SelectedNode.Level == 0)
            {
                if (TraverseTreeView.SelectedNode.Name != "Site")
                {
                    mainform.InsertSite(siteUserControl, lA, _siteNode, cNode);
                    GSiteId = _siteNode._id;
                    TraverseTreeView.SelectedNode.Text = cNode._tText.ToString();
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    SiteName = cNode._tText;
                    TraverseTreeView.SelectedNode.StateImageKey = cNode._tStateImageKey;
                    TraverseTreeView.SelectedNode.Name = "Site";
                }
                else
                {
                    mainform.UpdateSite(siteUserControl, lA, _siteNode, cNode);
                    TraverseTreeView.SelectedNode.Text = cNode._tText.ToString();
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    SiteName = cNode._tText;
                    TraverseTreeView.SelectedNode.StateImageKey = cNode._tStateImageKey;
                }
                return;
            }

            //Inserting data into Block table
            if (TraverseTreeView.SelectedNode.Level == 1)
            {

                if (TraverseTreeView.SelectedNode.Text == "Block" && TraverseTreeView.SelectedNode.Tag == null)
                {
                    mainform.InsertBlock(blockUserControl, lB, ref _blockNode, ref _siteNode, ref cNode);
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    TraverseTreeView.SelectedNode.Name = "Block";
                    BlockName = cNode._tText;
                    GBlock = _blockNode._blockID;
                    BlockData._blockID = GBlock;
                    blockUserControl.ShowForecastGroup();
                    TraverseTreeView.SelectedNode.StateImageKey = cNode._tStateImageKey;
                    generateXML.Create(_siteNode);

                }

                else
                {
                    //update block code
                    int id = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                    mainform.UpdateBlock(blockUserControl, ref _blockNode, cNode, ref _siteNode, id);
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    BlockName = cNode._tText;
                    //TraverseTreeView.SelectedNode.StateImageKey = cNode._tStateImageKey;
                    generateXML.Create(_siteNode);
                    return;
                }

                blockUserControl.UpdateEnhancement(blockUserControl, GBlock);
                if (TraverseTreeView.SelectedNode.Text == BlockName)
                {
                    TreeNode n;
                    int GTCount1 = BlockConfiguration.GTCount1;
                    for (int i = 0; i < GTCount1; i++)
                    {
                        _gasTurbineNode = gasTurbineTreeNode(nodeInc, null);
                        lC++;

                        _ctGeneratorNode = new CTGeneratorTree
                        {
                            _ctGeneratorName = "CTGenerator",
                            level = _gasTurbineNode.level + "." + Convert.ToString(lD)
                        };
                        n = new TreeNode();
                        n.Text = _ctGeneratorNode._ctGeneratorName;
                        n.StateImageKey = _ctGeneratorNode.level;
                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                        lD++;

                        _hrsgNode = new HRSGTree
                        {
                            _hrsgName = "HRSG",
                            level = _gasTurbineNode.level + "." + Convert.ToString(lD)
                        };
                        n = new TreeNode();
                        n.Text = _hrsgNode._hrsgName;
                        n.StateImageKey = _hrsgNode.level;
                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[GTNode].Nodes.Add(n);
                        lD--;

                        _gasTurbineNode._cTGeneratorTree = _ctGeneratorNode;
                        _gasTurbineNode._hRSGTree = _hrsgNode;
                        _blockNode._gasTurbineTree.Add(_gasTurbineNode);
                        GTNode = GTNode + 1;
                        GTCount++;
                    }

                    if (BlockConfiguration.STCount1 != 0)
                    {
                        STNode = GTNode;
                        _steamTurbineNode = steamTurbineTreeNode(nodeInc, null);

                        _stGeneratorNode = new STGeneratorTree
                        {
                            _stGeneratorName = "STGenerator",
                            level = _steamTurbineNode.level + "." + Convert.ToString(lD)
                        };
                        n = new TreeNode();
                        n.Text = _stGeneratorNode._stGeneratorName;
                        n.StateImageKey = _stGeneratorNode.level;
                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[STNode].Nodes.Add(n);
                        lD++;

                        _condenserTreeNode = new CondenserTree
                        {
                            _CondenserName = "Condenser",
                            level = _steamTurbineNode.level + "." + Convert.ToString(lD)
                        };
                        n = new TreeNode();
                        n.Text = _condenserTreeNode._CondenserName;
                        n.StateImageKey = _condenserTreeNode.level;
                        TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes[STNode].Nodes.Add(n);
                        lD--;

                        _steamTurbineNode._condenserTree = _condenserTreeNode;
                        _steamTurbineNode.sTGeneratorTreeSteam = _stGeneratorNode;
                        _blockNode._steamTurbineTree.Add(_steamTurbineNode);
                        GTNode = STNode + 1;
                    }
                    lC = 0;
                    GTNode = 0;
                    nodeInc++;
                }
                generateXML.Create(_siteNode);
                return;
            }

            //=============== updating gasTurbine =============================================
            if (TraverseTreeView.SelectedNode.Name == "GasTurbine")
            {
                mainform.UpdateGasturbine(gasTurbineUserControl, Convert.ToInt32(TraverseTreeView.SelectedNode.Tag), ref cNode);
                TraverseTreeView.SelectedNode.Text = cNode._tText;
                generateXML.updateObject(ref _siteNode, levels, cNode._tName, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                _gasTurbineNode._gasTurbineName = cNode._tName;
                generateXML.Create(_siteNode);
                return;
            }

            //Inserting data into GasTurbine table
            if (TraverseTreeView.SelectedNode.Text == "GasTurbine" && TraverseTreeView.SelectedNode.Name == "")
            {
                mainform.InsertGasturbine(gasTurbineUserControl, GBlock, GSiteId, ref cNode);
                TraverseTreeView.SelectedNode.Text = cNode._tText;
                TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                GasTurbineId = cNode._tTag;
                TraverseTreeView.SelectedNode.Name = "GasTurbine";
                generateXML.updateObject(ref _siteNode, levels, cNode._tName, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                generateXML.Create(_siteNode);
                return;
            }

            //=============== updating value of Steam turbine =================================================
            if (TraverseTreeView.SelectedNode.Name == "SteamTurbine")
            {
                int sID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                mainform.UpdateSteamTurbine(steamTurbineUserControl, sID, ref cNode);
                TraverseTreeView.SelectedNode.Text = cNode._tText;
                _steamTurbineNode._steamTurbineName = cNode._tName;
                generateXML.updateObject(ref _siteNode, levels, cNode._tName, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                generateXML.Create(_siteNode);
                return;
            }

            //Inserting data into SteamTurbine table
            if (TraverseTreeView.SelectedNode.Text == "SteamTurbine" && TraverseTreeView.SelectedNode.Name == "")
            {
                mainform.InsertSteamTurbine(steamTurbineUserControl, GBlock, GSiteId, ref cNode);
                TraverseTreeView.SelectedNode.Text = cNode._tText;
                TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                TraverseTreeView.SelectedNode.Name = "SteamTurbine";
                _steamTurbineNode._steamTurbineName = cNode._tName;
                generateXML.updateObject(ref _siteNode, levels, cNode._tName, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                generateXML.Create(_siteNode);
                return;
            }

            //=================== Updating CTGenerator =========================================================
            if (TraverseTreeView.SelectedNode.Name == "CTGenerator")
            {
                int CTid = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                mainform.UpdateCTGenerator(generatorUserControl, CTid, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    _ctGeneratorNode._ctGeneratorName = cNode._tName;
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }

            //Inserting data into CTGenerator table
            if (TraverseTreeView.SelectedNode.Text == "CTGenerator" && TraverseTreeView.SelectedNode.Name == "")
            {
                mainform.InsertCTGenerator(generatorUserControl, GBlock, GSiteId, GasTurbineId, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    TraverseTreeView.SelectedNode.Name = "CTGenerator";
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }

            //======== Updating value of StGenerator ====================================================
            if (TraverseTreeView.SelectedNode.Name == "STGenerator")
            {
                int STid = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                mainform.UpdateSTGenerator(generatorUserControl, STid, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    _steamTurbineNode._steamTurbineName = cNode._tName;
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }

            //Inserting data into STGenerator table
            if (TraverseTreeView.SelectedNode.Text == "STGenerator" && TraverseTreeView.SelectedNode.Name == "")
            {
                mainform.InsertSTGenerator(generatorUserControl, GBlock, GSiteId, SteamTurbineID, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    TraverseTreeView.SelectedNode.Name = "STGenerator";
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }

            //======== Updating HRSG table values ====================================================
            if (TraverseTreeView.SelectedNode.Name == "HRSG")
            {
                int hrsgId = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                mainform.UpdateHrsg(hrsgUserControl, hrsgId, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    _hrsgNode._hrsgName = cNode._tName;
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }

            //================= Inserting data into HRSG table =============================================
            if (TraverseTreeView.SelectedNode.Text == "HRSG" && TraverseTreeView.SelectedNode.Name == "")
            {
                mainform.InsertHrsg(hrsgUserControl, GBlock, GSiteId, GasTurbineId, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    TraverseTreeView.SelectedNode.Name = "HRSG";
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }

            //======== Updating Condenser table values ====================================================
            if (TraverseTreeView.SelectedNode.Name == "Condenser")
            {
                int CondenserId = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                mainform.UpdateCondenser(condenserUserControl, CondenserId, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    _condenserTreeNode._CondenserName = cNode._tName;
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }

            //Inserting data into Condenser table
            if (TraverseTreeView.SelectedNode.Text == "Condenser" && TraverseTreeView.SelectedNode.Name == "")
            {
                mainform.InsertCondenser(condenserUserControl, GBlock, GSiteId, ref cNode);
                {
                    TraverseTreeView.SelectedNode.Text = cNode._tText;
                    TraverseTreeView.SelectedNode.Tag = cNode._tTag;
                    TraverseTreeView.SelectedNode.Name = "Condenser";
                    generateXML.updateObject(ref _siteNode, levels, TraverseTreeView.SelectedNode.Text, cNode._tTag, TraverseTreeView.SelectedNode.Name);
                    generateXML.Create(_siteNode);
                }
                return;
            }
        }

        private void AddBlockMenuItem_Click(object sender, EventArgs e)
        {
            if (TraverseTreeView.SelectedNode.Text == SiteName)
            {
                TreeNode n = new TreeNode();
                n.StateImageKey = Convert.ToString(lA + "." + lB);
                n.Text = "Block";
                TraverseTreeView.Nodes[0].Nodes.Add(n);
            }
        }

        private void DeleteBlockMenuItem_Click(object sender, EventArgs e)
        {
            int level = TraverseTreeView.SelectedNode.Level;
            if (TraverseTreeView.SelectedNode.Tag != null)
            {
                string id = TraverseTreeView.SelectedNode.Tag.ToString();
            }
            if (level == 0)
            {
                int l1 = TraverseTreeView.SelectedNode.Level;
            }

            if (level == 1)
            {
                int l1 = TraverseTreeView.SelectedNode.Level;
            }
        }

        private void TraverseTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //string BlkName1 = TraverseTreeView.Nodes[0].Nodes[0].Text;
            int tIndex = TraverseTreeView.SelectedNode.Level;
            string nn = TraverseTreeView.SelectedNode.Name;
            if (tIndex == 0 || TraverseTreeView.SelectedNode.Text == "Site")
            {
                contextMenuStrip1.Items[1].Visible = true;
                //contextMenuStrip1.Items.Add("Add Block");
                if (TraverseTreeView.SelectedNode.Text != "Site")
                {
                    siteUserControl.Controls.Clear();
                    int _siID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                    using (var db = new WizardDatabaseEntities())
                    {
                        var data = from s in db.Sites
                                   where s.SiteID == _siID
                                   select s;
                        var st = data.FirstOrDefault<Site>();
                        SiteData._name = st.Name;
                        SiteData._acronym = st.Acronym;
                        SiteData._latitude = st.Latitude;
                        SiteData._longitude = st.Longitude;
                        SiteData._elevation = st.Elevation;
                        SiteData._comboBoxInterval = st.Interval;
                        SiteData._comboBoxDuration = st.Duration;
                        SiteData._comboBoxArchiveInterval = st.ArchiveInterval;
                        SiteData._comboBoxArchiveDuration = st.Archive_Duration;
                        SiteData._comboBoxGridFrequency = st.Grid_Frequency;
                        SiteData._comboBoxHeatRateUnits = st.Heat_Rate_Units;
                        SiteData._comboBoxHeatRateCalculation = st.Heat_Rate_Calculation;
                    }
                    SiteData._status = "Exist";
                }
                siteUserControl = new SiteUserControl();
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(siteUserControl);
                siteUserControl.Dock = DockStyle.Left;
                splitContainer1.Panel2.Controls.Add(saveButton);
                saveButton.Dock = DockStyle.None;

                return;
            }

            //After selecting on block
            else if (tIndex == 1 || TraverseTreeView.SelectedNode.Text == "Block")
            {
                //contextMenuStrip1.Items.RemoveAt(0);// .Remove(mnuItemNew); 
                contextMenuStrip1.Items[1].Visible = false;
                BlockData._status = "New";
                //Checking block is exist or not                
                if (Convert.ToString(TraverseTreeView.SelectedNode.Name) != "")
                {
                    blockUserControl.Controls.Clear();
                    int _blkID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                    using (var db = new WizardDatabaseEntities())
                    {
                        var data = from b in db.Blocks
                                   where b.BlockID == _blkID
                                   select b;
                        var blk = data.FirstOrDefault<Block>();
                        BlockData._name = blk.Name;
                        BlockData._acronym = blk.Acronym;
                        BlockData._blockID = blk.BlockID;
                        BlockData._typeConfig = blk.BlockType;
                        BlockData._gasTurbineType = blk.GasTurbineType;
                    }
                    BlockData._status = "Exist";
                }
                _blockNode._longName = BlockData.lname ?? "LongName";
                _blockNode._shortName = BlockData.sname ?? "ShortName";
                blockUserControl = new BlockUserControl();
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(blockUserControl);
                blockUserControl.Dock = DockStyle.Left;
                splitContainer1.Panel2.Controls.Add(saveButton);
                saveButton.Dock = DockStyle.None;
                return;
            }
            //After selecting on GasTurbine
            if (tIndex == 2 || TraverseTreeView.SelectedNode.Text == "GasTurbine")
            {
                if (nn == "GasTurbine" || TraverseTreeView.SelectedNode.Text == "GasTurbine")
                {
                    GasTurbineData._status = "New";
                    //Checking block is exist or not
                    if (Convert.ToInt32(TraverseTreeView.SelectedNode.Tag) >= 1)
                    {
                        int _gtID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        gasTurbineUserControl.Controls.Clear();
                        using (var db = new WizardDatabaseEntities())
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
                    gasTurbineUserControl = new GasTurbineUserControl(TraverseTreeView.SelectedNode.Index + 1, (int)TraverseTreeView.SelectedNode.Parent.Tag);
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
                    if (Convert.ToInt32(TraverseTreeView.SelectedNode.Parent.Tag) != 0)
                    {
                        HRSGData._status = "New";
                        //Checking block is exist or not
                        if (Convert.ToInt32(TraverseTreeView.SelectedNode.Tag) != 0)
                        {
                            int _hrID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                            hrsgUserControl.Controls.Clear();
                            using (var db = new WizardDatabaseEntities())
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
                        hrsgUserControl = new HRSGUserControl(TraverseTreeView.SelectedNode.Parent.Index + 1, (int)TraverseTreeView.SelectedNode.Parent.Parent.Tag);
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(hrsgUserControl);
                        hrsgUserControl.Dock = DockStyle.Left;
                        splitContainer1.Panel2.Controls.Add(saveButton);
                        saveButton.Dock = DockStyle.None;
                    }
                    else
                    {
                        MessageBox.Show("Please create Parent node first!");
                    }
                }
            }

            if (tIndex == 3 || TraverseTreeView.SelectedNode.Text == "CTGenerator")
            {
                if (nn == "CTGenerator" || TraverseTreeView.SelectedNode.Text == "CTGenerator")
                {
                    if (Convert.ToInt32(TraverseTreeView.SelectedNode.Parent.Tag) != 0)
                    {
                        GeneratorData._status = "New";
                        //Checking block is exist or not
                        if (TraverseTreeView.SelectedNode.Tag != null)
                        {
                            int _gtID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                            generatorUserControl.Controls.Clear();
                            using (var db = new WizardDatabaseEntities())
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
                        generatorUserControl = new GeneratorUserControl(TraverseTreeView.SelectedNode.Parent.Index + 1, (int)TraverseTreeView.SelectedNode.Parent.Parent.Tag);
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(generatorUserControl);
                        generatorUserControl.Dock = DockStyle.Left;
                        splitContainer1.Panel2.Controls.Add(saveButton);
                        saveButton.Dock = DockStyle.None;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Please create Parent node first!");
                    }
                }

            }

            if (tIndex == 3 || TraverseTreeView.SelectedNode.Text == "STGenerator")
            {
                if (nn == "STGenerator" || TraverseTreeView.SelectedNode.Text == "STGenerator")
                {
                    if (TraverseTreeView.SelectedNode.Parent.Name != "")
                    {
                        GeneratorData._status = "New";
                        //Checking block is exist or not
                        if (TraverseTreeView.SelectedNode.Name != "")
                        {
                            int _gtID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                            generatorUserControl.Controls.Clear();
                            using (var db = new WizardDatabaseEntities())
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
                        generatorUserControl = new GeneratorUserControl(TraverseTreeView.SelectedNode.Parent.Index + 1, (int)TraverseTreeView.SelectedNode.Parent.Parent.Tag);
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(generatorUserControl);
                        generatorUserControl.Dock = DockStyle.Left;
                        splitContainer1.Panel2.Controls.Add(saveButton);
                        saveButton.Dock = DockStyle.None;
                    }
                    else
                    {
                        MessageBox.Show("Please create Parent node first!");
                    }
                }
            }

            //After selecting on SteamTurbine
            else if (tIndex == 2 || TraverseTreeView.SelectedNode.Text == "SteamTurbine")
            {
                if (nn == "SteamTurbine" || TraverseTreeView.SelectedNode.Text == "SteamTurbine")
                {
                    SteamTurbineData._status = "New";
                    //Checking block is exist or not
                    //if (TraverseTreeView.SelectedNode.Text != "GasTurbine1")
                    if (Convert.ToInt32(TraverseTreeView.SelectedNode.Tag) >= 1)
                    {
                        int _stID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                        steamTurbineUserControl.Controls.Clear();
                        using (var db = new WizardDatabaseEntities())
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
                    return;
                }
            }

            //After selecting Condenser
            if (tIndex == 3 || TraverseTreeView.SelectedNode.Text == "Condenser")
            {
                if (nn == "Condenser" || TraverseTreeView.SelectedNode.Text == "Condenser")
                {
                    if (TraverseTreeView.SelectedNode.Parent.Name != "")
                    {
                        CondenserData._status = "New";
                        //Checking block is exist or not
                        if (TraverseTreeView.SelectedNode.Text != "Condenser")
                        {
                            int _conID = Convert.ToInt32(TraverseTreeView.SelectedNode.Tag);
                            condenserUserControl.Controls.Clear();
                            using (var db = new WizardDatabaseEntities())
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
                        condenserUserControl = new CondenserUserControl((int)TraverseTreeView.SelectedNode.Parent.Parent.Tag);
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(condenserUserControl);
                        condenserUserControl.Dock = DockStyle.Left;
                        splitContainer1.Panel2.Controls.Add(saveButton);
                    }
                    else
                    {
                        MessageBox.Show("Please create Parent node first!");
                    }
                }
            }
        }

        private void addVariablesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddMasterVariableForm f = new AddMasterVariableForm();
            f.Show();
        }

        private GasTurbineTree gasTurbineTreeNode(Int32 nodeInc, GasTurbine row1, Boolean flag = false)
        {
            _gasTurbineNode = new GasTurbineTree
            {
                _gasTurbineName = flag ? row1.Name : "GasTurbine",
                _gtId = flag ? row1.GasTurbineID : 0,
                _cTGeneratorTree = new CTGeneratorTree(),
                _hRSGTree = new HRSGTree(),
                level = _blockNode.level + "." + Convert.ToString(lC)
            };
            generatNode(_gasTurbineNode._gasTurbineName, _gasTurbineNode.level, Convert.ToInt32(_gasTurbineNode._gtId), "GasTurbine", flag);
            TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes.Add(node);
            return _gasTurbineNode;

        }

        private void generatNode(string text, string level, Int32 tag, string name, Boolean flag = false)
        {
            node = new TreeNode();
            node.Text = text;
            node.StateImageKey = level;
            node.Tag = tag;
            node.Name = flag ? name : "";
        }

        //Class for adding Stem turbine tree 
        private SteamTurbineTree steamTurbineTreeNode(Int32 nodeInc, SteamTurbine row, Boolean flag = false)
        {
            lC = 0;
            _steamTurbineNode = new SteamTurbineTree
            {
                _steamTurbineName = flag ? row.Name : "SteamTurbine",
                _stId = flag ? row.SteamTurbineID : 0,
                sTGeneratorTreeSteam = new STGeneratorTree(),
                _condenserTree = new CondenserTree(),
                level = _blockNode.level + "." + Convert.ToString(lC)
            };
            generatNode(_steamTurbineNode._steamTurbineName, _steamTurbineNode.level, Convert.ToInt32(_steamTurbineNode._stId), "SteamTurbine", flag);
            TraverseTreeView.Nodes[0].Nodes[nodeInc].Nodes.Add(node);
            return _steamTurbineNode;
        }

        private void OnbtnGenXMl_Click(object sender, EventArgs e)
        {
            generateXML.Create(_siteNode);
        }
    }
}
