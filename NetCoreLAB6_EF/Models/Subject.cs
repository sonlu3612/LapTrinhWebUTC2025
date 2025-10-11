using System.ComponentModel.DataAnnotations;

namespace NetCoreLAB6_EF.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string SubjectName { get; set; }

        // Navigation property
        public ICollection<Mark> Marks { get; set; }
    }
}
