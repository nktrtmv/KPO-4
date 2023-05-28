namespace OrderProcessingService.Domain.Abstractions.Services;

public interface IDishService
{
    Task Create();

    Task GetAll();

    Task Add();

    Task Delete();
}