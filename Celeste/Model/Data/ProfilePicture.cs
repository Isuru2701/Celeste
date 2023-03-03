namespace Celeste.Model.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProfilePicture")]
    public partial class ProfilePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int enduser_id { get; set; }

        public byte[] picture { get; set; }

        public virtual EndUser EndUser { get; set; }
    }
}
