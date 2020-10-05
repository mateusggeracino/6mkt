using _6MKT.BackOffice.Api.AutoMapper;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace _6MKT.BackOffice.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton(MapperConfig.Config().CreateMapper());

            Services(services);
            Repositories(services);
        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<IProviderService, ProviderService>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IProviderRepository, ProviderRepository>();
        }
    }
}