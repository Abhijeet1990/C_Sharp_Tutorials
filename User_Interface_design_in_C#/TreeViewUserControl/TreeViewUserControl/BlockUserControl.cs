using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeViewUserControl
{
    //class to send the status data to the main form
    
    public partial class BlockUserControl : UserControl
    {
        public int BlockID;
        public int SiteID;
        public static int count = 0;
        public event EventHandler textBoxChanged;
        public event EventHandler childNodeCBChanged;
        public event EventHandler changeOfBlockConfigured;
        public List<ChildUserControl> CUCList = new List<ChildUserControl>();
        public bool isBlockConfigured=false;
        public event StatusUpdateEventHandler StatusUpdate;

        

        public BlockUserControl(int x)
        {
            InitializeComponent();
            count++;
            this.BlockID = count;
            this.SiteID = x;


            
        }


        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxChanged != null)
                this.textBoxChanged(this, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.childNodeCBChanged != null)
                this.childNodeCBChanged(this, e);
        }

        private void blockSaveButton_Click(object sender, EventArgs e)
        {
            //in this save event we can call a function which will check the field of mandatory attribute nd comply the information through a class 
            Data status = new TreeViewUserControl.Data();
            foreach (var child in this.CUCList)
            {
                if (!child.TestingCheckBoxChecked)
                {
                    this.isBlockConfigured = false;
                    status.status = false;
                    status.ChildName = child.Name;
                    if (this.StatusUpdate != null)
                        this.StatusUpdate(this, status);
                    break;
                }
                else
                {
                    this.isBlockConfigured = true;
                    
                }
            }
            if (this.isBlockConfigured)
            {
                this.label3.Text = "All child Configured";
                if (this.changeOfBlockConfigured != null)
                    this.changeOfBlockConfigured(this, e);
            }



            using (var db = new ABC())
            {
                var name = textBox1.Text;
                //var siteid = this.SiteCount;
                var Block = new Block
                {
                    BlockID = this.BlockID,
                    Name = name,
                    SiteID = this.SiteID
                    //UseMetricUnits = useMetric
                };
                db.Blocks.Add(Block);
                db.SaveChanges();

            }
        }

        private void TestingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TestingCheckBox.Checked)
            {
                foreach(var child in this.CUCList)
                {
                    child.TestingGroupBox.Enabled = true;
                }
            }
        }

        private void BlockUserControl_Load(object sender, EventArgs e)
        {
            
            
            
        }
    }

    public class Data : EventArgs
    {
        public bool status;
        public string ChildName;
    }

    public delegate void StatusUpdateEventHandler(object o, Data d);
}
