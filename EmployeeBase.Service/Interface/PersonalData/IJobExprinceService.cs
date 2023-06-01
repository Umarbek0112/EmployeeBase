using EmployeeBase.Domain.Configurations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.PersonalData.JobExperince;
using EmployeeBase.Domain.Entities.PersonalData;

namespace EmployeeBase.Service.Interface.PersonalData
{
    public interface IJobExprinceService
    {
        IEnumerable<JobExperinceForViewDTOs> GetAll(PaginationParams @params, Expression<Func<JobExperince, bool>> expression = null);
        Task<JobExperinceForViewDTOs> GetAsync(Expression<Func<JobExperince, bool>> expression);
        Task<JobExperinceForViewDTOs> CreateAsync(JobExperinceForCreateDTOs jobExperinceForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<JobExperinceForViewDTOs> UpdateAsync(int id, JobExperinceForCreateDTOs jobExperinceForCreateDTO);
    }
}
