namespace Celeste.Model.Lunar
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_score
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int enduser_id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime entry_date { get; set; }

        public float? score { get; set; }

        public virtual EndUser EndUser { get; set; }
    }
}
