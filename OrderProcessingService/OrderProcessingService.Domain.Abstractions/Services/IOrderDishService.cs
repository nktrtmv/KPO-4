using OrderProcessingService.Domain.Abstractions.Models;

namespace OrderProcessingService.Domain.Abstractions.Services;

public interface IOrderDishService
{
    Task AddDishes(int orderId, DishQ[] dishes, CancellationToken cancellationToken);

    Task DeleteDishes(int[] ordersIds, CancellationToken cancellationToken);
}