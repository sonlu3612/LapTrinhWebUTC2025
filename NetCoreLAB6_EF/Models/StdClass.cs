using System.ComponentModel.DataAnnotations;

namespace NetCoreLAB6_EF.Models
{
    public class StdClass
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string ClassName { get; set; }

        // Navigation property
        public ICollection<Student> Students { get; set; }
    }
}
