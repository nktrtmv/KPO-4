using OrderProcessingService.Domain.Abstractions.Models;

namespace OrderProcessingService.Domain.Abstractions.Services;

public interface IDishService
{
    Task CreateDish(
        string name,
        string description,
        decimal price,
        int quantity,
        CancellationToken cancellationToken);

    Task<Dish[]> GetAllDishes(CancellationToken cancellationToken);

    Task IncreaseDishQuantity(int dishId, int increaseValue, CancellationToken cancellationToken);

    Task DeleteDish(int dishId, CancellationToken cancellationToken);

    Task<SlimDish[]> GetMenu(CancellationToken cancellationToken);
}