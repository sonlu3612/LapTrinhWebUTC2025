using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreLAB6_EF.Entities;
using NetCoreLAB6_EF.Models;
using System.Diagnostics;

namespace NetCoreLAB6_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var banners = await _context.Banners.ToListAsync();
            Console.WriteLine("Banners loaded in Index action: " + string.Join(", ", banners.Select(b => b.Name)));
            return View(banners);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Product()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
            Console.WriteLine("Products loaded in Product action: " + string.Join(", ", products.Select(p => p.Name)));
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
