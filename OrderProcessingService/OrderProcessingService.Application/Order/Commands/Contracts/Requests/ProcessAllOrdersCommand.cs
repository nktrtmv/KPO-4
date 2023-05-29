using MediatR;

namespace OrderProcessingService.Application.Order.Commands.Contracts.Requests;

public sealed record ProcessAllOrdersCommand : IRequest;