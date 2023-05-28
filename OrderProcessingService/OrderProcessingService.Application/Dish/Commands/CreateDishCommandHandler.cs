using MediatR;

using OrderProcessingService.Application.Dish.Commands.Contracts.Requests;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Dish.Commands;

public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand>
{
    private readonly IDishService _dishService;

    public CreateDishCommandHandler(IDishService dishService)
    {
        _dishService = dishService;
    }

    public async Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        await _dishService.CreateDish(request.Name, request.Description, request.Price, request.Quantity, cancellationToken);
    }
}