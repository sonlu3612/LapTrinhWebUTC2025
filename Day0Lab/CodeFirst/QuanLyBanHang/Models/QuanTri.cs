using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{
    public class QuanTri
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? TaiKhoan { get; set; }
        [Required]
        public string? MatKhau { get; set; }
        public bool TrangThai { get; set; }
    }
}
