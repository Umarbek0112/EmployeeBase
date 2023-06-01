using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using EmployeeBase.Service.DTOs.GeneralData.Regions;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.GeneralData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.GeneralData
{
    public class RegionService : IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RegionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<RegionForViewDTOs> CreateAsync(RegionForCreateDTOs regionForCreateDTO)
        {
            var region = _mapper.Map<Region>(regionForCreateDTO);
            region.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.Region.CreateAsync(region);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<RegionForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedRegion = await _unitOfWork.Region.GetAsync(x => x.Id == id);
            if (deletedRegion is null)
                throw new EmployeeBaseException(404, "Region not found");

            var deletResult = await _unitOfWork.Region.DeleteAsync(deletedRegion.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<RegionForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Region, bool>> expression = null)
            => _mapper.Map<IEnumerable<RegionForViewDTOs>>(
                _unitOfWork.Region.GetAll(expression, isTracking: false)
                .ToPagedList(@params));

        public async Task<RegionForViewDTOs> GetAsync(Expression<Func<Region, bool>> expression)
        {
            var region = await _unitOfWork.Region.GetAsync(expression);
            if (region is null)
                throw new EmployeeBaseException(404, "Region not found");

            return _mapper.Map<RegionForViewDTOs>(region);
        }

        public async Task<RegionForViewDTOs> UpdateAsync(int id, RegionForCreateDTOs regionForCreateDTO)
        {
            var updated = await _unitOfWork.Region.GetAsync(x => x.Id == id);
            if (updated == null)
                throw new EmployeeBaseException(404, "Region notfound");

            updated.UpdateAt = DateTime.UtcNow;
            updated = _unitOfWork.Region.Update(_mapper.Map(regionForCreateDTO, updated));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<RegionForViewDTOs>(updated);
        }
    }
}
