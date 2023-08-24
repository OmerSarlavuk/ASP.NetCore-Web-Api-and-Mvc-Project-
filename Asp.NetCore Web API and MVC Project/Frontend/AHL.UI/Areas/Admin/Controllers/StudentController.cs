using AHL.UI.Areas.Admin.Extensions;
using AHL.UI.Areas.Admin.Filters;
using AHL.UI.Areas.Admin.HttpApiServices;
using AHL.UI.Areas.Admin.Models;
using AHL.UI.Areas.Admin.Models.Dtos.StudentDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;

namespace AHL.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class StudentController : Controller
    {
        private readonly IHttpApiService _httpApiService;
        public StudentController(IHttpApiService httpApiService)
        {
            _httpApiService = httpApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = 
                await _httpApiService.GetData<ResponseBody<List<StudentItem>>>("/Students", token.Token);

            return View(response.Data);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateStudentDto dto)
        {
            var postObj = new
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                SchoolIdentity = dto.SchoolIdentity,
                Email = dto.Email,
                Phone = dto.Phone,
                Gender = dto.Gender,
            };

            var response = await _httpApiService.PutData<ResponseBody<UpdateStudentDto>>("/Students",
                JsonSerializer.Serialize(postObj));

            if (response.StatusCode.ToString().StartsWith("2"))
            {
                return Json(new { IsSuccess = true, Message = "Öğrenci başarılı bir şekilde güncellendi" });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = response.ErrorMessages });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewStudentDto dto)
        {
            var postObj = new
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                SchoolIdentity = dto.SchoolIdentity,
                Email = dto.Email,
                Phone = dto.Phone,
                Gender = dto.Gender,
                IsActive = dto.IsActive
            };

            var response = await _httpApiService.PostData<ResponseBody<NewStudentDto>>("/Students", JsonSerializer.Serialize(postObj));

            if (response.StatusCode.ToString().StartsWith("2"))
            {
                return Json(new { IsSuccess = true, Message = "Öğrenci başarılı bir şekilde kaydedildi" });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = response.ErrorMessages });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/Students/{id}", token.Token!);

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent(int id)
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.GetData<ResponseBody<NewStudentDto>>($"/Students/{id}", token.Token);
            return Json(new
            {
                Id= response.Data.Id,
                FirstName = response.Data.FirstName,
                LastName = response.Data.LastName,
                SchoolIdentity = response.Data.SchoolIdentity,
                Email = response.Data.Email,
                Gender = response.Data.Gender,
                Phone = response.Data.Phone,
                IsActive = response.Data.IsActive
            });
        }
    }
}

