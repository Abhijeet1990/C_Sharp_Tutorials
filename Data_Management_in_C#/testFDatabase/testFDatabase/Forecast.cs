//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testFDatabase
{
    using System;
    using System.Collections.Generic;
    
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
}
