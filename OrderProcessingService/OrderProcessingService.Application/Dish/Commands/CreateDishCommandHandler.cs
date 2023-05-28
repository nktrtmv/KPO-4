using MediatR;

using OrderProcessingService.Application.Dish.Commands.Contracts.Requests;

namespace OrderProcessingService.Application.Dish.Commands;

public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand>
{
    public Task Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}