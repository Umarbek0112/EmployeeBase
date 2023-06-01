using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.DTOs.Employees;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.Employees;

namespace EmployeeBase.Service.Interface.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Employee, bool>> expression = null);
        Task<EmployeeForViewDTOs> GetAsync(Expression<Func<Employee, bool>> expression);
        Task<EmployeeForViewDTOs> CreateAsync(EmployeeForCreateDTOs employeeForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<EmployeeForViewDTOs> UpdateAsync(int id, EmployeeForCreateDTOs employeeForCreateDTO);
        public IEnumerable<EmployeeForViewDTOs> Search(PaginationParams @params, string searchText);
    }
}
