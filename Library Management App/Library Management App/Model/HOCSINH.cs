namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCSINH")]
    public partial class HOCSINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCSINH()
        {
            HOCTAPs = new HashSet<HOCTAP>();
            KETQUAs = new HashSet<KETQUA>();
            LOPs = new HashSet<LOP>();
            NHANXETs = new HashSet<NHANXET>();
            TBMONs = new HashSet<TBMON>();
            THANHTICHes = new HashSet<THANHTICH>();
            THIs = new HashSet<THI>();
        }

        [Key]
        public int MAHS { get; set; }

        [StringLength(255)]
        public string HOTEN { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NTNS { get; set; }

        [StringLength(255)]
        public string NOISINH { get; set; }

        public bool? GIOITINH { get; set; }

        [StringLength(255)]
        public string DANTOC { get; set; }

        [StringLength(255)]
        public string TONGIAO { get; set; }

        [StringLength(255)]
        public string CHINHSACH { get; set; }

        [StringLength(30)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string GHICHU { get; set; }

        [StringLength(255)]
        public string SOHIEU { get; set; }

        [StringLength(255)]
        public string DIACHI { get; set; }

        [StringLength(20)]
        public string NIENKHOA { get; set; }

        public int? MALOGIN { get; set; }

        [StringLength(100)]
        public string AVA { get; set; }

        public bool? DELETED { get; set; }

        public virtual LOGIN LOGIN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCTAP> HOCTAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANXET> NHANXETs { get; set; }

        public virtual PHUHUYNH PHUHUYNH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBMON> TBMONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTICH> THANHTICHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THI> THIs { get; set; }
    }
}
