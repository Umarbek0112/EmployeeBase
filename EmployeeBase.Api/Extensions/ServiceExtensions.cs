using EmployeeBase.Data.IRepository;
using EmployeeBase.Data.Repository;
using EmployeeBase.Service.Interface.Employees;
using EmployeeBase.Service.Interface.GeneralData;
using EmployeeBase.Service.Interface.PersonalData;
using EmployeeBase.Service.Services.Employees;
using EmployeeBase.Service.Services.GeneralData;
using EmployeeBase.Service.Services.PersonalData;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeBase.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<INationService, NationService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IWorkTypeService, WorkTypeService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IFamilyMemberService, FamilyMemberService>();
            services.AddScoped<IJobExprinceService, JobExprinceService>();
        }
    }
}
