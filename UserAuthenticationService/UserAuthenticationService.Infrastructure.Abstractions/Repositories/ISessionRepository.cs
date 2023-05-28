namespace UserAuthenticationService.Infrastructure.Abstractions.Repositories;

public interface ISessionRepository : IDbRepository
{
    Task LogIn();

    Task LogOut();
}