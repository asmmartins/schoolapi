using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Domain.Shared
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task Save(T aggregation);
        Task<IEnumerable<T>> GetAll();
    }
}