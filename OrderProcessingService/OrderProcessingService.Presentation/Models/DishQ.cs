namespace OrderProcessingService.Presentation.Models;

public abstract record DishQ(
    int Id,
    decimal Price,
    int Quantity);