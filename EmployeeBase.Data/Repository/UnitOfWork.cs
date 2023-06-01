using EmployeeBase.Data.DbContexs;
using EmployeeBase.Data.IRepository;
using EmployeeBase.Domain.Entities.Employees;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Domain.Entities.PersonalData;
using System;
using System.Threading.Tasks;

namespace EmployeeBase.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Employee> Employee { get; }
        public IGenericRepository<District> District { get; }
        public IGenericRepository<Nation> Nation { get; }
        public IGenericRepository<Region> Region { get; }
        public IGenericRepository<WorkType> WorkType { get; }
        public IGenericRepository<Education> Education { get; }
        public IGenericRepository<FamilyMember> FamilyMember { get; }
        public IGenericRepository<JobExperince> JobExperience { get; }
        public EmployeeBaseDbContex DbContex { get; }

        public UnitOfWork(EmployeeBaseDbContex dbContex)
        {
            DbContex = dbContex;

            Employee = new GenericRepository<Employee>(dbContex);
            District = new GenericRepository<District>(dbContex);
            Nation = new GenericRepository<Nation>(dbContex);
            Region = new GenericRepository<Region>(dbContex);
            WorkType = new GenericRepository<WorkType>(dbContex);
            Education = new GenericRepository<Education>(dbContex);
            FamilyMember = new GenericRepository<FamilyMember>(dbContex);
            JobExperience = new GenericRepository<JobExperince>(dbContex);
        }

        public Task SavechangesAsync()
            => DbContex.SaveChangesAsync();
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
