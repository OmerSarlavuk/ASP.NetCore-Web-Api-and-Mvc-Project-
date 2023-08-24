using AHL.DataAccess.EF.Context;
using AHL.DataAccess.Interfaces;
using AHL.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.DataAccess.EF.Repositories
{
    public class DistrictRepository : BaseRepository<District, AHLDataContext>, IDistrictRepository
    {

        public async Task<District> GetByIdAsync(int districtId, params string[] includeList)
        {
            return await GetAsync(dst => dst.Id == districtId, includeList);
        }
        public async Task<District> GetByStudentId(int studentId)
        {
            return await GetAsync(adr => adr.StudentId == studentId);
        }
    }
}
