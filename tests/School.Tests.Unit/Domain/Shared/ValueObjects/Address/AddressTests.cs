using FluentAssertions;
using FluentValidation;
using System.Linq;
using Xunit;
using VO = School.Domain.Shared.ValueObjects;

namespace School.Tests.Unit.Domain.Shared.ValueObjects.Address
{
    public class AddressTests
    {
        [Theory]
        [InlineData(null, "'Zip Code' não pode ser nulo.")]
        [InlineData("", "'Zip Code' deve ser informado.")]
        [InlineData("202300111", "'Zip Code' deve ter entre 8 e 8 caracteres. Você digitou 9 caracteres.")]
        [InlineData("0A859685", "'Zip Code' não está no formato correto.")]
        public void Shouldnot_CreateAddress_WithZipCodeInvalid(string zipCode, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => VO.Addresses.Address.Create(zipCode, "", "", "", "", VO.Addresses.State.SP));

            // Asserts
            ex.Should().NotBeNull();
            ex.Errors.Should().NotBeNullOrEmpty();
            ex.Errors.FirstOrDefault().ErrorMessage.Should().Be(errorMessage);
        }

        [Theory]
        [InlineData("20230011", "Rua Riachuelo, 221", "Apt 915", "Centro", "Rio de Janeiro", VO.Addresses.State.RJ)]
        [InlineData("22763040", "Ria Inácio do Amaral, 537", "Casa 03", "Freguesia / JPA", "Rio de Janeiro", VO.Addresses.State.RJ)]        
        public void Should_CreateAddress(string zipCode, string baseAddress, string complementAddress, string neighborhood, string city, VO.Addresses.State state)
        {
            var address = VO.Addresses.Address.Create(zipCode, baseAddress, complementAddress, neighborhood, city, state);

            address.Should().NotBeNull();
            address.ZipCode.Should().Be(zipCode);
            address.BaseAddress.Should().Be(baseAddress);
            address.ComplementAddress.Should().Be(complementAddress);            
            address.Neighborhood.Should().Be(neighborhood);
            address.City.Should().Be(city);
            address.State.Should().Be(state);
        }
    }
}
