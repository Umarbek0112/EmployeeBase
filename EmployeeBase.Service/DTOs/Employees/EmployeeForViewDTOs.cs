using System.ComponentModel.DataAnnotations;
using System;
using EmployeeBase.Service.DTOs.GeneralData.Nations;
using EmployeeBase.Service.DTOs.GeneralData.WorkTypes;
using EmployeeBase.Service.DTOs.GeneralData.Regions;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using System.Collections;
using System.Collections.Generic;
using EmployeeBase.Service.DTOs.PersonalData.JobExperince;
using EmployeeBase.Service.DTOs.PersonalData.FamiliyMembers;
using EmployeeBase.Service.DTOs.PersonalData.Eductions;

namespace EmployeeBase.Service.DTOs.Employees
{
    public class EmployeeForViewDTOs
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Pasport { get; set; }
        public string Jshshr { get; set; }
        public NationForViewDTOs Nation { get; set; }
        public DateTime BrithDate { get; set; }
        public WorkTypeForViewDTOs WorkType { get; set; }
        public RegionForViewDTOs Region { get; set; }
        public DistrictForViewDTOs District { get; set; }

        public ICollection<JobExperinceForViewDTOs> JobExperince { get; set; }
        public ICollection<FamilyMemberForViewDTOs> FamilyMember { get; set; }
        public ICollection<EducationForViewDTOs> Education { get; set; }
    }
}
