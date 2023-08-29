using AutoMapper;
using FirstTut.Data;
using FirstTut.Dtos.Skill;
using FirstTut.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstTut.Services.SkillService
{
    public class SkillService: ISkillService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public SkillService(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetSkillDto>>> AddSkill(AddSkillDto newSkill)
        {
            var response = new ServiceResponse<List<GetSkillDto>>();

            var skill = new Skill()
            {
                Name = newSkill.Name,
                Damage = newSkill.Damage,

            };
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            var mappedSkill = _mapper.Map<GetSkillDto>(skill);
            response.Data = new List<GetSkillDto> { mappedSkill };
            return response;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> GetAllSkill()
        {
            var response = new ServiceResponse<List<GetSkillDto>>();

            var skills = await _context.Skills.ToListAsync();

            // Map each Skill to GetSkillDto, including Id, Name, and Damage
            response.Data = skills.Select(skill => new GetSkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Damage = skill.Damage
            }).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetSkillDto>> UpdateSkill(int id, UpdateSkillDto updatedSkill)
        {
            var response = new ServiceResponse<GetSkillDto>();

            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                response.Message = "Skill not found";
                response.Success = false;
                return response;
            }

            skill.Name = updatedSkill.Name;
            skill.Damage = updatedSkill.Damage;

            _context.Skills.Update(skill);
            await _context.SaveChangesAsync();

            response.Data = _mapper.Map<GetSkillDto>(skill);
            response.Message = "Skill updated successfully";
            return response;
        }

        public async Task<ServiceResponse<List<GetSkillDto>>> DeleteSkill(int id)
        {
            var response = new ServiceResponse<List<GetSkillDto>>();

            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                response.Message = "Skill not found";
                response.Success = false;
                return response;
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            // Return the updated skills list after deletion
            response.Data = (await GetAllSkill()).Data; // Get the List<GetSkillDto> from the GetAllSkill response
            response.Message = "Skill deleted successfully";
            return response;
        }

        public async Task<ServiceResponse<GetSkillDto>> GetSkillById(int id)
        {
            var response = new ServiceResponse<GetSkillDto>();

            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                response.Message = "Skill not found";
                response.Success = false;
                return response;
            }

            response.Data = _mapper.Map<GetSkillDto>(skill);
            return response;
        }
    }
}
