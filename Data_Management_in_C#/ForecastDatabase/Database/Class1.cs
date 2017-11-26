using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{


    public partial class Site
    {
        public int SiteID { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public Nullable<decimal> Elevation { get; set; }
        public string DataDirectory { get; set; }
        public Nullable<bool> UseMetricUnits { get; set; }
    }


    public partial class Block
    {
        public int BlockID { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int SiteID { get; set; }
        public Nullable<int> BlockTypeID { get; set; }
        public Nullable<int> PlantObjectID { get; set; }
    }

    public partial class Mapping
    {
        public int BlockID { get; set; }
        public Nullable<int> PlantObjectID { get; set; }
        public Nullable<int> ObjectID { get; set; }
        public Nullable<int> TrainID { get; set; }
        public string Alias { get; set; }
    }

    public partial class GasTurbine
    {
        public int ObjectID { get; set; }
        public Nullable<int> GasTurbineTypeID { get; set; }
        public Nullable<double> BaseLoadIGV { get; set; }
        public Nullable<double> PeakFireMWGain { get; set; }
        public Nullable<double> SteamInjectionMWGain { get; set; }
        public Nullable<double> NormalizedLoadMax { get; set; }
        public Nullable<double> NormalizedLoadMin { get; set; }
        public Nullable<int> FiringCurveLUTID { get; set; }
        public Nullable<int> MaxLoadLUTID { get; set; }
    }

    public partial class Generator
    {
        public int ObjectID { get; set; }
        public Nullable<float> MaxPower { get; set; }
        public Nullable<float> MinPower { get; set; }
    }

    public partial class HRSG
    {
        public int ObjectID { get; set; }
        public Nullable<float> DuctBurnFuelMaxRate { get; set; }
        public Nullable<float> DuctBurnMaxMWGain { get; set; }
        public Nullable<float> COEmissionsLimit { get; set; }
        public Nullable<float> NormalizedLoadMax { get; set; }
        public Nullable<float> NormalizedLoadMin { get; set; }
        public Nullable<float> NOXEmissionsLimit { get; set; }
    }

    public partial class InletAirCooling
    {
        public int ObjectID { get; set; }
        public Nullable<float> MinTempOn { get; set; }
        public Nullable<float> MinHumidityOn { get; set; }
        public Nullable<int> CoolingTypeID { get; set; }
    }

    public partial class VariableStandard
    {
        public int StandardVariableID { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public Nullable<int> VariableTypeID { get; set; }
        public Nullable<bool> Mandatory { get; set; }
        public Nullable<int> PlantObjectID { get; set; }
    }

    public partial class VariableSnapShot
    {
        public int VariableID { get; set; }
        public Nullable<System.DateTimeOffset> Timestamp { get; set; }
        public Nullable<float> Value { get; set; }
        public Nullable<bool> Good { get; set; }
    }

    public partial class VariableType
    {
        public int VariableTypeID { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string MetricUnits { get; set; }
        public string EnglishUnits { get; set; }
    }

    public partial class VariableList
    {
        public int VariableID { get; set; }
        public string Tag { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string EngUnits { get; set; }
        public Nullable<int> StandardVariableID { get; set; }
        public Nullable<int> SiteID { get; set; }
        public Nullable<int> BlockID { get; set; }
        public Nullable<int> PlantObjectID { get; set; }
        public Nullable<int> DataSourceID { get; set; }
        public Nullable<float> MinValue { get; set; }
        public Nullable<float> MaxValue { get; set; }
        public Nullable<float> DefaultValue { get; set; }
        public Nullable<int> ForecastID { get; set; }
        public Nullable<bool> Archived { get; set; }
    }

    public partial class Forecast
    {
        public int ForecastID { get; set; }
        public Nullable<int> SiteID { get; set; }
        public Nullable<int> BlockID { get; set; }
        public Nullable<int> ActualVariableID { get; set; }
        public Nullable<int> PredictedVariableID { get; set; }
        public Nullable<int> ForecastTypeID { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
    }

    public partial class ForecastType
    {
        public int ForecastTypeID { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public Nullable<int> EngUnits { get; set; }
    }

    public partial class ForecastValue
    {
        public int ForecastID { get; set; }
        public Nullable<System.DateTimeOffset> Timestamp { get; set; }
        public Nullable<float> Value { get; set; }
        public Nullable<bool> Good { get; set; }
    }

    public partial class XYLUT
    {
        public int XYLUTID { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public Nullable<int> XAxisVariableID { get; set; }
        public Nullable<int> YAxisVariableID { get; set; }
    }

    public partial class XYLUTValue
    {
        public int XYLUTID { get; set; }
        public Nullable<float> Xvalue { get; set; }
        public Nullable<float> Yvalue { get; set; }
    }






}
