namespace OrderProcessingService.Domain.Abstractions.Services;

public interface IOrderDishService
{
    Task Add();

    Task GetAll();
}