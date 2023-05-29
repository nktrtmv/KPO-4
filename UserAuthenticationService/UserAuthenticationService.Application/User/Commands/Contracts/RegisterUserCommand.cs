using MediatR;

using UserAuthenticationService.Application.User.Models;

namespace UserAuthenticationService.Application.User.Commands.Contracts;

public sealed record RegisterUserCommand(
    string Username,
    string Email,
    string Password,
    string PasswordCopy,
    string Role) : IRequest<RegisterUserResult>;