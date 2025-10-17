using System.ComponentModel.DataAnnotations;

namespace LvtsDay9LabCF.Models
{
    public class LvtsLoaiSanPham
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? MaLoai { get; set; }
        [Required]
        public string? TenLoai { get; set; }
        public bool TrangThai { get; set; }

        public ICollection<LvtsSanPham>? SanPhams { get; set; }
    }
}
