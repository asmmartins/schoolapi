using FluentAssertions;
using FluentValidation;
using School.Tests.Unit.Shared;
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
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'Base Address' não pode ser nulo.")]
        [InlineData("", "'Base Address' deve ser informado.")]
        [InlineData("Calculate the length of your string of text or numbers to check the number of characters it contains! Using our online character counting tool is quick", "'Base Address' deve ser menor ou igual a 150 caracteres. Você digitou 151 caracteres.")]
        public void Shouldnot_CreateAddress_WithBaseAddressInvalid(string baseAddress, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => VO.Addresses.Address.Create("20230011", baseAddress, "", "", "", VO.Addresses.State.AM));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData("Calculate the length of your string of text or number", "'Complement Address' deve ser menor ou igual a 50 caracteres. Você digitou 53 caracteres.")]
        public void Shouldnot_CreateAddress_WithComplementAddressInvalid(string complementAddress, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => VO.Addresses.Address.Create("20230011", "Rua Riachuelo, 221", complementAddress, "", "", VO.Addresses.State.CE));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'Neighborhood' não pode ser nulo.")]
        [InlineData("", "'Neighborhood' deve ser informado.")]
        [InlineData("Calculate the length of your string of text or numb", "'Neighborhood' deve ser menor ou igual a 50 caracteres. Você digitou 51 caracteres.")]
        public void Shouldnot_CreateAddress_WithNeighborhoodInvalid(string neighborhood, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => VO.Addresses.Address.Create("20230011", "Ria Riachuelo, 221", "Apt 915", neighborhood, "", VO.Addresses.State.RS));
            ex.AssertErrorMessage(errorMessage);
        }

        [Theory]
        [InlineData(null, "'City' não pode ser nulo.")]
        [InlineData("", "'City' deve ser informado.")]
        [InlineData("Calculate the length of your string of text or numb", "'City' deve ser menor ou igual a 50 caracteres. Você digitou 51 caracteres.")]
        public void Shouldnot_CreateAddress_WithCityInvalid(string city, string errorMessage)
        {
            ValidationException ex = Assert.Throws<ValidationException>(() => VO.Addresses.Address.Create("20230011", "Ria Riachuelo, 221", "Apt 915", "Centro", city, VO.Addresses.State.SP));
            ex.AssertErrorMessage(errorMessage);
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
