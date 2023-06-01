using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Service.DTOs.GeneralData.WorkTypes
{
    public class WorkTypeForCreateDTOs
    {
        [MaxLength(64)]
        public string Name { get; set; }
        [MaxLength(64)]
        public string Department { get; set; }
    }
}
