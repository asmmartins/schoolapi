using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Application.UseCases.ObterTotalEventosSensorPorRegiao
{
    public interface IObterTotalEventosSensorPorRegiaoUseCase
    {
        Task<IEnumerable<TotalEventosSensorPorRegiaoResponse>> Execute();
    }
}
