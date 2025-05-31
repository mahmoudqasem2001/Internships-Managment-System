using InternGo.Infrastructure.Authentication.Jwt;
using InternGo.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InternGo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    IConfiguration config)
        {
            ArgumentNullException.ThrowIfNull(config);
            var jwtSettingsSection = config.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();


            services.AddPersistenceInfrastructure(config);
             

            return services;
        }
    }
}
