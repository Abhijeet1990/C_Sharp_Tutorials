using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWA_13.Infrastructure
{
    public class BlockConfiguration
    {
        public static int GTCount1 { get; set; }
        public static int STCount1 { get; set; }
    }

    public class SiteData
    {
        public static string _status { get; set; }
        public static string _name { get; set; }
        public static string _acronym { get; set; }
        public static int _blockID { get; set; }
    }

    public class BlockData
    {
        public static string _status { get; set; }
        public static string _typeConfig { get; set; }
        public static string _name { get; set; }
        public static string _acronym { get; set; }
        public static int _blockID { get; set; }
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
