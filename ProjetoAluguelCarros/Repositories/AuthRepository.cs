using Microsoft.EntityFrameworkCore;
using ProjetoAluguelCarros.Models;

namespace ProjetoAluguelCarros.Repositories
{
    public class AuthRepository
    {

        private readonly AluguelDbContext _context;

        public AuthRepository(AluguelDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> GetClienteByEmailAndPassword(string email, string password)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email && c.Password == password);
        }
    }
}
