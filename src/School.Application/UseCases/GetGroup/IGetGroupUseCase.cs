using School.Application.UseCases.Shared.Dtos;
using System;
using System.Threading.Tasks;

namespace School.Application.UseCases.GetGroup
{
    public interface IGetGroupUseCase
    {
        Task<GroupDto> Execute(Guid id);
    }
}