using Microsoft.AspNetCore.Mvc;
using Project3.Controllers;

namespace Project3.Areas.Admin.Controllers
{
    [Route("Admin")]
    public class HomeAdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
