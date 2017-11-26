using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ForecastSoftware
{
    class DataStructure
    {

        public class Site
        {

            public string Acronym { get; set; }//eg. CEC
            public int SiteID { get; set; }
            public int BlockID { get; set; }
            public string Description { get; set; }//long site name eg Calgary energy centre
            public string Location { get; set; }
            public decimal Latitude { get; set; }
            public decimal Longitude { get; set; }
            public decimal Elevation { get; set; }
            public double GridFreq { get; set; }
            public string Directory { get; set; }
            public bool MetricUnits { get; set; }
            
        }

        public enum BlockType
        {
            SC1X0,//only Gas
            CC1X1,//
            CC2X1,
            CC3X1

        }

        public class Block
        {

            // BlockType value is determined by the icon selected by the user in the front panel
            public int SiteID { get; set; }
            public int BlockID { get; set; }
            public BlockType Type { get; set; }
            //public bool SingleShaft { get; set; }

        }


        
        public class PlantObject
        {
            
            public int SiteID { get; set; }
            public int BlockID { get; set; }
            //ConnectorID .. (Gen>>GT>>HRSG) forms one Train
            public int UnitID { get; set; }//ex: 1,2,3...
            public string UnitAlias { get; set; } //ex: company designation A,B,C...

            public enum TurbineType
            {
                //list of OEMs
                //Turbine models
                //model will let us know the OEM name
            }
            public class GasTurbine
            {
                //fill this with Gas Turbine Atrribute
                //public int BlockId { get; set; }
                public int GasTurbineID { get; set; }
                public TurbineType Type { get; set; }
                public string Description { get; set; }
                public string Acronym { get; set; }
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

        }
        public static void test()
        {
            //PlantObject p1 = new PlantObject();
            PlantObject.GasTurbine gt = new PlantObject.GasTurbine();
            
        }

    }


    public enum ObjectType
    {
        Generator,
        GasTurbine,
        HRSG,
        SteamTurbine
    }

    public class VariableType
    {
        public int VariableTypeID { get; set; }
        public int SiteID { get; set; }
        public int BlockID { get; set; }
        public string Tag { get; set; }
        public string Acronym { get; set; }
        public string FullName { get; set; }
        public string SIUnits { get; set; }
        public string EngUnits { get; set; }
        public ObjectType Type { get; set; }
    }
    

    public class StandardVariable
    {
        public int VariableID { get; set; }
        public string Acronym { get; set; }
        public string FullName { get; set; }
        public int VariableTypeID { get; set; }


    }

    //public class Variable
    //{

    //    //These are the variables based on the Block Type Selected....Depending on the block type the PlantObject List would vary
    //    //Then based on the PlantObject list the number of Tags would vary
    //    List<object> VariableTagList = new List<object>();
    //    public Variable(List<object> PlantObject)
    //    {
    //        foreach (object i in PlantObject)
    //        {
    //            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(i))
    //            {
    //                string name = descriptor.Name;
    //                object value = descriptor.GetValue(i);
    //                // as all the Tags are in Acronym
    //                if (name.All(char.IsUpper))
    //                {
    //                    VariableTagList.Add(value);
    //                    Console.WriteLine("{0}={1}", name, value);
    //                }
    //                //Console.WriteLine("{0}={1}", name, value);
    //            }

    //        }

    //    }


    //}

}


