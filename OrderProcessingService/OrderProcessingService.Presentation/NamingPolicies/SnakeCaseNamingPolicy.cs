using System.Text.Json;

using OrderProcessingService.Presentation.Extensions;

namespace OrderProcessingService.Presentation.NamingPolicies;

public sealed class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}