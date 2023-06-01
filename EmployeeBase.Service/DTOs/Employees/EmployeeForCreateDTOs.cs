using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeBase.Service.DTOs.Employees
{
    public class EmployeeForCreateDTOs
    {
        [MaxLength(16)]
        public string LastName { get; set; }
        [MaxLength(16)]
        public string FirstName { get; set; }
        [MaxLength(16)]
        public string MiddleName { get; set; }
        [MaxLength(9)]
        public string Pasport { get; set; }
        [MaxLength(14)]
        public string Jshshr { get; set; }
        public int NationId { get; set; }
        public DateTime BrithDate { get; set; }
        public int WorkTypeId { get; set; }
        public int RegionId { get; set; }
        public int DistrictId { get; set; }
    }
}
