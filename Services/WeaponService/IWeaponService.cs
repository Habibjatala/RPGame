using FirstTut.Dtos.Character;
using FirstTut.Dtos.Weapon;
using FirstTut.Models;

namespace FirstTut.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}
