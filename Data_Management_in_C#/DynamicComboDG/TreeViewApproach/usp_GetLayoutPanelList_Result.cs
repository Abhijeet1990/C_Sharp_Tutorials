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
    
    public partial class usp_GetLayoutPanelList_Result
    {
        public int LayoutPanelID { get; set; }
        public byte UserID { get; set; }
        public string Name { get; set; }
        public byte[] LayoutImage { get; set; }
        public System.DateTimeOffset LastModified { get; set; }
        public Nullable<int> PanelWidth { get; set; }
        public Nullable<int> PanelHeight { get; set; }
        public Nullable<bool> AutoSize { get; set; }
    }
}
