using School.Application.UseCases.ObterTotalEventosSensor;
using School.Domain.Sensores;
using School.Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.UseCases.ObterTotalEventosSensor
{
    public class ObterTotalEventosSensorUseCase : IObterTotalEventosSensorUseCase
    {
        private readonly IRepository<EventoSensor> _eventoSensorRepository;

        public ObterTotalEventosSensorUseCase(IRepository<EventoSensor> eventoSensorRepository)
        {
            _eventoSensorRepository = eventoSensorRepository;
        }

        public async Task<IEnumerable<TotalEventosSensorResponse>> Execute()
        {
            var eventosSensores = await _eventoSensorRepository.GetAll();

            if (eventosSensores.Count() == 0) return null;

            var totalEventosSensores = from eventoSchool in eventosSensores group eventoSchool by eventoSchool.TagFull into eventoSensorGroup select new TotalEventosSensorResponse { Tag = eventoSensorGroup.Key, Total = eventoSensorGroup.Count() };

            return totalEventosSensores;
        }
    }
}
