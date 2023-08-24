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
    public class AdminUserRepository : BaseRepository<AdminUser, AHLDataContext>, IAdminUserRepository
    {
        public async Task<AdminUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(adm => adm.UserName == userName && adm.Password == password &&
            adm.IsActive.Value, includeList);
        }
    }
}
