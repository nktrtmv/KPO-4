using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

namespace OrderProcessingService.Domain.Services;

public sealed class OrderDishService : IOrderDishService
{
    private readonly IOrderDishRepository _orderDishRepository;

    public OrderDishService(IOrderDishRepository orderDishRepository)
    {
        _orderDishRepository = orderDishRepository;
    }

    public Task Add()
    {
        throw new NotImplementedException();
    }

    public Task GetAll()
    {
        throw new NotImplementedException();
    }
}