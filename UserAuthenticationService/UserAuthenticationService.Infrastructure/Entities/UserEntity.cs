namespace UserAuthenticationService.Infrastructure.Entities;

public sealed record UserEntity(
    int Id,
    string Username,
    string Email,
    string PasswordHash,
    string Role,
    DateTime CreatedAt,
    DateTime UpdatedAt);