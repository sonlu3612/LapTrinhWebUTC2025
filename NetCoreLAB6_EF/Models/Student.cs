using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreLAB6_EF.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string StudentName { get; set; }

        [Required, StringLength(100)]
        [EmailAddress]
        public string StudentEmail { get; set; }

        [Required, StringLength(50)]
        public string StudentPhone { get; set; }

        [Required, StringLength(150)]
        public string StudentAddress { get; set; }

        [Required, StringLength(100)]
        public string StudentAvatar { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime StudentBirthday { get; set; }

        [ForeignKey("StdClass")]
        public int ClassId { get; set; }

        // Navigation properties
        public StdClass StdClass { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
