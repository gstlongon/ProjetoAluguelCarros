using Microsoft.EntityFrameworkCore;
using ProjetoAluguelCarros.Models;

namespace ProjetoAluguelCarros.Repositories
{
    public class ClienteRepository
    {
        private readonly AluguelDbContext _context;

        public ClienteRepository(AluguelDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> ObterClientePorId(string idCliente)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Id == idCliente);
        }
    }
}
