using Application.User.Models;

using MediatR;

namespace Application.User.Commands.Contracts;

public sealed record LogOutUserCommand(
    string Email,
    string Password) : IRequest<LogOutUserResult>;