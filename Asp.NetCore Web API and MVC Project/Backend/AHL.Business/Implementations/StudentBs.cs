using AHL.Business.CustomExceptions;
using AHL.Business.Interfaces;
using AHL.DataAccess.EF.Context;
using AHL.DataAccess.Interfaces;
using AHL.Model.Dtos.Address;
using AHL.Model.Dtos.Student;
using AHL.Model.Entities;
using AutoMapper;
using Infrastructure.DataAccess.Implementations.EF;
using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AHL.Business.Implementations
{
    public class StudentBs : IStudentBs
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressBs _addressBs;
        private readonly IDistrictRepository _districtRepository;

        public StudentBs(IStudentRepository studentRepository, IMapper mapper, IAddressRepository addressRepository, IDistrictRepository districtRepository, IAddressBs addressBs)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
            _districtRepository = districtRepository;
            _addressBs = addressBs;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var student = await _studentRepository.GetByIdAsync(id);
            var address = await _addressRepository.GetByStudentId(student.Id);
            var district = await _districtRepository.GetByStudentId(student.Id);

            if (student != null)
            {
                student.IsActive = false;
                if (address != null)
                {
                    address.IsActive = false;
                    await _addressRepository.UpdateAsync(address);
                }
                if (district != null)
                {
                    district.IsActive = false;
                    await _districtRepository.UpdateAsync(district);
                }

                await _studentRepository.UpdateAsync(student);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }

            throw new NotFoundException("Girilen id değerine uygun öğrenci bulunamadı");
        }

        public async Task<ApiResponse<StudentGetDto>> GetByIdAsync(int studentId, params string[] includeList)
        {
            if (studentId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var student = await _studentRepository.GetByIdAsync(studentId, includeList);
            if (student != null)
            {
                var dto = _mapper.Map<StudentGetDto>(student);
                return ApiResponse<StudentGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Öğrenci Bulunamadı");
        }

        public async Task<ApiResponse<List<StudentGetDto>>> GetBySchoolIdentityAsync(string identity, params string[] includeList)
        {
            if (identity == null)
                throw new BadRequestException("identity alanı boş olamaz");

            var Identity = await _studentRepository.GetBySchoolIdentityAsync(identity, includeList);
            if (Identity.Count > 0)
            {
                var returnList = _mapper.Map<List<StudentGetDto>>(Identity);
                return ApiResponse<List<StudentGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Kimlik Bulunamadı");
        }

        public async Task<ApiResponse<List<StudentGetDto>>> GetStudentsAsync(params string[] includeList)
        {
            var students = await _studentRepository.GetAllAsync(predicate: null!, includeList);

            if (students.Count > 0)
            {
                var returnList = _mapper.Map<List<StudentGetDto>>(students);

                var response = ApiResponse<List<StudentGetDto>>.Success(StatusCodes.Status200OK, returnList);

                return response;
            }

            throw new NotFoundException("Öğrenci Bulunamadı");
        }

        public async Task<ApiResponse<Student>> InsertAsync(StudentPostDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("Kaydedilecek öğrenci bilgisini yollayınız.");

            var student = _mapper.Map<Student>(dto);

            var insertedStudent = await _studentRepository.InsertAsync(student);

            return ApiResponse<Student>.Success(StatusCodes.Status201Created, insertedStudent);
        }



        public async Task<ApiResponse<NoData>> UpdateAsync(StudentPutDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("Güncellenecek öğrenci bilgisini yollayınız.");

            if (dto.FirstName == null)
                throw new ArgumentException("İsim bilgisi boş olamaz");

            if (dto.LastName == null)
                throw new ArgumentException("Soyisim bilgisi boş olamaz");

            var student = _mapper.Map<Student>(dto);

            student.IsActive = true;
            await _studentRepository.UpdateAsync(student);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
