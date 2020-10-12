using System;
using System.Net.Http;
using _6MKT.BackOffice.Domain.ValueObjects.AppSettings;
using _6MKT.BackOffice.Domain.Wrapper.Endpoint;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace _6MKT.BackOffice.Api.Extensions
{
    public static class RefitExtension
    {
        public static void AddRefit(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var appSettings = provider.GetService<IAppSettings>();

            services.AddHttpClient("6mktSso")
                .ConfigureHttpClient((serviceProvider, conf) =>
                {
                    conf.BaseAddress = new Uri(appSettings.Endpoints.IdentityUrl);
                });

            services.AddRefitEndpoint<IUserSsoEndpoint>("6mktSso");
        }

        public static IServiceCollection AddRefitEndpoint<TEndpoint>(this IServiceCollection services, string name)
            where TEndpoint : class
        {
            return services.AddTransient(factory =>
            {
                var httpFactory = factory.GetService<IHttpClientFactory>();
                return RestService.For<TEndpoint>(httpFactory.CreateClient(name));
            });
        }
    }
}