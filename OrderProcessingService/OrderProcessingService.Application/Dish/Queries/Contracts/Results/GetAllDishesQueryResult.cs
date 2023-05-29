namespace OrderProcessingService.Application.Dish.Queries.Contracts.Results;

public sealed record GetAllDishesQueryResult(Domain.Abstractions.Models.Dish[] Dishes);