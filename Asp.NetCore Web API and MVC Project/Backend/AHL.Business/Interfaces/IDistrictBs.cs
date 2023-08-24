using AHL.Model.Dtos.District;
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
    public interface IDistrictBs
    {
        Task<ApiResponse<List<DistrictGetDto>>> GetDistrictAsync(params string[] includeList);
        Task<ApiResponse<DistrictGetDto>> GetByIdAsync(int districtId, params string[] includeList);
    }
}
