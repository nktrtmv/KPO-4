using Npgsql.Replication.PgOutput.Messages;

namespace UserAuthenticationService.Infrastructure.Repositories;

internal static class UserRepositoryQueries
{
    internal static string Insert => @"
INSERT INTO user
(
    username,
    email,
    password_hash,
    role,
    created_at,
    updated_at
)
VALUES 
(
    @username,
    @email,
    @password_hash,
    @role,
    @created_at,
    @updated_at
)
";

    internal static string Get => @"
select id, username, email, password_hash, role, created_at updated_at from user where email = @email, password_hash = @password_hash
";
}