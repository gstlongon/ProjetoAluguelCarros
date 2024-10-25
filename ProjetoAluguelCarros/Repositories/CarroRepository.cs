using Microsoft.EntityFrameworkCore;
using ProjetoAluguelCarros.Models;

namespace ProjetoAluguelCarros.Repositories
{
    public class CarroRepository
    {
        private readonly AluguelDbContext _context;

        public CarroRepository(AluguelDbContext context)
        {
            _context = context;
        }

        public async Task<Carro?> ObterCarroPorId(string idCarro)
        {
            return await _context.Carros.FirstOrDefaultAsync(c => c.Id == idCarro);
        }
    }
}
