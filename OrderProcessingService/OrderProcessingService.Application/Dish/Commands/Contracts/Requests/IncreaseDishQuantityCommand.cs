using MediatR;

namespace OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

public sealed record IncreaseDishQuantityCommand(
    int DishId,
    int IncreaseValue) : IRequest;