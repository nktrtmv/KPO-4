using MediatR;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using OrderProcessingService.Application.Order.Commands.Contracts.Requests;

namespace OrderProcessingService.Presentation.BackgroundServices;

public sealed class OrderProcessingService : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public OrderProcessingService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Delay(10000, stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var command = new ProcessAllOrdersCommand();

            await mediator.Send(command, stoppingToken);

            await Task.Delay(3000, stoppingToken);
        }
    }
}