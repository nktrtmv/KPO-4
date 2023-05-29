using MediatR;

using OrderProcessingService.Application.Dish.Commands.Contracts.Requests;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Dish.Commands;

public class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommand>
{
    private readonly IDishService _dishService;

    public DeleteDishCommandHandler(IDishService dishService)
    {
        _dishService = dishService;
    }

    public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        await _dishService.DeleteDishFromMenu(request.DishId, cancellationToken);
    }
}