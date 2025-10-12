using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public string HoTenKhachHang { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string DienThoai { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public DateTime NgayDangKy { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
