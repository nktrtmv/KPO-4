using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OrderProcessingService.Application.Order.Commands.Contracts.Requests;
using OrderProcessingService.Application.Order.Queries.Contracts.Requests;
using OrderProcessingService.Application.Order.Queries.Contracts.Results;
using OrderProcessingService.Domain.Abstractions.Models;
using OrderProcessingService.Presentation.Contracts.Requests.Orders;
using OrderProcessingService.Presentation.Contracts.Responses.Orders;

using SlimDish = OrderProcessingService.Presentation.Models.SlimDish;

namespace OrderProcessingService.Presentation.Controllers;

[Route("[controller]")]
public sealed class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("menu")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetMenuResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMenu(CancellationToken token)
    {
        try
        {
            var query = new GetMenuQuery();
            GetMenuQueryResult result = await _mediator.Send(query, token);

            return Ok(
                new GetMenuResponse(
                    result.Menu
                        .Select(d => new SlimDish(d.Name, d.Description, d.Price))
                        .ToArray()));
        }
        catch
        {
            return BadRequest("fail");
        }
    }

    [HttpPost("create-order")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateOrderResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder(
        CreateOrderRequest request,
        CancellationToken token)
    {
        try
        {
            var command = new CreateOrderCommand(
                request.UserId,
                request.Dishes
                    .Select(d => new DishQ(d.Id, d.Price, d.Quantity))
                    .ToArray(),
                request.SpecialRequests);
            await _mediator.Send(command, token);

            return Ok(new CreateOrderResponse("success"));
        }
        catch
        {
            return BadRequest(new CreateOrderResponse("fail"));
        }
    }

    [HttpPost("info")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetOrderInfoResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetOrderInfo(
        GetOrderInfoRequest request,
        CancellationToken token)
    {
        try
        {
            var query = new GetOrderInfoQuery(request.OrderId);
            GetOrderInfoQueryResult result = await _mediator.Send(query, token);

            return Ok(new GetOrderInfoResponse(result.DishesNames, result.Status));
        }
        catch
        {
            return BadRequest("fail");
        }
    }
}