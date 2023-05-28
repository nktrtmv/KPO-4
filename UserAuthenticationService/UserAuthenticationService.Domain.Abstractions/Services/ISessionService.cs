namespace UserAuthenticationService.Domain.Abstractions.Services;

public interface ISessionService
{
    Task LogIn(int userId, CancellationToken cancellationToken);

    Task<bool> IsLogged(int userId, CancellationToken cancellationToken);
}