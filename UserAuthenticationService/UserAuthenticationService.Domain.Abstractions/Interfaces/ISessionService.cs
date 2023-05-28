namespace UserAuthenticationService.Domain.Abstractions.Interfaces;

public interface ISessionService
{
    Task LogIn();

    Task LogOut();
}