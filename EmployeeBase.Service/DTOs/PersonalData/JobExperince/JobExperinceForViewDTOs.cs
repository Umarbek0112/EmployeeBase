using System.ComponentModel.DataAnnotations;
using System;
using EmployeeBase.Service.DTOs.Employees;

namespace EmployeeBase.Service.DTOs.PersonalData.JobExperince
{
    public class JobExperinceForViewDTOs
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Tasks { get; set; }
        public EmployeeForViewDTOs Employee { get; set; }
        public DateTime BeganDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
