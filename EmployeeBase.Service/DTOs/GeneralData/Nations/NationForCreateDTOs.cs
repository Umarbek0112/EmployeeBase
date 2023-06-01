using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Service.DTOs.GeneralData.Nations
{
    public class NationForCreateDTOs
    {
        [MaxLength(32)]
        public string Name { get; set; }
    }
}
