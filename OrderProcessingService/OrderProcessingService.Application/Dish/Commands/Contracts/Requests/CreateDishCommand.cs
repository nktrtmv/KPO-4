using MediatR;

namespace OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

public sealed record CreateDishCommand(
    string Name,
    string Description,
    decimal Price,
    int Quantity) : IRequest;