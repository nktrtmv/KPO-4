using Microsoft.Extensions.DependencyInjection;

using UserAuthenticationService.Domain.Abstractions.Interfaces;

namespace UserAuthenticationService.Domain.Abstractions.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IUserService>();
        services.AddTransient<ISessionService>();

        return services;
    }
}