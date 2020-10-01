using School.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Application.UseCases.GetPublicSchools
{
    public interface IGetPublicSchoolsUseCase
    {
        Task<IEnumerable<PublicSchoolDto>> Execute();
    }
}