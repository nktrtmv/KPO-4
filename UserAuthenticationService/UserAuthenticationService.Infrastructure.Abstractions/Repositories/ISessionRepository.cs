using UserAuthenticationService.Infrastructure.Abstractions.Entities;

namespace UserAuthenticationService.Infrastructure.Abstractions.Repositories;

public interface ISessionRepository : IDbRepository
{
    Task Upsert(SessionEntity entity, CancellationToken cancellationToken);

    Task<DateTime> GetUserLogTime(int userId, CancellationToken cancellationToken);
}