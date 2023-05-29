using Dapper;

using Microsoft.Extensions.Options;

using Npgsql;

using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Models;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;
using OrderProcessingService.Infrastructure.Repositories.Abstractions;
using OrderProcessingService.Infrastructure.Settings;

namespace OrderProcessingService.Infrastructure.Repositories;

public sealed class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<int> Create(OrderEntity order, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            UserId = order.UserId,
            Status = order.Status,
            SpecialRequests = order.SpecialRequests,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt
        };

        int id = await connection.ExecuteAsync(
            new CommandDefinition(
                OrderRepositoryQueries.Insert,
                sqlParams,
                cancellationToken: cancellationToken));

        return id;
    }

    public async Task<int[]> CompleteAll(DateTime now, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            UpdatedAt = now,
            Status = "Completed"
        };

        IEnumerable<int> ordersIds = await connection.QueryAsync<int>(
            new CommandDefinition(
                OrderRepositoryQueries.UpdateAll,
                sqlParams,
                cancellationToken: cancellationToken));

        return ordersIds.ToArray();
    }

    public async Task<string> GetStatus(int orderId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var sqlParams = new
        {
            Id = orderId,
        };

        IEnumerable<OrderEntity>? orders = await connection.QueryAsync<OrderEntity>(
            new CommandDefinition(
                OrderRepositoryQueries.Query,
                sqlParams,
                cancellationToken: cancellationToken));

        OrderEntity order = orders.Single();

        return order.Status;
    }
}