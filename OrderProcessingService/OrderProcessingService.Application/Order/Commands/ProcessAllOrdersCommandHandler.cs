using MediatR;

using OrderProcessingService.Application.Order.Commands.Contracts.Requests;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Order.Commands;

public class ProcessAllOrdersCommandHandler : IRequestHandler<ProcessAllOrdersCommand>
{
    private readonly IOrderDishService _orderDishService;
    private readonly IOrderService _orderService;

    public ProcessAllOrdersCommandHandler(IOrderService orderService, IOrderDishService orderDishService)
    {
        _orderService = orderService;
        _orderDishService = orderDishService;
    }

    public async Task Handle(ProcessAllOrdersCommand request, CancellationToken cancellationToken)
    {
        int[] ordersIds = await _orderService.ProcessAllOrders(DateTime.UtcNow, cancellationToken);

        await _orderDishService.DeleteDishes(ordersIds, cancellationToken);
    }
}