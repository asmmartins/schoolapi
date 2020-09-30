using Microsoft.Extensions.DependencyInjection;

namespace School.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static void AddDependecyInjection(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddUseCases();
        }
    }
}
