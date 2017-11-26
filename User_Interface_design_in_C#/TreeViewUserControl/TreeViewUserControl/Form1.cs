using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewUserControl
{
    public partial class Form1 : Form
    {
        TestUserControl TUC = new TestUserControl();
        List<TestUserControl> TUCList = new List<TestUserControl>();
        List<BlockUserControl> BUCList = new List<BlockUserControl>();
        public Form1()
        {
            InitializeComponent();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(TUC);
            splitContainer1.Panel2.VerticalScroll.Enabled = true;
            treeView1.ContextMenuStrip = contextMenuStrip1;
            
        }
        protected void textBoxChanged(object sender, EventArgs e,BlockUserControl BUC,TreeNode AssociatedNode)
        {
            AssociatedNode.Text = BUC.textBox1.Text;
        }

        protected void ChildtextBoxChanged(object sender, EventArgs e, ChildUserControl CUC, TreeNode AssociatedNode)
        {
            AssociatedNode.Text = CUC.childNameTextBox.Text;
        }
        protected void GrandChildtextBoxChanged(object sender, EventArgs e, GrandChildUserControl GCUC, TreeNode AssociatedNode)
        {
            AssociatedNode.Text = GCUC.GrandchildNameTextBox.Text;
        }
        protected void createChildNodes(object sender, EventArgs e, BlockUserControl BUC, TreeNode AssociatedNode)
        {
            int childcount;
            //reset from User control List
            BUC.CUCList.Clear();
            //reset from the tree view
            AssociatedNode.Nodes.Clear();
            childcount = BUC.comboBox1.SelectedIndex + 1;
            //MessageBox.Show(childcount.ToString());
            //create an array of child node tree and array of child user control
            TreeNode[] ChildNodes = new TreeNode[childcount];
            for (int i = 0; i < childcount; i++)
            {
                ChildNodes[i] = new TreeNode("Child"+ (i + 1).ToString());
                ChildNodes[i].Name = ChildNodes[i].Text;
                AssociatedNode.Nodes.Add(ChildNodes[i]);
                ChildUserControl c = new ChildUserControl(BUC.BlockID,1);
                c.Name = ChildNodes[i].Name;
                BUC.CUCList.Add(c);
            }
            
        }
        protected void createGrandChildNodes(object sender, EventArgs e, ChildUserControl CUC, TreeNode AssociatedNode)
        {
            int Grandchildcount;
            //reset from usercontrol List
            CUC.GCUCList.Clear();
            //reset from the tree view
            AssociatedNode.Nodes.Clear();
            Grandchildcount = CUC.comboBox1.SelectedIndex + 1;
            //MessageBox.Show(childcount.ToString());
            //create an array of child node tree and array of child user control
            TreeNode[] GrandChildNodes = new TreeNode[Grandchildcount];
            for (int i = 0; i < Grandchildcount; i++)
            {
                GrandChildNodes[i] = new TreeNode("Grand" + (i + 1).ToString());
                GrandChildNodes[i].Name = GrandChildNodes[i].Text;
                AssociatedNode.Nodes.Add(GrandChildNodes[i]);
                GrandChildUserControl gc = new GrandChildUserControl(CUC.ChildID,CUC.BlockID ,1);
                gc.Name = GrandChildNodes[i].Name;
                CUC.GCUCList.Add(gc);
            }

        }

        protected void updateStatusinTree(object sender, EventArgs e, TreeNode AssociatedNode)
        {
            AssociatedNode.SelectedImageIndex = 2;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeNode BlockNode = new TreeNode("Block");
            BlockUserControl BUC = new BlockUserControl(1);
            BUC.Name = BlockNode.Text + BUC.BlockID.ToString();
            BlockNode.Name = BUC.Name;
            treeView1.Nodes[0].Nodes.Add(BlockNode);
            this.BUCList.Add(BUC);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox.Show(e.Node.Name);
            if (e.Node.Name.Contains("Site"))
            {
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(TUC);
            }
            else if (e.Node.Name.Contains("Block"))
            {
                foreach(var id in this.BUCList)
                {
                    if(e.Node.Name==id.Name)
                    {
                        splitContainer1.Panel2.Controls.Clear();
                        splitContainer1.Panel2.Controls.Add(id);

                        //MessageBox.Show(e.Node.Name+id.Name);
                        id.textBoxChanged += new EventHandler((sender1, e1) => textBoxChanged(sender1, e1, id,e.Node));
                        id.childNodeCBChanged +=new EventHandler((sender1, e1) => createChildNodes(sender1, e1, id, e.Node));
                        id.changeOfBlockConfigured += new EventHandler((sender1, e1) => updateStatusinTree(sender1, e1, e.Node));
                        id.StatusUpdate += new StatusUpdateEventHandler((object sender1,Data e1) => MessageBox.Show(e1.ChildName+" status is "+e1.status.ToString() ));
                    }
                }
               
            }
            else if(e.Node.Name.Contains("Child"))
            {

               // MessageBox.Show(e.Node.Text);
                foreach(var id in this.BUCList)
                {
                    if(e.Node.Parent.Name==id.Name)
                    {
                        //MessageBox.Show(e.Node.Parent.Name + id.Name);
                        foreach (var childid in id.CUCList)
                        {
                            if(e.Node.Name==childid.Name)
                            {
                                splitContainer1.Panel2.Controls.Clear();
                                splitContainer1.Panel2.Controls.Add(childid);
                                childid.Status.Text = "My Parent name Based on tree is " + e.Node.Parent.Name + " Based on UC is " + id.Name;
                                childid.textBoxChanged += new EventHandler((sender1, e1) => ChildtextBoxChanged(sender1, e1, childid, e.Node));
                                childid.GrandchildNodeCBChanged += new EventHandler((sender1, e1) => createGrandChildNodes(sender1, e1, childid, e.Node));
                            }
                        }
                    }
                }
            }
            else if(e.Node.Name.Contains("Grand"))
            {
                //MessageBox.Show("It is a Grand Child");
                foreach (var id in this.BUCList)
                {
                    if (e.Node.Parent.Parent.Name == id.Name)
                    {
                        //MessageBox.Show(e.Node.Parent.Name + id.Name);
                        foreach (var childid in id.CUCList)
                        {
                            if (e.Node.Parent.Name == childid.Name)
                            {
                               foreach(var grandchildid in childid.GCUCList)
                                {
                                    if(e.Node.Name==grandchildid.Name)
                                    {
                                        splitContainer1.Panel2.Controls.Clear();
                                        splitContainer1.Panel2.Controls.Add(grandchildid);
                                        grandchildid.Status.Text = "My Parent name Based on tree is " + e.Node.Parent.Name + " Based on UC is " + childid.Name;
                                        grandchildid.textBoxChanged += new EventHandler((sender1, e1) => GrandChildtextBoxChanged(sender1, e1, grandchildid, e.Node));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Test");
            foreach(var Block in this.BUCList)
            {
                //MessageBox.Show(Block.isBlockConfigured.ToString());
                if(!Block.isBlockConfigured)
                {
                    treeView1.Nodes[0].SelectedImageIndex = 1;
                }
                else
                {
                    treeView1.Nodes[0].SelectedImageIndex = 2;
                }
            }
        }
    }
}
