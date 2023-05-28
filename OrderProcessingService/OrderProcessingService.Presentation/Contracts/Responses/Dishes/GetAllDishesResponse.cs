using OrderProcessingService.Presentation.Models;

namespace OrderProcessingService.Presentation.Contracts.Responses.Dishes;

public sealed record GetAllDishesResponse(Dish Dishes);