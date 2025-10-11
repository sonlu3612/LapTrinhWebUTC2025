using System.ComponentModel.DataAnnotations;

namespace NetCoreLAB6_EF.Models
{
    public class Banner
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Image: {Image}";
        }
    }
}
