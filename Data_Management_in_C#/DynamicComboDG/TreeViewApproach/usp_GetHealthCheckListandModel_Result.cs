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
    
    public partial class usp_GetHealthCheckListandModel_Result
    {
        public bool Visible { get; set; }
        public Nullable<System.DateTimeOffset> Time { get; set; }
        public bool AlertStatus { get; set; }
        public string Site { get; set; }
        public string Equipment { get; set; }
        public string Name { get; set; }
        public float Actual { get; set; }
        public float Predicted { get; set; }
        public float Diff { get; set; }
        public float Threshold { get; set; }
        public Nullable<float> PercentDiff { get; set; }
        public string EngUnits { get; set; }
        public string Model { get; set; }
        public int HealthCheckID { get; set; }
        public Nullable<int> ModelID { get; set; }
        public Nullable<int> FilterID { get; set; }
    }
}
