using MediatR;

using OrderProcessingService.Application.Order.Commands.Contracts.Requests;
using OrderProcessingService.Domain.Abstractions.Models;
using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

namespace OrderProcessingService.Application.Order.Commands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IDishService _dishService;
    private readonly IOrderService _orderService;
    private readonly IOrderDishService _orderDishService;

    public CreateOrderCommandHandler(IDishService dishService, IOrderService orderService, IOrderDishService orderDishService)
    {
        _dishService = dishService;
        _orderService = orderService;
        _orderDishService = orderDishService;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        int orderId = await _orderService.CreateOrder(request.UserId, request.SpecialRequests, DateTime.UtcNow, DateTime.UtcNow, cancellationToken);

        await _orderDishService.AddDishes(orderId, request.Dishes, cancellationToken);

        foreach (DishQ dish in request.Dishes)
        {
            for (int i = 0; i < dish.Quantity; i++)
            {
                await _dishService.DeleteDish(dish.Id, cancellationToken);
            }
        }
    }
}