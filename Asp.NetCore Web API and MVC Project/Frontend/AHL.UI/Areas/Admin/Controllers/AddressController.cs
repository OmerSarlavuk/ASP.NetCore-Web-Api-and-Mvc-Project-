using AHL.UI.Areas.Admin.Extensions;
using AHL.UI.Areas.Admin.Filters;
using AHL.UI.Areas.Admin.HttpApiServices;
using AHL.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace AHL.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class AddressController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public AddressController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.GetData<ResponseBody<List<AddressItem>>>("/Addresses", token.Token);

            return View(response.Data);

        }
    }
}
