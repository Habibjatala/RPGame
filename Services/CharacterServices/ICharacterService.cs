using FirstTut.Dtos.Character;
using FirstTut.Models;

namespace FirstTut.Services.CharacterServices
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character);
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetSingle(int id);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatecharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> Delete(int id);
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterskill);
    }
}