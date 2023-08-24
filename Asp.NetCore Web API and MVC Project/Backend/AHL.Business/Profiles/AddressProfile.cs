using AHL.Model.Dtos.Address;
using AHL.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Business.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressGetDto>()
                .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Province.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.studentfirstName, opt => opt.MapFrom(src => src.Student.FirstName))
                .ForMember(dest => dest.studentlastName, opt => opt.MapFrom(src => src.Student.LastName));
        }
    }
}
