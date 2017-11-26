using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FWA
{
    public partial class BlockUC : UserControl
    {
        public static int count = 0;
        public int storesCount;
        public BlockUC()
        {
            InitializeComponent();
            count++;
            this.storesCount = count;
        }
        public event EventHandler ConfigComboSelected;
        public event EventHandler DuctBurnerCheckBoxChecked;
        public event EventHandler SteamPowerAugCheckBoxChecked;
        public event EventHandler SteamPowerAugDBCheckBoxChecked;
        private void comboBoxConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ConfigComboSelected != null)
                this.ConfigComboSelected(this, e);
        }

        private void DuctBurnerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.DuctBurnerCheckBoxChecked != null)
                this.DuctBurnerCheckBoxChecked(this, e);
        }

        private void SteamPowerAugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SteamPowerAugCheckBoxChecked != null)
                this.SteamPowerAugCheckBoxChecked(this, e);
        }

        private void SteamPowerAugDBCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SteamPowerAugDBCheckBoxChecked != null)
                this.SteamPowerAugDBCheckBoxChecked(this, e);
        }
    }
}
