using System.Threading.Tasks;

namespace School.Application.UseCases.GetPublicSchool
{
    public interface IGetPublicSchoolUseCase
    {
        Task<GetPublicSchoolResponse> Execute(string inep);
    }
}