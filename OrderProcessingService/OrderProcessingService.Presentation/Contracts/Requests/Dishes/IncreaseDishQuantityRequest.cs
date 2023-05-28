namespace OrderProcessingService.Presentation.Contracts.Requests.Dishes;

public sealed record IncreaseDishQuantityRequest(
    int DishId,
    int IncreaseValue);