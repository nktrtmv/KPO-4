using OrderProcessingService.Infrastructure.Abstractions.Entities;

namespace OrderProcessingService.Infrastructure.Abstractions.Repositories;

public interface IOrderRepository : IDbRepository
{
    Task<int> Create(OrderEntity order, CancellationToken cancellationToken);

    Task<int[]> CompleteAll(DateTime now, CancellationToken cancellationToken);

    Task<string> GetStatus(int orderId, CancellationToken cancellationToken);
}