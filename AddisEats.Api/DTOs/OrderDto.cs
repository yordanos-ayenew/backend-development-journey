using AddisEats.Api.Models;

namespace AddisEats.Api.Dtos;

public record OrderDto(
    int Id,
    int RestaurantId,
    string Area,
    int Qty,
    OrderStatus Status
);