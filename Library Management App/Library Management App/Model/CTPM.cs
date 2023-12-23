namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPM")]
    public partial class CTPM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MACTPM { get; set; }

        public int? MAPM { get; set; }

        [StringLength(50)]
        public string MASACH { get; set; }

        public virtual PHIEUMUON PHIEUMUON { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
