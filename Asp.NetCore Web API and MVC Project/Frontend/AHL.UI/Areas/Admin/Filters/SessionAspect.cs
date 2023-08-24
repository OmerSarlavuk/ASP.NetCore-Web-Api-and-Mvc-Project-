using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AHL.UI.Areas.Admin.Filters
{
    public class SessionAspect : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sessionJson = context.HttpContext.Session.GetString("ActiveAdminUser");

            if (string.IsNullOrEmpty(sessionJson))
            {
                context.Result = new RedirectResult("/Admin/Authentication/LogIn");
            }
    }
}
}
