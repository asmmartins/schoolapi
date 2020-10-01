using School.Application.UseCases.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Application.UseCases.GetGroups
{
    public interface IGetGroupsUseCase
    {
        Task<IEnumerable<GroupDto>> Execute(string inep);
    }
}