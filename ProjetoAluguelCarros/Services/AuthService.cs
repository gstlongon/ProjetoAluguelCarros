using ProjetoAluguelCarros.Models;
using ProjetoAluguelCarros.Repositories;
using System.Security.Claims;

namespace ProjetoAluguelCarros.Services
{
    public class AuthService
    {

        private readonly AuthRepository _authRepository;
        private readonly TokenService _tokenService;

        public AuthService(AuthRepository authRepository, TokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public string? GetAuthenticatedUserId(ClaimsPrincipal User)
        {
            return User.FindFirst("id")?.Value;
        }

        public async Task<string> SignIn(string email, string password)
        {
            Cliente cliente = await _authRepository.GetClienteByEmailAndPassword(email, password);
            if (cliente == null)
            {
                throw new Exception("Usuário e/ou senha inválidos");
            }

            string token = _tokenService.CreateClienteToken(cliente);

            return token;
        }
    }
}
