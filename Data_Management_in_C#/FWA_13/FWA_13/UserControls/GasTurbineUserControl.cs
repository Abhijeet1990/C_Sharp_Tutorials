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

namespace FWA_13.UserControls
{
    public partial class GasTurbineUserControl : UserControl
    {

        GroupBox AmbientAirGroupBox = new GroupBox();
        GroupBox CompressedInletAirGroupBox = new GroupBox();
        GroupBox CompressorGroupBox = new GroupBox();
        GroupBox CombusterShellGroupBox = new GroupBox();
        GroupBox FuelGasGroupBox = new GroupBox();
        GroupBox TurbineGroupBox = new GroupBox();
        GroupBox NormalizedLoadGroupBox = new GroupBox();
        public GroupBox SteamPowerAugmentationGroupBox = new GroupBox();
        public GasTurbineUserControl()
        {
            InitializeComponent();
            if (GasTurbineData._status == "Exist")
                PopulateData();


            
        }

        public void PopulateData()
        {
            if (GasTurbineData._name != null)
            {
                txtGasTurbineLongName.Text = GasTurbineData._name.ToString();
                txtGasTurbineShortName.Text = GasTurbineData._acronym.ToString();
            }
        }

        private void GasTurbineUserControl_Load(object sender, EventArgs e)
        {
            //populating Tags
            AmbientAirGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AmbientAirGroupBox.Text = "Ambient Air Tags";

            this.GasTurbineTagsGroupBox.Controls.Add(AmbientAirGroupBox);
            AmbientAirGroupBox.Location = new Point(20, 20);
            TagCollectorUserControl[] AmbientAirTag = new TagCollectorUserControl[4];
            for (int i = 0; i < AmbientAirTag.Length; i++)
            {
                AmbientAirTag[i] = new TagCollectorUserControl();
            }
            AmbientAirTag[0].VariableName.Text = "Temperature (Dry Bulb)";
            AmbientAirTag[1].VariableName.Text = "Temperature (Wet Bulb)";
            AmbientAirTag[2].VariableName.Text = "Relative Humidity";
            AmbientAirTag[3].VariableName.Text = "Ambient Pressure";
            for (int i = 0; i < AmbientAirTag.Length; i++)
            {
                AmbientAirGroupBox.Controls.Add(AmbientAirTag[i]);
                if (i == 0)
                {
                    AmbientAirTag[i].Location = new Point(20, 20);
                }
                else
                {
                    AmbientAirTag[i].Location = new Point(20, AmbientAirTag[i - 1].Bottom);
                }

            }
            //Place Compressed Inlet Air GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            CompressedInletAirGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CompressedInletAirGroupBox.Text = "Compressed Inlet Air Tags";
            this.GasTurbineTagsGroupBox.Controls.Add(CompressedInletAirGroupBox);
            CompressedInletAirGroupBox.Location = new Point(20, AmbientAirGroupBox.Bottom);
            TagCollectorUserControl[] CompressedInletAirTag = new TagCollectorUserControl[3];
            for (int i = 0; i < CompressedInletAirTag.Length; i++)
            {
                CompressedInletAirTag[i] = new TagCollectorUserControl();
            }
            CompressedInletAirTag[0].VariableName.Text = "Temperature";
            CompressedInletAirTag[1].VariableName.Text = "Specific Humidity";
            CompressedInletAirTag[2].VariableName.Text = "Differential Pressure";

            for (int i = 0; i < CompressedInletAirTag.Length; i++)
            {
                CompressedInletAirGroupBox.Controls.Add(CompressedInletAirTag[i]);
                if (i == 0)
                {
                    CompressedInletAirTag[i].Location = new Point(20, 20);
                }
                else
                {
                    CompressedInletAirTag[i].Location = new Point(20, CompressedInletAirTag[i - 1].Bottom);
                }

            }


            //Compressor GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            CompressorGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CompressorGroupBox.Text = "Compressor Tags";
            this.GasTurbineTagsGroupBox.Controls.Add(CompressorGroupBox);
            CompressorGroupBox.Location = new Point(20, CompressedInletAirGroupBox.Bottom);
            TagCollectorUserControl CompressorTag = new TagCollectorUserControl();
            CompressorTag.VariableName.Text = "Inlet Guide Vane Angle";
            CompressorGroupBox.Controls.Add(CompressorTag);
            CompressorTag.Location = new Point(20, 20);

            //Place Combustor shell..Similarly we need to do for other tags
            CombusterShellGroupBox.AutoSize = true;
            CombusterShellGroupBox.Text = "Combustor Shell Tags";
            this.GasTurbineTagsGroupBox.Controls.Add(CombusterShellGroupBox);
            CombusterShellGroupBox.Location = new Point(20, CompressorGroupBox.Bottom);
            TagCollectorUserControl[] CombusterShellTag = new TagCollectorUserControl[2];
            for (int i = 0; i < CombusterShellTag.Length; i++)
            {
                CombusterShellTag[i] = new TagCollectorUserControl();
            }
            CombusterShellTag[0].VariableName.Text = "Pressure";
            CombusterShellTag[1].VariableName.Text = "Temperature";

            for (int i = 0; i < CombusterShellTag.Length; i++)
            {
                CombusterShellGroupBox.Controls.Add(CombusterShellTag[i]);
                if (i == 0)
                {
                    CombusterShellTag[i].Location = new Point(20, 20);
                }
                else
                {
                    CombusterShellTag[i].Location = new Point(20, CombusterShellTag[i - 1].Bottom);
                }

            }

            //FuelGas GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            FuelGasGroupBox.AutoSize = true;
            FuelGasGroupBox.Text = "Fuel Gas Tags";
            this.GasTurbineTagsGroupBox.Controls.Add(FuelGasGroupBox);
            FuelGasGroupBox.Location = new Point(20, CombusterShellGroupBox.Bottom);
            TagCollectorUserControl FuelGasTag = new TagCollectorUserControl();
            FuelGasTag.VariableName.Text = "Energy Input Rate";
            FuelGasGroupBox.Controls.Add(FuelGasTag);
            FuelGasTag.Location = new Point(20, 20);



            //Place TurbineGroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags

            TurbineGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TurbineGroupBox.Text = "Turbine Tags";
            this.GasTurbineTagsGroupBox.Controls.Add(TurbineGroupBox);
            TurbineGroupBox.Location = new Point(20, FuelGasGroupBox.Bottom);
            TagCollectorUserControl[] TurbineTag = new TagCollectorUserControl[4];
            for (int i = 0; i < TurbineTag.Length; i++)
            {
                TurbineTag[i] = new TagCollectorUserControl();
            }
            TurbineTag[0].VariableName.Text = "Temp Control Flag";
            TurbineTag[1].VariableName.Text = "Blade Path Temp";
            TurbineTag[2].VariableName.Text = "Exhaust Gas Temp";
            TurbineTag[3].VariableName.Text = "Exhaust Gas Diff Press";
            for (int i = 0; i < TurbineTag.Length; i++)
            {
                TurbineGroupBox.Controls.Add(TurbineTag[i]);
                if (i == 0)
                {
                    TurbineTag[i].Location = new Point(20, 20);
                }
                else
                {
                    TurbineTag[i].Location = new Point(20, TurbineTag[i - 1].Bottom);
                }

            }

            //NormalizedLoad GroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags
            NormalizedLoadGroupBox.AutoSize = true;
            NormalizedLoadGroupBox.Text = "Normalized Load Tags";
            this.GasTurbineTagsGroupBox.Controls.Add(NormalizedLoadGroupBox);
            NormalizedLoadGroupBox.Location = new Point(20, TurbineGroupBox.Bottom);
            TagCollectorUserControl NormalizedLoadTag = new TagCollectorUserControl();
            NormalizedLoadTag.VariableName.Text = "Normalized Load";
            NormalizedLoadGroupBox.Controls.Add(NormalizedLoadTag);
            NormalizedLoadTag.Location = new Point(20, 20);



            //Place SteamPowerAugmentationGroupBox inside Gas Turbine Tag ...Similarly we need to do for other tags

            SteamPowerAugmentationGroupBox.AutoSize = true;
            //AmbientAirGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            SteamPowerAugmentationGroupBox.Text = "Steam Power Augmentation Tags";
            this.GasTurbineTagsGroupBox.Controls.Add(SteamPowerAugmentationGroupBox);
            SteamPowerAugmentationGroupBox.Location = new Point(20, NormalizedLoadGroupBox.Bottom);
            TagCollectorUserControl[] SteamPowerAugmentationTag = new TagCollectorUserControl[4];
            for (int i = 0; i < SteamPowerAugmentationTag.Length; i++)
            {
                SteamPowerAugmentationTag[i] = new TagCollectorUserControl();
            }
            SteamPowerAugmentationTag[0].VariableName.Text = "Isolator Valve Closed";
            SteamPowerAugmentationTag[1].VariableName.Text = "Steam Temperature";
            SteamPowerAugmentationTag[2].VariableName.Text = "Steam Pressure";
            SteamPowerAugmentationTag[3].VariableName.Text = "Steam Mass Flow Rate";
            for (int i = 0; i < SteamPowerAugmentationTag.Length; i++)
            {
                SteamPowerAugmentationGroupBox.Controls.Add(SteamPowerAugmentationTag[i]);
                if (i == 0)
                {
                    SteamPowerAugmentationTag[i].Location = new Point(20, 20);
                }
                else
                {
                    SteamPowerAugmentationTag[i].Location = new Point(20, SteamPowerAugmentationTag[i - 1].Bottom);
                }

            }
            //SteamPowerAugmentationGroupBox.Enabled = false;
        }
    }
}
