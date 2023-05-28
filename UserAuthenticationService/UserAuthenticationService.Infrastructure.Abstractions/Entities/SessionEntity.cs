namespace UserAuthenticationService.Infrastructure.Abstractions.Entities;

public sealed record SessionEntity
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public string SessionToken { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
}