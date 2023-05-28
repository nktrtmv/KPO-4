using System.Text;

using Application.User.Commands.Contracts;
using Application.User.Models;

using MediatR;

using UserAuthenticationService.Domain.Abstractions.Models;
using UserAuthenticationService.Domain.Abstractions.Services;

namespace Application.User.Commands;

public class LogInUserCommandHandler : IRequestHandler<LogInUserCommand, LogInUserResult>
{
    private readonly IUserService _userService;
    private readonly ISessionService _sessionService;

    public LogInUserCommandHandler(IUserService userService, ISessionService sessionService)
    {
        _userService = userService;
        _sessionService = sessionService;
    }

    public async Task<LogInUserResult> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {
        string passwordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Password));

        UserWithPassword result = await _userService.GetWithPassword(request.Email, cancellationToken);

        if (result.PasswordHash != passwordHash)
        {
            return new LogInUserResult(false);
        }

        await _sessionService.LogIn(result.Id, cancellationToken);

        return new LogInUserResult(true);
    }
}