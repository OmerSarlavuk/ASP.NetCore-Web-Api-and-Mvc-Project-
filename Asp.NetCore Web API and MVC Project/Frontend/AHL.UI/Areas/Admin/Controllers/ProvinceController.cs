using AHL.UI.Areas.Admin.Extensions;
using AHL.UI.Areas.Admin.Filters;
using AHL.UI.Areas.Admin.HttpApiServices;
using AHL.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace AHL.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class ProvinceController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public ProvinceController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.GetData<ResponseBody<List<ProvinceItem>>>("/Provinces", token.Token);

            return View(response.Data);

        }
    }
}
