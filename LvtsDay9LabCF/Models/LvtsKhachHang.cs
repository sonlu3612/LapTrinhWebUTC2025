using System.ComponentModel.DataAnnotations;

namespace LvtsDay9LabCF.Models
{
    public class LvtsKhachHang
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

        public ICollection<LvtsHoaDon>? HoaDons { get; set; }
    }
}
