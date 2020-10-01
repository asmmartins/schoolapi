using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.GetGroup;
using School.Application.UseCases.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetGroupController : ControllerBase
    {
        private readonly IGetGroupUseCase _getGroupUseCase;

        public GetGroupController(IGetGroupUseCase getGroupUseCase)
        {
            _getGroupUseCase = getGroupUseCase;
        }

        /// <summary>
        /// Obtém as turmas de uma escola pública.
        /// </summary>
        /// <remarks>Retorna o total de eventos por School.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("groups/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GroupDto>> Execute(Guid id)
        {
            var response = await _getGroupUseCase.Execute(id);

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}