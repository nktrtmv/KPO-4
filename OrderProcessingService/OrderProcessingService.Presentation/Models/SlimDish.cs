namespace OrderProcessingService.Presentation.Models;

public sealed record SlimDish(
    string Name,
    string Description,
    decimal Price);