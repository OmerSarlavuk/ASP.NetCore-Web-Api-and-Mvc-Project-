using AHL.Model.Dtos.Province;
using AHL.Model.Entities;
using AutoMapper;

namespace AHL.Business.Profiles
{
    public class ProvinceProfile : Profile
    {
        public ProvinceProfile()
        {
            CreateMap<Province, ProvinceGetDto>();
        }
    }
}
