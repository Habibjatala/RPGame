using AutoMapper;
using FirstTut.Dtos.Character;
using FirstTut.Models;
using FirstTut.Services.CharacterServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace FirstTut.Controllers
{
    [Authorize]
    
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacter()
        {
           
                return Ok(await _characterService.GetAllCharacter());
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetSingle(id));
        }

        [HttpPost]

        public async Task<ActionResult <ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto character)
        {

           
            return Ok(await _characterService.AddCharacter(character));
        }
        [HttpPut]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatecharacter)
        {
            var response = await _characterService.UpdateCharacter(updatecharacter);
            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
            var response = await _characterService.Delete(id);
            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkill(
           AddCharacterSkillDto newCharacterSkill)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkill));
        }
    }
}
