using System.ComponentModel.DataAnnotations;
using System;
using EmployeeBase.Service.DTOs.Employees;

namespace EmployeeBase.Service.DTOs.PersonalData.Eductions
{
    public class EducationForViewDTOs
    {
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(32)]
        public string Faculty { get; set; }
        public DateTime BeganDate { get; set; }
        public DateTime ExpriyDate { get; set; }
        public EmployeeForViewDTOs Employee { get; set; }
    }
}
