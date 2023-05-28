using MediatR;

using OrderProcessingService.Application.Order.Queries.Contracts.Requests;
using OrderProcessingService.Application.Order.Queries.Contracts.Results;

namespace OrderProcessingService.Application.Order.Queries;

public class GetOrderInfoQueryHandler : IRequestHandler<GetOrderInfoQuery, GetOrderInfoQueryResult>
{
    public Task<GetOrderInfoQueryResult> Handle(GetOrderInfoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}