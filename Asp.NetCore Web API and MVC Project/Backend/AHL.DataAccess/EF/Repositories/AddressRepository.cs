using AHL.DataAccess.EF.Context;
using AHL.DataAccess.Interfaces;
using AHL.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.DataAccess.EF.Repositories
{
    public class AddressRepository : BaseRepository<Address, AHLDataContext>, IAddressRepository
    {
        public async Task<Address> GetByIdAsync(int addressId, params string[] includeList)
        {
            return await GetAsync(adr => adr.Id == addressId, includeList);
        }

        public async Task<Address> GetByStudentId(int studentId)
        {
            return await GetAsync(adr => adr.StudentId == studentId);
        }

    }
}
