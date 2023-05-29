using MediatR;

using Microsoft.AspNetCore.Mvc;

using UserAuthenticationService.Application.User.Commands.Contracts;
using UserAuthenticationService.Application.User.Models;
using UserAuthenticationService.Application.User.Queries.Contracts;
using UserAuthenticationService.Contracts.Requests;
using UserAuthenticationService.Contracts.Responses;
using UserAuthenticationService.Contracts.Validators;

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
        try
        {
            RegisterNewUserValidator.ValidateEmail(request);
            RegisterNewUserValidator.ValidatePassword(request);

            var command = new RegisterUserCommand(
                request.Username,
                request.Email,
                request.Password,
                request.PasswordCopy,
                request.Role);

            RegisterUserResult result = await _mediator.Send(command, token);

            return result.Success ? Ok(new RegisterNewUserResponse()) : BadRequest("Error, try to register new user again with another email");
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return BadRequest("Unexpected Error, try again");
        }
    }

    [HttpPost("log-in")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LogInUserResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LogInUser(
        LogInUserRequest request,
        CancellationToken token)
    {
        try
        {
            var command = new LogInUserCommand(request.Email, request.Password);
            LogInUserResult result = await _mediator.Send(command, token);

            return result.Success
                ? Ok(new LogInUserResponse("success"))
                : BadRequest("Cant log in this account, are you sure that you entered right email and password?");
        }
        catch
        {
            return BadRequest("Cant log in this account, are you sure that you entered right email and password?");
        }
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
            var query = new GetUserInfoQuery(request.Email);
            GetUserInfoResult result = await _mediator.Send(query, token);

            return Ok(new GetUserInfoResponse(result.Username, result.Email, result.Role));
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return BadRequest("It seems like there is no such user");
        }
    }
}