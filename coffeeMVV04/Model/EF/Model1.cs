using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace coffeeMVV04.Model.EF
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model14")
        {
        }

        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.SanPhams)
                .WithOptional(e => e.DanhMuc)
                .HasForeignKey(e => e.IDDanhMuc);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithOptional(e => e.HoaDon)
                .HasForeignKey(e => e.IDHoaDon);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.IDUser);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietHoaDons)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.IDSanPham);
        }
    }
}
