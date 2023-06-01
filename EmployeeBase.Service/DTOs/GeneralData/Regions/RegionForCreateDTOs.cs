using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Service.DTOs.GeneralData.Regions
{
    public class RegionForCreateDTOs
    {
        [MaxLength(32)]
        public string Name { get; set; }
    }
}
