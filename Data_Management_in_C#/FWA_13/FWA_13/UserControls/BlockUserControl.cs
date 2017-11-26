using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FWA_13.Infrastructure;
using FWD;

namespace FWA_13
{
    public partial class BlockUserControl : UserControl
    {
        public new MainForm ParentForm { get; set; }

        public class Status:EventArgs
        {
            public bool spiChecked;
        }

        public event SteamPowerInjectionCheckedHandler SteamPowerInjectionChecked;

        public delegate void SteamPowerInjectionCheckedHandler(object sender, Status s);
        
        

        public BlockUserControl()
        {
            InitializeComponent();
            if (BlockData._status == "Exist")
                PopulateData();
        }

        public void PopulateData()
        {
            if (BlockData._name != null)
                textBoxName.Text = BlockData._name.ToString();
            comboBoxConfig.SelectedValue = BlockData._typeConfig.ToString();
        }
        
        private void comboBoxConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            ForecastAppDatabaseEntities db = new ForecastAppDatabaseEntities();
            List<TrainMapping> TrainMappingLists = db.TrainMappings.ToList();

            switch (this.comboBoxConfig.SelectedIndex)
            {
                case 0:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 1 select c).Max(c => c.GasTurbineID);
                        //MessageBox.Show(GTCount.ToString());
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 1 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 1:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 2 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 2 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 2:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 3 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 3 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 3:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 4 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 4 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        break;
                    }
                case 4:
                    {
                        var GTCount = (from c in db.TrainMappings where c.BlockTypeID == 5 select c).Max(c => c.GasTurbineID);
                        var STCount = (from c in db.TrainMappings where c.BlockTypeID == 5 select c).Max(c => c.SteamTurbineID);
                        BlockConfiguration.GTCount1 = GTCount;
                        BlockConfiguration.STCount1 = STCount;
                        //for (int i = 0; i < GTCount; i++)
                        //{
                        //    TreeNode GasTurbineNode = new TreeNode();
                        //    GasTurbineNode.Text = "GasTurbine" + (i + 1).ToString();
                        //    GasTurbineNode.Name = GasTurbineNode.Text;
                        //}
                        //TreeNode SteamTurbineNode = new TreeNode();
                        //SteamTurbineNode.Text = "SteamTurbine1";
                        //SteamTurbineNode.Name = SteamTurbineNode.Text;
                        break;
                    }
            }
        }

        private void SteamPowerAugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Status s = new Status();
            if(this.SteamPowerAugCheckBox.Checked)
            {
                s.spiChecked = true;
            }
            else
            {
                s.spiChecked = false;
            }
            if(this.SteamPowerInjectionChecked!=null)
            {
                this.SteamPowerInjectionChecked(sender, s);
            }
        }
    }
}
