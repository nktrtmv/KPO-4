using OrderProcessingService.Presentation.Models;

namespace OrderProcessingService.Presentation.Contracts.Requests.Orders;

public sealed record CreateOrderRequest(
    int UserId,
    DishQ[] Dishes,
    string? SpecialRequests);