using System.Transactions;

namespace UserAuthenticationService.Infrastructure.Abstractions.Repositories;

public interface IDbRepository
{
    TransactionScope CreateTransactionScope(IsolationLevel level = IsolationLevel.ReadCommitted);
}