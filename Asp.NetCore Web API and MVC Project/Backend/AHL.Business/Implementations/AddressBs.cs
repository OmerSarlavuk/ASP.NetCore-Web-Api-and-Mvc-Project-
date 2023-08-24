using AHL.Business.CustomExceptions;
using AHL.Business.Interfaces;
using AHL.DataAccess.EF.Context;
using AHL.DataAccess.EF.Repositories;
using AHL.DataAccess.Interfaces;
using AHL.Model.Dtos.Address;
using AHL.Model.Dtos.Province;
using AHL.Model.Dtos.Student;
using AHL.Model.Entities;
using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AHL.Business.Implementations
{
    public class AddressBs : IAddressBs
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public AddressBs(IAddressRepository addressRepository, IMapper mapper, IDistrictRepository districtRepository, IStudentRepository studentRepository)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _districtRepository = districtRepository;
            _studentRepository = studentRepository;
        }
        public async Task<ApiResponse<List<AddressGetDto>>> GetAddressAsync(params string[] includeList)
        {
            var address = await _addressRepository.GetAllAsync(predicate: null!, includeList);

            if (address.Count > 0)
            {
                var returnList = _mapper.Map<List<AddressGetDto>>(address);
                var response = ApiResponse<List<AddressGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("Adres Bulunamadı");
        }

        public async Task<ApiResponse<AddressGetDto>> GetByIdAsync(int addressId, params string[] includeList)
        {
            if (addressId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var address = await _addressRepository.GetByIdAsync(addressId, includeList);
            if (address != null)
            {
                var dto = _mapper.Map<AddressGetDto>(address);
                return ApiResponse<AddressGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("Adres Bulunamadı");
        }
    }
}

