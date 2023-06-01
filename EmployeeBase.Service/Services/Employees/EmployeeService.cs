using AutoMapper;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Configurations;
using EmployeeBase.Domain.Entities.Employees;
using EmployeeBase.Service.DTOs.Employees;
using EmployeeBase.Service.Exceptions;
using EmployeeBase.Service.Extensions;
using EmployeeBase.Service.Interface.Employees;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeBase.Service.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EmployeeForViewDTOs> CreateAsync(EmployeeForCreateDTOs employeeForCreateDTO)
        {
            var employee = _mapper.Map<Employee>(employeeForCreateDTO);
            employee.CreateAt = DateTime.UtcNow;
            var createAt = await _unitOfWork.Employee.CreateAsync(employee);
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<EmployeeForViewDTOs>(createAt);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedEmployee = await _unitOfWork.Employee.GetAsync(x => x.Id == id);
            if (deletedEmployee is null)
                throw new EmployeeBaseException(404, "Employee not found");

            var deletResult = await _unitOfWork.Employee.DeleteAsync(deletedEmployee.Id);
            await _unitOfWork.SavechangesAsync();

            return deletResult;
        }

        public IEnumerable<EmployeeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Employee, bool>> expression = null)
             => _mapper.Map<IEnumerable<EmployeeForViewDTOs>>(
                _unitOfWork.Employee.GetAll(expression, new string[] {"Nation", "WorkType", "Region", "District", "JobExperince", "FamilyMember", "Education" }, isTracking: false)
                .ToPagedList(@params));       

        public async Task<EmployeeForViewDTOs> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            var employee = await _unitOfWork.Employee.GetAsync(expression, new string[] { "Nation", "WorkType", "Region", "District", "JobExperince", "FamilyMember", "Education" }, isTracking: false);
            if (employee is null)
                throw new EmployeeBaseException(404, "Employee not found");

            return _mapper.Map<EmployeeForViewDTOs>(employee);
        }

        public async Task<EmployeeForViewDTOs> UpdateAsync(int id, EmployeeForCreateDTOs employeeForCreateDTO)
        {
            var updatedEmployee = await _unitOfWork.Employee.GetAsync(x => x.Id == id);
            if (updatedEmployee == null)
                throw new EmployeeBaseException(404, "Employee notfound");

            updatedEmployee.UpdateAt = DateTime.UtcNow;
            updatedEmployee = _unitOfWork.Employee.Update(_mapper.Map(employeeForCreateDTO, updatedEmployee));
            await _unitOfWork.SavechangesAsync();

            return _mapper.Map<EmployeeForViewDTOs>(updatedEmployee);
        }

        public IEnumerable<EmployeeForViewDTOs> Search(PaginationParams @params, string searchText)
           => _mapper.Map<IEnumerable<EmployeeForViewDTOs>>(
               _unitOfWork.Employee.GetAll(
                   x => x.FirstName.Contains(searchText) | 
                   x.LastName.Contains(searchText) |
                   x.Jshshr.Contains(searchText) |
                   x.Pasport.Contains(searchText) |
                   x.MiddleName.Contains(searchText), 
                   isTracking: false)
               .ToPagedList(@params));
    }
}
