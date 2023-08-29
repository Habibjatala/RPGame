using FirstTut.Dtos.Skill;
using FirstTut.Models;

namespace FirstTut.Services.SkillService
{
    public interface ISkillService
    {
        Task<ServiceResponse<List<GetSkillDto>>> AddSkill(AddSkillDto newSkill);
        Task<ServiceResponse<List<GetSkillDto>>> GetAllSkill();
        Task<ServiceResponse<GetSkillDto>> GetSkillById(int id);
        Task<ServiceResponse<GetSkillDto>> UpdateSkill(int id, UpdateSkillDto updatedSkill);
        Task<ServiceResponse<List<GetSkillDto>>> DeleteSkill(int id);
    }
}
