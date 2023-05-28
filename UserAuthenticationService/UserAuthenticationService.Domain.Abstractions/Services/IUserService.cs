using UserAuthenticationService.Domain.Abstractions.Models;

namespace UserAuthenticationService.Domain.Abstractions.Services;

public interface IUserService
{
    Task Add(string userName, string email, string passwordHash, string role, DateTime createdTime, DateTime updatedTime, CancellationToken cancellationToken);

    Task<User> Get(string email, CancellationToken cancellationToken);

    Task<UserWithPassword> GetWithPassword(string email, CancellationToken cancellationToken);
}