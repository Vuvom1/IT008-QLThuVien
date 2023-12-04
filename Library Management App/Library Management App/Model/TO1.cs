namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TO1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TO1()
        {
            GIAOVIENs = new HashSet<GIAOVIEN>();
        }

        [Key]
        public int MATO { get; set; }

        [StringLength(255)]
        public string TENTO { get; set; }

        public int? SOLUONG { get; set; }

        public int? TOTRUONG { get; set; }

        public bool? DELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAOVIEN> GIAOVIENs { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }
    }
}
