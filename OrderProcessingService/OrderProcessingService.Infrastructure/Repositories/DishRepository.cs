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

    public async Task Create(DishEntity dish, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            dish.Name,
            dish.Description,
            dish.Price,
            dish.Quantity
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                DishRepositoryQueries.Insert,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task IncreaseDishQuantity(int dishId, int increaseValue, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            Dishid = dishId,
            IncreaseValue = increaseValue
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                DishRepositoryQueries.IncreaseDishQuantity,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task DecreaseDishQuantity(int dishId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            DishId = dishId
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                DishRepositoryQueries.DecreaseDishQuantity,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task Delete(int dishId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            DishId = dishId
        };

        await connection.ExecuteAsync(
            new CommandDefinition(
                DishRepositoryQueries.Delete,
                sqlParams,
                cancellationToken: cancellationToken));
    }

    public async Task<DishEntity[]> QueryAll(CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        IEnumerable<DishEntity> dishes = await connection.QueryAsync<DishEntity>(
            new CommandDefinition(
                DishRepositoryQueries.QueryAll,
                cancellationToken: cancellationToken));

        return dishes.Where(d => d.Quantity > 0).ToArray();
    }
}