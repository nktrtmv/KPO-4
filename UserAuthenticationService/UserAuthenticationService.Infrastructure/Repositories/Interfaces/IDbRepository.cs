using System.Transactions;

namespace UserAuthenticationService.Infrastructure.Repositories.Interfaces;

public interface IDbRepository
{
    TransactionScope CreateTransactionScope(IsolationLevel level = IsolationLevel.ReadCommitted);
}