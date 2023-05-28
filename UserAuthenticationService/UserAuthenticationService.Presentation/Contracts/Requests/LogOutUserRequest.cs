namespace UserAuthenticationService.Contracts.Requests;

public sealed record LogOutUserRequest(string Email, string Password);