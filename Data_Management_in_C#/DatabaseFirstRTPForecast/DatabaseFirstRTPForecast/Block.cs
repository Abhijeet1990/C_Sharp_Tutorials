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
    
    public partial class Block
    {
        public byte BlockID { get; set; }
        public string Acronym { get; set; }
        public byte SiteID { get; set; }
        public string Name { get; set; }
        public string DataServer { get; set; }
        public short Port { get; set; }
        public string FileLocation { get; set; }
    }
}
