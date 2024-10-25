using Microsoft.EntityFrameworkCore.Storage.Json;
using ProjetoAluguelCarros.Models;
using ProjetoAluguelCarros.Repositories;

namespace ProjetoAluguelCarros.Services
{
    public class AluguelService
    {
        private readonly CarroService _carroService;
        private readonly ClienteService _clienteService;
        private readonly AluguelRepository _aluguelRepository;

        public AluguelService(CarroService carroService, ClienteService clienteService, AluguelRepository aluguelRepository)
        {
            _carroService = carroService;
            _clienteService = clienteService;
            _aluguelRepository = aluguelRepository;
        }

        public async Task<Aluguel> CriarAluguel(string idCarro, string idCliente, DateTime dataAluguel)
        {
            bool carroReservado = await _aluguelRepository.ExisteReservaParaOCarroNaData(idCarro, dataAluguel);
            if (carroReservado)
            {
                throw new Exception("O carro já está reservado nessa data");
            }

            Carro carro = await _carroService.ObterCarroPorId(idCarro);

            Cliente cliente = await _clienteService.ObterClientePorId(idCliente);

            Aluguel aluguel = new Aluguel(cliente, carro, dataAluguel);
            aluguel = await _aluguelRepository.SalvarAluguel(aluguel);

            return aluguel;
        }
    }
}
