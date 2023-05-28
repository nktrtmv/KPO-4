using MediatR;

using OrderProcessingService.Application.Order.Commands.Contracts.Requests;

namespace OrderProcessingService.Application.Order.Commands;

public class ProcessAllOrdersCommandHandler : IRequestHandler<ProcessAllOrdersCommand>
{
    public Task Handle(ProcessAllOrdersCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}