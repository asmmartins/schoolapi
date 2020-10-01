using FluentAssertions;
using FluentValidation;
using School.Application.UseCases.CreatePublicSchool;
using School.Application.UseCases.Shared.Dtos;
using School.Tests.Integration.Shared;
using System;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Integration.UseCases
{
    public class CreatePublicSchoolUseCaseTests
    {
        private readonly ICreatePublicSchoolUseCase _createPublicSchoolUseCase;

        public CreatePublicSchoolUseCaseTests(
            ICreatePublicSchoolUseCase createPublicSchoolUseCase)
        {
            _createPublicSchoolUseCase = createPublicSchoolUseCase;            
        }

        [Theory]
        [InlineData("Escola Municipal Piox", "22763040", "Praça IV, 25", "Apt 915", "Centro", "Rio de Janeiro", Domain.Shared.ValueObjects.Addresses.State.RJ)]
        public async Task Should_CreatePublicSchoolUseCase(string name, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, Domain.Shared.ValueObjects.Addresses.State state)
        {
            CreatePublicSchoolRequest request = new CreatePublicSchoolRequest()
            {
                Name = name,
                Address = new Application.UseCases.Shared.Dtos.AddressDto()
                {
                    ZipCode = zipCode,
                    BaseAddress = baseAddress,
                    ComplementAddress = complementAddress,
                    Neighborhood = neighborhood,
                    City = city,
                    State = state
                }
            };

            await _createPublicSchoolUseCase.Execute(request);
        }

        [Fact]       
        public async Task Shouldnot_CreatePublicSchoolUseCase_WithRequestNull()
        {
            ArgumentNullException ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _createPublicSchoolUseCase.Execute(null));
            ex.Should().NotBeNull();
            ex.Message.Should().Be("Value cannot be null. (Parameter 'CreatePublicSchoolRequest')");
        }

        [Fact]
        public async Task Shouldnot_CreatePublicSchoolUseCase_WithAddressNull()
        {
            var request = new CreatePublicSchoolRequest() { Name = "Escola Nossa Senhora do Loreto" };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createPublicSchoolUseCase.Execute(request));            
            ex.AssertErrorMessage("'Address' não pode ser nulo.");
        }

        [Fact]
        public async Task Shouldnot_CreatePublicSchoolUseCase_WithNameInvalid()
        {
            var request = new CreatePublicSchoolRequest() { Name = null, Address = new AddressDto() };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createPublicSchoolUseCase.Execute(request));
            ex.AssertErrorMessage("'Name' não pode ser nulo.");
        }
    }
}