namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            CTPMs = new HashSet<CTPM>();
            CTPNs = new HashSet<CTPN>();
        }

        [Required]
        [StringLength(50)]
        public string TENSACH { get; set; }

        public int? MATL { get; set; }

        public int? MANXB { get; set; }

        public int? NAMXUATBAN { get; set; }

        public int? TONGSL { get; set; }

        public int? SLCONLAI { get; set; }

        public decimal? TRIGIA { get; set; }

        [Key]
        [StringLength(50)]
        public string MASACH { get; set; }

        [Required]
        [StringLength(20)]
        public string ISBN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPM> CTPMs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPNs { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
