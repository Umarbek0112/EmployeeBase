using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Service.DTOs.GeneralData.Regions;
using EmployeeBase.Service.DTOs.GeneralData.WorkTypes;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.GeneralData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.GeneralData
{
    public class WorkTypeService : IWorkTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public WorkTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<WorkTypeForViewDTOs> CreateAsync(WorkTypeForCreateDTOs workTypeForCreateDTO)
        {
            var workType = _mapper.Map<WorkType>(workTypeForCreateDTO);
            workType.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.WorkType.CreateAsync(workType);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<WorkTypeForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedWorkType = await _unitOfWork.WorkType.GetAsync(x => x.Id == id);
            if (deletedWorkType is null)
                throw new EmployeeBaseException(404, "WorkType not found");

            var deletResult = await _unitOfWork.WorkType.DeleteAsync(deletedWorkType.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<WorkTypeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<WorkType, bool>> expression = null)
            => _mapper.Map<IEnumerable<WorkTypeForViewDTOs>>(
                _unitOfWork.WorkType.GetAll(expression, isTracking: false)
                .ToPagedList(@params));

        public async Task<WorkTypeForViewDTOs> GetAsync(Expression<Func<WorkType, bool>> expression)
        {
            var workType = await _unitOfWork.WorkType.GetAsync(expression);
            if (workType is null)
                throw new EmployeeBaseException(404, "WorkType not found");

            return _mapper.Map<WorkTypeForViewDTOs>(workType);
        }

        public async Task<WorkTypeForViewDTOs> UpdateAsync(int id, WorkTypeForCreateDTOs workTypeForCreateDTO)
        {
            var updated = await _unitOfWork.WorkType.GetAsync(x => x.Id == id);
            if (updated == null)
                throw new EmployeeBaseException(404, "WorkType notfound");

            updated.UpdateAt = DateTime.UtcNow;
            updated = _unitOfWork.WorkType.Update(_mapper.Map(workTypeForCreateDTO, updated));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<WorkTypeForViewDTOs>(updated);
        }
    }
}
