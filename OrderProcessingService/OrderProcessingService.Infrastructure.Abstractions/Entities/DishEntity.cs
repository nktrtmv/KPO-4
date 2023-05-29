namespace OrderProcessingService.Infrastructure.Abstractions.Entities;

public sealed class DishEntity
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public int Quantity { get; init; }
}