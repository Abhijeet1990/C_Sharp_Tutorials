using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicTreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            const string nodeKey = "hostNode";

            TreeNode tn1 = new TreeNode("My Node");
            tn1.Name = nodeKey; // This is the name (=key) for the node.

            TreeNode tn2 = new TreeNode("My Node2");
            tn2.Name = "otherKey"; // This is the key for node 2.

            treeView1.Nodes.Add(tn1); // Add node1.
            treeView1.Nodes.Add(tn2); // Add node2.


            // Find node by name (=key). Use the key specified above for tn1.
            // If key is not unique you will get more than one node here.
            TreeNode[] found = treeView1.Nodes.Find(nodeKey, true);

            // Do something with the found node - e.g. add just another node to the found node.
            TreeNode newChild = new TreeNode("A Child");
            newChild.Name = "newChild";

            found[0].Nodes.Add(newChild);
        }
    }
}
