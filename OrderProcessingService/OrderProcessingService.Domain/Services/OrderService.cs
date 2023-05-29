
using OrderProcessingService.Domain.Abstractions.Models;
using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

namespace OrderProcessingService.Domain.Services;

public sealed class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> CreateOrder(int userId, string? specialRequests, DateTime createdAt, DateTime updatedAt, CancellationToken cancellationToken)
    {
        int orderId = await _orderRepository.Create(
            new OrderEntity
            {
                UserId = userId,
                Status = "In Progress",
                SpecialRequests = specialRequests!,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt
            },
            cancellationToken);

        return orderId;
    }

    public async Task<int[]> ProcessAllOrders(DateTime now, CancellationToken cancellationToken)
    {
        int[] ordersIds = await _orderRepository.CompleteAll(now, cancellationToken);

        return ordersIds;
    }

    public async Task<string> GetOrderStatus(int orderId, CancellationToken cancellationToken)
    {
        string info = await _orderRepository.GetStatus(orderId, cancellationToken);

        return info;
    }
}