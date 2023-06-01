using EmployeeBase.Domain.Configurations;
using EmployeeBase.Service.DTOs.PersonalData.Eductions;
using EmployeeBase.Service.Interface.PersonalData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeBase.Api.Controllers.PersonalData
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _service;
        public EducationController(IEducationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EducationForCreateDTOs educationForCreateDTO)
          => Ok(await _service.CreateAsync(educationForCreateDTO));

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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, EducationForCreateDTOs educationForCreateDTO)
            => Ok(await _service.UpdateAsync(id, educationForCreateDTO));
    }
}
