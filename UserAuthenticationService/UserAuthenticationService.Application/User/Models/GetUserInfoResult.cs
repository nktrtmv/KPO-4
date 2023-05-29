namespace UserAuthenticationService.Application.User.Models;

public sealed record GetUserInfoResult(string Username, string Email, string Role);