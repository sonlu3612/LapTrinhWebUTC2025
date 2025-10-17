using System.ComponentModel.DataAnnotations;

namespace LvtsDay9LabCF.Models
{
    public class LvtsHoaDon
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

        public LvtsKhachHang? KhachHang { get; set; }
        public ICollection<LvtsChiTietHoaDon>? ChiTietHoaDons { get; set; }
    }
}
