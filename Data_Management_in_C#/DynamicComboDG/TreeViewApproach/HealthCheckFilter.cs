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
    using System.Collections.Generic;
    
    public partial class HealthCheckFilter
    {
        public int FilterID { get; set; }
        public int VariableID { get; set; }
        public Nullable<float> Lower { get; set; }
        public Nullable<bool> LowerEqual { get; set; }
        public Nullable<float> Upper { get; set; }
        public Nullable<bool> UpperEqual { get; set; }
        public string EngUnits { get; set; }
        public byte Position { get; set; }
    }
}
