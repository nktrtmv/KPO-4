using Application.User.Commands.Contracts;
using Application.User.Models;

using MediatR;

namespace Application.User.Commands;

public class LogOutUserCommandHandler : IRequestHandler<LogOutUserCommand, LogOutUserResult>
{
    public Task<LogOutUserResult> Handle(LogOutUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}