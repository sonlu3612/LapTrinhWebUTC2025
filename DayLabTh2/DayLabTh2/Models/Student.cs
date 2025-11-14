using System.ComponentModel.DataAnnotations;

namespace DayLabTh2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Tên sinh viên")]
        [Required(ErrorMessage = "Vui lòng nhập tên sinh viên")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải từ 4 đến 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Mật khẩu phải tối thiểu 8 ký tự, gồm chữ hoa, chữ thường, số và ký tự đặc biệt")]
        public string? Password { get; set; }

        public Branch? Branch { get; set; }
        public Gender? Gender { get; set; }

        [Display(Name = "Sinh viên chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBorth { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string? Avatar { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng 0.0 đến 10.0")]
        public double Score { get; set; }
    }
}
