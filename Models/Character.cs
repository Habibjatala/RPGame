using System.ComponentModel.DataAnnotations.Schema;

namespace FirstTut.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Ali";
        public int Hitpoints { get; set; } = 100;
        public int Strength { get; set; } = 100;
        public int Defence { get; set; } = 100;
        public int Intelligence { get; set; } = 100;
        public RpgClass Class { get; set; } = RpgClass.knight;

        public User? User { get; set; }

        public Weapon? Weapon { get; set; }

        public List<Skill>? Skills { get; set; }

        public int Fights { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }


    }


    }

