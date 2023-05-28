using Microsoft.Extensions.DependencyInjection;

using UserAuthenticationService.Domain.Services;
using UserAuthenticationService.Domain.Services.Interfaces;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }

    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ISessionService, SessionService>();

        return services;
    }
}