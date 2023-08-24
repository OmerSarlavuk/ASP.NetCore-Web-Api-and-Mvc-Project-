using AHL.Business.Implementations;
using AHL.Business.Interfaces;
using AHL.Business.Profiles;
using AHL.DataAccess.EF.Repositories;
using AHL.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StudentProfile));
            services.AddAutoMapper(typeof(AddressProfile));
            services.AddAutoMapper(typeof(ProvinceProfile));
            services.AddAutoMapper(typeof(DistrictProfile));

            services.AddScoped<IAddressBs, AddressBs>();
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.AddScoped<IDistrictBs, DistrictBs>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();

            services.AddScoped<IProvinceBs, ProvinceBs>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();

            services.AddScoped<IStudentBs, StudentBs>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IAdminUserBs, AdminUserBs>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();
        }
    }
}
