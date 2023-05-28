using MediatR;

using OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

namespace OrderProcessingService.Application.Dish.Commands;

public class IncreaseDishQuantityCommandHandler : IRequestHandler<IncreaseDishQuantityCommand>
{
    public Task Handle(IncreaseDishQuantityCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}