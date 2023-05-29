namespace OrderProcessingService.Infrastructure.Abstractions.Entities;

public class OrderDishEntity
{
    public int Id { get; init; }
    public int OrderId { get; init; }
    public int DishId { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}