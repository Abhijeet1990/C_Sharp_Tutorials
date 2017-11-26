using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastWizardApplication.Infrastructure
{
    public class BlockConfiguration
    {
        public static int GTCount1 { get; set; }
        public static int STCount1 { get; set; }
    }

    public class SiteData
    {
        public static int _siteID { get; set; }
        public static string _status { get; set; }
        public static string _name { get; set; }
        public static string _acronym { get; set; }
        public static int _blockID { get; set; }
        public static float _latitude { get; set; }
        public static float _longitude { get; set; }
        public static float _elevation { get; set; }
        public static string _comboBoxInterval { get; set; }
        public static string _comboBoxDuration { get; set; }
        public static string _comboBoxArchiveInterval { get; set; }
        public static string _comboBoxArchiveDuration { get; set; }
        public static string _comboBoxGridFrequency { get; set; }
        public static string _comboBoxHeatRateUnits { get; set; }
        public static string _comboBoxHeatRateCalculation { get; set; }
        
    }

    public class BlockData
    {
        public static string _status { get; set; }
        public static string _typeConfig { get; set; }
        public static string _name { get; set; }
        public static string _acronym { get; set; }
        public static int _blockID { get; set; }
        public static string _gasTurbineType { get; set; }
        public static string lname { get; set; }
        public static string sname { get; set; }

    }

    public class GasTurbineData
    {
        public static int _gasTurbineID { get; set; }
        public static string _status { get; set; }
        public static string _name { get; set; }
        public static string _acronym { get; set; }
    }

    public class GeneratorData
    {
        public static int _generatorID { get; set; }
        public static string _status { get; set; }
        public static string _name { get; set; }
        public static string _alias { get; set; }
    }

    public class HRSGData
    {
        public static int _hrsgID { get; set; }
        public static string _status { get; set; }
        public static string _name { get; set; }
        public static string _acronym { get; set; }
    }

    public class CondenserData
    {
        public static int _condenserID { get; set; }
        public static string _status { get; set; }
        public static string _name { get; set; }
        public static string _alias { get; set; }
    }

    public class SteamTurbineData
    {
        public static int _steamTurbineID { get; set; }
        public static string _status { get; set; }
        public static string _name { get; set; }
        public static string _acronym { get; set; }
    }
}
