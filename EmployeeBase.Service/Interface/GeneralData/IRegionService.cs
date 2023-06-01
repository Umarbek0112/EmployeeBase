using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.GeneralData;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.GeneralData.Regions;

namespace EmployeeBase.Service.Interface.GeneralData
{
    public interface IRegionService
    {
        IEnumerable<RegionForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Region, bool>> expression = null);
        Task<RegionForViewDTOs> GetAsync(Expression<Func<Region, bool>> expression);
        Task<RegionForViewDTOs> CreateAsync(RegionForCreateDTOs regionForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<RegionForViewDTOs> UpdateAsync(int id, RegionForCreateDTOs regionForCreateDTO);
    }
}
