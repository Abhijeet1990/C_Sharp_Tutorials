using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ForecastSoftware.DataStructure;

namespace ForecastSoftware
{
    public partial class ForecastForm : Form
    {
        public ForecastForm(string AccessibleName)
        {
            InitializeComponent();
            label1.Text = "Forecast for Block " + AccessibleName;
            switch(AccessibleName)
            {
                case "first":
                    Generator[] gen_case1 = new Generator[3];
                    GasTurbine[] gt_case1 = new GasTurbine[2];
                    HRSG[] hrsg_case1 = new HRSG[2];
                    SteamTurbine[] st_case1 = new SteamTurbine[1];
                    Thread t1 = new Thread(()=>FetchData(3,2,2,1));
                    t1.Start();
                    break;
                case "second":
                    Generator[] gen_case3 = new Generator[2];
                    GasTurbine[] gt_case3 = new GasTurbine[1];
                    HRSG[] hrsg_case3 = new HRSG[1];
                    SteamTurbine[] st_case3 = new SteamTurbine[1];
                    Thread t2 = new Thread(() => FetchData(2, 1, 1, 1));
                    t2.Start();
                    break;
                case "third":
                    Generator[] gen_case2 = new Generator[4];
                    GasTurbine[] gt_case2 = new GasTurbine[3];
                    HRSG[] hrsg_case2 = new HRSG[3];
                    SteamTurbine[] st_case2 = new SteamTurbine[1];
                    Thread t3 = new Thread(() => FetchData(4,3,3, 1));
                    t3.Start();
                    break;
                default:
                    Generator[] gen_case4 = new Generator[1];
                    GasTurbine[] gt_case4 = new GasTurbine[1];
                    Thread t4 = new Thread(() => FetchData(1, 1, 0, 0));
                    t4.Start();
                    break;
            }
            
        }


        public void FetchData(int genCount, int gtCount, int hrsgCount, int stCount)
        {
            //listBox1.
            Site s = new Site
            {
                Acronym = "ATA",
                SiteId = 1,
                Description = "it is a co-gen plant",
                Location = "california",
                Latitude = 42,
                Longitude = 89,
                Elevation = 56,
                GridFreq = 61.2,
                HeatRateUnitsID = 345,
                HHV = true,
                LLF = false,
                AAP = 34,
                AARH = 78,
                AAT = 56
            };

            Block b1 = new Block
            {
                BlockId = 1,
                SiteId = 1,
                BlockType = "two_one",
                SingleShaft = false
                

            };

            
          

            Generator g1 = new Generator
            {
                BlockId = 1,
                GenId = 1,
                GTId = 1,
                STId = 0,
                FullName = "GeneratorGasTurbine01",
                ShortName = "GGT01",
                MaxPowOutput = 34,
                BCT = true,
                GPOT = 45,
                SST = 3600
            };
            Generator g2 = new Generator
            {
                BlockId = 1,
                GenId = 2,
                GTId = 2,
                STId = 0,
                FullName = "GeneratorGasTurbine02",
                ShortName = "GGT02",
                MaxPowOutput = 34,
                BCT = true,
                GPOT = 45,
                SST = 3600
            };
            Generator g3 = new Generator
            {
                BlockId = 1,
                GenId = 3,
                GTId = 0,
                STId = 1,
                FullName = "GeneratorSteamTurbine01",
                ShortName = "GST01",
                MaxPowOutput = 34,
                BCT = true,
                GPOT = 45,
                SST = 3600
            };


            GasTurbine gt1 = new GasTurbine
            {
                BlockId = 1,
                GasTurbineId = 1,
                TurbineType = "gas",
                FullName = "GasTurbiune01",
                ShortName = "GT01",
                AILoss = 34,
                BLIAngle = 23,
                NormLoadMin = 21,
                OFMWGain = 34,
                SIMax = 23,
                SIMGain = 45,
                AAPT = 12,
                AARHT = 31,
                AADBTT = 32,
                AAWBTT = 2,
                AIVPT = 23,
                CDAPT = 32,
                CIADFT = 32,
                CIASHT = 25,
                CIATT = 43,
                CIGVAT = 34,
                IAHST = 34,
                EGTT = 89,
                EGTCT = 48,
                FGEIRT = 89,
                NL = 34

            };
            GasTurbine gt2 = new GasTurbine
            {
                BlockId = 1,
                GasTurbineId = 2,
                TurbineType = "gas",
                FullName = "GasTurbiune02",
                ShortName = "GT02",
                AILoss = 34,
                BLIAngle = 23,
                NormLoadMin = 21,
                OFMWGain = 34,
                SIMax = 23,
                SIMGain = 45,
                AAPT = 12,
                AARHT = 31,
                AADBTT = 32,
                AAWBTT = 2,
                AIVPT = 23,
                CDAPT = 32,
                CIADFT = 32,
                CIASHT = 25,
                CIATT = 43,
                CIGVAT = 34,
                IAHST = 34,
                EGTT = 89,
                EGTCT = 48,
                FGEIRT = 89,
                NL = 34
            };

            SteamTurbine st1 = new SteamTurbine
            {
                BlockId = 1,
                HRSGId = 1,
                STId = 1,
                FullName = "SteamTurbine01",
                ShortName = "ST01"

            };

            HRSG h1 = new HRSG
            {
                BlockId = 1,
                HRSGId = 1,
                GTId = 1,
                STId = 1,
                FullName = "HRSG01",
                ShortName = "HRSG01",
                DuctBurnMax = 34,
                DuctBurnMaxMWGain = 45,
                COEmiLimit = 23,
                NOXEmiLimit = 17,
                DBFGEIT = 34,
                DEGCCT = 32,
                DEGNCT = 21
            };
            HRSG h2 = new HRSG
            {
                BlockId = 1,
                HRSGId = 2,
                GTId = 2,
                STId = 0,
                FullName = "HRSG02",
                ShortName = "HRSG02",
                DuctBurnMax = 34,
                DuctBurnMaxMWGain = 45,
                COEmiLimit = 23,
                NOXEmiLimit = 17,
                DBFGEIT = 34,
                DEGCCT = 32,
                DEGNCT = 21
            };
            Variable v = new Variable(b1.PlantObject);
            dataGridView1.DataSource = v;


        }
    }
}
