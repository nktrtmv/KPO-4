namespace UserAuthenticationService.Infrastructure.Abstractions.Repositories;

public interface IUserRepository
{
    Task Add();

    Task Get();
}