using System.Transactions;

using OrderProcessingService.Domain.Abstractions.Models;
using OrderProcessingService.Domain.Abstractions.Services;
using OrderProcessingService.Infrastructure.Abstractions.Entities;
using OrderProcessingService.Infrastructure.Abstractions.Repositories;

namespace OrderProcessingService.Domain.Services;

public sealed class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;

    public DishService(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task CreateDish(string name, string description, decimal price, int quantity, CancellationToken cancellationToken)
    {
        var dish = new DishEntity
        {
            Name = name,
            Description = description,
            Price = price,
            Quantity = quantity
        };

        using TransactionScope transaction = _dishRepository.CreateTransactionScope();

        await _dishRepository.Create(dish, cancellationToken);

        transaction.Complete();
    }

    public async Task<Dish[]> GetAllDishes(CancellationToken cancellationToken)
    {
        DishEntity[] dishes = await _dishRepository.QueryAll(cancellationToken);

        Dish[] result = dishes.Select(d => new Dish(d.Id, d.Name, d.Description, d.Price, d.Quantity)).ToArray();

        return result;
    }

    public async Task IncreaseDishQuantity(int dishId, int increaseValue, CancellationToken cancellationToken)
    {
        using TransactionScope transaction = _dishRepository.CreateTransactionScope();

        await _dishRepository.IncreaseDishQuantity(dishId, increaseValue, cancellationToken);

        transaction.Complete();
    }

    public async Task DeleteDish(int dishId, CancellationToken cancellationToken)
    {
        using TransactionScope transaction = _dishRepository.CreateTransactionScope();

        await _dishRepository.Delete(dishId, cancellationToken);

        transaction.Complete();
    }

    public async Task<SlimDish[]> GetMenu(CancellationToken cancellationToken)
    {
        DishEntity[] dishes = await _dishRepository.QueryAll(cancellationToken);

        SlimDish[] result = dishes.Select(d => new SlimDish(d.Name, d.Description, d.Price)).ToArray();

        return result;
    }
}