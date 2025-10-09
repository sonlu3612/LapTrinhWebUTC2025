using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Day7Lab.Models;

namespace Day7Lab.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CtHoaDon> CtHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CT_HOA_D__3214EC27CE99679B");

            entity.ToTable("CT_HOA_DON");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HoaDonId).HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId).HasColumnName("SanPhamID");

            entity.HasOne(d => d.HoaDon).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.HoaDonId)
                .HasConstraintName("FK__CT_HOA_DO__HoaDo__36B12243");

            entity.HasOne(d => d.SanPham).WithMany(p => p.CtHoaDons)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK__CT_HOA_DO__SanPh__37A5467C");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HOA_DON__3214EC27F2B2A746");

            entity.ToTable("HOA_DON");

            entity.HasIndex(e => e.MaHoaDon, "UQ__HOA_DON__835ED13A71FAE05C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(255);
            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");
            entity.Property(e => e.NgayNhan).HasColumnType("datetime");

            entity.HasOne(d => d.MaKhaHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhaHang)
                .HasConstraintName("FK__HOA_DON__MaKhaHa__33D4B598");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KHACH_HA__3214EC2716DEDCD0");

            entity.ToTable("KHACH_HANG");

            entity.HasIndex(e => e.DienThoai, "UQ__KHACH_HA__1F031876FD7BA43B").IsUnique();

            entity.HasIndex(e => e.MaKhachHang, "UQ__KHACH_HA__88D2F0E4F09C71EA").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__KHACH_HA__A9D1053400A0055E").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(255);
            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NgayDangKy).HasColumnType("datetime");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAI_SAN__3214EC27DDC9A147");

            entity.ToTable("LOAI_SAN_PHAM");

            entity.HasIndex(e => e.MaLoai, "UQ__LOAI_SAN__730A5758114F4AF7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenLoai).HasMaxLength(255);
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QUAN_TRI__3214EC27838A5F38");

            entity.ToTable("QUAN_TRI");

            entity.HasIndex(e => e.TaiKhoan, "UQ__QUAN_TRI__D5B8C7F01A99EE30").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SAN_PHAM__3214EC27160EACCA");

            entity.ToTable("SAN_PHAM");

            entity.HasIndex(e => e.MaSanPham, "UQ__SAN_PHAM__FAC7442C235FEF00").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaSanPham)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TenSanPham).HasMaxLength(255);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK__SAN_PHAM__MaLoai__2B3F6F97");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}