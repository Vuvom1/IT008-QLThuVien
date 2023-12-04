namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        public int MAAD { get; set; }

        [StringLength(255)]
        public string TENAD { get; set; }

        public int? MALOGIN { get; set; }

        [StringLength(100)]
        public string AVA { get; set; }

        public bool? DELETED { get; set; }

        public virtual LOGIN LOGIN { get; set; }
    }
}
