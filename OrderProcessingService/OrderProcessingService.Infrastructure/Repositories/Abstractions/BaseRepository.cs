using System.Transactions;

using Npgsql;

using OrderProcessingService.Infrastructure.Abstractions.Repositories;
using OrderProcessingService.Infrastructure.Settings;

namespace OrderProcessingService.Infrastructure.Repositories.Abstractions;

public abstract class BaseRepository : IDbRepository
{
    private readonly DalOptions _dalSettings;

    protected BaseRepository(DalOptions dalSettings)
    {
        _dalSettings = dalSettings;
    }

    public TransactionScope CreateTransactionScope(IsolationLevel level = IsolationLevel.ReadCommitted)
    {
        return new TransactionScope(
            TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = level,
                Timeout = TimeSpan.FromSeconds(5)
            },
            TransactionScopeAsyncFlowOption.Enabled);
    }

    protected async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        const string conn = "User ID=orders_user;Password=orders_password;Host=localhost;Port=4321;Database=orders_database;Pooling=true;";

        var connection = new NpgsqlConnection(conn);
        await connection.OpenAsync();
        await connection.ReloadTypesAsync();

        return connection;
    }
}