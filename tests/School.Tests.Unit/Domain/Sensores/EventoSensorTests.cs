using FluentAssertions;
using School.Domain.Sensores;
using Xunit;

namespace School.Tests.Unit.Domain.Sensores
{
    public class EventoSensorTests
    {
        [Theory]
        [InlineData(1539112021301, "brasil.sudeste.sensor05", "16516516")]
        [InlineData(1597233079, "brasil.norte.sensor08", "JNFY561616")]
        [InlineData(1539112021301, "brasil.sul.sensor07", "FKDHNBUF")]
        [InlineData(1597233079, "brasil.nordeste.sensor06", "95265")]
        public void Should_CreateEventoSensor(long timestamp, string fullTag, string value)
        {
            var tag = Tag.Create(fullTag);
            var eventoSensor = EventoSensor.Create(timestamp, tag, value);

            // Asserts
            eventoSensor.Should().NotBeNull();
            eventoSensor.Timestamp.Should().Be(timestamp);
            eventoSensor.Tag.Should().NotBeNull();
            eventoSensor.Value.Should().Be(value);
            eventoSensor.TagFull.Should().Be(fullTag);
        }
    }
}