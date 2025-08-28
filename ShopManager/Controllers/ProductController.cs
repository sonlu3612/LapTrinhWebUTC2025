using Microsoft.AspNetCore.Mvc;
using ShopManager.Models;

namespace ShopManager.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 15000000, Description = "A high-performance laptop suitable for all your computing needs." },
            new Product { Id = 2, Name = "Smartphone", Price = 8000000, Description = "A sleek smartphone with the latest features." },
            new Product { Id = 3, Name = "Tablet", Price = 6000000, Description = "A lightweight tablet perfect for media consumption and light work." }
        };

        public IActionResult ListProduct()
        {
            return View(products);
        }

        public IActionResult ProductDetail(int id)
        {
            var prd = products.FirstOrDefault(p => p.Id == id);
            if (prd == null)
            {
                return NotFound();
            }
            return View(prd);
        }
    }
}
