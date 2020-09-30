using School.Domain.Sensores;
using System.Collections.Generic;

namespace School.Repository.Shared
{
    public class EventoSensorDbContext
    {
        private readonly IList<EventoSensor> sensores;

        public EventoSensorDbContext()
        {
            sensores = new List<EventoSensor>();
        }

        public void Save(EventoSensor eventoSensor) =>
            sensores.Add(eventoSensor);

        public IEnumerable<EventoSensor> GetAll() => sensores;
    }
}