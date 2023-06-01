using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.PersonalData;
using EmployeeBase.Service.DTOs.PersonalData.JobExperince;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.PersonalData;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.PersonalData
{
    public class JobExprinceService : IJobExprinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public JobExprinceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<JobExperinceForViewDTOs> CreateAsync(JobExperinceForCreateDTOs jobExperinceForCreateDTO)
        {
            var jobexprince = _mapper.Map<JobExperince>(jobExperinceForCreateDTO);
            jobexprince.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.JobExperience.CreateAsync(jobexprince);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<JobExperinceForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedJobExprince = await _unitOfWork.JobExperience.GetAsync(x => x.Id == id);
            if (deletedJobExprince is null)
                throw new EmployeeBaseException(404, "JobExprince not found");

            var deletResult = await _unitOfWork.JobExperience.DeleteAsync(deletedJobExprince.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<JobExperinceForViewDTOs> GetAll(PaginationParams @params, Expression<Func<JobExperince, bool>> expression = null)
            => _mapper.Map<IEnumerable<JobExperinceForViewDTOs>>(
                _unitOfWork.JobExperience.GetAll(expression, new string[] { "Employee" }, isTracking: false)
                .ToPagedList(@params));

        public async Task<JobExperinceForViewDTOs> GetAsync(Expression<Func<JobExperince, bool>> expression)
        {
            var jobExprince = await _unitOfWork.JobExperience.GetAsync(expression, new string[] { "Employee" }, isTracking: false);
            if (jobExprince is null)
                throw new EmployeeBaseException(404, "JobExprince not found");

            return _mapper.Map<JobExperinceForViewDTOs>(jobExprince);
        }

        public async Task<JobExperinceForViewDTOs> UpdateAsync(int id, JobExperinceForCreateDTOs jobExperinceForCreateDTO)
        {
            var updated = await _unitOfWork.JobExperience.GetAsync(x => x.Id == id);
            if (updated == null)
                throw new EmployeeBaseException(404, "Education notfound");

            updated.UpdateAt = DateTime.UtcNow;
            updated = _unitOfWork.JobExperience.Update(_mapper.Map(jobExperinceForCreateDTO, updated));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<JobExperinceForViewDTOs>(updated);
        }
    }
}
