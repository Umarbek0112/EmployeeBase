using EmployeeBase.Domain.Configurations;
using EmployeeBase.Service.DTOs.Employees;
using EmployeeBase.Service.Interface.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeBase.Api.Controllers.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeForCreateDTOs employeeForCreateDTO)
           => Ok(await _service.CreateAsync(employeeForCreateDTO));

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams @params)
            => Ok(_service.GetAll(@params));

        [HttpGet("search/{name}")]
        public IActionResult Search([FromRoute] string name, [FromQuery] PaginationParams @params)
            => Ok(_service.Search(@params, name));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await _service.GetAsync(x => x.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await _service.DeleteAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, EmployeeForCreateDTOs employeeForCreateDTO)
            => Ok(await _service.UpdateAsync(id, employeeForCreateDTO));
    }
}
