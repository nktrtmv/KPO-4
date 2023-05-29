using OrderProcessingService.Presentation.Models;

namespace OrderProcessingService.Presentation.Contracts.Responses.Orders;

internal sealed record GetMenuResponse(SlimDish[] Menu);