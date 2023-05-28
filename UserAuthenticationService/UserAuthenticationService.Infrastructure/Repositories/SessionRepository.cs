using Dapper;

using Microsoft.Extensions.Options;

using Npgsql;

using UserAuthenticationService.Infrastructure.Abstractions.Entities;
using UserAuthenticationService.Infrastructure.Abstractions.Repositories;
using UserAuthenticationService.Infrastructure.Settings;

namespace UserAuthenticationService.Infrastructure.Repositories;

public sealed class SessionRepository : BaseRepository, ISessionRepository
{
    public SessionRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task Upsert(SessionEntity entity, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            UserId = entity.UserId,
            SessionToken = entity.SessionToken,
            ExpiresAt = entity.ExpiresAt
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                SessionRepositoryQueries.Upsert,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task<DateTime> GetUserLogTime(int userId, CancellationToken cancellationToken)
    {
        var sqlParams = new
        {
            UserId = userId
        };

        await using NpgsqlConnection connection = await GetAndOpenConnection();

        IEnumerable<SessionEntity>? sessions = await connection.QueryAsync<SessionEntity>(
            new CommandDefinition(
                SessionRepositoryQueries.Query,
                sqlParams,
                cancellationToken: cancellationToken));

        SessionEntity session = sessions.Single();

        return session.ExpiresAt;
    }
}