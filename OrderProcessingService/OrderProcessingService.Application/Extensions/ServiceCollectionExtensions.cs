using Microsoft.Extensions.DependencyInjection;

using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Domain.Services;

namespace OrderProcessingService.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }

    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IDishService, DishService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderDishService, OrderDishService>();

        return services;
    }
}