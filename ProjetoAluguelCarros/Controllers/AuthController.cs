using Microsoft.AspNetCore.Mvc;
using ProjetoAluguelCarros.DTOs;
using ProjetoAluguelCarros.Services;

namespace ProjetoAluguelCarros.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signIn")]
        public async Task<ActionResult<string>> SignIn(SignInDTO signInDTO)
        {
            string token = await _authService.SignIn(signInDTO.Email, signInDTO.Password);

            return CreatedAtAction(nameof(SignIn), token);
        }
    }
}
