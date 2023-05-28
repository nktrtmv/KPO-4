using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using UserAuthenticationService.Infrastructure.Abstractions.Repositories;
using UserAuthenticationService.Infrastructure.Repositories;
using UserAuthenticationService.Infrastructure.Settings;

namespace UserAuthenticationService.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDalRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();

        return services;
    }

    public static IServiceCollection AddDalInfrastructure(
        this IServiceCollection services,
        IConfigurationRoot config)
    {
        //read config
        services.Configure<DalOptions>(config.GetSection(nameof(DalOptions)));

        //configure postgres types
        Postgres.MapCompositeTypes();

        //add migrations
        Postgres.AddMigrations(services);

        return services;
    }
}