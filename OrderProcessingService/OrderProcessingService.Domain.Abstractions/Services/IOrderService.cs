namespace OrderProcessingService.Domain.Abstractions.Services;

public interface IOrderService
{
    Task<int> CreateOrder(
        int userId,
        string? specialRequests,
        DateTime createdAt,
        DateTime updatedAt,
        CancellationToken cancellationToken);

    Task<int[]> ProcessAllOrders(DateTime now, CancellationToken cancellationToken);

    Task<string> GetOrderStatus(int orderId, CancellationToken cancellationToken);
}