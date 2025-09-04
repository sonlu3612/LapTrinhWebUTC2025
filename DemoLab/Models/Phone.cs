using System.Collections.Generic;

namespace DemoLab.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;  

        public List<Phone> GetPhoneList()
        {
            return new List<Phone>
            {
                new Phone { Id = 1, Name = "IPhone 16 512GB", Image = "/images/products/phone1.png" },
                new Phone { Id = 2, Name = "IPhone 16 512GB", Image = "/images/products/phone1.png" },
                new Phone { Id = 3, Name = "IPhone 16 512GB", Image = "/images/products/phone1.png" },
            };
        }
    }
}
