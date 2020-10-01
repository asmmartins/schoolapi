using FluentAssertions;
using FluentValidation;
using School.Application.UseCases.CreateGroup;
using School.Application.UseCases.CreatePublicSchool;
using School.Application.UseCases.GetGroup;
using School.Application.UseCases.GetGroups;
using School.Application.UseCases.Shared.Dtos;
using School.Tests.Integration.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Integration.UseCases
{
    public class CreateGroupUseCaseTests
    {
        private readonly ICreatePublicSchoolUseCase _createPublicSchoolUseCase;
        private readonly ICreateGroupUseCase _createGroupUseCase;
        private readonly IGetGroupsUseCase _getGroupsUseCase;
        private readonly IGetGroupUseCase _getGroupUseCaso;

        public CreateGroupUseCaseTests(
            ICreatePublicSchoolUseCase createPublicSchoolUseCase,
            ICreateGroupUseCase createGroupUseCase,
            IGetGroupsUseCase getGroupsUseCase,
            IGetGroupUseCase getGroupUseCaso)
        {
            _createPublicSchoolUseCase = createPublicSchoolUseCase;
            _createGroupUseCase = createGroupUseCase;
            _getGroupsUseCase = getGroupsUseCase;
            _getGroupUseCaso = getGroupUseCaso;
        }

        [Theory]
        [InlineData("Turma 58", "59785410", "Escola Municipal Piox", "22763040", "Praça IV, 25", "Apt 915", "Centro", "Rio de Janeiro", Domain.Shared.ValueObjects.Addresses.State.RJ)]
        public async Task Should_CreateGroupUseCase(string name, string inep, string namePublicSchool, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, Domain.Shared.ValueObjects.Addresses.State state)
        {
            CreatePublicSchoolRequest createPublicSchoolRequest = new CreatePublicSchoolRequest()
            {
                Inep = inep,
                Name = namePublicSchool,
                Address = new AddressDto()
                {
                    ZipCode = zipCode,
                    BaseAddress = baseAddress,
                    ComplementAddress = complementAddress,
                    Neighborhood = neighborhood,
                    City = city,
                    State = state
                }
            };

            await _createPublicSchoolUseCase.Execute(createPublicSchoolRequest);

            CreateGroupRequest createGroupRequest = new CreateGroupRequest()
            {
                Inep = inep,
                Name = name
            };

            await _createGroupUseCase.Execute(createGroupRequest);

            var groups = await _getGroupsUseCase.Execute(inep);
            groups.Should().NotBeNull();
            groups.Should().OnlyHaveUniqueItems();

            foreach (var g in groups)
            {
                var existentGroup = await _getGroupUseCaso.Execute(g.Id);
                existentGroup.Should().NotBeNull();
                existentGroup.Should().BeEquivalentTo(g);
            }
        }

        [Fact]       
        public async Task Shouldnot_CreateGroupUseCase_WithRequestNull()
        {
            ArgumentNullException ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _createGroupUseCase.Execute(null));
            ex.Should().NotBeNull();
            ex.Message.Should().Be("Value cannot be null. (Parameter 'CreateGroupRequest')");
        }

        [Fact]
        public async Task Shouldnot_CreateGroupUseCase_WithInepNull()
        {
            var request = new CreateGroupRequest() { Inep = null, Name = "Escola Nossa Senhora do Loreto" };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createGroupUseCase.Execute(request));            
            ex.AssertErrorMessage("'Inep' não pode ser nulo.");
        }

        [Fact]
        public async Task Shouldnot_CreateGroupUseCase_WithNameNull()
        {
            var request = new CreateGroupRequest() { Inep = "14523698", Name = null };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createGroupUseCase.Execute(request));
            ex.AssertErrorMessage("'Name' não pode ser nulo.");
        }


        [Fact]
        public async Task Shouldnot_CreateGroupUseCase_WithPublicSchoolNull()
        {
            var request = new CreateGroupRequest() { Inep = "00000000", Name = "Escola Maria Claudia" };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createGroupUseCase.Execute(request));
            ex.AssertErrorMessage("'Public School' não pode ser nulo.");
        }
    }
}