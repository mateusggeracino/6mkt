using _6MKT.BackOffice.Api.AutoMapper;
using _6MKT.BackOffice.Domain.Repositories.Interfaces;
using _6MKT.BackOffice.Domain.Services;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.UnitOfWork;
using _6MKT.BackOffice.Domain.ValueObjects.AppSettings;
using _6MKT.BackOffice.Infra.Context;
using _6MKT.BackOffice.Infra.Repositories;
using _6MKT.BackOffice.Infra.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _6MKT.BackOffice.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IAppSettings appSettings)
        {
            services.AddDbContext<AppContext>(x =>
                x.UseSqlServer(appSettings.ConnectionStrings.Connection,
                    y => y.MigrationsHistoryTable("HistoryMigration", "backoffice"))
            );

            services.AddSingleton(MapperConfig.Config().CreateMapper());
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services(services);
            Repositories(services);
        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<INaturalPersonService, NaturalPersonService>();
            services.AddScoped<IBusinessService, BusinessService>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
        }
    }
}