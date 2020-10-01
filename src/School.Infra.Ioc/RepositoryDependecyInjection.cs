using Microsoft.Extensions.DependencyInjection;
using School.Domain.Groups;
using School.Domain.PublicSchools;
using School.Domain.Sensores;
using School.Domain.Shared;
using School.Repository.Sensores;
using School.Repository.Shared;

namespace School.Infra.Ioc
{
    internal static class RepositoryDependecyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<EventoSensorDbContext>();            
            services.AddScoped<IRepository<EventoSensor>, EventoSensorRepository>();

            services.AddSingleton<PublicSchoolDbContext>();
            services.AddScoped<IRepository<PublicSchool>, PublicSchoolRepository>();

            services.AddSingleton<GroupDbContext>();
            services.AddScoped<IRepository<Group>, GroupRepository>();
        }
    }
}