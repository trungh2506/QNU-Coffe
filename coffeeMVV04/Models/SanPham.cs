//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace coffeeMVV04.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    
        public int ID { get; set; }
        public string TenSP { get; set; }
        public string Avatar { get; set; }
        public Nullable<int> IDDanhMuc { get; set; }
        public string MoTaNgan { get; set; }
        public Nullable<double> GiaSP { get; set; }
        public Nullable<double> GiamGiaSP { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<bool> TinhTrang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DanhMuc DanhMuc { get; set; }
    }
}
