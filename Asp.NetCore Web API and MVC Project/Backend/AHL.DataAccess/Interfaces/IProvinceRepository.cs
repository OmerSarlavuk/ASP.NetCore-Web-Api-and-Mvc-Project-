using AHL.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.DataAccess.Interfaces
{
    public interface IProvinceRepository : IBaseRepository<Province>
    {
        Task<Province> GetByIdAsync(int provinceId, params string[] includeList);
        Task<List<Province>> GetByProvinceNameAsync(string name, params string[] includeList);
    }
}
