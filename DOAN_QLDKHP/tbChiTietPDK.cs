//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOAN_QLDKHP
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbChiTietPDK
    {
        public string MaDK { get; set; }
        public string MaMH { get; set; }
        public string TenLHP { get; set; }
        public string SoTinChi { get; set; }
        public string ThongTin { get; set; }
    
        public virtual tbMonHoc tbMonHoc { get; set; }
        public virtual tbPhieuDangKy tbPhieuDangKy { get; set; }
    }
}