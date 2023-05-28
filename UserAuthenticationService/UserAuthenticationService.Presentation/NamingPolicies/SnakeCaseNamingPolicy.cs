using System.Text.Json;

using UserAuthenticationService.Extensions;

namespace UserAuthenticationService.NamingPolicies;

public sealed class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}