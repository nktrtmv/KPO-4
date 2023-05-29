namespace OrderProcessingService.Infrastructure.Repositories;

internal static class OrderDishRepositoryQueries
{
    internal static string Insert => @"
INSERT INTO orders_dishes
(
    order_id,
    dish_id,
    quantity,
    price
)
VALUES 
(
    @OrderId,
    @DishId,
    @Quantity,
    @Price
)
";

    internal static string Delete => "delete from orders_dishes where order_id = @OrderId";

    internal static string QueryDishesIds => "select dish_id from orders_dishes where order_id = @OrderId";
}