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
    
    public partial class usp_GetHealthCheckRealTimeInfo_Result
    {
        public string Name { get; set; }
        public float Actual { get; set; }
        public float Predicted { get; set; }
        public float Threshold { get; set; }
        public float Difference { get; set; }
        public int HealthCheckID { get; set; }
        public bool AlertStatus { get; set; }
        public Nullable<System.DateTimeOffset> Timestamp { get; set; }
        public string EngUnits { get; set; }
    }
}
