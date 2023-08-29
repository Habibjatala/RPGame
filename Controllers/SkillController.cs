using FirstTut.Dtos.Skill;
using FirstTut.Models;
using FirstTut.Services.SkillService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstTut.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
       private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }   

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> AddSkill(AddSkillDto newSkill)
        {
            var skill = await _skillService.AddSkill(newSkill);

            if (skill == null)
            {
                return BadRequest();
            }
            return Ok(skill);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> GetAllSkill()
        {
            var response = await _skillService.GetAllSkill();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> GetSkillById(int id)
        {
            var response = await _skillService.GetSkillById(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSkillDto>>> UpdateSkill(int id, UpdateSkillDto updatedSkill)
        {
            var response = await _skillService.UpdateSkill(id, updatedSkill);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetSkillDto>>>> DeleteSkill(int id)
        {
            var response = await _skillService.DeleteSkill(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
