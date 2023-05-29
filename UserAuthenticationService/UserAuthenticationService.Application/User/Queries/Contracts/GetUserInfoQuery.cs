using MediatR;

using UserAuthenticationService.Application.User.Models;

namespace UserAuthenticationService.Application.User.Queries.Contracts;

public sealed record GetUserInfoQuery(string Email) : IRequest<GetUserInfoResult>;