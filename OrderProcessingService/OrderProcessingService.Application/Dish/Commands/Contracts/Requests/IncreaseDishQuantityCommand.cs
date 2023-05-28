using MediatR;

namespace OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

public record IncreaseDishQuantityCommand(
    int DishId,
    int IncreaseValue) : IRequest;