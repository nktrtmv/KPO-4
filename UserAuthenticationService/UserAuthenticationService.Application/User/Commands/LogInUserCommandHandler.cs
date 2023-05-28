using Application.User.Commands.Contracts;
using Application.User.Models;

using MediatR;

namespace Application.User.Commands;

public class LogInUserCommandHandler : IRequestHandler<LogInUserCommand, LogInUserResult>
{
    public Task<LogInUserResult> Handle(LogInUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}