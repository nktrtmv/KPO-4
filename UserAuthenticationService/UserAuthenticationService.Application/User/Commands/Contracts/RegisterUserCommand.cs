using Application.User.Models;

using MediatR;

namespace Application.User.Commands.Contracts;

public sealed record RegisterUserCommand(
    string Username,
    string Email,
    string Password,
    string PasswordCopy,
    string Role) : IRequest<RegisterUserResult>;