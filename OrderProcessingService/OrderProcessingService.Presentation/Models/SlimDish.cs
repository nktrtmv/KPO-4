namespace OrderProcessingService.Presentation.Models;

public record SlimDish(
    string Name,
    string Description,
    decimal Price);