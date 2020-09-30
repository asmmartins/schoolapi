using School.Domain.Sensores;
using School.Domain.Shared;
using School.Repository.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Repository.Sensores
{
    public class EventoSensorRepository : IRepository<EventoSensor>
    {
        private readonly EventoSensorDbContext _context;

        public EventoSensorRepository(EventoSensorDbContext context)
        {
            _context = context;
        }

        public async Task Save(EventoSensor aggregation)
        {
            _context.Save(aggregation);
        }


        public async Task<IEnumerable<EventoSensor>> GetAll()
        {
            return _context.GetAll();
        }
    }
}