using Microsoft.AspNetCore.Mvc;

namespace Day4Lab_Layout.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
