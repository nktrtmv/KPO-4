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

    protected async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(_dalSettings.ConnectionString);
        await connection.OpenAsync();
        await connection.ReloadTypesAsync();

        return connection;
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
}