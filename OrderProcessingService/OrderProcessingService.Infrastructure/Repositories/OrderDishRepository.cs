using Dapper;

using Microsoft.Extensions.Options;

using Npgsql;

using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Models;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;
using OrderProcessingService.Infrastructure.Repositories.Abstractions;
using OrderProcessingService.Infrastructure.Settings;

namespace OrderProcessingService.Infrastructure.Repositories;

public sealed class OrderDishRepository : BaseRepository, IOrderDishRepository
{
    public OrderDishRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task AddDish(OrderDishEntity orderDish, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            OrderId = orderDish.OrderId,
            DishId = orderDish.DishId,
            Quantity = orderDish.Quantity,
            Price = orderDish.Price
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                OrderDishRepositoryQueries.Insert,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task DeleteDishes(IEnumerable<int> ordersIds, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        foreach (int orderId in ordersIds)
        {
            var sqlParams = new
            {
                OrderId = orderId
            };

            await connection.ExecuteAsync(
                new CommandDefinition(
                    OrderDishRepositoryQueries.Delete,
                    sqlParams,
                    cancellationToken: cancellationToken));
        }
    }

    public async Task<int[]> GetDishesIds(int orderId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            OrderId = orderId
        };

        IEnumerable<int>? ids = await connection.QueryAsync<int>(
            new CommandDefinition(
                OrderDishRepositoryQueries.QueryDishesIds,
                sqlParams,
                cancellationToken: cancellationToken));

        return ids.ToArray();
    }
}