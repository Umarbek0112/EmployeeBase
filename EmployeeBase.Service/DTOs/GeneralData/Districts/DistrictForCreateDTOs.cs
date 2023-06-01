using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Service.DTOs.GeneralData.Districts
{
    public class DistrictForCreateDTOs
    {
        [MaxLength(16)]
        public string Name { get; set; }
        public int RegionId { get; set; }
    }
}
