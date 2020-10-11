using _6MKT.Identity.Api.Extensions;
using _6MKT.Identity.Domain.ValueObjects.AppSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using _6MKT.Common.Identity;

namespace _6MKT.Identity.Api
{
    public class Startup
    {
        private readonly IAppSettings _appSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build()
                .Get<AppSettings>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.SwaggerServices();
            services.ConfigureDependencyInjection(_appSettings);
            services.AddAuthenticationJwt(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.SwaggerApp();
            app.UseRouting();

            app.AddIdentityConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
