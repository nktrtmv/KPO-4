namespace UserAuthenticationService.Contracts.Requests;

public sealed record RegisterNewUserRequest(
    string Username,
    string Email,
    string Password,
    string PasswordCopy,
    string Role);