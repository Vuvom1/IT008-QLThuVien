namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANHTICH")]
    public partial class THANHTICH
    {
        [Key]
        public int MATT { get; set; }

        [StringLength(255)]
        public string TENTT { get; set; }

        public int? MAHS { get; set; }

        public int? MALOP { get; set; }

        public bool? DELETED { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual LOP LOP { get; set; }
    }
}
