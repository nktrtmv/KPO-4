using Application.User.Models;
using Application.User.Queries.Contracts;

using MediatR;

using UserAuthenticationService.Domain.Abstractions.Interfaces;

namespace Application.User.Queries;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoResult>
{
    private readonly IUserService _userService;

    public GetUserInfoQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetUserInfoResult> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        UserAuthenticationService.Domain.Abstractions.Models.User user = await _userService.Get(
            request.Email,
            request.Password,
            cancellationToken);

        var result = new GetUserInfoResult(user.Username, user.Email, user.Role);

        return result;
    }
}