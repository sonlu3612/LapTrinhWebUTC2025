using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreLAB6_EF.Models
{
    public class Mark
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public float? Score { get; set; }

        // Navigation properties
        public Subject Subject { get; set; }
        public Student Student { get; set; }
    }
}
