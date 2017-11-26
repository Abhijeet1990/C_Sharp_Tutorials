using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantForecast
{
    public class Site
    {
        
        public string Acronym { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal Latitude { get; set; }
        public decimal Lomgitude { get; set; }
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

        public List<Generator> GenList = new List<Generator>();
        public List<GasTurbine> GTList = new List<GasTurbine>();
        public List<HRSG> HRSGList = new List<HRSG>();
        public List<SteamTurbine> STList = new List<SteamTurbine>();
        public List<object> PlantObject = new List<Object>();
        /*
        public Generator[] arrGen = new Generator[0];
        public GasTurbine[] arrGT = new GasTurbine[0];
        public HRSG[] arrHRSG = new HRSG[0];
        public SteamTurbine[] arrST = new SteamTurbine[0];
        */

        public void Map(List<Generator> Gen, List<GasTurbine> GT, List<HRSG> HRSG, List<SteamTurbine> ST)
        {
            
            foreach (Generator i in Gen)
            {
                GenList.Add(i);
            }
            foreach (GasTurbine i in GT)
            {
                GTList.Add(i);
            }
            foreach (HRSG i in HRSG)
            {
                HRSGList.Add(i);
            }
            foreach (SteamTurbine i in ST)
            {
                STList.Add(i);
            }
            PlantObject.AddRange(GenList);
            PlantObject.AddRange(GTList);
            PlantObject.AddRange(HRSGList);
            PlantObject.AddRange(STList);


        }        

}

    
    public class StandardVariable : Block
    {
        //these are the fixed variables for any block

    }
    
    public class Variable : Block
    {

        //These are the variables based on the Block Type Selected....Depending on the block type the PlantObject List would vary
        //Then based on the PlantObject list the number of Tags would vary
        List<object> VariableTagList = new List<object>();
        public Variable()
        {
            foreach(List<object> i in PlantObject)
            {
                foreach(List<Attribute> attrib in i)
                {
                    VariableTagList.Add(attrib);
                }
            }

        }

        
    }
}
