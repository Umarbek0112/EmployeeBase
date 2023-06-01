using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Service.DTOs.GeneralData.Regions;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.PersonalData.Eductions;
using EmployeeBase.Domain.Entities.PersonalData;

namespace EmployeeBase.Service.Interface.PersonalData
{
    public interface IEducationService
    {
        IEnumerable<EducationForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Education, bool>> expression = null);
        Task<EducationForViewDTOs> GetAsync(Expression<Func<Education, bool>> expression);
        Task<EducationForViewDTOs> CreateAsync(EducationForCreateDTOs educationForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<EducationForViewDTOs> UpdateAsync(int id, EducationForCreateDTOs educationForCreateDTO);
    }
}
