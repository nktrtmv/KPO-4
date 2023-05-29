using MediatR;

using OrderProcessingService.Application.Dish.Commands.Contracts.Requests;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Dish.Commands;

public class IncreaseDishQuantityCommandHandler : IRequestHandler<IncreaseDishQuantityCommand>
{
    private readonly IDishService _dishService;

    public IncreaseDishQuantityCommandHandler(IDishService dishService)
    {
        _dishService = dishService;
    }

    public async Task Handle(IncreaseDishQuantityCommand request, CancellationToken cancellationToken)
    {
        await _dishService.IncreaseDishQuantity(request.DishId, request.IncreaseValue, cancellationToken);
    }
}