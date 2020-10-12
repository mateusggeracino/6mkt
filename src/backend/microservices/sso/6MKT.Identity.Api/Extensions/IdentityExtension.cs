using _6MKT.Identity.Domain.Entities;
using _6MKT.Identity.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace _6MKT.Identity.Api.Extensions
{
    public static class IdentityExtension
    {
        public static void ConfigIdentity(this IServiceCollection services)
        {
            services
                .AddDefaultIdentity<UserEntity>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });
        }
    }
}