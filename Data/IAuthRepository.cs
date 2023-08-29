using FirstTut.Dtos.User;
using FirstTut.Models;

namespace FirstTut.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(AddRegisterDto request);
        Task<ServiceResponse<AuthenticatedUserDto>> Login(String username, string password);
        Task<bool> UserExists(string username);
    }
}
