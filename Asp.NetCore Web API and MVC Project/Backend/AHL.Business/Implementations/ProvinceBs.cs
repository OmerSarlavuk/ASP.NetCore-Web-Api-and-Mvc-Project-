using AHL.Business.CustomExceptions;
using AHL.Business.Interfaces;
using AHL.DataAccess.EF.Repositories;
using AHL.DataAccess.Interfaces;
using AHL.Model.Dtos.Province;
using AHL.Model.Dtos.Student;
using AHL.Model.Entities;
using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Business.Implementations
{
    public class ProvinceBs : IProvinceBs
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public ProvinceBs(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProvinceGetDto>> GetByIdAsync(int provinceId, params string[] includeList)
        {
            if (provinceId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var province = await _provinceRepository.GetByIdAsync(provinceId, includeList);
            if(province != null)
            {
                var dto = _mapper.Map<ProvinceGetDto>(province); 
                return ApiResponse<ProvinceGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Şehir Bulunamadı");
        }

        public async Task<ApiResponse<List<ProvinceGetDto>>> GetByProvinceNameAsync(string name, params string[] includeList)
        {
            if (name == null)
                throw new NotFoundException("Şehir değerini giriniz");

            var provinceList = await _provinceRepository.GetByProvinceNameAsync(name, includeList);
            if (provinceList.Count > 0)
            {
                var returnList = _mapper.Map<List<ProvinceGetDto>>(provinceList);  
                return ApiResponse<List<ProvinceGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("Şehir Bulunamadı");
        }


        public async Task<ApiResponse<List<ProvinceGetDto>>> GetProvinceAsync(params string[] includeList)
        {
            var provinces = await _provinceRepository.GetAllAsync(predicate: null, includeList);

            if(provinces.Count > 0)
            {
                var returnList = _mapper.Map<List<ProvinceGetDto>>(provinces);
                var response = ApiResponse<List<ProvinceGetDto>> .Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Şehir Bulunamadı");
        }
    }
}
