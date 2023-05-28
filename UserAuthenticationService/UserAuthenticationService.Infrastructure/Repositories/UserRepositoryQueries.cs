namespace UserAuthenticationService.Infrastructure.Repositories;

internal static class UserRepositoryQueries
{
    internal static string Insert => @"
INSERT INTO users
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
    @Username,
    @Email,
    @PasswordHash,
    @Role,
    @CreatedAt,
    @UpdatedAt
)
";

    internal static string Get => @"
select id, username, email, password_hash, role, created_at, updated_at from users where email = @Email
";
}