using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeBase.Service.DTOs.PersonalData.Eductions
{
    public class EducationForCreateDTOs
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
        public DateTime BeganDate { get; set; }
        public DateTime ExpriyDate { get; set; }
        public int EmployeeId { get; set; }
    }
}
