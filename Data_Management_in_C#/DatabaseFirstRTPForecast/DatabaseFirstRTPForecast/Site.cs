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
    using System.Collections.Generic;
    
    public partial class Site
    {
        public byte SiteID { get; set; }
        public string Acronym { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public float Elevation { get; set; }
        public string Timezone { get; set; }
        public string DataDirectory { get; set; }
        public bool UseMetricUnits { get; set; }
    }
}
