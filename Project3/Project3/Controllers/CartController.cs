using Microsoft.AspNetCore.Mvc;

namespace Project3.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
