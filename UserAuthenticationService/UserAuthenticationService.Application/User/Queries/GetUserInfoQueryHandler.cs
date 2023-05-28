using Application.User.Models;
using Application.User.Queries.Contracts;

using MediatR;

namespace Application.User.Queries;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoResult>
{
    public Task<GetUserInfoResult> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}