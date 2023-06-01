using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Service.DTOs.GeneralData.Regions;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.GeneralData.WorkTypes;

namespace EmployeeBase.Service.Interface.GeneralData
{
    public interface IWorkTypeService
    {
        IEnumerable<WorkTypeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<WorkType, bool>> expression = null);
        Task<WorkTypeForViewDTOs> GetAsync(Expression<Func<WorkType, bool>> expression);
        Task<WorkTypeForViewDTOs> CreateAsync(WorkTypeForCreateDTOs workTypeForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<WorkTypeForViewDTOs> UpdateAsync(int id, WorkTypeForCreateDTOs workTypeForCreateDTO);
    }
}
