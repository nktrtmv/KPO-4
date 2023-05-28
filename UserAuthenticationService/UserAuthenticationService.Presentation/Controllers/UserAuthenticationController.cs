using Application.User.Commands.Contracts;
using Application.User.Models;
using Application.User.Queries.Contracts;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using UserAuthenticationService.Contracts.Requests;
using UserAuthenticationService.Contracts.Responses;

namespace UserAuthenticationService.Controllers;

[Route("[controller]")]
public sealed class UserAuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserAuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterNewUserResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterNewUser(
        RegisterNewUserRequest request,
        CancellationToken token)
    {
        var command = new RegisterUserCommand(
            request.Username,
            request.Email,
            request.Password,
            request.PasswordCopy,
            request.Role);

        RegisterUserResult result = await _mediator.Send(command, token);

        return result.Success ? Ok(new RegisterNewUserResponse()) : BadRequest("Error, try to register new user again with another email");
    }

    [HttpPost("log-in")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LogInUserResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LogInUser(
        LogInUserRequest request,
        CancellationToken token)
    {
        var command = new LogInUserCommand(request.Email, request.Password);
        LogInUserResult result = await _mediator.Send(command, token);

        return Ok();
    }

    [HttpPost("log-out")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LogOutUserResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LogOutUser(
        LogOutUserRequest request,
        CancellationToken token)
    {
        var command = new LogOutUserCommand(request.Email, request.Password);
        LogOutUserResult result = await _mediator.Send(command, token);

        return Ok();
    }

    [HttpPost("info")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserInfoResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUserInfo(
        GetUserInfoRequest request,
        CancellationToken token)
    {
        try
        {
            var query = new GetUserInfoQuery(request.Email, request.Password);
            GetUserInfoResult result = await _mediator.Send(query, token);

            return Ok(new GetUserInfoResponse(result.Username, result.Email, result.Role));
        }
        catch (Exception)
        {
            return BadRequest("It seems like there is no such user");
        }
    }
}