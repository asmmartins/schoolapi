using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.CreateGroup;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CreateGroupController : ControllerBase
    {
        private readonly ICreateGroupUseCase _createGroupUseCase;

        public CreateGroupController(ICreateGroupUseCase createGroupUseCase)
        {
            _createGroupUseCase = createGroupUseCase;
        }

        /// <summary>
        /// Cria turma em uma escola pública.
        /// </summary>
        /// <remarks>Cria turma em uma escola pública.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPost("public-schools/{inep}/groups")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(string inep, CreateGroupRequest createGroupRequest)
        {
            if (createGroupRequest.Inep != inep)
                return BadRequest();

            await _createGroupUseCase.Execute(createGroupRequest);            

            return NoContent();
        }
    }
}