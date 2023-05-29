using MediatR;

using OrderProcessingService.Application.Order.Queries.Contracts.Requests;
using OrderProcessingService.Application.Order.Queries.Contracts.Results;
using OrderProcessingService.Domain.Abstractions.Models;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Order.Queries;

public class GetMenuQueryHandler : IRequestHandler<GetMenuQuery, GetMenuQueryResult>
{
    private readonly IDishService _dishService;

    public GetMenuQueryHandler(IDishService dishService)
    {
        _dishService = dishService;
    }

    public async Task<GetMenuQueryResult> Handle(GetMenuQuery request, CancellationToken cancellationToken)
    {
        SlimDish[] result = await _dishService.GetMenu(cancellationToken);

        return new GetMenuQueryResult(result);
    }
}