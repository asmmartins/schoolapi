using System.Threading.Tasks;

namespace School.Application.UseCases.CapturarEventoSensor
{
    public interface ICapturarEventoSensorUseCase
    {
        Task Execute(CapturarEventoSensorRequest capturarEventoSensorRequest);
    }
}