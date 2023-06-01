using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using EmployeeBase.Service.DTOs.GeneralData.Nations;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.GeneralData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.GeneralData
{
    public class NationService : INationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<NationForViewDTOs> CreateAsync(NationForCreateDTOs nationForCreateDTO)
        {
            var nation = _mapper.Map<Nation>(nationForCreateDTO);
            nation.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.Nation.CreateAsync(nation);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<NationForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedNation = await _unitOfWork.Nation.GetAsync(x => x.Id == id);
            if (deletedNation is null)
                throw new EmployeeBaseException(404, "Nation not found");

            var deletResult = await _unitOfWork.Nation.DeleteAsync(deletedNation.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<NationForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Nation, bool>> expression = null)
            => _mapper.Map<IEnumerable<NationForViewDTOs>>(
                _unitOfWork.Nation.GetAll(expression, isTracking: false)
                .ToPagedList(@params));

        public async Task<NationForViewDTOs> GetAsync(Expression<Func<Nation, bool>> expression)
        {
            var nation = await _unitOfWork.Nation.GetAsync(expression);
            if (nation is null)
                throw new EmployeeBaseException(404, "Nation not found");

            return _mapper.Map<NationForViewDTOs>(nation);
        }

        public async Task<NationForViewDTOs> UpdateAsync(int id, NationForCreateDTOs nationForCreateDTO)
        {
            var updated = await _unitOfWork.Nation.GetAsync(x => x.Id == id);
            if (updated == null)
                throw new EmployeeBaseException(404, "Nation notfound");

            updated.UpdateAt = DateTime.UtcNow;
            updated = _unitOfWork.Nation.Update(_mapper.Map(nationForCreateDTO, updated));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<NationForViewDTOs>(updated);
        }
    }
}
