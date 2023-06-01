using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Domain.Entities.PersonalData;
using EmployeeBase.Service.DTOs.GeneralData.WorkTypes;
using EmployeeBase.Service.DTOs.PersonalData.Eductions;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.PersonalData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.PersonalData
{
    public class EducationService : IEducationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EducationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationForViewDTOs> CreateAsync(EducationForCreateDTOs educationForCreateDTO)
        {
            var education = _mapper.Map<Education>(educationForCreateDTO);
            education.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.Education.CreateAsync(education);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<EducationForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedEducation = await _unitOfWork.Education.GetAsync(x => x.Id == id);
            if (deletedEducation is null)
                throw new EmployeeBaseException(404, "Education not found");

            var deletResult = await _unitOfWork.Education.DeleteAsync(deletedEducation.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<EducationForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Education, bool>> expression = null)
             => _mapper.Map<IEnumerable<EducationForViewDTOs>>(
                _unitOfWork.Education.GetAll(expression, isTracking: false)
                .ToPagedList(@params));

        public async Task<EducationForViewDTOs> GetAsync(Expression<Func<Education, bool>> expression)
        {
            var education = await _unitOfWork.Education.GetAsync(expression, isTracking: false);
            if (education is null)
                throw new EmployeeBaseException(404, "Education not found");

            return _mapper.Map<EducationForViewDTOs>(education);
        }

        public async Task<EducationForViewDTOs> UpdateAsync(int id, EducationForCreateDTOs educationForCreateDTO)
        {
            var updated = await _unitOfWork.Education.GetAsync(x => x.Id == id);
            if (updated == null)
                throw new EmployeeBaseException(404, "Education notfound");

            updated.UpdateAt = DateTime.UtcNow;
            updated = _unitOfWork.Education.Update(_mapper.Map(educationForCreateDTO, updated));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<EducationForViewDTOs>(updated);
        }
    }
}
