using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForecast
{
    class Program
    {
        static void Main(string[] args)
        {

            Site s = new Site
            {
                Acronym = "ATA",
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
                BlockType="two_one",
                //BlockType = args[0],
                SingleShaft = false,
                //GenList=genList,
                //GTList=gtList,
                //HRSGList=hrsgList,
                //STList=stList

            };
            /*
            //Based on the wizard selection the number of objects that are created would differ
            switch(b1.BlockType)
            {
                case "two_one":
                    Generator[] gen_case1 = new Generator[3];
                    GasTurbine[] gt_case1 = new GasTurbine[2];
                    HRSG[] hrsg_case1 = new HRSG[2];
                    SteamTurbine[] st_case1 = new SteamTurbine[1];
                    break;
                case "three_one":
                    Generator[] gen_case2 = new Generator[4];
                    GasTurbine[] gt_case2 = new GasTurbine[3];
                    HRSG[] hrsg_case2 = new HRSG[3];
                    SteamTurbine[] st_case2 = new SteamTurbine[1];
                    break;
                case "one_one":
                    Generator[] gen_case3 = new Generator[2];
                    GasTurbine[] gt_case3 = new GasTurbine[1];
                    HRSG[] hrsg_case3 = new HRSG[1];
                    SteamTurbine[] st_case3 = new SteamTurbine[1];
                    break;
                default:
                    Generator[] gen_case4 = new Generator[1];
                    GasTurbine[] gt_case4 = new GasTurbine[1];
                    break;
            
            }
            */

            Generator g1 = new Generator
            {
                BlockId = 1,
                GenId =1,
                GTId =1,
                STId =0,
                FullName ="GeneratorGasTurbine01",
                ShortName ="GGT01",
                MaxPowOutput =34,
                BCT =true,
                GPOT =45,
                SST =3600
            };
            Generator g2 = new Generator
            {
                BlockId = 1,
                GenId = 2,
                GTId =2,
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
                BLIAngle =23,
                NormLoadMin =21,
                OFMWGain=34,
                SIMax=23,
                SIMGain=45,
                AAPT=12,
                AARHT=31,
                AADBTT=32,
                AAWBTT=2,
                AIVPT=23,
                CDAPT=32,
                CIADFT=32,
                CIASHT=25,
                CIATT=43,
                CIGVAT=34,
                IAHST=34,
                EGTT=89,
                EGTCT=48,
                FGEIRT=89,
                NL=34

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
                BlockId=1,
                HRSGId=1,
                STId=1,
                FullName="SteamTurbine01",
                ShortName="ST01"

            };
        
            HRSG h1 = new HRSG
            {
                BlockId=1,
                HRSGId=1,
                GTId=1,
                STId=1,
                FullName="HRSG01",
                ShortName="HRSG01",
                DuctBurnMax=34,
                DuctBurnMaxMWGain=45,
                COEmiLimit=23,
                NOXEmiLimit=17,
                DBFGEIT=34,
                DEGCCT=32,
                DEGNCT=21
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
            List<Generator> genList = new List<Generator>();
            genList.Add(g1);
            genList.Add(g2);
            genList.Add(g3);

            List<GasTurbine> gtList = new List<GasTurbine>();
            gtList.Add(gt1);
            gtList.Add(gt2);

            List<HRSG> hrsgList = new List<HRSG>();
            hrsgList.Add(h1);
            hrsgList.Add(h2);

            List<SteamTurbine> stList = new List<SteamTurbine>();
            stList.Add(st1);    

            b1.Map(genList, gtList, hrsgList, stList);

            /*
            foreach(Generator i in genList)
            {
                foreach(PropertyDescriptor descriptor in TypeDescriptor.GetProperties(i) )
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(i);
                    Console.WriteLine("{0}={1}", name, value);
                }
            }*/
            foreach (object i in b1.PlantObject)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(i))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(i);
                    Console.WriteLine("{0}={1}", name, value);
                }
            }

            /*

            foreach(List<Generator> i in b1.PlantObject)
            {
                foreach (var attrib in i)
                {
                    Console.WriteLine(attrib);
                }
            }
            */
            Variable v = new Variable(b1.PlantObject);
            Console.ReadLine();
        }


        public class Site
        {

            public string Acronym { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
            public decimal Elevation { get; set; }
            public double GridFreq { get; set; }
            //not sure of this attribute
            public int HeatRateUnitsID { get; set; }
            //High heating value
            public bool HHV { get; set; }
            //Low Load Forecasting
            public bool LLF { get; set; }

            ////////Block Tag Attributes////////////
            //Ambient Air Pressure
            public decimal AAP { get; set; }
            //Ambient Air Relative Humidity
            public decimal AARH { get; set; }
            //Ambient Air Temperature
            public decimal AAT { get; set; }

        }


        public class GasTurbine
        {
            //fill this with Gas Turbine Atrribute
            public int BlockId { get; set; }
            public int GasTurbineId { get; set; }
            public string TurbineType { get; set; }
            public string FullName { get; set; }
            public string ShortName { get; set; }
            //Anti Icing MW Loss
            public decimal AILoss { get; set; }
            //Base Load IGV Angle
            public decimal BLIAngle { get; set; }
            //Normalized Load Min
            public decimal NormLoadMin { get; set; }
            //Overfitting MW Gain
            public decimal OFMWGain { get; set; }
            //Steam Injection Max
            public decimal SIMax { get; set; }
            //Steam Injection MW Gain
            public decimal SIMGain { get; set; }


            /////GT Tag Attribute////////////
            //Amb Air Press Tag 
            public decimal AAPT { get; set; }
            //Amb Air Rel Humid Tag
            public decimal AARHT { get; set; }
            //Amb Air Dry Bulb Temp Tag
            public decimal AADBTT { get; set; }
            //Amb Air Dry Bulb Temp Tag
            public decimal AAWBTT { get; set; }
            //Anti Icing Valve Position Tag
            public decimal AIVPT { get; set; }
            //Comp Disch Air Press Tag
            public decimal CDAPT { get; set; }
            //Comp Inlet Air Diff Press Tag
            public decimal CIADFT { get; set; }
            //Comp Inlet Air Spec Humid Tag
            public decimal CIASHT { get; set; }
            //Comp Inlet Air Temp Tag
            public decimal CIATT { get; set; }
            //Comp Inlet Guide Vane Angle Tag
            public decimal CIGVAT { get; set; }
            //Inlet Air Heating In Service Tag
            public decimal IAHST { get; set; }
            //Exhaust Gas Temp Tag
            public decimal EGTT { get; set; }
            //Exhaust Gas Temp Control Tag
            public decimal EGTCT { get; set; }
            //Fuel Gas Energy Input Rate Tag
            public decimal FGEIRT { get; set; }
            //Normalized Load
            public decimal NL { get; set; }


        }

        public class Generator
        {
            //Fill it with Generator Attribute
            public int BlockId { get; set; }
            public int GenId { get; set; }
            public int GTId { get; set; }
            public int STId { get; set; }
            public string FullName { get; set; }
            public string ShortName { get; set; }
            public decimal MaxPowOutput { get; set; }

            ////////Generator Tag Attributes////////
            //Breaker Closed Tag
            public bool BCT { get; set; }
            //Gross Power Output Tag
            public decimal GPOT { get; set; }
            //Shaft Speed Tag
            public decimal SST { get; set; }
        }

        public class HRSG
        {
            //Fill it with HRSG Attribute
            public int BlockId { get; set; }
            public int HRSGId { get; set; }
            public int GTId { get; set; }
            public int STId { get; set; }
            public string FullName { get; set; }
            public string ShortName { get; set; }
            public decimal DuctBurnMax { get; set; }
            public decimal DuctBurnMaxMWGain { get; set; }
            public decimal COEmiLimit { get; set; }
            public decimal NOXEmiLimit { get; set; }

            /////////HRSG Tag Attribute///////////
            //Duct Burner Fuel Gas Energy Input 
            public decimal DBFGEIT { get; set; }
            //Dry Exhaust Gas CO Conc
            public decimal DEGCCT { get; set; }
            //Dry Exhaust Gas NOx Conc
            public decimal DEGNCT { get; set; }

        }

        public class SteamTurbine
        {
            //Fill it with Steam Turbine Attribute
            public int BlockId { get; set; }
            public int HRSGId { get; set; }
            public int STId { get; set; }
            public string FullName { get; set; }
            public string ShortName { get; set; }

        }


        public class Block
        {
            // BlockType value is determined by the icon selected by the user in the front panel
            public string BlockType { get; set; }
            public int SiteId { get; set; }
            public int BlockId { get; set; }
            public bool SingleShaft { get; set; }
            //value of the enums cannot be changed at the run time
            //so if we select the plant icon in the app..based on it if we populate our table..it is not possible by using enum
            /*
            public List<Generator> GenList = new List<Generator>();
            public List<GasTurbine> GTList = new List<GasTurbine>();
            public List<HRSG> HRSGList = new List<HRSG>();
            public List<SteamTurbine> STList = new List<SteamTurbine>();
            */
            public List<object> PlantObject = new List<Object>();
            /*
            public Generator[] arrGen = new Generator[0];
            public GasTurbine[] arrGT = new GasTurbine[0];
            public HRSG[] arrHRSG = new HRSG[0];
            public SteamTurbine[] arrST = new SteamTurbine[0];
            */

            public void Map(List<Generator> Gen, List<GasTurbine> GT, List<HRSG> HRSG, List<SteamTurbine> ST)
            {
                /*
                foreach (Generator i in Gen.ToList())
                {
                    GenList.Add(i);
                }
                foreach (GasTurbine i in GT.ToList())
                {
                    GTList.Add(i);
                }
                foreach (HRSG i in HRSG.ToList())
                {
                    HRSGList.Add(i);
                }
                foreach (SteamTurbine i in ST.ToList())
                {
                    STList.Add(i);
                }
                */
                PlantObject.AddRange(Gen);
                PlantObject.AddRange(GT);
                PlantObject.AddRange(HRSG);
                PlantObject.AddRange(ST);


            }

        }
        

        public class StandardVariable : Block
        {
            //these are the fixed variables for any block

        }

        public class Variable 
        {

            //These are the variables based on the Block Type Selected....Depending on the block type the PlantObject List would vary
            //Then based on the PlantObject list the number of Tags would vary
            List<object> VariableTagList = new List<object>();
            public Variable(List<object> PlantObject)
            {
                foreach (object i in PlantObject)
                {
                    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(i))
                    {
                        string name = descriptor.Name;
                        object value = descriptor.GetValue(i);
                        // as all the Tags are in Acronym
                        if (name.All(char.IsUpper))
                        {
                            VariableTagList.Add(value);
                            Console.WriteLine("{0}={1}", name, value);
                        }
                        //Console.WriteLine("{0}={1}", name, value);
                    }
                    
                }

            }


        }
        
    }
}
