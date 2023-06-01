using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeBase.Service.DTOs.PersonalData.JobExperince
{
    public class JobExperinceForCreateDTOs
    {
        [MaxLength(32)]
        public string Type { get; set; }
        [MaxLength(32)]
        public string Tasks { get; set; }
        public int EmployeeId { get; set; }
        public DateTime BeganDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
