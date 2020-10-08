using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace _6MKT.BackOffice.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void SwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "123Vendido - Deixe que disputem por você",
                        Version = "v1",
                        Description = "API REST - 123Vendido",
                        Contact = new OpenApiContact
                        {
                            Name = "6MKT Corporation",
                            Url = new Uri("https://github.com/mateusggeracino/6mkt")
                        }
                    });
            });
        }

        public static void SwaggerApp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "123Vendido v1");
            });

        }
    }
}