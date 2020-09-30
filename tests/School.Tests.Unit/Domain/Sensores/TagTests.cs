using FluentAssertions;
using School.Domain.Sensores;
using System;
using Xunit;

namespace School.Tests.Unit.Domain.Sensores
{
    public class TagTests
    {
        public TagTests() { }

        [Theory]
        [InlineData("brasil.sudeste.sensor01", "brasil", "sudeste", "sensor01")]
        [InlineData("brasil.sul.sensor01", "brasil", "sul", "sensor01")]
        [InlineData("brasil.sul.sensor02", "brasil", "sul", "sensor02")]
        [InlineData("brasil.sudeste.sensor02", "brasil", "sudeste", "sensor02")]
        public void Should_CreateTagObjectValue(string fullTag, string country, string region, string sensor)
        {
            var tag = Tag.Create(fullTag);

            // Asserts
            tag.Should().NotBeNull();
            tag.Country.Should().Be(country);
            tag.Region.Should().Be(region);
            tag.Sensor.Should().Be(sensor);
        }

        [Theory]
        [InlineData("brasil.nordeste.sensor03", "brasil", "nordeste", "sensor03")]
        public void Should_CreateEqualsTagObjectValue(string fullTag, string country, string region, string sensor)
        {
            var firstTag = Tag.Create(fullTag);
            var secondTag = Tag.Create(fullTag);

            // Asserts
            firstTag.Equals(secondTag).Should().BeTrue();
            firstTag.Should().NotBeNull();
            secondTag.Country.Should().Be(country);
            firstTag.Region.Should().Be(region);
            secondTag.Sensor.Should().Be(sensor);
        }

        [Theory]
        [InlineData("", "A tag é obrigatória.")]
        [InlineData("brasilsulsensor01", "A tag está incorreta.")]
        public void Shouldnot_CreateTagObjectValue(string fullTag, string errorMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => Tag.Create(fullTag));

            Assert.Equal(errorMessage, ex.Message);
        }
    }
}