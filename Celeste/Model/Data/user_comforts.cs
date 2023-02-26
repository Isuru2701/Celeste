namespace Celeste.Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_comforts
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int enduser_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int trigger_id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime entry_date { get; set; }

        public virtual comfort comfort { get; set; }

        public virtual EndUser EndUser { get; set; }
    }
}
