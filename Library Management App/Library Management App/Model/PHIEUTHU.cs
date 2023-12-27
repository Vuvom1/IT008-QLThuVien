namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUTHU")]
    public partial class PHIEUTHU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MAPT { get; set; }

        public int MAPM { get; set; }

        [Required]
        [StringLength(50)]
        public string MAND { get; set; }

        public int? TONGNO { get; set; }
        public int? TIENTHU { get; set; }

        public int? TIENCONLAI { get; set; }

        public DateTime TGPT { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }
    }
}
