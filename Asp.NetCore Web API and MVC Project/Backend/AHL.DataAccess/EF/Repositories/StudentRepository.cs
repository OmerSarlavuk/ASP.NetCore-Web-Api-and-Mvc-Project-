using AHL.DataAccess.EF.Context;
using AHL.DataAccess.Interfaces;
using AHL.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.DataAccess.EF.Repositories
{
    public class StudentRepository : BaseRepository<Student, AHLDataContext>, IStudentRepository
    {
        public async Task<Student> GetByIdAsync(int studentId, params string[] includeList)
        {
            return await GetAsync(std => std.Id == studentId, includeList);
        }

        public async Task<List<Student>> GetBySchoolIdentityAsync(string identity, params string[] includeList)
        {
            return await GetAllAsync(st => st.SchoolIdentity == identity, includeList);
        }
    }
}
