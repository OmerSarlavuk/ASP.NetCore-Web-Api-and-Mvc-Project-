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
    public class ProvinceRepository : BaseRepository<Province, AHLDataContext>, IProvinceRepository
    {
        public async  Task<List<Province>> GetByProvinceNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(pr => pr.Name == name, includeList);
        }

        public async Task<Province> GetByIdAsync(int provinceId, params string[] includeList)
        {
            return await GetAsync(prv => prv.Id == provinceId, includeList);
        }
    }
}
