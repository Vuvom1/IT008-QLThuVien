namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THI")]
    public partial class THI
    {
        [Key]
        public int MATHI { get; set; }

        public int? MAHS { get; set; }

        public int? MALOP { get; set; }

        public int? MAMH { get; set; }

        public int? MALD { get; set; }

        [StringLength(4)]
        public string DIEM { get; set; }

        public int? HOCKY { get; set; }

        public bool? DELETED { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual LOAIDIEM LOAIDIEM { get; set; }

        public virtual LOP LOP { get; set; }

        public virtual MONHOC MONHOC { get; set; }
    }
}
