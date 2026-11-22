using AddisEats.Api.Models;

namespace AddisEats.Api.Dtos;

public static class OrderMapping
{
    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto(
            order.Id,
            order.RestaurantId,
            order.Area,
            order.Qty,
            order.Status
        );
    }
}