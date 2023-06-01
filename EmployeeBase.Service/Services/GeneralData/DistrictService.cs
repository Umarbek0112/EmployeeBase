using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.Employees;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Service.DTOs.Employees;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.GeneralData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.GeneralData
{
    public class DistrictService : IDistrictService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DistrictService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DistrictForViewDTOs> CreateAsync(DistrictForCreateDTOs districtForCreateDTO)
        {
            var district = _mapper.Map<District>(districtForCreateDTO);
            district.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.District.CreateAsync(district);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<DistrictForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedDistrict = await _unitOfWork.District.GetAsync(x => x.Id == id);
            if (deletedDistrict is null)
                throw new EmployeeBaseException(404, "District not found");

            var deletResult = await _unitOfWork.District.DeleteAsync(deletedDistrict.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<DistrictForViewDTOs> GetAll(PaginationParams @params, Expression<Func<District, bool>> expression = null)
             => _mapper.Map<IEnumerable<DistrictForViewDTOs>>(
                _unitOfWork.District.GetAll(expression, new string[] { "Region" }, isTracking: false)
                .ToPagedList(@params));

        public async Task<DistrictForViewDTOs> GetAsync(Expression<Func<District, bool>> expression)
        {
            var district = await _unitOfWork.District.GetAsync(expression, new string[] { "Region" }, isTracking: false);
            if (district is null)
                throw new EmployeeBaseException(404, "District not found");

            return _mapper.Map<DistrictForViewDTOs>(district);
        }

        public async Task<DistrictForViewDTOs> UpdateAsync(int id, DistrictForCreateDTOs districtForCreateDTO)
        {
            var updated = await _unitOfWork.District.GetAsync(x => x.Id == id);
            if (updated == null)
                throw new EmployeeBaseException(404, "District notfound");

            updated.UpdateAt = DateTime.UtcNow;
            updated = _unitOfWork.District.Update(_mapper.Map(districtForCreateDTO, updated));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<DistrictForViewDTOs>(updated);
        }
    }
}
