//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management_App.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            this.CTPMs = new HashSet<CTPM>();
            this.CTPNs = new HashSet<CTPN>();
        }
    
        public string TENSACH { get; set; }
        public string IMAGESACH { get; set; }
        public string MOTA { get; set; }
        public Nullable<int> MATL { get; set; }
        public Nullable<int> MANXB { get; set; }
        public Nullable<int> NAMXUATBAN { get; set; }
        public Nullable<int> TONGSL { get; set; }
        public Nullable<int> SLCONLAI { get; set; }
        public Nullable<int> TRIGIA { get; set; }
        public string MASACH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPM> CTPMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPNs { get; set; }
        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
        public virtual THELOAI THELOAI { get; set; }
    }
}
