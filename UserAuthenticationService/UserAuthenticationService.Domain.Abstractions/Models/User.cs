namespace UserAuthenticationService.Domain.Abstractions.Models;

public sealed record User(string Username, string Email, string Role);
