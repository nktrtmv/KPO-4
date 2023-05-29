namespace OrderProcessingService.Domain.Abstractions.Models;

public sealed record OrderInfo(string[] DishesNames, string Status);