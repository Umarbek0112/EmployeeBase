using EmployeeBase.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Domain.Entities.GeneralData
{
    public class WorkType : Auditable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
    }
}
