namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHUHUYNH")]
    public partial class PHUHUYNH
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAHS { get; set; }

        [StringLength(255)]
        public string HOTENBO { get; set; }

        [StringLength(255)]
        public string HOTENME { get; set; }

        [StringLength(255)]
        public string NGHEBO { get; set; }

        [StringLength(255)]
        public string NGHEME { get; set; }

        [StringLength(30)]
        public string SDTBO { get; set; }

        [StringLength(30)]
        public string SDTME { get; set; }

        public bool? DELETED { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }
    }
}
