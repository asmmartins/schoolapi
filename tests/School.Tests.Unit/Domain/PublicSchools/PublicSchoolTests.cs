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
        [InlineData(null, "'Inep' não pode ser nulo.")]
        [InlineData("", "'Inep' deve ser informado.")]
        [InlineData("202300111", "'Inep' deve ter entre 8 e 8 caracteres. Você digitou 9 caracteres.")]
        [InlineData("0A859685", "'Inep' não está no formato correto.")]
        public void Shouldnot_CreatePublicSchool_WithInepInvalid(string inep, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => PublicSchoolDomain.PublicSchool.Create(inep, null, null));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("13082175", null, "'Name' não pode ser nulo.")]
        [InlineData("13082175", "", "'Name' deve ser informado.")]        
        public void Shouldnot_CreatePublicSchool_WithNameInvalid(string inep, string name, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => PublicSchoolDomain.PublicSchool.Create(inep, name, null));
            ex.AssertErrorMessage(errorMessage);
        }        

        [Theory]
        [InlineData("13082175", "Escola Municipal Piox", "20230011", "Rua Riachuelo, 221", "Apt 915", "Centro", "Rio de Janeiro", VO.Addresses.State.RJ)]        
        public void Should_CreatePublicSchool(string inep, string name, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, VO.Addresses.State state)
        {
            var address = VO.Addresses.Address.Create(zipCode, baseAddress, complementAddress, neighborhood, city, state);
            var publicSchool = PublicSchoolDomain.PublicSchool.Create(inep, name, address);

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
