using Microsoft.AspNetCore.Mvc;
using ProjetoAluguelCarros.DTOs;
using ProjetoAluguelCarros.Models;
using ProjetoAluguelCarros.Services;

namespace ProjetoAluguelCarros.Controllers
{
    [Route("api/carros")]
    [ApiController]
    public class AluguelController : ControllerBase
    {

        private readonly AluguelService _aluguelService;

        public AluguelController(AluguelService aluguelService)
        {
            _aluguelService = aluguelService;
        }

        [HttpPost("{idCarro}/alugueis")]
        public async Task<ActionResult<Aluguel>> CriarAluguel(string idCarro, CriarAluguelDTO aluguelDTO)
        {
            Aluguel aluguel = await _aluguelService.CriarAluguel(idCarro, aluguelDTO.IdCliente, aluguelDTO.DataAluguel);

            return CreatedAtAction(nameof(CriarAluguel), new { id = aluguel.Id }, aluguel);
        }
    }
}
