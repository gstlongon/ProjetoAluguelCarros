using Microsoft.EntityFrameworkCore;
using ProjetoAluguelCarros.Models;

namespace ProjetoAluguelCarros.Repositories
{
    public class AluguelRepository
    {
        private readonly AluguelDbContext _context;

        public AluguelRepository(AluguelDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExisteReservaParaOCarroNaData(string idCarro, DateTime data)
        {
            return await _context.Alugueis.AnyAsync(a => a.Carro.Id == idCarro && a.Data.Date == data.Date);
        }

        public async Task<Aluguel> SalvarAluguel(Aluguel aluguel)
        {
            _context.Alugueis.Add(aluguel);
            await _context.SaveChangesAsync();

            return aluguel;
        }
    }
}
