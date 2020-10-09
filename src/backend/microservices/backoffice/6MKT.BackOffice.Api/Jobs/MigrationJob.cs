using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MktContext = _6MKT.BackOffice.Infra.Context.MktContext;

namespace _6MKT.BackOffice.Api.Jobs
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

            scope.ServiceProvider.GetService<MktContext>()
                .Database.Migrate();

            return Task.CompletedTask;
        }
    }
}