using FluentValidation;
using School.Application.UseCases.CreateGroup;
using School.Domain.Groups;
using School.Domain.PublicSchools;
using School.Domain.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace School.UseCases.CreateGroup
{
    public class CreateGroupUseCase : ICreateGroupUseCase
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<PublicSchool> _publicSchoolRepository;

        public CreateGroupUseCase(
            IRepository<Group> groupRepository,
            IRepository<PublicSchool> publicSchoolRepository)
        {
            _groupRepository = groupRepository;
            _publicSchoolRepository = publicSchoolRepository;
        }

        public async Task Execute(CreateGroupRequest createGroupRequest)
        {
            Validate(createGroupRequest);

            var publicSchool = await GetPublicSchoolByInep(createGroupRequest.Inep);

            var existentGroup = await GetGroupByName(createGroupRequest.Name);

            if (existentGroup == null)
            {
                var group = Group.Create(createGroupRequest.Name, publicSchool);
                await _groupRepository.Save(group);
                return;
            }

            existentGroup.Update(publicSchool);
            await _groupRepository.Save(existentGroup);
        }

        private static void Validate(CreateGroupRequest createGroupRequest)
        {
            if (createGroupRequest == null)
                throw new ArgumentNullException("CreateGroupRequest");

            var validator = new CreateGroupRequestValidator();
            validator.ValidateAndThrow(createGroupRequest);
        }

        private async Task<PublicSchool> GetPublicSchoolByInep(string inep)
        {
            var publicSchools = await _publicSchoolRepository.GetAll();
            return publicSchools?.FirstOrDefault(ps => ps.Inep == inep?.Trim());
        }

        private async Task<Group> GetGroupByName(string name)
        {
            var groups = await _groupRepository.GetAll();
            return groups?.FirstOrDefault(group => group.Name == name?.Trim());
        }
    }
}