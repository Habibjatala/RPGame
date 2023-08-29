using FirstTut.Dtos.Skill;
using FirstTut.Dtos.Weapon;
using FirstTut.Models;

namespace FirstTut.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Ali";
        public int Hitpoints { get; set; } = 100;
        public int Strength { get; set; } = 100;
        public int Defence { get; set; } = 100;
        public int Intelligence { get; set; } = 100;
        public RpgClass Class { get; set; } = RpgClass.knight;
        public GetWeaponDto? Weapon { get; set; }
        public List<GetSkillDto>? Skills { get; set; }

        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
    }
}
