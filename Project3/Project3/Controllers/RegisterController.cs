using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Models;

namespace Project3.Controllers
{
    public class RegisterController : Controller
    {
        private readonly Sem3DBContext _context;

        public RegisterController(Sem3DBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("AccountId,FullName,Email,Password,Phone,Address,Avatar,AccountStatus,AccountType")] Account account)
        {
            var accounts = _context.Accounts.FirstOrDefault(a => a.FullName.Equals(account.FullName));
            if (accounts != null)
            {
                ViewBag.error = "Account name already exists";
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
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
    }
}
