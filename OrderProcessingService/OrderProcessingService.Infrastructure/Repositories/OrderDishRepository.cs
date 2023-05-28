using Dapper;

using Microsoft.Extensions.Options;

using Npgsql;

using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;
using OrderProcessingService.Infrastructure.Repositories.Abstractions;
using OrderProcessingService.Infrastructure.Settings;

namespace OrderProcessingService.Infrastructure.Repositories;

public sealed class OrderDishRepository : BaseRepository, IOrderDishRepository
{
    public OrderDishRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    // public async Task Upsert(SessionEntity entity, CancellationToken cancellationToken)
    // {
    //     await using NpgsqlConnection connection = await GetAndOpenConnection();
    //
    //     var sqlParams = new
    //     {
    //         UserId = entity.UserId,
    //         SessionToken = entity.SessionToken,
    //         ExpiresAt = entity.ExpiresAt
    //     };
    //
    //     await connection.ExecuteAsync(
    //         new CommandDefinition(
    //             OrderRepositoryQueries.Upsert,
    //             sqlParams,
    //             cancellationToken: cancellationToken));
    // }
    //
    // public async Task<DateTime> GetUserLogTime(int userId, CancellationToken cancellationToken)
    // {
    //     var sqlParams = new
    //     {
    //         UserId = userId
    //     };
    //
    //     await using NpgsqlConnection connection = await GetAndOpenConnection();
    //
    //     IEnumerable<SessionEntity>? sessions = await connection.QueryAsync<SessionEntity>(
    //         new CommandDefinition(
    //             OrderRepositoryQueries.Query,
    //             sqlParams,
    //             cancellationToken: cancellationToken));
    //
    //     SessionEntity session = sessions.Single();
    //
    //     return session.ExpiresAt;
    // }
}