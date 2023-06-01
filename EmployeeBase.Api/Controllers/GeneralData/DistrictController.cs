using EmployeeBase.Domain.Configurations;
using EmployeeBase.Service.DTOs.Employees;
using EmployeeBase.Service.DTOs.GeneralData.Districts;
using EmployeeBase.Service.Interface.GeneralData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeBase.Api.Controllers.GeneralData
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _service;
        public DistrictController(IDistrictService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DistrictForCreateDTOs districtForCreateDTO)
           => Ok(await _service.CreateAsync(districtForCreateDTO));

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams @params)
            => Ok(_service.GetAll(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await _service.GetAsync(x => x.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await _service.DeleteAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, DistrictForCreateDTOs districtForCreateDTO)
            => Ok(await _service.UpdateAsync(id, districtForCreateDTO));
    }
}
