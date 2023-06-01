using EmployeeBase.Domain.Configurations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.PersonalData.FamiliyMembers;
using EmployeeBase.Domain.Entities.PersonalData;

namespace EmployeeBase.Service.Interface.PersonalData
{
    public interface IFamilyMemberService
    {
        IEnumerable<FamilyMemberForViewDTOs> GetAll(PaginationParams @params, Expression<Func<FamilyMember, bool>> expression = null);
        Task<FamilyMemberForViewDTOs> GetAsync(Expression<Func<FamilyMember, bool>> expression);
        Task<FamilyMemberForViewDTOs> CreateAsync(FamilyMemberForCreateDTOs familyMemberForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<FamilyMemberForViewDTOs> UpdateAsync(int id, FamilyMemberForCreateDTOs familyMemberForCreateDTO);
    }
}
