using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.CapturarEventoSensor;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CapturarEventoSensorController : ControllerBase
    {
        private readonly ICapturarEventoSensorUseCase _capturarEventoSensorUseCase;

        public CapturarEventoSensorController(ICapturarEventoSensorUseCase capturarEventoSensorUseCase)
        {
            _capturarEventoSensorUseCase = capturarEventoSensorUseCase;
        }

        /// <summary>
        /// Captura o evento do School.
        /// </summary>
        /// <remarks>Captura o evento do School.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPost("sensores")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(CapturarEventoSensorRequest capturarEventoSensorRequest)
        {
            await _capturarEventoSensorUseCase.Execute(capturarEventoSensorRequest);

            return NoContent();
        }
    }
}