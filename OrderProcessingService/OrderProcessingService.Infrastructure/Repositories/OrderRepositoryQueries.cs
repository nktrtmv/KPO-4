namespace OrderProcessingService.Infrastructure.Repositories;

internal static class OrderRepositoryQueries
{
    internal static string Insert => @"
INSERT INTO orders
(
    user_id,
    status,
    special_requests,
    created_at,
    updated_at
)
VALUES 
(
    @UserId,
    @Status,
    @SpecialRequests,
    @CreatedAt,
    @UpdatedAt
)
Returning id
";

    internal static string UpdateAll => "update orders set updated_at = @UpdatedAt, status = @Status returning id;";

    internal static string Query => "select id, user_id, status, special_requests, created_at, updated_at from orders where id = @Id";
}