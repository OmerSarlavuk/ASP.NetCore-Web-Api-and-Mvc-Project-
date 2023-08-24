using AHL.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.DataAccess.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        Task<Address> GetByIdAsync(int addressId, params string[] includeList);
        Task<Address> GetByStudentId(int studentId);
    }
}
