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
    
    public partial class PHIEUTHU
    {
        public string MAPT { get; set; }
        public int MAPM { get; set; }
        public string MAND { get; set; }
        public string MADG { get; set; }
        public string TENND { get; set; }
        public Nullable<int> TIENTHU { get; set; }
        public Nullable<int> TONGNO { get; set; }
        public Nullable<int> TIENCONLAI { get; set; }
        public System.DateTime TGPT { get; set; }
    
        public virtual DOCGIA DOCGIA { get; set; }
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        public virtual PHIEUMUON PHIEUMUON { get; set; }
    }
}
