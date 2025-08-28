using Microsoft.AspNetCore.Mvc;
using ShopManager.Models;

namespace ShopManager.Controllers
{
    public class CustomerController : Controller
    {
        private static List<Customer> Customers = new List<Customer>()
        {
            new Customer { Id = 1, Name = "SonLu", Email = "sonlu@gmail.com", Phone = "0123456789" },
            new Customer { Id = 2, Name = "GiangNguyen", Email = "giang@gmail.com", Phone = "0987654321" },
            new Customer { Id = 3, Name = "AnPham", Email = "an@gmail.com", Phone = "0112233445" }
        };

        public IActionResult Index()
        {
            return View(Customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            customer.Id = Customers.Count + 1;
            Customers.Add(customer);
            return RedirectToAction("Index");
        }

        public IActionResult SearchByName(string name)
        {
            var result = Customers.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return View("Index", result);
        }
    }
}
