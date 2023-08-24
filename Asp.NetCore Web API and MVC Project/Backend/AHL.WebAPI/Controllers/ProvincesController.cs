using AHL.Business.Implementations;
using AHL.Business.Interfaces;
using AHL.Model.Dtos.Province;
using AHL.Model.Dtos.Student;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AHL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProvincesController : BaseController
    {
        private readonly IProvinceBs _provinceBs;

        public ProvincesController(IProvinceBs provinceBs)
        {
            _provinceBs = provinceBs;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _provinceBs.GetByIdAsync(id);
            return SendResponse(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetProvince()
        {
            var response = await _provinceBs.GetProvinceAsync();

            return SendResponse(response);

        }

        [HttpGet("GetByProvinceName")]

        public async Task<IActionResult> GetByProvinceName([FromQuery] string name)
        {
            var response = await _provinceBs.GetByProvinceNameAsync(name);

            return SendResponse(response);

        }
    }
}
