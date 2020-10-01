using System.Threading.Tasks;

namespace School.Application.UseCases.CreateGroup
{
    public interface ICreateGroupUseCase
    {
        Task Execute(CreateGroupRequest CreateGroupRequest);
    }
}