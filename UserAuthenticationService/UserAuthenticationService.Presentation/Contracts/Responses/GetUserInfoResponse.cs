namespace UserAuthenticationService.Contracts.Responses;

public sealed record GetUserInfoResponse(string Username, string Email, string Role);