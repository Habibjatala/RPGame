using AutoMapper;
using FirstTut.Data;
using FirstTut.Dtos.Character;
using FirstTut.Dtos.Fight;
using FirstTut.Dtos.Skill;
using FirstTut.Dtos.Weapon;
using FirstTut.Models;


namespace FirstTut
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill,GetSkillDto>();
            CreateMap<Character, HighscoreDto>();
        
        }
    }
}




    


        