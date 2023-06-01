

using AutoMapper;
using EmployeeBase.Domain.Entities.Employees;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Domain.Entities.PersonalData;
using EmployeeBase.Service.DTOs.Employees;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using EmployeeBase.Service.DTOs.GeneralData.Nations;
using EmployeeBase.Service.DTOs.GeneralData.Regions;
using EmployeeBase.Service.DTOs.GeneralData.WorkTypes;
using EmployeeBase.Service.DTOs.PersonalData.Eductions;
using EmployeeBase.Service.DTOs.PersonalData.FamiliyMembers;
using EmployeeBase.Service.DTOs.PersonalData.JobExperince;

namespace EmployeeBase.Service.Mappers
{
    public class MappingProfile : Profile   
    {
        public MappingProfile()
        {
            #region Employee
            CreateMap<Employee, EmployeeForCreateDTOs>().ReverseMap();
            CreateMap<Employee, EmployeeForViewDTOs>().ReverseMap();
            #endregion

            #region District
            CreateMap<District, DistrictForCreateDTOs>().ReverseMap();
            CreateMap<District, DistrictForViewDTOs>().ReverseMap();
            #endregion
            
            #region Nation
            CreateMap<Nation, NationForCreateDTOs>().ReverseMap();
            CreateMap<Nation, NationForViewDTOs>().ReverseMap();
            #endregion
            
            #region Region
            CreateMap<Region, RegionForCreateDTOs>().ReverseMap();
            CreateMap<Region, RegionForViewDTOs>().ReverseMap();
            #endregion
            
            #region WorkType 
            CreateMap<WorkType, WorkTypeForCreateDTOs>().ReverseMap();
            CreateMap<WorkType, WorkTypeForViewDTOs>().ReverseMap();
            #endregion
            
            #region Education
            CreateMap<Education, EducationForCreateDTOs>().ReverseMap();
            CreateMap<Education, EducationForViewDTOs>().ReverseMap();
            #endregion
            
            #region FamiliyMember
            CreateMap<FamilyMember, FamilyMemberForCreateDTOs>().ReverseMap();
            CreateMap<FamilyMember, FamilyMemberForViewDTOs>().ReverseMap();
            #endregion
            
            #region JobExperince
            CreateMap<JobExperince, JobExperinceForCreateDTOs>().ReverseMap();
            CreateMap<JobExperince, JobExperinceForViewDTOs>().ReverseMap();
            #endregion
        }
    }
}
