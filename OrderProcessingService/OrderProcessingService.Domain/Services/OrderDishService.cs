using OrderProcessingService.Domain.Abstractions.Models;
using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

namespace OrderProcessingService.Domain.Services;

public sealed class OrderDishService : IOrderDishService
{
    private readonly IOrderDishRepository _orderDishRepository;

    public OrderDishService(IOrderDishRepository orderDishRepository)
    {
        _orderDishRepository = orderDishRepository;
    }

    public async Task AddDishes(int orderId, DishQ[] dishes, CancellationToken cancellationToken)
    {
        foreach (DishQ dishQ in dishes)
        {
            await _orderDishRepository.AddDish(
                new OrderDishEntity
                {
                    OrderId = orderId,
                    DishId = dishQ.Id,
                    Quantity = dishQ.Quantity,
                    Price = dishQ.Price
                },
                cancellationToken);
        }
    }

    public async Task DeleteDishes(int[] ordersIds, CancellationToken cancellationToken)
    {
        await _orderDishRepository.DeleteDishes(ordersIds, cancellationToken);
    }

    public async Task<int[]> GetDishesIds(int orderId, CancellationToken cancellationToken)
    {
        int[] ids = await _orderDishRepository.GetDishesIds(orderId, cancellationToken);

        return ids;
    }
}