using System.ComponentModel.DataAnnotations;

namespace LvtsDay9LabCF.Models
{
    public class LvtsChiTietHoaDon
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

        public LvtsHoaDon? HoaDon { get; set; }
        public LvtsSanPham? SanPham { get; set; }
    }
}
