using Application.User.Models;

using MediatR;

namespace Application.User.Queries.Contracts;

public sealed record GetUserInfoQuery(string Email) : IRequest<GetUserInfoResult>;