using Dapper;

using Microsoft.Extensions.Options;

using Npgsql;

using UserAuthenticationService.Infrastructure.Abstractions.Entities;
using UserAuthenticationService.Infrastructure.Abstractions.Repositories;
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
            username = entity.Username,
            email = entity.Email,
            password_hash = entity.PasswordHash,
            role = entity.Role,
            created_at = entity.CreatedAt,
            updated_at = entity.UpdatedAt
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                UserRepositoryQueries.Insert,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task<UserEntity> Query(string email, string passwordHash, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            email,
            password_hash = passwordHash
        };

        IEnumerable<UserEntity>? user = await connection.QueryAsync<UserEntity>(
            new CommandDefinition(
                UserRepositoryQueries.Insert,
                sqlParams,
                cancellationToken: cancellationToken));

        return user.Single();
    }
}