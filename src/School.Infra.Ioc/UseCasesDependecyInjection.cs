using Microsoft.Extensions.DependencyInjection;
using School.Application.UseCases.CapturarEventoSensor;
using School.Application.UseCases.CreateGroup;
using School.Application.UseCases.CreatePublicSchool;
using School.Application.UseCases.GetGroups;
using School.Application.UseCases.GetPublicSchool;
using School.Application.UseCases.ObterTotalEventosSensor;
using School.Application.UseCases.ObterTotalEventosSensorPorRegiao;
using School.UseCases.CapturarEventoSensor;
using School.UseCases.CreateGroup;
using School.UseCases.CreatePublicSchool;
using School.UseCases.GetGroups;
using School.UseCases.GetPublicSchool;
using School.UseCases.ObterTotalEventosSensor;
using School.UseCases.ObterTotalEventosSensorPorRegiao;

namespace School.Infra.Ioc
{
    internal static class UseCasesDependecyInjection
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICapturarEventoSensorUseCase, CapturarEventoSensorUseCase>();
            services.AddTransient<IObterTotalEventosSensorUseCase, ObterTotalEventosSensorUseCase>();
            services.AddTransient<IObterTotalEventosSensorPorRegiaoUseCase, ObterTotalEventosSensorPorRegiaoUseCase>();
            services.AddTransient<ICreatePublicSchoolUseCase, CreatePublicSchoolUseCase>();
            services.AddTransient<ICreateGroupUseCase, CreateGroupUseCase>();
            services.AddTransient<IGetPublicSchoolUseCase, GetPublicSchoolUseCase>();
            services.AddTransient<IGetGroupsUseCase, GetGroupUseCase>();
        }
    }
}
