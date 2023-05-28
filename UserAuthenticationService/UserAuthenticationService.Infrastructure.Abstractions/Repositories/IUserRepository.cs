using UserAuthenticationService.Infrastructure.Abstractions.Entities;

namespace UserAuthenticationService.Infrastructure.Abstractions.Repositories;

public interface IUserRepository : IDbRepository
{
    Task Add(UserEntity entity, CancellationToken cancellationToken);

    Task<UserEntity> Query(string email, CancellationToken cancellationToken);
}