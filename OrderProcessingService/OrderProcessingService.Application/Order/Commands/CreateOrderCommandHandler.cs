using MediatR;

using OrderProcessingService.Application.Order.Commands.Contracts.Requests;

namespace OrderProcessingService.Application.Order.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}