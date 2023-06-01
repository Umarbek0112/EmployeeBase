using EmployeeBase.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Domain.Entities.GeneralData
{
    public class Nation : Auditable
    {
        [Required]
        public string Name { get; set; }
    }
}
