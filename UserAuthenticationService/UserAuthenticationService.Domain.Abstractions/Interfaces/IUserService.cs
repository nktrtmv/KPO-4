using UserAuthenticationService.Domain.Abstractions.Models;

namespace UserAuthenticationService.Domain.Abstractions.Interfaces;

public interface IUserService
{
    Task Add(string userName, string email, string passwordHash, string role, DateTime createdTime, DateTime updatedTime, CancellationToken cancellationToken);

    Task<User> Get(string email, string password, CancellationToken cancellationToken);
}