//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForecastAppDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlantMasterVariable
    {
        public int PlantMasterVariableID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> PlantObjectTypeID { get; set; }
        public Nullable<int> ObjectGroupID { get; set; }
        public Nullable<int> UniqueID { get; set; }
        public string Mandatory { get; set; }
    }
}
