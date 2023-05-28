using UserAuthenticationService.Contracts.Requests;

namespace UserAuthenticationService.Contracts.Validators;

public static class RegisterNewUserValidator
{
    public static void ValidateEmail(RegisterNewUserRequest request)
    {
        if (!(request.Email.Contains('@') && (request.Email.Contains(".com") || request.Email.Contains(".ru"))))
        {
            throw new ArgumentException("Entered email is invalid");
        }
    }

    public static void ValidatePassword(RegisterNewUserRequest request)
    {
        if (request.Password != request.PasswordCopy)
        {
            throw new ArgumentException("Password is not equal to PasswordCopy");
        }

        if (request.Password.Length < 5)
        {
            throw new ArgumentException("Minimum password length is 8");
        }
    }
}