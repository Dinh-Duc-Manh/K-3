using Microsoft.AspNetCore.Mvc;
using Project3.Data;
using Project3.Models;

namespace Project3.Controllers
{
    [Area("Admin")]
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
                var checkAccount = _context.Accounts.Where(a => a.AccountType == false && a.AccountStatus == "In force").FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                var checkAccount1 = _context.Accounts.Where(a => a.AccountType == true).FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                var checkAccount2 = _context.Accounts.Where(a => a.AccountType == false).FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                if (checkAccount != null)
                {
                    HttpContext.Session.SetString("LoginAdmin", checkAccount.FullName);
                    HttpContext.Session.SetString("LoginAdminAvatar", checkAccount.Avatar);
                    return RedirectToAction("Index", "HomeAdmin");
                }
                else if (checkAccount1 != null)
                {
                    TempData["MessageError"] = "Sai loại tài khoản vui lòng đăng nhập tài khoản Admin";
                }
                else if (checkAccount2 != null && checkAccount2.AccountStatus != "In force")
                {
                    HttpContext.Session.SetString("LoginAdminError", checkAccount2.AccountStatus);
                }
                else
                {
                    TempData["MessageError"] = "Tên đăng nhập hoặc mật khẩu không đúng hoặc tài khoản này chưa tồn tại";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginAdmin");
            return RedirectToAction("Index");
        }

    }
}
