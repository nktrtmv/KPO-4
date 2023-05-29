namespace OrderProcessingService.Infrastructure.Repositories;

internal static class DishRepositoryQueries
{
    internal static string Insert => @"
INSERT INTO dishes
(
    name,
    description,
    price,
    quantity
)
VALUES 
(
    @Name,
    @Description,
    @Price,
    @Quantity
)
";

    internal static string IncreaseDishQuantity => "update dishes set quantity = quantity + @IncreaseValue where id = @DishId";

    internal static string DecreaseDishQuantity => "update dishes set quantity = quantity - 1 where id = @DishId";

    internal static string Delete => "delete from dishes where id = @DishId";

    internal static string QueryAll => "select id, name, description, price, quantity from dishes";
}