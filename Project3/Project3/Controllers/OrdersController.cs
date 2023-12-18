using Microsoft.AspNetCore.Mvc;

namespace Project3.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
