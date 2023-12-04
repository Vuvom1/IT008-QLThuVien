namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SOHD { get; set; }

        [StringLength(50)]
        public string MAND { get; set; }

        [StringLength(50)]
        public string MADG { get; set; }

        public DateTime TGHD { get; set; }

        public int TRIGIA { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
    }
}
