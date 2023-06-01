using EmployeeBase.Data.DbContexs;
using EmployeeBase.Domain.Entities.Employees;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Domain.Entities.PersonalData;
using System.Threading.Tasks;

namespace EmployeeBase.Data.IRepository
{
    public interface IUnitOfWork
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
        public Task SavechangesAsync();
    }
}
