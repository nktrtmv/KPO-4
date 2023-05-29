using MediatR;

using OrderProcessingService.Application.Order.Queries.Contracts.Requests;
using OrderProcessingService.Application.Order.Queries.Contracts.Results;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Order.Queries;

public class GetOrderInfoQueryHandler : IRequestHandler<GetOrderInfoQuery, GetOrderInfoQueryResult>
{
    private readonly IDishService _dishService;
    private readonly IOrderDishService _orderDishService;
    private readonly IOrderService _orderService;

    public GetOrderInfoQueryHandler(IOrderService orderService, IOrderDishService orderDishService, IDishService dishService)
    {
        _orderService = orderService;
        _orderDishService = orderDishService;
        _dishService = dishService;
    }

    public async Task<GetOrderInfoQueryResult> Handle(GetOrderInfoQuery request, CancellationToken cancellationToken)
    {
        string status = await _orderService.GetOrderStatus(request.OrderId, cancellationToken);

        if (status == "Completed")
        {
            throw new ArgumentException("Order already completed");
        }

        int[] ids = await _orderDishService.GetDishesIds(request.OrderId, cancellationToken);

        Domain.Abstractions.Models.Dish[] allDishes = await _dishService.GetAllDishes(cancellationToken);

        string[] dishesNames = allDishes.Where(d => ids.Contains(d.Id)).Select(d => d.Name).ToArray();

        return new GetOrderInfoQueryResult(dishesNames, status);
    }
}