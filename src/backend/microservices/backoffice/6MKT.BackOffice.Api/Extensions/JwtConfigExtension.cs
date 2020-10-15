using _6MKT.BackOffice.Domain.Constants;
using _6MKT.Common.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using _6MKT.BackOffice.Domain.Services.Interfaces;
using _6MKT.BackOffice.Domain.ValueObjects.UserIdentifier;

namespace _6MKT.BackOffice.Api.Extensions
{
    public static class JwtConfigExtension
    {
        public static void AddAuthenticationJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("Jwt");
            services.Configure<JwtSettings>(appSettingsSection);

            services.AddScoped<IUserIdentifier, UserIdentifier>();
            
            var appSettings = appSettingsSection.Get<JwtSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = true;
                bearerOptions.SaveToken = true;
                bearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidatedAt,
                    ValidIssuer = appSettings.Origin
                };
                bearerOptions.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        if (!(context.SecurityToken is JwtSecurityToken accessToken)) return;

                        var userType = context.Principal.Claims.FirstOrDefault(x => x.Type == JwtCustomClaimNames.UserType);
                        if (userType == null)
                            return;

                        var userProviderId = context.Principal.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"));

                        var userService = context.HttpContext.RequestServices.GetService<IUserIdentifierService>();

                        var useridentifier = await userService.GetUserAsync(userProviderId?.Value, userType.Value);

                        var user = context.HttpContext.RequestServices.GetService<IUserIdentifier>();

                        user.Id = useridentifier.Id;
                        user.Type = useridentifier.Type;

                        await Task.CompletedTask;
                    }
                };
            });
        }

        public static void AddIdentityConfiguration(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}