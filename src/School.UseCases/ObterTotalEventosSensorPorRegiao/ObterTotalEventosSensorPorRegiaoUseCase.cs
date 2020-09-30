using School.Application.UseCases.ObterTotalEventosSensorPorRegiao;
using School.Domain.Sensores;
using School.Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.UseCases.ObterTotalEventosSensorPorRegiao
{
    public class ObterTotalEventosSensorPorRegiaoUseCase : IObterTotalEventosSensorPorRegiaoUseCase
    {
        private readonly IRepository<EventoSensor> _eventoSensorRepository;

        public ObterTotalEventosSensorPorRegiaoUseCase(IRepository<EventoSensor> eventoSensorRepository)
        {
            _eventoSensorRepository = eventoSensorRepository;
        }

        public async Task<IEnumerable<TotalEventosSensorPorRegiaoResponse>> Execute()
        {
            var eventosSensores = await _eventoSensorRepository.GetAll();

            if (eventosSensores.Count() == 0) return null;

            var totalEventosPorRegiaoSensores = from eventoSchool in eventosSensores group eventoSchool by eventoSchool.Tag.Region into eventoSensorGroup select new TotalEventosSensorPorRegiaoResponse { Region = eventoSensorGroup.Key, Total = eventoSensorGroup.Count() };

            return totalEventosPorRegiaoSensores;
        }
    }
}