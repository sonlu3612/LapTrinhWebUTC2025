using QuanLyBanHang.Models;
using Microsoft.EntityFrameworkCore;

namespace QuanLyBanHang.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<QuanTri> QuanTris { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=QLBanHang;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .HasOne(h => h.KhachHang)
                .WithMany(k => k.HoaDons)
                .HasForeignKey(h => h.MaKhachHang);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(ct => ct.HoaDon)
                .WithMany(h => h.ChiTietHoaDons)
                .HasForeignKey(ct => ct.HoaDonID);

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(ct => ct.SanPham)
                .WithMany(s => s.ChiTietHoaDons)
                .HasForeignKey(ct => ct.SanPhamID);

            modelBuilder.Entity<SanPham>()
                .HasOne(s => s.LoaiSanPham)
                .WithMany(l => l.SanPhams)
                .HasForeignKey(s => s.MaLoai);
        }
    }
}
