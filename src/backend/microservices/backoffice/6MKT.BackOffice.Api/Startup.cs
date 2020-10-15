using _6MKT.BackOffice.Api.Extensions;
using _6MKT.BackOffice.Api.Jobs;
using _6MKT.BackOffice.Domain.ValueObjects.AppSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace _6MKT.BackOffice.Api
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
            services.AddHostedService<MigrationJob>();
            services.AddControllers();

            services.ConfigureDependencyInjection(_appSettings);
            services.SwaggerServices();
            services.AddAuthenticationJwt(Configuration);
            services.AddRefit();
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
