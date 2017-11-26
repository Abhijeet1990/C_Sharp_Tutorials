using ForecastAppDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ForecastWizardApplication.Infrastructure
{

    class Common
    {
        public static string CheckBox1 { get; set; }
        public static string CheckBox2 { get; set; }
        public static string CheckBox3 { get; set; }
        public static string CheckBox4 { get; set; }
        public static string CheckBox5 { get; set; }
        public static string CheckBox6 { get; set; }
        public static string CheckBox7 { get; set; }

        public static int InletAirCoolingSelectedIndex { get; set; }

    }

    public class SiteNode
    {
        public List<BlockTree> _site { get; set; }
        public string _name { get; set; }
        public int _id { get; set; }
        public float _latitude { get; set; }
        public float _longitude { get; set; }
        public float _elevation { get; set; }
        public string _comboBoxInterval { get; set; }
        public string _comboBoxDuration { get; set; }
        public string _comboBoxArchiveInterval { get; set; }
        public string _comboBoxArchiveDuration { get; set; }
        public string _comboBoxGridFrequency { get; set; }
        public string _comboBoxHeatRateUnits { get; set; }
        public string _comboBoxHeatRateCalculation { get; set; }
        public string level { get; set; }
        //public string _Temperature { get; set; }
        //public string _RelativeHumidity { get; set; }
        //public string _Pressure { get; set; }
    }

    public class BlockTree
    {
        public string _status { get; set; }
        public string _gasTurbineType { get; set; }
        public string _typeConfig { get; set; }
        public string _name { get; set; }
        public string _acronym { get; set; }
        public string _longName { get; set; }
        public string _shortName { get; set; }
        public int _blockID { get; set; }
        public string chkbx1 { get; set; }
        public string chkbx2 { get; set; }
        public string chkbx3 { get; set; }
        public string chkbx4 { get; set; }
        public string chkbx5 { get; set; }
        public string chkbx6 { get; set; }
        public string chkbx7 { get; set; }


        public List<GasTurbineTree> _gasTurbineTree { get; set; }
        public List<SteamTurbineTree> _steamTurbineTree { get; set; }
        public string level { get; set; }
    }

    public class GasTurbineTree
    {
        public string _gasTurbineName { get; set; }
        public int _gtId { get; set; }

        public CTGeneratorTree _cTGeneratorTree { get; set; }
        public HRSGTree _hRSGTree { get; set; }

        public string level { get; set; }
    }

    public class SteamTurbineTree
    {
        public string _steamTurbineName { get; set; }
        public int _stId { get; set; }
        public STGeneratorTree sTGeneratorTreeSteam { get; set; }
        public CondenserTree _condenserTree { get; set; }
        public string level { get; set; }
    }

    public class CTGeneratorTree
    {
        public string _ctGeneratorName { get; set; }
        public int _genId { get; set; }
        // public string _ctGeneratoName { get; set; }
        public string level { get; set; }
    }

    public class STGeneratorTree
    {
        public string _stGeneratorName { get; set; }
        public int _stgenId { get; set; }

        public string level { get; set; }
    }
    public class HRSGTree
    {
        public string _hrsgName { get; set; }
        public int _hrsgId { get; set; }

        public string level { get; set; }
    }

    public class CondenserTree
    {
        public string _CondenserName { get; set; }
        public int _condenId { get; set; }

        public string level { get; set; }
    }

    public class CustomNode
    {
        public string _tText { get; set; }
        public string _tStateImageKey { get; set; }
        public int _tTag { get; set; }
        public string _tName { get; set; }
        public string _tLevel { get; set; }

    }
}
