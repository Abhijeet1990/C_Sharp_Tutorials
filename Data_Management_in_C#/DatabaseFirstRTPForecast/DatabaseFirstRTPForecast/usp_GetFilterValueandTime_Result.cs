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
    
    public partial class usp_GetFilterValueandTime_Result
    {
        public string Name { get; set; }
        public Nullable<bool> Relative { get; set; }
        public Nullable<System.DateTimeOffset> Start { get; set; }
        public Nullable<System.DateTimeOffset> Finish { get; set; }
        public string Block { get; set; }
        public Nullable<float> LOWER { get; set; }
        public string LC { get; set; }
        public string Variable { get; set; }
        public string UC { get; set; }
        public Nullable<float> UPPER { get; set; }
        public string Units { get; set; }
    }
}