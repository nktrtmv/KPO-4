namespace OrderProcessingService.Presentation.Models;

public record Dish(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity);