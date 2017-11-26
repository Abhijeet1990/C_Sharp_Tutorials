using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormToXML.UserControls;
using System.Xml.Serialization;
using System.IO;
using static FormToXML.Infrastructure.ClassContainer;

namespace FormToXML
{
    public partial class Form1 : Form
    {
        int blockCount = 0;
        int objCount = 0;
        SiteUserControl siteUserControl = new SiteUserControl();
        BlockUserControl blockUserControl = new BlockUserControl();
        ObjectUserControl objectUserControl = new ObjectUserControl();
        Site site;
        Block block;
        PlantObject po;
        

        string SiteName;
        string BlockName;
        string PlantObjectName;

        public static string CONFIG_FNAME = "config.xml";


        public Form1()
        {
            InitializeComponent();
            splitContainer1.Panel2.Controls.Clear();
            splitContainer1.Panel2.Controls.Add(siteUserControl);
            siteUserControl.Dock = DockStyle.Left;
            splitContainer1.Panel2.Controls.Add(saveButton);
            saveButton.Dock = DockStyle.None;
            treeView1.ContextMenuStrip = AddBlockMenuStrip;
            //treeView1.ContextMenuStrip = AddObjectMenuStrip;
            //if (treeView1.SelectedNode.Name == "Root")
            //{
            //    treeView1.ContextMenuStrip = AddBlockMenuStrip;
            //}
            //else if(treeView1.SelectedNode.Name.Contains("Block"))
            //{
            //    treeView1.ContextMenuStrip = AddObjectMenuStrip;
            //}

        }

        private void AddBlock_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(treeView1.SelectedNode.Text);
            if (treeView1.SelectedNode.Text == SiteName)
            {
                treeView1.Nodes[0].Nodes.Add("Block");
                treeView1.Nodes[0].Nodes[blockCount].Name = "Block" + (blockCount+1).ToString();
            }
            blockCount++;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Name);
            if (treeView1.SelectedNode.Name == "Root")
            {
                SiteName = siteUserControl.textBox1.Text;
                treeView1.SelectedNode.Text = SiteName;
                site = new Site { SiteName = SiteName };
                //Start Adding to the XML File
                SaveToXML(ref site);
            }
            if (treeView1.SelectedNode.Name.Contains("Block"))
            {
                BlockName = blockUserControl.textBox1.Text;
                treeView1.SelectedNode.Text = BlockName;
                
                block = new Block { BlockName = BlockName };
                site.Blocks.Add(block);
                SaveToXML(ref site);

            }
            if (treeView1.SelectedNode.Name.Contains("Object"))
            {
                PlantObjectName = objectUserControl.textBox1.Text;
                treeView1.SelectedNode.Text = PlantObjectName;

                po = new PlantObject { ObjectName = PlantObjectName };
                block.Objects.Add(po);
                SaveToXML(ref site);

            }


        }
        

        private void SaveToXML<T>(ref T obj)
        {
            if (!File.Exists(CONFIG_FNAME))
            {
                using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Create))
                {
                    if (treeView1.SelectedNode.Name == "Root")
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(Site));
                        xs.Serialize(fs, obj);
                    }
                }

            }
            else
            {
                using (FileStream fs = new FileStream(CONFIG_FNAME, FileMode.Open))
                {
                    if (treeView1.SelectedNode.Name != "Root")
                    {

                        XmlSerializer xs = new XmlSerializer(typeof(Site));
                        xs.Serialize(fs, obj);
                    }
                    
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(treeView1.SelectedNode.Text==SiteName)
            {
                treeView1.ContextMenuStrip = AddBlockMenuStrip;
                siteUserControl = new SiteUserControl();
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(siteUserControl);
                siteUserControl.Dock = DockStyle.Left;
                splitContainer1.Panel2.Controls.Add(saveButton);
                saveButton.Dock = DockStyle.None;

            }
            else if(treeView1.SelectedNode.Name.Contains("Block"))
            {
                treeView1.ContextMenuStrip = AddObjectMenuStrip;
                blockUserControl = new BlockUserControl();
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(blockUserControl);
                siteUserControl.Dock = DockStyle.Left;
                splitContainer1.Panel2.Controls.Add(saveButton);
                saveButton.Dock = DockStyle.None;
            }
            else if (treeView1.SelectedNode.Name.Contains("Object"))
            {
                objectUserControl = new ObjectUserControl();
                splitContainer1.Panel2.Controls.Clear();
                splitContainer1.Panel2.Controls.Add(objectUserControl);
                siteUserControl.Dock = DockStyle.Left;
                splitContainer1.Panel2.Controls.Add(saveButton);
                saveButton.Dock = DockStyle.None;
            }
        }

        private void AddPlantObjectMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Name.Contains("Block"))
            {
                treeView1.SelectedNode.Nodes.Add("Object");
                treeView1.Nodes[0].Nodes[blockCount-1].Nodes[objCount].Name = "Object" + (objCount + 1).ToString();
            }
            objCount++;
        }
    }
}
