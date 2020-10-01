using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.UseCases.CreatePublicSchool;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class CreatePublicSchoolController : ControllerBase
    {
        private readonly ICreatePublicSchoolUseCase _createPublicSchoolUseCase;

        public CreatePublicSchoolController(ICreatePublicSchoolUseCase createPublicSchoolUseCase)
        {
            _createPublicSchoolUseCase = createPublicSchoolUseCase;
        }

        /// <summary>
        /// Cria uma escola pública.
        /// </summary>
        /// <remarks>Cria uma escola pública.</remarks>
        /// <response code="204">Sucesso.</response>
        /// <response code="400">Requisição inválida.</response>        
        /// <response code="422">Entidade não processada.</response>        
        [HttpPost("public-schools")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Execute(CreatePublicSchoolRequest createPublicSchoolRequest)
        {
            await _createPublicSchoolUseCase.Execute(createPublicSchoolRequest);

            return NoContent();
        }
    }
}