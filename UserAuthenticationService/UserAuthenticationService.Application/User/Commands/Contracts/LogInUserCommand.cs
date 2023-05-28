using Application.User.Models;

using MediatR;

namespace Application.User.Commands.Contracts;

public sealed record LogInUserCommand(
    string Email,
    string Password) : IRequest<LogInUserResult>;