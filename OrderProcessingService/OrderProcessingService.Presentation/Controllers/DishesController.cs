using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OrderProcessingService.Presentation.Contracts.Requests.Dishes;
using OrderProcessingService.Presentation.Contracts.Responses.Dishes;

namespace OrderProcessingService.Presentation.Controllers;

[Route("[controller]")]
public class DishesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DishesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateDishResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDish(
        CreateDishRequest request,
        CancellationToken token)
    {
        return Ok();
    }

    [HttpPost("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllDishesResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllDishes(
        CancellationToken token)
    {
        return Ok();
    }

    [HttpPost("increase-dish-quantity")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IncreaseDishQuantityResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> IncreaseDishQuantity(
        IncreaseDishQuantityRequest request,
        CancellationToken token)
    {
        return Ok();
    }

    [HttpPost("delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteDishResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteDish(
        DeleteDishRequest request,
        CancellationToken token)
    {
        return Ok();
    }
}