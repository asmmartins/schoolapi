using FluentAssertions;
using School.Application.UseCases.CapturarEventoSensor;
using School.Application.UseCases.ObterTotalEventosSensor;
using School.Application.UseCases.ObterTotalEventosSensorPorRegiao;
using System.Threading.Tasks;
using Xunit;

namespace School.Tests.Integration.UseCases
{
    public class CapturarEventoSensorUseCaseTests
    {
        private readonly ICapturarEventoSensorUseCase _capturarEventoSensorUseCase;
        private readonly IObterTotalEventosSensorUseCase _obterTotalEventosSensorUseCase;
        private readonly IObterTotalEventosSensorPorRegiaoUseCase _obterTotalEventosSensorPorRegiaoUseCase;

        public CapturarEventoSensorUseCaseTests(
            ICapturarEventoSensorUseCase capturarEventoSensorUseCase,
            IObterTotalEventosSensorUseCase obterTotalEventosSensorUseCase,
            IObterTotalEventosSensorPorRegiaoUseCase obterTotalEventosSensorPorRegiaoUseCase)
        {
            _capturarEventoSensorUseCase = capturarEventoSensorUseCase;
            _obterTotalEventosSensorUseCase = obterTotalEventosSensorUseCase;
            _obterTotalEventosSensorPorRegiaoUseCase = obterTotalEventosSensorPorRegiaoUseCase;
        }

        [Theory]
        [InlineData(1597241444, "brasil.sudeste.sensor01", "68409")]
        [InlineData(1597241444, "brasil.centrooeste.sensor02", "SUB635165")]
        public async Task Should_CapturarEventoSensorUseCase(long timestamp, string fullTag, string value)
        {
            var capturarEventoSensorRequest = new CapturarEventoSensorRequest() { Timestamp = timestamp, Tag = fullTag, Value = value };

            await _capturarEventoSensorUseCase.Execute(capturarEventoSensorRequest);
            var totalEventoSensor = await _obterTotalEventosSensorUseCase.Execute();
            var totalEventoSensorPorRegiao = await _obterTotalEventosSensorPorRegiaoUseCase.Execute();

            totalEventoSensor.Should().NotBeNullOrEmpty();
            totalEventoSensorPorRegiao.Should().NotBeNullOrEmpty();
        }
    }
}