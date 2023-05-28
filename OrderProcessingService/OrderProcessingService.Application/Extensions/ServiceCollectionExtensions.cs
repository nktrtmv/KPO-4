using Microsoft.Extensions.DependencyInjection;

using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Domain.Services;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

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
        services.AddTransient<IDishService, DishService>();
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IOrderDishService, OrderDishService>();

        return services;
    }
}