//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirstRTPForecast
{
    using System;
    
    public partial class usp_GetChartInfo_Result
    {
        public int ChartID { get; set; }
        public byte UserID { get; set; }
        public byte Type { get; set; }
        public string Title { get; set; }
        public bool LHAxis { get; set; }
        public byte LHAxisDP { get; set; }
        public string LHAxisEngUnits { get; set; }
        public float LHAxisMax { get; set; }
        public float LHAxisMin { get; set; }
        public float LHAxisMajor { get; set; }
        public float LHAxisMinor { get; set; }
        public string LHAxisTitle { get; set; }
        public byte LHAxisVariableTypeID { get; set; }
        public bool RHAxis { get; set; }
        public Nullable<byte> RHAxisDP { get; set; }
        public string RHAxisEngUnits { get; set; }
        public Nullable<float> RHAxisMax { get; set; }
        public Nullable<float> RHAxisMin { get; set; }
        public Nullable<float> RHAxisMajor { get; set; }
        public Nullable<float> RHAxisMinor { get; set; }
        public string RHAxisTitle { get; set; }
        public Nullable<byte> RHAxisVariableTypeID { get; set; }
        public bool TAxis { get; set; }
        public Nullable<byte> TAxisMode { get; set; }
        public Nullable<System.DateTimeOffset> TAxisMax { get; set; }
        public Nullable<System.DateTimeOffset> TAxisMin { get; set; }
        public Nullable<int> TAxisPlus { get; set; }
        public Nullable<int> TAxisMinus { get; set; }
        public string TAxisTitle { get; set; }
        public bool XAxis { get; set; }
        public Nullable<byte> XAxisDP { get; set; }
        public string XAxisEngUnits { get; set; }
        public Nullable<float> XAxisMax { get; set; }
        public Nullable<float> XAxisMin { get; set; }
        public Nullable<float> XAxisMajor { get; set; }
        public Nullable<float> XAxisMinor { get; set; }
        public string XAxisTitle { get; set; }
        public Nullable<byte> XAxisVariableTypeID { get; set; }
        public int FilterID { get; set; }
        public Nullable<bool> TGroupMode { get; set; }
        public Nullable<decimal> TAxisMinor { get; set; }
        public Nullable<decimal> TAxisMajor { get; set; }
        public string TAxisMinorType { get; set; }
        public string TAxisMajorType { get; set; }
        public Nullable<System.DateTimeOffset> LastModified { get; set; }
        public string Filter { get; set; }
    }
}
