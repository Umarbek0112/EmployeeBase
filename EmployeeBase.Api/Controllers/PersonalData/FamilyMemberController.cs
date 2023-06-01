using EmployeeBase.Domain.Configurations;
using EmployeeBase.Service.DTOs.GeneralData.Nations;
using EmployeeBase.Service.DTOs.PersonalData.FamiliyMembers;
using EmployeeBase.Service.Interface.PersonalData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeBase.Api.Controllers.PersonalData
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMemberController : ControllerBase
    {
        private readonly IFamilyMemberService _service;
        public FamilyMemberController(IFamilyMemberService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FamilyMemberForCreateDTOs familyMemberForCreateDTO)
          => Ok(await _service.CreateAsync(familyMemberForCreateDTO));

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
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, FamilyMemberForCreateDTOs familyMemberForCreateDTO)
            => Ok(await _service.UpdateAsync(id, familyMemberForCreateDTO));
    }
}
