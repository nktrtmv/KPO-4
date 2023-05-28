using MediatR;

using Microsoft.Extensions.Hosting;

using OrderProcessingService.Application.Order.Commands.Contracts.Requests;

namespace OrderProcessingService.Presentation.BackgroundServices;

public sealed class OrderProcessingService : BackgroundService
{
    private readonly IMediator _mediator;

    public OrderProcessingService(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var command = new ProcessAllOrdersCommand();

            await _mediator.Send(command, stoppingToken);

            await Task.Delay(3000, stoppingToken);
        }
    }
}