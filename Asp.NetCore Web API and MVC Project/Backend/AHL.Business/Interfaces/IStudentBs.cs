using AHL.Model.Dtos.Student;
using AHL.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Business.Interfaces
{
    public interface IStudentBs
    {
        Task<ApiResponse<List<StudentGetDto>>> GetStudentsAsync(params string[] includeList);

        Task<ApiResponse<List<StudentGetDto>>> GetBySchoolIdentityAsync(string identity, params string[] includeList);
        Task<ApiResponse<StudentGetDto>> GetByIdAsync(int studentId, params string[] includeList);

        Task<ApiResponse<Student>> InsertAsync(StudentPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(StudentPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
