using EmployeeBase.Domain.Commons;
using EmployeeBase.Domain.Entities.GeneralData;
using EmployeeBase.Domain.Entities.PersonalData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Domain.Entities.Employees
{
    public class Employee : Auditable
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string Pasport { get; set; }
        [Required]
        public string Jshshr { get; set; }
        [Required]
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        [Required]
        public DateTime BrithDate { get; set; }
        [Required]
        public int WorkTypeId { get; set; }
        public WorkType WorkType { get; set; }
        [Required]
        public int RegionId { get; set; }
        public Region Region { get; set; }
        [Required]
        public int DistrictId { get; set; }
        public District District { get; set; }

        public ICollection<JobExperince> JobExperince { get; set; }
        public ICollection<FamilyMember> FamilyMember { get; set; }
        public ICollection<Education> Education { get; set; }
    }
}
