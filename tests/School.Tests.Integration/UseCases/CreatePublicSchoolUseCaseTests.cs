using FluentAssertions;
using School.Application.UseCases.CreatePublicSchool;
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
            ex.Message.Should().Be("Value cannot be null. (Parameter 'Escola pública é obrigatória.')");
        }
    }
}