using AHL.Model.Dtos.District;
using AHL.Model.Entities;
using AutoMapper;

namespace AHL.Business.Profiles
{
    public class DistrictProfile : Profile
    {
        public DistrictProfile()
        {
            CreateMap<District, DistrictGetDto>()
                .ForMember(dest => dest.AddressDetail, opt => opt.MapFrom(src => src.Addresses.AddressDetail))
                .ForMember(dest => dest.ProvinceName, opt => opt.MapFrom(src => src.Province.Name))
                .ForMember(dest => dest.studentfirstName, opt => opt.MapFrom(src => src.Student.FirstName))
                .ForMember(dest => dest.studentlastName, opt => opt.MapFrom(src => src.Student.LastName));
        }
        
    }
}
