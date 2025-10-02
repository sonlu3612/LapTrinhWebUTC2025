using NetCoreMVCLAB5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace NetCoreMVCLAB5.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult Index()
        {
            List<Account> accounts = new List<Account>();
            return View(accounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            Account model = new Account();
            return View(model);
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account model)
        {
            if (ModelState.IsValid)
            {
                // Save logic here
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            // Fetch account by id logic here
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Account model)
        {
            if (ModelState.IsValid)
            {
                // Update logic here
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            // Fetch account by id logic here
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // Delete logic here
            return RedirectToAction(nameof(Index));
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex _isPhone = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (!_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} không đúng định dạng. VD: 0975054036 hoặc 097.505.4036");
            }
            return Json(true);
        }
    }
}