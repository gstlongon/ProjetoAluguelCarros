using ProjetoAluguelCarros.Models;
using ProjetoAluguelCarros.Repositories;

namespace ProjetoAluguelCarros.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> ObterClientePorId(string idCliente)
        {
            Cliente? cliente = await _clienteRepository.ObterClientePorId(idCliente);
            if (cliente == null || !cliente.Ativo)
            {
                throw new Exception("Cliente não encontrado");
            }

            return cliente;
        }
    }
}
