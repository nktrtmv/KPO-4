namespace UserAuthenticationService.Infrastructure.Abstractions.Entities;

public sealed record SessionEntity(
    int Id,
    int UserId,
    string SessionToken,
    DateTime ExpiresAt);