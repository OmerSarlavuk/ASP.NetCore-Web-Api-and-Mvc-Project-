using AHL.Model.Dtos.Address;
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
    public interface IAddressBs
    {
        Task<ApiResponse<List<AddressGetDto>>> GetAddressAsync(params string[] includeList);
        Task<ApiResponse<AddressGetDto>> GetByIdAsync(int addressId, params string[] includeList);
    }
}
