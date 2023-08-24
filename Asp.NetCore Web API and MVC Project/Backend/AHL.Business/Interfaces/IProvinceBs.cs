using AHL.Model.Dtos.Province;
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
    public interface IProvinceBs
    {
        Task<ApiResponse<List<ProvinceGetDto>>> GetProvinceAsync(params string[] includeList);

        Task<ApiResponse<List<ProvinceGetDto>>> GetByProvinceNameAsync(string name, params string[] includeList);
        Task<ApiResponse<ProvinceGetDto>> GetByIdAsync(int provinceId, params string[] includeList);
    }
}
