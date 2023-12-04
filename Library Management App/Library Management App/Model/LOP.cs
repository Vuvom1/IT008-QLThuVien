namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOP")]
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            GIANGDAYs = new HashSet<GIANGDAY>();
            HOCTAPs = new HashSet<HOCTAP>();
            KETQUAs = new HashSet<KETQUA>();
            NHANXETs = new HashSet<NHANXET>();
            TBMONs = new HashSet<TBMON>();
            THANHTICHes = new HashSet<THANHTICH>();
            THIs = new HashSet<THI>();
        }

        [Key]
        public int MALOP { get; set; }

        [StringLength(10)]
        public string TENLOP { get; set; }

        public int? SISO { get; set; }

        [StringLength(10)]
        public string NAMHOC { get; set; }

        public int? GVCN { get; set; }

        public int? LOPTRUONG { get; set; }

        public int? MAKHOI { get; set; }

        public bool? DELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIANGDAY> GIANGDAYs { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCTAP> HOCTAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }

        public virtual KHOI KHOI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANXET> NHANXETs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBMON> TBMONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANHTICH> THANHTICHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THI> THIs { get; set; }
    }
}
