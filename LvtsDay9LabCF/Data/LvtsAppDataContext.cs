using Microsoft.EntityFrameworkCore;
using LvtsDay9LabCF.Models;

namespace LvtsDay9LabCF.Data
{
    public class LvtsAppDataContext : DbContext
    {
        public DbSet<LvtsQuanTri> QuanTris { get; set; }
        public DbSet<LvtsKhachHang> KhachHangs { get; set; }
        public DbSet<LvtsHoaDon> HoaDons { get; set; }
        public DbSet<LvtsChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<LvtsSanPham> SanPhams { get; set; }
        public DbSet<LvtsLoaiSanPham> LoaiSanPhams { get; set; }

        public LvtsAppDataContext(DbContextOptions<LvtsAppDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LvtsHoaDon>()
                .HasOne(h => h.KhachHang)
                .WithMany(k => k.HoaDons)
                .HasForeignKey(h => h.MaKhachHang);

            modelBuilder.Entity<LvtsChiTietHoaDon>()
                .HasOne(ct => ct.HoaDon)
                .WithMany(h => h.ChiTietHoaDons)
                .HasForeignKey(ct => ct.HoaDonID);

            modelBuilder.Entity<LvtsChiTietHoaDon>()
                .HasOne(ct => ct.SanPham)
                .WithMany(s => s.ChiTietHoaDons)
                .HasForeignKey(ct => ct.SanPhamID);

            modelBuilder.Entity<LvtsSanPham>()
                .HasOne(s => s.LoaiSanPham)
                .WithMany(l => l.SanPhams)
                .HasForeignKey(s => s.MaLoai);
        }
    }
}
