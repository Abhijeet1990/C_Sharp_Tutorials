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
    
    public partial class Display
    {
        public int DisplayID { get; set; }
        public byte UserID { get; set; }
        public string Name { get; set; }
        public byte Rows { get; set; }
        public byte Columns { get; set; }
        public int MinRowHeight { get; set; }
        public Nullable<System.DateTimeOffset> LastModified { get; set; }
        public Nullable<int> FilterID { get; set; }
    }
}
