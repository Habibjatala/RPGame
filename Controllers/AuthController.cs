using FirstTut.Data;
using FirstTut.Dtos.User;
using FirstTut.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstTut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(AddRegisterDto request)
        {
            var response = await _authRepo.Register(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<AuthenticatedUserDto>>> Login(LoginDto request)
        {
            var response = await _authRepo.Login(request.Email, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }


        

    }
}
