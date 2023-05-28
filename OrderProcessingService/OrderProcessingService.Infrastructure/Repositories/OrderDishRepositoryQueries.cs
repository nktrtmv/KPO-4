namespace OrderProcessingService.Infrastructure.Repositories;

internal static class OrderDishRepositoryQueries
{
    internal static string Upsert => @"
WITH upsert AS (
    UPDATE sessions
    SET expires_at = @ExpiresAt
    WHERE user_id = @UserId
    RETURNING *
)
INSERT INTO sessions (user_id, session_token, expires_at)
SELECT @UserId, @SessionToken, @ExpiresAt
WHERE NOT EXISTS (SELECT 1 FROM upsert);
";

    internal static string Query => "select id, user_id, session_token, expires_at from sessions where user_id = @UserId";
}