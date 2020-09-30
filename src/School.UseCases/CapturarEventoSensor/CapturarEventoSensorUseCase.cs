using School.Application.UseCases.CapturarEventoSensor;
using School.Domain.Sensores;
using School.Domain.Shared;
using System;
using System.Threading.Tasks;

namespace School.UseCases.CapturarEventoSensor
{
    public class CapturarEventoSensorUseCase : ICapturarEventoSensorUseCase
    {
        private readonly IRepository<EventoSensor> _eventoSensorRepository;

        public CapturarEventoSensorUseCase(IRepository<EventoSensor> eventoSensorRepository)
        {
            _eventoSensorRepository = eventoSensorRepository;
        }

        public async Task Execute(CapturarEventoSensorRequest capturarEventoSensorRequest)
        {
            Validate(capturarEventoSensorRequest);

            var tag = Tag.Create(capturarEventoSensorRequest.Tag);
            var eventoSensor = EventoSensor.Create(capturarEventoSensorRequest.Timestamp, tag, capturarEventoSensorRequest.Value);

            await _eventoSensorRepository.Save(eventoSensor);
        }

        private static void Validate(CapturarEventoSensorRequest capturarEventoSensorRequest)
        {
            if (capturarEventoSensorRequest == null) throw new ArgumentNullException("O evento do sensor é obrigatório.");
        }
    }
}