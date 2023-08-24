using AHL.Business.CustomExceptions;
using AHL.Business.Interfaces;
using AHL.DataAccess.EF.Repositories;
using AHL.DataAccess.Interfaces;
using AHL.Model.Dtos.Address;
using AHL.Model.Dtos.District;
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
    public class DistrictBs : IDistrictBs
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IMapper _mapper;

        public DistrictBs(IDistrictRepository districtRepository, IMapper mapper)
        {
            _districtRepository = districtRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<DistrictGetDto>> GetByIdAsync(int districtId, params string[] includeList)
        {
            if (districtId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var district = await _districtRepository.GetByIdAsync(districtId, includeList);
            if (district != null)
            {
                var dto = _mapper.Map<DistrictGetDto>(district);
                return ApiResponse<DistrictGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Açıklama Bulunamadı");
        }

        public async Task<ApiResponse<List<DistrictGetDto>>> GetDistrictAsync(params string[] includeList)
        {
            var district = await _districtRepository.GetAllAsync(predicate: null, includeList);

            if (district.Count > 0)
            {
                var returnList = _mapper.Map<List<DistrictGetDto>>(district);
                var response = ApiResponse<List<DistrictGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Açıklama Bulunamadı");
        }
    }
}
