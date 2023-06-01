using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeBase.Service.DTOs.PersonalData.FamiliyMembers
{
    public class FamilyMemberForCreateDTOs
    {
        [MaxLength(16)]
        public string Who { get; set; }
        [MaxLength(32)]
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(32)]
        public string BrithPlace { get; set; }
        [MaxLength(64)]
        public string JobPosition { get; set; }
        [MaxLength(32)]
        public string Addres { get; set; }
        public int EmployeeId { get; set; }
    }
}
