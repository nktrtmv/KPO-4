namespace OrderProcessingService.Infrastructure.Abstractions.Models;

public sealed record OrderInfo(string[] DishesNames, string Status);