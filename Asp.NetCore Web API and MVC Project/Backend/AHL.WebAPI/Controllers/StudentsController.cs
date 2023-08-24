using AHL.Business.Interfaces;
using AHL.Model.Dtos.Student;
using AHL.Model.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AHL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController
    {
        private readonly IStudentBs _studentBs;
        public StudentsController(IStudentBs studentBs)
        {
            _studentBs = studentBs;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var student = await _studentBs.GetByIdAsync(id, "Address");
            
            return SendResponse(student);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentBs.GetStudentsAsync("Address");
            
            return SendResponse(students);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewStudent([FromBody] StudentPostDto dto)
        {
            var response = await _studentBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
                return SendResponse(response);
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response);

        }

        [Authorize]
        [HttpGet("getbyidentity")]

        public async Task<IActionResult> GetByIdentityName([FromQuery] string identity)
        {
            var response = await _studentBs.GetBySchoolIdentityAsync(identity, "Address");

            return SendResponse(response);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentPutDto dto)
        {
            var response = await _studentBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var response = await _studentBs.DeleteAsync(id);

            return SendResponse(response);
        }
    }
}
