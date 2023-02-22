namespace Celeste.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EndUser")]
    public partial class EndUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EndUser()
        {
            ProfilePictures = new HashSet<ProfilePicture>();
            user_entries = new HashSet<user_entries>();
            user_score = new HashSet<user_score>();
        }

        [Key]
        public int enduser_id { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(128)]
        public string password_hash { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dob { get; set; }

        [StringLength(1)]
        public string gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfilePicture> ProfilePictures { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_entries> user_entries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_score> user_score { get; set; }
    }
}
