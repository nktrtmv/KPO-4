using System.Transactions;

using UserAuthenticationService.Domain.Abstractions.Interfaces;
using UserAuthenticationService.Domain.Abstractions.Models;
using UserAuthenticationService.Infrastructure.Abstractions.Entities;
using UserAuthenticationService.Infrastructure.Abstractions.Repositories;

namespace UserAuthenticationService.Domain.Services;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Add(
        string username,
        string email,
        string passwordHash,
        string role,
        DateTime createdTime,
        DateTime updatedTime,
        CancellationToken cancellationToken)
    {
        var entity = new UserEntity
        {
            Username = username,
            Email = email,
            PasswordHash = passwordHash,
            Role = role,
            CreatedAt = createdTime,
            UpdatedAt = updatedTime
        };

        using TransactionScope transaction = _userRepository.CreateTransactionScope();

        await _userRepository.Add(entity, cancellationToken);

        transaction.Complete();
    }

    public async Task<User> Get(string email, string password, CancellationToken cancellationToken)
    {
        using TransactionScope transaction = _userRepository.CreateTransactionScope();

        UserEntity user = await _userRepository.Query(email, password.GetHashCode().ToString(), cancellationToken);

        transaction.Complete();

        var result = new User(user.Username, user.Email, user.Role);

        return result;
    }
}