namespace OrderProcessingService.Application.Order.Models;

public record SlimDish(
    string Name,
    string Description,
    decimal Price);