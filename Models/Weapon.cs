using System.ComponentModel.DataAnnotations.Schema;

namespace FirstTut.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } 

   
    
        public virtual Character? Character { get; set; }
        public int CharacterId { get; set; }   
    }
}
