namespace EntityFrameworkDataAccess1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public string UserName { get; set; }

        public string display_name { get; set; }
    }
}
