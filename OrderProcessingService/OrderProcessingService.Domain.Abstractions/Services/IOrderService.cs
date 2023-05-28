
namespace OrderProcessingService.Domain.Abstractions.Services;

public interface IOrderService
{
    Task Create();

    Task Process();

    Task Get();
}