using MediatR;

using OrderProcessingService.Application.Dish.Queries.Contracts.Requests;
using OrderProcessingService.Application.Dish.Queries.Contracts.Results;
using OrderProcessingService.Domain.Abstractions.Services;

namespace OrderProcessingService.Application.Dish.Queries;

public class GetAllDishesQueryHandler : IRequestHandler<GetAllDishesQuery, GetAllDishesQueryResult>
{
    private readonly IDishService _dishService;

    public GetAllDishesQueryHandler(IDishService dishService)
    {
        _dishService = dishService;
    }

    public async Task<GetAllDishesQueryResult> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        Domain.Abstractions.Models.Dish[] result = await _dishService.GetAllDishes(cancellationToken);

        return new GetAllDishesQueryResult(result);
    }
}