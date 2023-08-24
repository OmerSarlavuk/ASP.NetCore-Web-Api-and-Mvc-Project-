using AHL.UI.Areas.Admin.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AHL.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }
    }
}
