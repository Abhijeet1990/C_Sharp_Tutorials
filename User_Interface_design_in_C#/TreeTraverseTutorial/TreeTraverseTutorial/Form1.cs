using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeTraverseTutorial
{
    public partial class Form1 : Form
    {
        public static int blockCount = 0;
        public static int unitCount = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void AddSiteButton_Click(object sender, EventArgs e)
        {
            treeView1.Nodes[0].Text = siteAttrib2TextBox.Text;
            treeView1.Nodes[0].Name = SiteAttrib1TextBox.Text;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Name== SiteAttrib1TextBox.Text)
            {
                tabControl1.SelectedIndex = 0;
            }
            else if(e.Node.Parent.Name==SiteAttrib1TextBox.Text)
            {
                tabControl1.SelectedIndex = 1;
                var BlockTag = e.Node.Tag;
                if(BlockTag is Block)
                {
                    var BlockObject = (Block)BlockTag;
                    tabControl1.TabPages[1].Text = e.Node.Text;
                    blockAttrib2TextBox.Text = BlockObject.Name;
                    blockAttrib1TextBox.Text = BlockObject.Alias;
                }
                //TreeNode[] found = treeView1.Nodes.Find(e.Node.Name, true);
                //if (e.Node.Name==)
            }
            else
            {
                TreeNode[] found = treeView1.Nodes.Find(e.Node.Name, true);
                var UnitTag = e.Node.Tag;
                if(UnitTag is Unit)
                {
                    var UnitObject = (Unit)UnitTag;
                    tabControl1.TabPages[1].Text = e.Node.Parent.Text;
                    
                    unitAttrib1TextBox.Text = UnitObject.Alias;
                    unitAttrib2textBox.Text = UnitObject.Name;
                    blockAttrib2TextBox.Text = UnitObject.BlockName;
                    blockAttrib1TextBox.Text = UnitObject.BlockAlias;
                }
            }

        }

        private void AddBlockButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            TreeNode BlockNode = new TreeNode(blockAttrib1TextBox.Text);
            BlockNode.Name = blockAttrib2TextBox.Text;
            MessageBox.Show(BlockNode.Name);
            //BlockNode.Name = blockAttrib2TextBox.Name;
            blockCount++;
            BlockNode.Tag = new Block
            {
                
                Name = blockAttrib2TextBox.Text,
                Alias = blockAttrib1TextBox.Text,
                
            };
            treeView1.Nodes[0].Nodes.Add(BlockNode);
            //TreeNode ConfigureNode = new TreeNode();
            //TreeNode ForecastNode = new TreeNode();
            //TreeNode VariableNode = new TreeNode();
            //ConfigureNode.Text = "Configure Units";
            //ConfigureNode.Name = "Configure";
            //VariableNode.Text = "Variable";
            //VariableNode.Name = "Variable";
            //ForecastNode.Text = "Forecast";
            //ForecastNode.Name = "Forecast";
            //BlockNode.Nodes.Add(ConfigureNode);
            //BlockNode.Nodes.Add(VariableNode);
            //BlockNode.Nodes.Add(ForecastNode);
        }



        private void AddUnitButton_Click(object sender, EventArgs e)
        {

            TreeNode[] found = treeView1.Nodes.Find(blockAttrib2TextBox.Text, true);
            MessageBox.Show(found[0].Name);
            // Do something with the found node - e.g. add just another node to the found node.
            TreeNode unit = new TreeNode(unitAttrib1TextBox.Text);
            
            unit.Name = unitAttrib2textBox.Text;
            unit.Tag = new Unit
            {
                Name = unitAttrib2textBox.Text,
                Alias = unitAttrib1TextBox.Text,
                BlockName = blockAttrib2TextBox.Text,
                BlockAlias = blockAttrib1TextBox.Text
            };
            found[0].Nodes.Add(unit);

            
        }
      }
    }

