using System.Threading.Tasks;

namespace School.Application.UseCases.CreatePublicSchool
{
    public interface ICreatePublicSchoolUseCase
    {
        Task Execute(CreatePublicSchoolRequest CreatePublicSchoolRequest);
    }
}