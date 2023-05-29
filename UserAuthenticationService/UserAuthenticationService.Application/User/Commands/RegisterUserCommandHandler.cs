using System.Text;

using MediatR;

using UserAuthenticationService.Application.User.Commands.Contracts;
using UserAuthenticationService.Application.User.Models;
using UserAuthenticationService.Domain.Abstractions.Services;

namespace UserAuthenticationService.Application.User.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResult>
{
    private readonly IUserService _userService;

    public RegisterUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterUserResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        string passwordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(request.Password));

        try
        {
            await _userService.Add(
                request.Username,
                request.Email,
                passwordHash,
                request.Role,
                DateTime.UtcNow,
                DateTime.UtcNow,
                cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

            return new RegisterUserResult(false);
        }

        return new RegisterUserResult(true);
    }
}