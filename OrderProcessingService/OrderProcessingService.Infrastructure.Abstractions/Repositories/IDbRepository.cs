using System.Transactions;

namespace OrderProcessingService.Infrastructure.Abstractions.Repositories;

public interface IDbRepository
{
    TransactionScope CreateTransactionScope(IsolationLevel level = IsolationLevel.ReadCommitted);
}