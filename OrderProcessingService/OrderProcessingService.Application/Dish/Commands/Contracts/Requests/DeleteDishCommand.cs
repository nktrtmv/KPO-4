using MediatR;

namespace OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

public record DeleteDishCommand(
    int DishId) : IRequest;