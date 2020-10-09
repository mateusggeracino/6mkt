using _6MKT.BackOffice.Api.AutoMapper;
using _6MKT.BackOffice.Domain.Clock;
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
            services.AddDbContext<MktContext>(x =>
                x.UseSqlServer(appSettings.ConnectionStrings.Connection,
                    y => y.MigrationsHistoryTable("HistoryMigration", "backoffice"))
            );

            services.AddSingleton(MapperConfig.Config().CreateMapper());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClock, Clock>();

            Services(services);
            Repositories(services);
        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<INaturalPersonService, NaturalPersonService>();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<INaturalPersonRepository, NaturalPersonRepository>();
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        }
    }
}