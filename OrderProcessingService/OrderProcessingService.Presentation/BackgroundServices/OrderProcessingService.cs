using Microsoft.Extensions.Hosting;

namespace OrderProcessingService.Presentation.BackgroundServices;

public class OrderProcessingService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(1, stoppingToken);
    }
}