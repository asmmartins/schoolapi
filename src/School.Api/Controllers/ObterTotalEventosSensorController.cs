using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.ObterTotalEventosSensor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class ObterTotalEventosSensorController : ControllerBase
    {
        private readonly IObterTotalEventosSensorUseCase _obterTotalEventosSensorUseCase;

        public ObterTotalEventosSensorController(IObterTotalEventosSensorUseCase obterTotalEventosSensorUseCase)
        {
            _obterTotalEventosSensorUseCase = obterTotalEventosSensorUseCase;
        }

        /// <summary>
        /// Obter o total de eventos por School.
        /// </summary>
        /// <remarks>Retorna o total de eventos por School.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("sensores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<TotalEventosSensorResponse>>> Execute()
        {
            var response = await _obterTotalEventosSensorUseCase.Execute();

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}