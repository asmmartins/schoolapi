using AutoMapper;
using School.Application.UseCases.GetGroups;
using School.Application.UseCases.Shared.Dtos;
using School.Domain.Groups;
using School.Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.UseCases.GetGroups
{
    public class GetGroupsUseCase : IGetGroupsUseCase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Group> _groupRepository;

        public GetGroupsUseCase(
            IMapper mapper,
            IRepository<Group> GroupRepository)
        {
            _mapper = mapper;
            _groupRepository = GroupRepository;
        }

        public async Task<IEnumerable<GroupDto>> Execute(string inep)
        {
            var groups = await GetGroupByInep(inep);
            return _mapper.Map<IEnumerable<GroupDto>>(groups);
        }

        private async Task<IEnumerable<Group>> GetGroupByInep(string inep)
        {
            var groups = await _groupRepository.GetAll();
            return groups?.Where(ps => ps.PublicSchool.Inep == inep?.Trim());
        }
    }
}
