﻿using FluentValidation;
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
        private readonly IRepository<PublicSchool> _publicRepository;

        public CreateGroupUseCase(
            IRepository<Group> groupRepository,
            IRepository<PublicSchool> publicSchoolRepository)
        {
            _groupRepository = groupRepository;
            _publicRepository = publicSchoolRepository;
        }

        public async Task Execute(CreateGroupRequest createGroupRequest)
        {
            Validate(createGroupRequest);

            var publicSchool = await GetPublicSchool(createGroupRequest.PublicSchoolId);
            var group = Group.Create(createGroupRequest.Name, publicSchool);

            await _groupRepository.Save(group);
        }

        private static void Validate(CreateGroupRequest createGroupRequest)
        {
            if (createGroupRequest == null) 
                throw new ArgumentNullException("CreateGroupRequest");

            var validator = new CreateGroupRequestValidator();
            validator.ValidateAndThrow(createGroupRequest);            
        }

        private async Task<PublicSchool> GetPublicSchool(Guid publicSchoolId)
        {
            var publicSchools = await _publicRepository.GetAll();
            return publicSchools.FirstOrDefault(ps => ps.Id == publicSchoolId);
        }
    }
}