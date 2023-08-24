using AHL.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.DataAccess.Interfaces
{
    public interface IDistrictRepository : IBaseRepository<District>
    {
        Task<District> GetByIdAsync(int districtId, params string[] includeList);
        Task<District> GetByStudentId(int studentId);
    }
}
