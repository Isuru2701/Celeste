namespace Celeste.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_entries
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int enduser_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime entry_date { get; set; }

        public string content { get; set; }

        public virtual EndUser EndUser { get; set; }
    }
}
