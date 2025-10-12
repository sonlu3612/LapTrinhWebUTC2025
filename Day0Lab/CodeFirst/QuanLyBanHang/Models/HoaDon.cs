using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{
    public class HoaDon
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? MaHoaDon { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public DateTime NgayNhan { get; set; }
        public string? HoTenKhachHang { get; set; }
        public string? Email { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        [Required]
        public decimal TongTriGia { get; set; }
        public bool TrangThai { get; set; }

        public KhachHang? KhachHang { get; set; }
        public ICollection<ChiTietHoaDon>? ChiTietHoaDons { get; set; }
    }
}
