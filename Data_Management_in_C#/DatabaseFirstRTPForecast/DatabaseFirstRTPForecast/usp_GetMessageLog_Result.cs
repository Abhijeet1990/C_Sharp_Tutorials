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
    
    public partial class usp_GetMessageLog_Result
    {
        public int LogID { get; set; }
        public System.DateTimeOffset Timestamp { get; set; }
        public byte UserID { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public Nullable<byte> DisplayObjectTypeID { get; set; }
        public string DisplayObjectID { get; set; }
    }
}
