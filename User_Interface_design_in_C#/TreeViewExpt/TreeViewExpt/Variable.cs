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
    using System.Collections.Generic;
    
    public partial class Variable
    {
        public int VariableID { get; set; }
        public string Name { get; set; }
        public string EngUnits { get; set; }
        public string VariableType { get; set; }
        public byte VariableTypeID { get; set; }
        public string Site { get; set; }
        public byte SiteID { get; set; }
        public string Block { get; set; }
        public byte BlockID { get; set; }
        public string PlantObjectType { get; set; }
        public byte PlantObjectTypeID { get; set; }
        public string PlantObject { get; set; }
        public byte PlantObjectID { get; set; }
        public string PlantObjectVariable { get; set; }
        public short PlantObjectVariableID { get; set; }
        public Nullable<short> ForecastID { get; set; }
        public bool Local { get; set; }
        public Nullable<System.DateTimeOffset> Timestamp { get; set; }
        public Nullable<float> Value { get; set; }
        public Nullable<bool> Good { get; set; }
    }
}