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
}