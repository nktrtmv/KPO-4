using OrderProcessingService.Domain.Abstractions.Models;

namespace OrderProcessingService.Application.Order.Queries.Contracts.Results;

public sealed record GetMenuQueryResult(SlimDish[] Menu);