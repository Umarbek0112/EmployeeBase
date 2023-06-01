using EmployeeBase.Domain.Configurations;
using EmployeeBase.Service.DTOs.GeneralData.Nations;
using EmployeeBase.Service.Interface.GeneralData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeBase.Api.Controllers.GeneralData
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationController : ControllerBase
    {
        private readonly INationService _service;
        public NationController(INationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(NationForCreateDTOs nationForCreateDTO)
          => Ok(await _service.CreateAsync(nationForCreateDTO));

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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, NationForCreateDTOs nationForCreateDTO)
            => Ok(await _service.UpdateAsync(id, nationForCreateDTO));
    }
}
