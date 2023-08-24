using AHL.Business.Implementations;
using AHL.Business.Interfaces;
using AHL.Model.Dtos.District;
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
    public class DistrictsController : BaseController
    {
        private readonly IDistrictBs _districtBs;

        public DistrictsController(IDistrictBs districtBs)
        {
            _districtBs = districtBs;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _districtBs.GetByIdAsync(id, "Province", "Addresses", "Student");
            return SendResponse(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetDistrict()
        {
            var response = await _districtBs.GetDistrictAsync("Province", "Addresses", "Student");

            return SendResponse(response);

        }
    }
}
