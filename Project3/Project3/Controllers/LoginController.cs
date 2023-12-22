using Microsoft.AspNetCore.Mvc;
using Project3.Data;
using Project3.Models;

namespace Project3.Controllers
{
    public class LoginController : Controller
    {
        private readonly Sem3DBContext _context;
        public LoginController(Sem3DBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login model)
        {
            TempData["MessageError"] = "";
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var checkAccount = _context.Accounts.Where(a => a.AccountType == true && a.AccountStatus == "In force").FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                var checkAccount1 = _context.Accounts.Where(a => a.AccountType == false && a.AccountStatus == "In force").FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                var checkAccount2 = _context.Accounts.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                if (checkAccount != null)
                {
                    HttpContext.Session.SetString("Login", checkAccount.FullName);
                    return RedirectToAction("Index", "Home");
                }
                else if (checkAccount1 != null)
                {
                    //HttpContext.Session.SetString("Login", checkAccount.FullName);
                    //HttpContext.Session.SetString("LoginAvatar", checkAccount.Avatar);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (checkAccount2 != null && checkAccount2.AccountStatus != "In force")
                {
                    HttpContext.Session.SetString("LoginError", checkAccount2.AccountStatus);
                }
                else
                {
                    TempData["MessageError"] = "Login information is incorrect or does not exist";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Login");
            return RedirectToAction("Index", "Home");
        }

    }
}
