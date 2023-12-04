namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCTAP")]
    public partial class HOCTAP
    {
        [Key]
        public int MAHT { get; set; }

        public int? MAHS { get; set; }

        public int? MALOP { get; set; }

        public bool? DELETED { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual LOP LOP { get; set; }
    }
}
