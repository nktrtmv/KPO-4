namespace UserAuthenticationService.Contracts.Requests;

public sealed record LogInUserRequest(string Email, string Password);