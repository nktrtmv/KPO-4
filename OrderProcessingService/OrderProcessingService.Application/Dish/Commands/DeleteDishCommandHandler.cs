using MediatR;

using OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

namespace OrderProcessingService.Application.Dish.Commands;

public class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommand>
{
    public Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}