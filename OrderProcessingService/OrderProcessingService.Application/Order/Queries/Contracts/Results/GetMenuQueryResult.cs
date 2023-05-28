using OrderProcessingService.Application.Order.Models;

namespace OrderProcessingService.Application.Order.Queries.Contracts.Results;

public record GetMenuQueryResult(SlimDish[] Menu);