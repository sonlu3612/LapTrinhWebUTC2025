using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        [Required]
        public int SoLuongMua { get; set; }
        [Required]
        public decimal DonGiaMua { get; set; }
        public decimal ThanhTien { get; set; }
        public bool TrangThai { get; set; }

        public HoaDon? HoaDon { get; set; }
        public SanPham? SanPham { get; set; }
    }
}
