using AHL.Model.Dtos.Student;
using AHL.Model.Entities;
using AutoMapper;


namespace AHL.Business.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentGetDto>()
                .ForMember(dest => dest.AddressDetail, opt => opt.MapFrom(src => src.Address.AddressDetail))
                .ForMember(dest => dest.AdressId, opt => opt.MapFrom(src => src.Address.Id));
            CreateMap<StudentPostDto, Student>();
            CreateMap<StudentPutDto, Student>();
        }
    }
}
