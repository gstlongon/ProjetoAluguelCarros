using ProjetoAluguelCarros.Models;
using ProjetoAluguelCarros.Repositories;

namespace ProjetoAluguelCarros.Services
{
    public class CarroService
    {
        private readonly CarroRepository _carroRepository;

        public CarroService(CarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<Carro> ObterCarroPorId(string idCarro)
        {
            Carro? carro = await _carroRepository.ObterCarroPorId(idCarro);
            if (carro == null)
            {
                throw new Exception("Carro não encontrado");
            }

            return carro;
        }
    }
}
