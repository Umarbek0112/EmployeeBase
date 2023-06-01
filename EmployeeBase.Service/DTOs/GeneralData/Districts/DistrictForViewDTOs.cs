using EmployeeBase.Service.DTOs.GeneralData.Regions;
using System.ComponentModel.DataAnnotations;

namespace EmployeeBase.Service.DTOs.GeneralData.Districts
{
    public class DistrictForViewDTOs
    {
        public string Name { get; set; }
        public RegionForViewDTOs Region { get; set; }
    }
}
