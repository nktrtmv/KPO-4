using OrderProcessingService.Infrastructure.Abstractions.Entities;

namespace OrderProcessingService.Infrastructure.Abstractions.Repositories;

public interface IOrderDishRepository : IDbRepository
{
    Task AddDish(OrderDishEntity orderDish, CancellationToken cancellationToken);

    Task DeleteDishes(IEnumerable<int> ordersIds, CancellationToken cancellationToken);

    Task<int[]> GetDishesIds(int orderId, CancellationToken cancellationToken);
}