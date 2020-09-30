using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Application.UseCases.ObterTotalEventosSensor
{
    public interface IObterTotalEventosSensorUseCase
    {
        Task<IEnumerable<TotalEventosSensorResponse>> Execute();
    }
}
