using AddisEats.Api.Data;
using AddisEats.Api.Dtos;
using AddisEats.Api.Models;

namespace AddisEats.Api.Services.OrderServices;

public class OrderService : IOrderService
{
    public Order? GetById(int id)
    {
        return OrderData.Items.FirstOrDefault(o => o.Id == id);
    }

    public Order Create(CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = OrderData.Items.Count == 0
                ? 1
                : OrderData.Items.Max(o => o.Id) + 1,

            RestaurantId = request.RestaurantId,
            Area = request.Area,
            Qty = request.Qty,
            Status = OrderStatus.Placed
        };
        OrderData.Items.Add(order);
        return order;
    }

    public Order? UpdateStatus(int id, OrderStatus status)
    {
        var order = GetById(id);
        if (order is null)
            return null;

        order.Status = status;
        return order;
    }
}