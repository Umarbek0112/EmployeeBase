using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.GeneralData.Nations;

namespace EmployeeBase.Service.Interface.GeneralData
{
    public interface INationService
    {
        IEnumerable<NationForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Nation, bool>> expression = null);
        Task<NationForViewDTOs> GetAsync(Expression<Func<Nation, bool>> expression);
        Task<NationForViewDTOs> CreateAsync(NationForCreateDTOs nationForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<NationForViewDTOs> UpdateAsync(int id, NationForCreateDTOs nationForCreateDTO);
    }
}
