using AHL.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.DataAccess.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<Student> GetByIdAsync(int studentId, params string[] includeList);
        Task<List<Student>> GetBySchoolIdentityAsync(string identity, params string[] includeList);
    }
}
