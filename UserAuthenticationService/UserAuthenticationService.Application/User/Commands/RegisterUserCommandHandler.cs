using System.Text;

using Application.User.Commands.Contracts;
using Application.User.Models;

using MediatR;

using UserAuthenticationService.Domain.Abstractions.Services;

namespace Application.User.Commands;

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