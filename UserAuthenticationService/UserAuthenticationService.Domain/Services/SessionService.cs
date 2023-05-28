using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;

using AutoFixture;

using Microsoft.IdentityModel.Tokens;

using UserAuthenticationService.Domain.Abstractions.Services;
using UserAuthenticationService.Infrastructure.Abstractions.Entities;
using UserAuthenticationService.Infrastructure.Abstractions.Repositories;

using DateTime = System.DateTime;

namespace UserAuthenticationService.Domain.Services;

public sealed class SessionService : ISessionService
{
    private readonly Fixture _fixture;
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _fixture = new Fixture();
        _sessionRepository = sessionRepository;
    }

    public async Task LogIn(int userId, CancellationToken cancellationToken)
    {
        using TransactionScope transaction = _sessionRepository.CreateTransactionScope();
        (string, DateTime) jwt = GenerateRandomJwtToken();

        await _sessionRepository.Upsert(
            new SessionEntity
            {
                UserId = userId,
                SessionToken = jwt.Item1,
                ExpiresAt = jwt.Item2
            },
            cancellationToken);

        transaction.Complete();
    }

    public async Task<bool> IsLogged(int userId, CancellationToken cancellationToken)
    {
        DateTime now = DateTime.UtcNow;

        try
        {
            DateTime expirationTime = await _sessionRepository.GetUserLogTime(userId, cancellationToken);

            return now < expirationTime;
        }
        catch
        {
            return false;
        }
    }

    private (string, DateTime) GenerateRandomJwtToken()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_fixture.Create<string>()));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, "random_user"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        DateTime expirationTime = DateTime.UtcNow.AddHours(1);

        var token = new JwtSecurityToken(
            issuer: _fixture.Create<string>(),
            audience: _fixture.Create<string>(),
            claims: claims,
            expires: expirationTime,
            signingCredentials: credentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);

        return (tokenString, expirationTime);
    }
}