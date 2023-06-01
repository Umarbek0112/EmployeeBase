using EmployeeBase.Domain.Commons;
using EmployeeBase.Domain.Entities.Employees;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Domain.Entities.PersonalData
{
    public class JobExperince : Auditable
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Tasks { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Required]
        public DateTime BeganDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
