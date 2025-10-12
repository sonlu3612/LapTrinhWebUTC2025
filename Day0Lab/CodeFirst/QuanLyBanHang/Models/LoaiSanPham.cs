using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? MaLoai { get; set; }
        [Required]
        public string? TenLoai { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<SanPham>? SanPhams { get; set; }
    }
}
