using System;
using System.Threading;
using System.Threading.Tasks;
using _6MKT.Identity.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _6MKT.Identity.Api.Jobs
{
    public class MigrationJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrationJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var scope = _serviceProvider.CreateScope();

            scope.ServiceProvider.GetService<IdentityContext>()
                .Database.Migrate();

            return Task.CompletedTask;
        }
    }
}