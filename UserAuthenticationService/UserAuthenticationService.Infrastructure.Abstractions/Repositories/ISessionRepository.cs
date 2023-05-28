namespace UserAuthenticationService.Infrastructure.Abstractions.Repositories;

public interface ISessionRepository
{
    Task LogIn();

    Task LogOut();
}