﻿using Microsoft.Extensions.DependencyInjection;
using School.Application.UseCases.CapturarEventoSensor;
using School.Application.UseCases.ObterTotalEventosSensor;
using School.Application.UseCases.ObterTotalEventosSensorPorRegiao;
using School.UseCases.CapturarEventoSensor;
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
        }
    }
}
