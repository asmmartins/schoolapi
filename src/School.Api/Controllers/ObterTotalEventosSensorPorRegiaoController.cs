using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.ObterTotalEventosSensorPorRegiao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class ObterTotalEventosSensorPorRegiaoController : ControllerBase
    {
        private readonly IObterTotalEventosSensorPorRegiaoUseCase _obterTotalEventosSensorPorRegiaoUseCase;

        public ObterTotalEventosSensorPorRegiaoController(IObterTotalEventosSensorPorRegiaoUseCase obterTotalEventosSensorPorRegiaoUseCase)
        {
            _obterTotalEventosSensorPorRegiaoUseCase = obterTotalEventosSensorPorRegiaoUseCase;
        }

        /// <summary>
        /// Obter o total de eventos de sensores por região.
        /// </summary>
        /// <remarks>Retorna o total de eventos de sensores por região.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("sensores-regionais")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TotalEventosSensorPorRegiaoResponse>>> Execute()
        {
            var response = await _obterTotalEventosSensorPorRegiaoUseCase.Execute();

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}