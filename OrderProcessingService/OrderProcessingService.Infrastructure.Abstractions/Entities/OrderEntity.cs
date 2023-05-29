namespace OrderProcessingService.Infrastructure.Abstractions.Entities;

public class OrderEntity
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public string Status { get; init; } = string.Empty;
    public string SpecialRequests { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}