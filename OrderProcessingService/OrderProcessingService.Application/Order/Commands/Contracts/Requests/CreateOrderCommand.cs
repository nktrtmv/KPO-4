using MediatR;

using OrderProcessingService.Domain.Abstractions.Models;

namespace OrderProcessingService.Application.Order.Commands.Contracts.Requests;

public sealed record CreateOrderCommand(
    int UserId,
    DishQ[] Dishes,
    string? SpecialRequests) : IRequest;