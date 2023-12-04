namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOVIEN")]
    public partial class GIAOVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAOVIEN()
        {
            GIANGDAYs = new HashSet<GIANGDAY>();
            LOPs = new HashSet<LOP>();
            TO11 = new HashSet<TO1>();
        }

        [Key]
        public int MAGV { get; set; }

        [StringLength(255)]
        public string HOTEN { get; set; }

        [StringLength(255)]
        public string EMAIL { get; set; }

        [StringLength(30)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DIACHI { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NTNS { get; set; }

        public bool? GIOITINH { get; set; }

        public int? MALOGIN { get; set; }

        public int? MATO { get; set; }

        [StringLength(100)]
        public string AVA { get; set; }

        public bool? DELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIANGDAY> GIANGDAYs { get; set; }

        public virtual LOGIN LOGIN { get; set; }

        public virtual TO1 TO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TO1> TO11 { get; set; }
    }
}
