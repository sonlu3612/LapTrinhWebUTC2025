using System.ComponentModel.DataAnnotations;

namespace _05_Model.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Phone]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
