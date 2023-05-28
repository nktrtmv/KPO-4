using MediatR;

using OrderProcessingService.Application.Order.Queries.Contracts.Requests;
using OrderProcessingService.Application.Order.Queries.Contracts.Results;

namespace OrderProcessingService.Application.Order.Queries;

public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, GetMenuQueryResult>
{
    public Task<GetMenuQueryResult> Handle(GetMenuQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}