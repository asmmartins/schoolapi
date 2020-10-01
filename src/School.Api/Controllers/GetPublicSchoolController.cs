using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.GetPublicSchool;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class GetPublicSchoolController : ControllerBase
    {
        private readonly IGetPublicSchoolUseCase _getPublicSchoolUseCase;

        public GetPublicSchoolController(IGetPublicSchoolUseCase getPublicSchoolUseCase)
        {
            _getPublicSchoolUseCase = getPublicSchoolUseCase;
        }

        /// <summary>
        /// Obtém uma escola pública a partir do Inep.
        /// </summary>
        /// <remarks>Retorna o total de eventos por School.</remarks>
        /// <response code="200">Ok.</response>
        /// <response code="400">Requisição Inválida.</response>        
        /// <response code="404">Não encontrado.</response>        
        [HttpGet("public-schools/{inep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPublicSchoolResponse>> Execute(string inep)
        {
            var response = await _getPublicSchoolUseCase.Execute(inep);

            if (response == null) return NotFound();

            return Ok(response);
        }
    }
}