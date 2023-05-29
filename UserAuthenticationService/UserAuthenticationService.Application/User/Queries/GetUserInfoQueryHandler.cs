using MediatR;

using UserAuthenticationService.Application.User.Models;
using UserAuthenticationService.Application.User.Queries.Contracts;
using UserAuthenticationService.Domain.Abstractions.Models;
using UserAuthenticationService.Domain.Abstractions.Services;

namespace UserAuthenticationService.Application.User.Queries;

public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoResult>
{
    private readonly ISessionService _sessionService;
    private readonly IUserService _userService;

    public GetUserInfoQueryHandler(IUserService userService, ISessionService sessionService)
    {
        _userService = userService;
        _sessionService = sessionService;
    }

    public async Task<GetUserInfoResult> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
    {
        Domain.Abstractions.Models.User user = await _userService.Get(
            request.Email,
            cancellationToken);

        UserWithPassword userWithPassword = await _userService.GetWithPassword(request.Email, cancellationToken);

        bool isLogged = await _sessionService.IsLogged(userWithPassword.Id, cancellationToken);

        if (!isLogged)
        {
            throw new ArgumentException("User is not logged in");
        }

        var result = new GetUserInfoResult(user.Username, user.Email, user.Role);

        return result;
    }
}