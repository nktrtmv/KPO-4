using Dapper;

using Microsoft.Extensions.Options;

using Npgsql;

using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;
using OrderProcessingService.Infrastructure.Repositories.Abstractions;
using OrderProcessingService.Infrastructure.Settings;

namespace OrderProcessingService.Infrastructure.Repositories;

public sealed class DishRepository : BaseRepository, IDishRepository
{
    public DishRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    // public async Task Add(
    //     UserEntity entity,
    //     CancellationToken cancellationToken)
    // {
    //     await using NpgsqlConnection connection = await GetAndOpenConnection();
    //
    //     var sqlParams = new
    //     {
    //         Username = entity.Username,
    //         Email = entity.Email,
    //         PasswordHash = entity.PasswordHash,
    //         Role = entity.Role,
    //         CreatedAt = entity.CreatedAt,
    //         UpdatedAt = entity.UpdatedAt
    //     };
    //
    //     await connection.ExecuteAsync(
    //         new CommandDefinition(
    //             DishRepositoryQueries.Insert,
    //             sqlParams,
    //             cancellationToken: cancellationToken));
    // }
    //
    // public async Task<UserEntity> Query(string email, CancellationToken cancellationToken)
    // {
    //     await using NpgsqlConnection connection = await GetAndOpenConnection();
    //
    //     var sqlParams = new
    //     {
    //         Email = email
    //     };
    //
    //     IEnumerable<UserEntity>? user = await connection.QueryAsync<UserEntity>(
    //         new CommandDefinition(
    //             DishRepositoryQueries.Get,
    //             sqlParams,
    //             cancellationToken: cancellationToken));
    //
    //     return user.Single();
    // }
}