namespace UserAuthenticationService.Infrastructure.Entities;

public sealed record SessionEntity(
    int Id,
    int UserId,
    string SessionToken,
    DateTime ExpiresAt);