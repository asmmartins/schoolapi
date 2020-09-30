using FluentAssertions;
using School.Domain.Sensores;
using School.Domain.Shared;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Integration.Repository
{
    public class EventoSensorRepositoryTests
    {
        private readonly IRepository<EventoSensor> _eventoSensorRepository;

        public EventoSensorRepositoryTests(IRepository<EventoSensor> eventoSensorRepository)
        {
            _eventoSensorRepository = eventoSensorRepository;
        }

        [Theory]
        [InlineData(1597239568, "brasil.centrooeste.sensor17", "68409")]
        [InlineData(1597239568, "brasil.centrooeste.sensor20", "JNFY561616")]
        public async Task Should_SaveAndGetAllEventoSensorInDbContext(long timestamp, string fullTag, string value)
        {
            var tag = Tag.Create(fullTag);
            var eventoSensor = EventoSensor.Create(timestamp, tag, value);
            await _eventoSensorRepository.Save(eventoSensor);
            var eventosSensores = _eventoSensorRepository.GetAll();
            eventosSensores.Should().NotBeNull();
        }
    }
}