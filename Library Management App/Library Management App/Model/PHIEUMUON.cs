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
    
    public partial class PHIEUMUON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUON()
        {
            this.CTPMs = new HashSet<CTPM>();
            this.PHIEUTHUs = new HashSet<PHIEUTHU>();
        }
    
        public int MAPM { get; set; }
        public string MADG { get; set; }
        public string MAND { get; set; }
        public Nullable<System.DateTime> TGMUON { get; set; }
        public Nullable<int> TIENPHAT { get; set; }
        public Nullable<System.DateTime> TGTRA { get; set; }
        public int SL { get; set; }
        public int TRIGIA { get; set; }
        public string TRANGTHAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPM> CTPMs { get; set; }
        public virtual DOCGIA DOCGIA { get; set; }
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUTHU> PHIEUTHUs { get; set; }
    }
}
