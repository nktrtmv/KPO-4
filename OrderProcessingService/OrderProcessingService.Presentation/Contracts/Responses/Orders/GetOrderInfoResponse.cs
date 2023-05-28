namespace OrderProcessingService.Presentation.Contracts.Responses.Orders;

internal sealed record GetOrderInfoResponse(string[] DishesNames, string Status);