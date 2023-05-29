using Dapper;

using Microsoft.Extensions.Options;

using Npgsql;

using UserAuthenticationService.Infrastructure.Abstractions.Entities;
using UserAuthenticationService.Infrastructure.Abstractions.Repositories;
using UserAuthenticationService.Infrastructure.Repositories.Abstractions;
using UserAuthenticationService.Infrastructure.Settings;

namespace UserAuthenticationService.Infrastructure.Repositories;

public sealed class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task Add(
        UserEntity entity,
        CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            entity.Username,
            entity.Email,
            entity.PasswordHash,
            entity.Role,
            entity.CreatedAt,
            entity.UpdatedAt
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                UserRepositoryQueries.Insert,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task<UserEntity> Query(string email, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            Email = email
        };

        IEnumerable<UserEntity>? user = await connection.QueryAsync<UserEntity>(
            new CommandDefinition(
                UserRepositoryQueries.Get,
                sqlParams,
                cancellationToken: cancellationToken));

        return user.Single();
    }
}