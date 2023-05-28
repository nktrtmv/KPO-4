using MediatR;

using OrderProcessingService.Application.Dish.Queries.Contracts.Requests;
using OrderProcessingService.Application.Dish.Queries.Contracts.Results;

namespace OrderProcessingService.Application.Dish.Queries;

public class GetAllDishesQueryHandler : IRequestHandler<GetAllDishesQuery, GetAllDishesQueryResult>
{
    public Task<GetAllDishesQueryResult> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}