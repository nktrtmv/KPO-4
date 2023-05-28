using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OrderProcessingService.Application.Dish.Commands.Contracts.Requests;
using OrderProcessingService.Application.Dish.Queries.Contracts.Requests;
using OrderProcessingService.Application.Dish.Queries.Contracts.Results;
using OrderProcessingService.Presentation.Contracts.Requests.Dishes;
using OrderProcessingService.Presentation.Contracts.Responses.Dishes;
using OrderProcessingService.Presentation.Models;

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
        try
        {
            var command = new CreateDishCommand(request.Name, request.Description, request.Price, request.Quantity);
            await _mediator.Send(command, token);

            return Ok(new CreateDishResponse("success"));
        }
        catch
        {
            return BadRequest(new CreateDishResponse("fail"));
        }
    }

    [HttpPost("get-all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAllDishesResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllDishes(CancellationToken token)
    {
        try
        {
            var query = new GetAllDishesQuery();
            GetAllDishesQueryResult result = await _mediator.Send(query, token);

            return Ok(
                new GetAllDishesResponse(
                    result.Dishes
                        .Select(d => new Dish(d.Id, d.Name, d.Description, d.Price, d.Quantity))
                        .ToArray()));
        }
        catch
        {
            return BadRequest("fail");
        }
    }

    [HttpPost("increase-dish-quantity")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IncreaseDishQuantityResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> IncreaseDishQuantity(
        IncreaseDishQuantityRequest request,
        CancellationToken token)
    {
        try
        {
            var command = new IncreaseDishQuantityCommand(request.DishId, request.IncreaseValue);
            await _mediator.Send(command, token);

            return Ok(new IncreaseDishQuantityResponse("success"));
        }
        catch
        {
            return BadRequest(new IncreaseDishQuantityResponse("fail"));
        }
    }

    [HttpPost("delete")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteDishResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteDish(
        DeleteDishRequest request,
        CancellationToken token)
    {
        try
        {
            var command = new DeleteDishCommand(request.DishId);
            await _mediator.Send(command, token);

            return Ok(new DeleteDishResponse("success"));
        }
        catch
        {
            return BadRequest(new DeleteDishResponse("fail"));
        }
    }
}