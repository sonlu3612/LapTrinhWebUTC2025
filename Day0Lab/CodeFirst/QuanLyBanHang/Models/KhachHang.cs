using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? MaKhachHang { get; set; }
        [Required]
        public string? HoTenKhachHang { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? MatKhau { get; set; }
        [Required]
        public string? DienThoai { get; set; }
        [Required]
        public string? DiaChi { get; set; }
        public DateTime NgayDangKy { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<HoaDon>? HoaDons { get; set; }
    }
}
