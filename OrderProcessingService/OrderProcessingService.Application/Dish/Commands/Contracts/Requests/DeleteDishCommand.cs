using MediatR;

namespace OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

public sealed record DeleteDishCommand(
    int DishId) : IRequest;