using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OrderProcessingService.Presentation.Contracts.Requests.Orders;
using OrderProcessingService.Presentation.Contracts.Responses.Orders;

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
    public async Task<IActionResult> GetMenu(
        CancellationToken token)
    {
        return Ok();
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
        return Ok();
    }
}