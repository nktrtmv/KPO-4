using MediatR;

using OrderProcessingService.Application.Order.Models;

namespace OrderProcessingService.Application.Order.Commands.Contracts.Requests;

public record CreateOrderCommand(
    int UserId,
    DishQ[] Dishes,
    string? SpecialRequests) : IRequest;