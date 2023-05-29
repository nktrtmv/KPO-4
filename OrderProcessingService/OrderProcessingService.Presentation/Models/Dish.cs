namespace OrderProcessingService.Presentation.Models;

public sealed record Dish(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity);