using System;
using System.Collections.Generic;

namespace QuanLyBanHang.Models;

public partial class SanPham
{
    public int Id { get; set; }

    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public int MaLoai { get; set; }

    public bool TrangThai { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual LoaiSanPham MaLoaiNavigation { get; set; } = null!;
}
