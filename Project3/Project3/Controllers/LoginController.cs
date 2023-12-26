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
                var checkAccount = _context.Accounts.Where(a => a.AccountStatus == "In force").FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                var checkAccount1 = _context.Accounts.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                if (checkAccount != null)
                {
                    HttpContext.Session.SetString("LoginName", checkAccount.FullName);
                    HttpContext.Session.SetString("LoginPhone", checkAccount.Phone);
                    HttpContext.Session.SetString("LoginEmail", checkAccount.Email);
                    HttpContext.Session.SetString("LoginAddress", checkAccount.Address);
                    HttpContext.Session.SetString("LoginAvatar", checkAccount.Avatar);
                    
                    HttpContext.Session.SetString("LoginCheck", checkAccount.AccountType);
                    return RedirectToAction("Index", "Home");
                }
                else if (checkAccount1 != null && checkAccount1.AccountStatus != "In force")
                {
                    HttpContext.Session.SetString("LoginError", checkAccount1.AccountStatus);
                }
                else
                {
                    TempData["MessageError"] = "Login information is incorrect or does not exist";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("AccountId,FullName,Email,Password,Phone,Address,Avatar,AccountStatus,AccountType")] Account account)
        {
            var accounts = _context.Accounts.FirstOrDefault(a => a.Email.Equals(account.Email));
            if (accounts != null)
            {
                ViewBag.error = "Account Email already exists";
                return View();
            }
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count() > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var FileName = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        account.Avatar = FileName;
                    }
                }
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            return View(account);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Login");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Account()
        {
            return View();
        }

    }
}
