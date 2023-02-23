namespace Celeste.Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class trigger
    {
        [Key]
        public int trigger_id { get; set; }

        [StringLength(30)]
        public string trigger_name { get; set; }
    }
}
