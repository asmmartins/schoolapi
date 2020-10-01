using FluentAssertions;
using FluentValidation;
using School.Application.UseCases.CreatePublicSchool;
using School.Application.UseCases.GetPublicSchool;
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
        private readonly IGetPublicSchoolUseCase _getPublicSchoolUseCase;

        public CreatePublicSchoolUseCaseTests(
            ICreatePublicSchoolUseCase createPublicSchoolUseCase,
            IGetPublicSchoolUseCase getPublicSchoolUseCase)
        {
            _createPublicSchoolUseCase = createPublicSchoolUseCase;
            _getPublicSchoolUseCase = getPublicSchoolUseCase;
        }

        [Theory]
        [InlineData("58963214", "Escola Municipal Piox", "22763040", "Praça IV, 25", "Apt 915", "Centro", "Rio de Janeiro", Domain.Shared.ValueObjects.Addresses.State.RJ)]
        public async Task Should_CreatePublicSchoolUseCase(string inep, string name, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, Domain.Shared.ValueObjects.Addresses.State state)
        {
            CreatePublicSchoolRequest request = new CreatePublicSchoolRequest()
            {
                Inep = inep,
                Name = name,
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

            await _createPublicSchoolUseCase.Execute(request);

            var publicSchool = await _getPublicSchoolUseCase.Execute(inep);

            publicSchool.Should().NotBeNull();
            publicSchool.Inep.Should().Be(inep);
            publicSchool.Name.Should().Be(name);
            publicSchool.Address.Should().NotBeNull();
            publicSchool.Address.ZipCode.Should().Be(zipCode);
            publicSchool.Address.BaseAddress.Should().Be(baseAddress);
            publicSchool.Address.ComplementAddress.Should().Be(complementAddress);
            publicSchool.Address.Neighborhood.Should().Be(neighborhood);
            publicSchool.Address.City.Should().Be(city);
            publicSchool.Address.State.Should().Be(state);
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
            var request = new CreatePublicSchoolRequest() { Inep = "59658745", Name = "Escola Nossa Senhora do Loreto" };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createPublicSchoolUseCase.Execute(request));
            ex.AssertErrorMessage("'Address' não pode ser nulo.");
        }

        [Fact]
        public async Task Shouldnot_CreatePublicSchoolUseCase_WithNameInvalid()
        {
            var request = new CreatePublicSchoolRequest() { Inep = "59658745", Name = null, Address = new AddressDto() };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createPublicSchoolUseCase.Execute(request));
            ex.AssertErrorMessage("'Name' não pode ser nulo.");
        }

        [Fact]
        public async Task Shouldnot_CreatePublicSchoolUseCase_WithInepInvalid()
        {
            var request = new CreatePublicSchoolRequest() { Inep = null, Name = "Escola Pio X", Address = new AddressDto() };

            ValidationException ex = await Assert.ThrowsAsync<ValidationException>(() => _createPublicSchoolUseCase.Execute(request));
            ex.AssertErrorMessage("'Inep' não pode ser nulo.");
        }
    }
}