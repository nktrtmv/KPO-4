using MediatR;

using OrderProcessingService.Application.Dish.Queries.Contracts.Results;

namespace OrderProcessingService.Application.Dish.Queries.Contracts.Requests;

public record GetAllDishesQuery : IRequest<GetAllDishesQueryResult>;