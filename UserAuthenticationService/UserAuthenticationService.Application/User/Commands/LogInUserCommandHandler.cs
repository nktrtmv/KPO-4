using System.Text;

using MediatR;

using UserAuthenticationService.Application.User.Commands.Contracts;
using UserAuthenticationService.Application.User.Models;
using UserAuthenticationService.Domain.Abstractions.Models;
using UserAuthenticationService.Domain.Abstractions.Services;

namespace UserAuthenticationService.Application.User.Commands;

public class LogInUserCommandHandler : IRequestHandler<LogInUserCommand, LogInUserResult>
{
    private readonly ISessionService _sessionService;
    private readonly IUserService _userService;

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