namespace OrderProcessingService.Presentation.Contracts.Requests.Dishes;

public sealed record CreateDishRequest(
    string Name,
    string Description,
    decimal Price,
    int Quantity);