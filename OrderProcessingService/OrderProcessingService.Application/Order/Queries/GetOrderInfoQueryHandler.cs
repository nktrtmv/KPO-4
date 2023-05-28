using MediatR;

using OrderProcessingService.Application.Order.Queries.Contracts.Requests;
using OrderProcessingService.Application.Order.Queries.Contracts.Results;
using OrderProcessingService.Domain.Abstractions.Models;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Order.Queries;

public class GetOrderInfoQueryHandler : IRequestHandler<GetOrderInfoQuery, GetOrderInfoQueryResult>
{
    private readonly IOrderService _orderService;

    public GetOrderInfoQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<GetOrderInfoQueryResult> Handle(GetOrderInfoQuery request, CancellationToken cancellationToken)
    {
        OrderInfo result = await _orderService.GetOrderInfo(request.OrderId, cancellationToken);

        return new GetOrderInfoQueryResult(result.DishesNames, result.Status);
    }
}