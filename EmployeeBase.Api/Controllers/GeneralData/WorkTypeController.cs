using EmployeeBase.Domain.Configurations;
using EmployeeBase.Service.DTOs.GeneralData.Nations;
using EmployeeBase.Service.DTOs.GeneralData.WorkTypes;
using EmployeeBase.Service.Interface.GeneralData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeBase.Api.Controllers.GeneralData
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypeController : ControllerBase
    {
        private readonly IWorkTypeService _service;
        public WorkTypeController(IWorkTypeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(WorkTypeForCreateDTOs workTypeForCreateDTO)
          => Ok(await _service.CreateAsync(workTypeForCreateDTO));

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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, WorkTypeForCreateDTOs workTypeForCreateDTO)
            => Ok(await _service.UpdateAsync(id, workTypeForCreateDTO));
    }
}
