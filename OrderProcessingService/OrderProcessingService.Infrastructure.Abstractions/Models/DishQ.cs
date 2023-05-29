namespace OrderProcessingService.Infrastructure.Abstractions.Models;

public sealed record DishQ(
    int Id,
    decimal Price,
    int Quantity);