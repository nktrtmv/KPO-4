using MediatR;

using OrderProcessingService.Application.Order.Queries.Contracts.Results;

namespace OrderProcessingService.Application.Order.Queries.Contracts.Requests;

public record GetMenuQuery : IRequest<GetMenuQueryResult>;