using FluentValidation;
using Xunit;
using VO = School.Domain.Shared.ValueObjects;
using PublicSchoolDomain = School.Domain.PublicSchools;
using GroupDomain = School.Domain.Groups;
using School.Tests.Unit.Shared;
using FluentAssertions;

namespace School.Tests.Unit.Domain.Groups
{
    public class GroupsTests
    {
        [Theory]
        [InlineData(null, "'Name' não pode ser nulo.")]
        [InlineData("", "'Name' deve ser informado.")]
        public void Shouldnot_CreatGroup_WithNameInvalid(string name, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => GroupDomain.Group.Create(name, null));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("Turma I", "Escola Municipal Piox", "20230011", "Rua Riachuelo, 221", "Apt 915", "Centro", "Rio de Janeiro", VO.Addresses.State.RJ)]
        public void Should_CreateGroup(string name, string namePublicSchool, string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, VO.Addresses.State state)
        {
            var address = VO.Addresses.Address.Create(zipCode, baseAddress, complementAddress, neighborhood, city, state);
            var publicSchool = PublicSchoolDomain.PublicSchool.Create(namePublicSchool, address);
            var group = GroupDomain.Group.Create(name, publicSchool);

            group.Should().NotBeNull();
            group.Name.Should().Be(name);
            group.PublicSchool.Should().NotBeNull();
            group.PublicSchool.Name.Should().Be(namePublicSchool);
            group.PublicSchool.Address.Should().NotBeNull();
            group.PublicSchool.Address.ZipCode.Should().Be(zipCode);
            group.PublicSchool.Address.BaseAddress.Should().Be(baseAddress);
            group.PublicSchool.Address.ComplementAddress.Should().Be(complementAddress);
            group.PublicSchool.Address.Neighborhood.Should().Be(neighborhood);
            group.PublicSchool.Address.City.Should().Be(city);
            group.PublicSchool.Address.State.Should().Be(state);
        }
    }
}
