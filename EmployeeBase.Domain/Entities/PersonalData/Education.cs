using EmployeeBase.Domain.Commons;
using EmployeeBase.Domain.Entities.Employees;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Domain.Entities.PersonalData
{
    public class Education : Auditable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        public DateTime BeganDate { get; set; }
        public DateTime ExpriyDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
