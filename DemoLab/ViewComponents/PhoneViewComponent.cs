using Microsoft.AspNetCore.Mvc;
using DemoLab.Models;

namespace DemoLab.ViewComponents
{
    public class PhoneViewComponent : ViewComponent
    {
        protected Phone phone = new Phone();
        public IViewComponentResult Invoke()
        {
            var phones = phone.GetPhoneList();
            return View(phones);
        }
    }
}
