using FluentAssertions;
using FluentValidation;
using School.Tests.Unit.Shared;
using Xunit;
using VO = School.Domain.Shared.ValueObjects;
using PublicSchoolDomain = School.Domain.PublicSchools;

namespace School.Tests.Unit.Domain.PublicSchools
{
    public class PublicSchoolTests
    {
        [Theory]
        [InlineData(null, "'Name' não pode ser nulo.")]
        [InlineData("", "'Name' deve ser informado.")]        
        public void Shouldnot_CreatePublicSchool_WithNameInvalid(string name, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => PublicSchoolDomain.PublicSchool.Create(name, null));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("Escola Municipal Piox", "20230011", "Rua Riachuelo, 221", "Apt 915", "Centro", "Rio de Janeiro", VO.Addresses.State.RJ)]        
        public void Should_CreatePublicSchool(string name, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, VO.Addresses.State state)
        {
            var address = VO.Addresses.Address.Create(zipCode, baseAddress, complementAddress, neighborhood, city, state);
            var publicSchool = PublicSchoolDomain.PublicSchool.Create(name, address);

            publicSchool.Should().NotBeNull();
            publicSchool.Name.Should().Be(name);
            publicSchool.Address.Should().NotBeNull();
            publicSchool.Address.ZipCode.Should().Be(zipCode);
            publicSchool.Address.BaseAddress.Should().Be(baseAddress);
            publicSchool.Address.ComplementAddress.Should().Be(complementAddress);
            publicSchool.Address.Neighborhood.Should().Be(neighborhood);
            publicSchool.Address.City.Should().Be(city);
            publicSchool.Address.State.Should().Be(state);
        }
    }
}
