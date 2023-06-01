using EmployeeBase.Domain.Configurations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using EmployeeBase.Domain.Entities.GeneralData;

namespace EmployeeBase.Service.Interface.GeneralData
{
    public interface IDistrictService
    {
        IEnumerable<DistrictForViewDTOs> GetAll(PaginationParams @params, Expression<Func<District, bool>> expression = null);
        Task<DistrictForViewDTOs> GetAsync(Expression<Func<District, bool>> expression);
        Task<DistrictForViewDTOs> CreateAsync(DistrictForCreateDTOs districtForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<DistrictForViewDTOs> UpdateAsync(int id, DistrictForCreateDTOs districtForCreateDTO);
    }
}
