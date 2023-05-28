using MediatR;

using UserAuthenticationService.Application.User.Models;

namespace UserAuthenticationService.Application.User.Commands.Contracts;

public sealed record LogInUserCommand(
    string Email,
    string Password) : IRequest<LogInUserResult>;