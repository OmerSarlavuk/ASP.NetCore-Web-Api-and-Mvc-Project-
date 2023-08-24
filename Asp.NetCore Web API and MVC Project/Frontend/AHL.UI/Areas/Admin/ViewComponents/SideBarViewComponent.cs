using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AHL.UI.Areas.Admin.Models;
using AHL.UI.Areas.Admin.Extensions;

namespace AHL.UI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            var adminUser = HttpContext.Session.GetObject<AdminUserItem>("ActiveAdminUser");

            return View(adminUser);
        }
    }
}
