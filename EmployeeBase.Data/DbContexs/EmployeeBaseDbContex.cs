using EmployeeBase.Domain.Entities.Employees;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Domain.Entities.PersonalData;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBase.Data.DbContexs
{
    public class EmployeeBaseDbContex : DbContext
    {
        public EmployeeBaseDbContex(DbContextOptions<EmployeeBaseDbContex> options) : base(options)
        {
            
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobExperince> JobExperiences { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Nation> Nations { get; set; }
        public virtual DbSet<WorkType> WorkTypes { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<District> Districts { get; set; }
    }
}
