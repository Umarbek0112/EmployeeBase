using EmployeeBase.Domain.Configurations;
using EmployeeBase.Service.DTOs.GeneralData.Nations;
using EmployeeBase.Service.DTOs.PersonalData.JobExperince;
using EmployeeBase.Service.Interface.PersonalData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeBase.Api.Controllers.PersonalData
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobExperinceController : ControllerBase
    {
        private readonly IJobExprinceService _service;
        public JobExperinceController(IJobExprinceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(JobExperinceForCreateDTOs jobExperinceForCreateDTO)
          => Ok(await _service.CreateAsync(jobExperinceForCreateDTO));

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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, JobExperinceForCreateDTOs jobExperinceForCreateDTO)
            => Ok(await _service.UpdateAsync(id, jobExperinceForCreateDTO));
    }
}
