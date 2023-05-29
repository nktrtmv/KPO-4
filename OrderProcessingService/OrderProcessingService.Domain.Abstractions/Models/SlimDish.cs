namespace OrderProcessingService.Domain.Abstractions.Models;

public sealed record SlimDish(
    string Name,
    string Description,
    decimal Price);