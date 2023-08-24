using AHL.Model.Dtos.AdminUser;
using AHL.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Business.Profiles
{
    public class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminUser, AdminUserGetDto>();
        }
    }
}
