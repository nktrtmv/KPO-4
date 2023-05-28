using MediatR;

namespace OrderProcessingService.Application.Order.Commands.Contracts.Requests;

public record ProcessAllOrdersCommand : IRequest;