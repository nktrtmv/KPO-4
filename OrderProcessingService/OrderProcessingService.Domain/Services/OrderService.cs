
using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

namespace OrderProcessingService.Domain.Services;

public sealed class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Create()
    {
        throw new NotImplementedException();
    }

    public Task Process()
    {
        throw new NotImplementedException();
    }

    public Task Get()
    {
        throw new NotImplementedException();
    }
}