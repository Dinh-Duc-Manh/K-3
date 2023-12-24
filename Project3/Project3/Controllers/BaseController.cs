using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project3.Data;
using Project3.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project3.Controllers
{
    public class BaseController : Controller, IActionFilter
    {
      
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Login") == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Area = "", Controller = "Login", Action = "Index" })
                );
            }
            if (context.HttpContext.Session.GetString("LoginCheck") == "user")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" })
                );
            }
            base.OnActionExecuting(context);
        }
    }

}
