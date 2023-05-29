using OrderProcessingService.Infrastructure.Abstractions.Entities;

namespace OrderProcessingService.Infrastructure.Abstractions.Repositories;

public interface IDishRepository : IDbRepository
{
    Task Create(DishEntity dish, CancellationToken cancellationToken);

    Task IncreaseDishQuantity(int dishId, int increaseValue, CancellationToken cancellationToken);

    Task DecreaseDishQuantity(int dishId, CancellationToken cancellationToken);

    Task Delete(int dishId, CancellationToken cancellationToken);

    Task<DishEntity[]> QueryAll(CancellationToken cancellationToken);
}