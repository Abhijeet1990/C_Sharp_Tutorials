//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TreeViewApproach
{
    using System;
    
    public partial class usp_GetHealthChecksInAlert_Result
    {
        public string Name { get; set; }
        public Nullable<float> Actual { get; set; }
        public Nullable<float> Predicted { get; set; }
        public Nullable<float> Threshold { get; set; }
        public string EngUnits { get; set; }
        public Nullable<int> HealthCheckID { get; set; }
        public Nullable<bool> AlertStatus { get; set; }
        public Nullable<System.DateTimeOffset> Time { get; set; }
    }
}
