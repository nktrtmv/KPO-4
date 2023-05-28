namespace UserAuthenticationService.Domain.Abstractions.Models;

public sealed record UserWithPassword(int Id, string Email, string PasswordHash);