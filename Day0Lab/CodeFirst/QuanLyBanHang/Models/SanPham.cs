using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? MaSanPham { get; set; }
        [Required]
        public string? TenSanPham { get; set; }
        public string? HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public int MaLoai { get; set; }
        public bool TrangThai { get; set; }

        public LoaiSanPham? LoaiSanPham { get; set; }
        public ICollection<ChiTietHoaDon>? ChiTietHoaDons { get; set; }
    }
}
