namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUON")]
    public partial class PHIEUMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUON()
        {
            CTPMs = new HashSet<CTPM>();
        }

        [Key]
        [StringLength(50)]
        public string MAPM { get; set; }

        [StringLength(50)]
        public string MADG { get; set; }

        [StringLength(50)]
        public string MAND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPM> CTPMs { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
