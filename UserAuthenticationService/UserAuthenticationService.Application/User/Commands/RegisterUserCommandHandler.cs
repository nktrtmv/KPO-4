using Application.User.Commands.Contracts;
using Application.User.Models;

using MediatR;

using UserAuthenticationService.Domain.Abstractions.Interfaces;

namespace Application.User.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IUserService _userService;

    public RegisterUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _userService.Add(
                request.Username,
                request.Email,
                request.Password.GetHashCode().ToString(),
                request.Role,
                DateTime.UtcNow,
                DateTime.UtcNow,
                cancellationToken);
        }
        catch (Exception)
        {
            return new RegisterUserResult(false);
        }

        return new RegisterUserResult(true);
    }
}