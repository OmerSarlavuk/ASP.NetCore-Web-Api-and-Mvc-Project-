using AHL.Business.Implementations;
using AHL.Business.Interfaces;
using AHL.Model.Dtos.Address;
using AHL.Model.Dtos.District;
using AHL.Model.Dtos.Student;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AHL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressesController : BaseController  
    {
        private readonly IAddressBs _addressBs;
        public AddressesController(IAddressBs addressBs)
        {
            _addressBs = addressBs;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _addressBs.GetByIdAsync(id, "Province", "District", "Student");
            return  SendResponse(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAddress()
        {
            var response = await _addressBs.GetAddressAsync("Province", "District", "Student");

            return SendResponse(response);

        }
    }
}
