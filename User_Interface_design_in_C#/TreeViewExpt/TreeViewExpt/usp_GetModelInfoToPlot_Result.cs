//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TreeViewExpt
{
    using System;
    
    public partial class usp_GetModelInfoToPlot_Result
    {
        public int ModelID { get; set; }
        public byte UserID { get; set; }
        public int VariableID { get; set; }
        public int FilterID { get; set; }
        public string Name { get; set; }
        public string ModelFilterName { get; set; }
        public Nullable<System.DateTimeOffset> FilterLastModified { get; set; }
        public double Constant { get; set; }
        public double Fit { get; set; }
        public Nullable<float> Min { get; set; }
        public Nullable<float> Max { get; set; }
        public Nullable<double> Mean { get; set; }
        public Nullable<double> Stdev { get; set; }
        public Nullable<int> PredictionID { get; set; }
        public Nullable<System.DateTimeOffset> ModelLastModified { get; set; }
    }
}
