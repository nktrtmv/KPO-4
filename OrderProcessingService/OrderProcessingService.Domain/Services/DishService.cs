using System.Security.Claims;
using System.Text;
using System.Transactions;

using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

using DateTime = System.DateTime;

namespace OrderProcessingService.Domain.Services;

public sealed class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;

    public DishService(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public Task Create()
    {
        throw new NotImplementedException();
    }

    public Task GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add()
    {
        throw new NotImplementedException();
    }

    public Task Delete()
    {
        throw new NotImplementedException();
    }
}