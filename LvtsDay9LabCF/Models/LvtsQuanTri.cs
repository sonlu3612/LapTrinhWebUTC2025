using System.ComponentModel.DataAnnotations;

namespace LvtsDay9LabCF.Models
{
    public class LvtsQuanTri
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
