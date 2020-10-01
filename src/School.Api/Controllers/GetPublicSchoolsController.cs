using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.GetPublicSchool;

using School.Application.UseCases.GetPublicSchools;
using School.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetPublicSchoolsController : ControllerBase
    {
        private readonly IGetPublicSchoolsUseCase _getPublicSchoolsUseCase;

        public GetPublicSchoolsController(IGetPublicSchoolsUseCase getPublicSchoolsUseCase)
        {
            _getPublicSchoolsUseCase = getPublicSchoolsUseCase;
        }

        /// <summary>
        /// Obtém todas as escolas publicas.
        /// </summary>
        /// <remarks>Retorna o total de eventos por School.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("public-schools")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PublicSchoolDto>>> Execute()
        {
            var response = await _getPublicSchoolsUseCase.Execute();

            if (!(response != null && response.Any())) return NotFound();

            return Ok(response);
        }
    }
}