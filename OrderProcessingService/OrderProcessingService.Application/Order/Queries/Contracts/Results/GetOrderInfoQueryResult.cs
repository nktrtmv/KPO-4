namespace OrderProcessingService.Application.Order.Queries.Contracts.Results;

public sealed record GetOrderInfoQueryResult(string[] DishesNames, string Status);