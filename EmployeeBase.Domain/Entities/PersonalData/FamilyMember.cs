using EmployeeBase.Domain.Commons;
using EmployeeBase.Domain.Entities.Employees;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Domain.Entities.PersonalData
{
    public class FamilyMember : Auditable
    {
        [Required]
        public string Who { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string BrithPlace { get; set; }
        [Required]
        public string JobPosition { get; set; }
        [Required]
        public string Addres { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
