using AHL.Model.Dtos.AdminUser;
using Infrastructure.Utilities.ApiResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Business.Interfaces
{
    public interface IAdminUserBs
    {
        Task<ApiResponse<AdminUserGetDto>> LogIn(string userName, string password, params string[] includeList);
    }
}
