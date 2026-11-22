namespace AddisEats.Api.Dtos;

public record CreateOrderRequest(
    int RestaurantId,
    string Area,
    int Qty
);