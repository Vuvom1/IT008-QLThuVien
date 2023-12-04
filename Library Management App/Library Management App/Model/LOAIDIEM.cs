namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIDIEM")]
    public partial class LOAIDIEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIDIEM()
        {
            THIs = new HashSet<THI>();
        }

        [Key]
        public int MALD { get; set; }

        [StringLength(20)]
        public string TENLD { get; set; }

        public int? HESO { get; set; }

        public bool? DELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THI> THIs { get; set; }
    }
}
