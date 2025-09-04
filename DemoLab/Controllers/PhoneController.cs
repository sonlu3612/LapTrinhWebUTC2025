using Microsoft.AspNetCore.Mvc;
using DemoLab.Models;

namespace DemoLab.Controllers
{
    public class PhoneController : Controller
    {
        private Phone phone = new Phone();
    
        public IActionResult Index()
        {
            var phones = phone.GetPhoneList();
            return View(phones);
        }
    }
}
