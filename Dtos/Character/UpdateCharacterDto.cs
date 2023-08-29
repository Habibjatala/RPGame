using FirstTut.Models;

namespace FirstTut.Dtos.Character
{
    public class UpdateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Ali";
        public int Hitpoints { get; set; } = 100;
        public int Strength { get; set; } = 100;
        public int Defence { get; set; } = 100;
        public int Intelligence { get; set; } = 100;
        public RpgClass Class { get; set; } = RpgClass.knight;
    }
}
