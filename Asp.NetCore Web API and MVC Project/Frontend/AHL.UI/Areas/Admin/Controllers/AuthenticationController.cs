using AHL.UI.Areas.Admin.Extensions;
using AHL.UI.Areas.Admin.Filters;
using AHL.UI.Areas.Admin.HttpApiServices;
using AHL.UI.Areas.Admin.Models;
using AHL.UI.Areas.Admin.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AHL.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public AuthenticationController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {

            var response = await _httpApiService.GetData<ResponseBody<AdminUserItem>>($"/Authentication/LogIn?userName={dto.UserName }&password={dto.Password}");

                if (response.ErrorMessages == null || response.ErrorMessages!.Count == 0)
                {
                    HttpContext.Session.SetObject("ActiveAdminUser", response.Data);

                await GetTokenAndSetInSession();
                    
                    return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }
        }

        public async Task GetTokenAndSetInSession()
        {
            var response = await _httpApiService.GetData<ResponseBody<AccessTokenItem>>(@"/authentication/gettoken");

            HttpContext.Session.SetObject("AccessToken", response.Data);
        }
    }
}
