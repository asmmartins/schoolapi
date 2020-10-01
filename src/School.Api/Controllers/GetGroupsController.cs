using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.GetGroups;
using School.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetGroupsController : ControllerBase
    {
        private readonly IGetGroupsUseCase _getGroupsUseCase;

        public GetGroupsController(IGetGroupsUseCase getGroupsUseCase)
        {
            _getGroupsUseCase = getGroupsUseCase;
        }

        /// <summary>
        /// Obtém as turmas de uma escola pública.
        /// </summary>
        /// <remarks>Retorna o total de eventos por School.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("public-schools/{inep}/groups")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<GroupDto>>> Execute(string inep)
        {
            var response = await _getGroupsUseCase.Execute(inep);

            if (!(response != null && response.Any())) return NotFound();

            return Ok(response);
        }
    }
}