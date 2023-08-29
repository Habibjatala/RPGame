using AutoMapper;
using FirstTut.Data;
using FirstTut.Dtos.Character;
using FirstTut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FirstTut.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>
        {

            new Character(),
        new Character {Id=1,Name="Sam"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public CharacterService(IMapper mapper,DataContext context, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _contextAccessor = contextAccessor;
        }


        private int GetUserId() => int.Parse(_contextAccessor.HttpContext!.User
            .FindFirstValue(ClaimTypes.NameIdentifier)!);


        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
        {
            var serviceReseponse = new ServiceResponse<List<GetCharacterDto>>();
            var characters = _mapper.Map<Character>(character);
            characters.User = await _context.Users.FirstOrDefaultAsync(x => x.Id == GetUserId());

            _context.Characters.Add(characters);
            await _context.SaveChangesAsync();

            serviceReseponse.Data = await _context.Characters
                .Where(c=>c.Id == GetUserId())
                .Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();


            return serviceReseponse;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            var serviceReseponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacter = await _context.Characters
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .Where(u=> u.User!.Id== GetUserId())
                .ToListAsync();
            serviceReseponse.Data= dbCharacter.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceReseponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetSingle(int id)
        {
            
            var serviceReseponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _context.Characters
                .Include(c => c.Weapon)
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == id && c.User!.Id== GetUserId());
            serviceReseponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceReseponse;
        }

      

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatecharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters.Include(c=>c.User).FirstOrDefaultAsync(c => c.Id == updatecharacter.Id);
                if(character == null  || character.User!.Id != GetUserId())
                {
                    throw new Exception($"Character with the Id '{updatecharacter.Id}' is not Found");
                }
                _mapper.Map(updatecharacter, character);
                character.Name = updatecharacter.Name;
                character.Hitpoints = updatecharacter.Hitpoints;
                character.Strength = updatecharacter.Strength;
                character.Defence = updatecharacter.Defence;
                character.Intelligence = updatecharacter.Intelligence;
                character.Class = updatecharacter.Class;

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
             }catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                var character = await  _context.Characters.FirstOrDefaultAsync(c => c.Id == id && c.User!.Id == GetUserId());
                if (character == null)
                {
                    throw new Exception($"Character with the Id '{id}' is not Found");
                }
                
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                

                serviceResponse.Data = await _context.Characters.Where(c=>c.User!.Id== GetUserId()).Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterskill)
        {
            var response = new ServiceResponse<GetCharacterDto>();
            try
            {
                var character = await _context.Characters
                    .Include(c => c.Weapon)
                    .Include(c => c.Skills)
                    .FirstOrDefaultAsync(c => c.Id == newCharacterskill.CharacterId &&
                        c.User!.Id == GetUserId());

                if (character is null)
                {
                    response.Success = false;
                    response.Message = "Character not found.";
                    return response;
                }

                var skill = await _context.Skills
                    .FirstOrDefaultAsync(s => s.Name == newCharacterskill.SkillName);
                if (skill is null)
                {
                    response.Success = false;
                    response.Message = "Skill not found.";
                    return response;
                }

                character.Skills!.Add(skill);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
