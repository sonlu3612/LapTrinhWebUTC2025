using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string MaHoaDon { get; set; } = null!;

    public int MaKhachHang { get; set; }

    public DateTime NgayHoaDon { get; set; }

    public DateTime NgayNhan { get; set; }

    public string? HoTenKhachHang { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public decimal TongTriGia { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;
}
