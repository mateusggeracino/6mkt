using _6MKT.BackOffice.Api.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace _6MKT.BackOffice.Api.Extensions
{
    public static class FilterExtension
    {
        public static void AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            });

            services.AddScoped<ExceptionFilter>();
        }
    }
}