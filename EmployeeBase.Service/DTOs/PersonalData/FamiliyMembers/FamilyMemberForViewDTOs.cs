using System.ComponentModel.DataAnnotations;
using System;
using EmployeeBase.Service.DTOs.Employees;

namespace EmployeeBase.Service.DTOs.PersonalData.FamiliyMembers
{
    public class FamilyMemberForViewDTOs
    {
        public int Id { get; set; }
        public string Who { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BrithPlace { get; set; }
        public string JobPosition { get; set; }
        public string Addres { get; set; }
        public EmployeeForViewDTOs Employee { get; set; }
    }
}
