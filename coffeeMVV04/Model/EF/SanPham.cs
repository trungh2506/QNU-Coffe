namespace coffeeMVV04.Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int ID { get; set; }

        [StringLength(400)]
        public string TenSP { get; set; }

        [StringLength(400)]
        public string Avatar { get; set; }

        public int? IDDanhMuc { get; set; }

        [StringLength(500)]
        public string MoTaNgan { get; set; }

        public double? GiaSP { get; set; }

        public double? GiamGiaSP { get; set; }

        public int? SoLuong { get; set; }

        public bool? TinhTrang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}
