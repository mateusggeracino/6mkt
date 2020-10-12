using _6MKT.Identity.Api.AutoMapper;
using _6MKT.Identity.Domain.Entities;
using _6MKT.Identity.Domain.Services;
using _6MKT.Identity.Domain.Services.Interfaces;
using _6MKT.Identity.Domain.ValueObjects.AppSettings;
using _6MKT.Identity.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace _6MKT.Identity.Api.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IAppSettings appSettings)
        {
            services.AddDbContext<IdentityContext>(x =>
                x.UseSqlServer(appSettings.ConnectionStrings.Connection,
                    y => y.MigrationsHistoryTable("MigrationHistory", "Identity")));
            
            services.AddSingleton(MapperConfig.Config().CreateMapper());
            services.AddSingleton(appSettings);

            services.AddScoped<IUserService, UserService>();
        }
    }
}